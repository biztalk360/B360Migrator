namespace XML2JSON
{
	using System;
	using System.Collections.Generic;

	using AutoMapper;

	using Newtonsoft.Json;

	public class NotificationChannelMigrationService
	{
		private readonly IMapper _mapper;
		public NotificationChannelMigrationService()
		{
			var config = new MapperConfiguration(config =>
			{
				config.CreateMap<Box, CustomNotificationChannelSettings>();
				config.CreateMap<Box, List<CustomNotificationChannelSettings>>();
				config.CreateMap<Section, CustomNotificationChannel>();
				config.CreateMap<DropDownBox, CustomNotificationChannelSettings>()
					.ForMember(dest => dest.Items, op => op.MapFrom(src => src.Items.Item));
				config.CreateMap<ItemElement, LabelValues>()
					.ForMember(dest => dest.Label, op => op.MapFrom(x => x.Name))
					.ForMember(dest => dest.Value, op => op.MapFrom(x => x.Value));
				config.CreateMap<Items, LabelValues>();
				config.CreateMap<KeyValuePairsItem, LabelValues>()
					.ForMember(dest => dest.Value, op => op.MapFrom(src => src.Value))
					.ForMember(dest => dest.Label, op => op.MapFrom(src => src.Key));
				config.CreateMap<KeyValuePairsItem, LabelValues>()
					.ForMember(dest => dest.Label, op => op.MapFrom(src => src.Key))
					.ForMember(dest => dest.Value, op => op.MapFrom(src => src.Value));
				config.CreateMap<KeyValuePairs, CustomNotificationChannelSettings>()
					.ForMember(dest => dest.Items, op => op.MapFrom(src => src.Item));

			});
			_mapper = config.CreateMapper();
		}
		public GlobalPropertySchema GetSchemaWithValue(string globalPropertySchema, string globalPropertyValues = null)
		{
			var jsonObj = JsonConvert.DeserializeObject<GlobalPropertySchema>(globalPropertySchema);
			if (globalPropertyValues != null)
			{
				var valueObject = JsonConvert.DeserializeObject<GlobalPropertySchema>(globalPropertyValues);

				valueObject.PropGlobalProperties.Section.ForEach(section =>
				{
					jsonObj.PropGlobalProperties.Section.ForEach(s =>
					{
						if (s.Name.Equals(section.Name, StringComparison.OrdinalIgnoreCase) &&
								s.DisplayName.Equals(section.DisplayName, StringComparison.OrdinalIgnoreCase))
						{
							if (section.TextBox != null &&
									section.TextBox.Name.Equals(s.TextBox.Name, StringComparison.OrdinalIgnoreCase))
							{
								s.TextBox.Value = section.TextArea.Value;
							}

							if (section.TextArea != null &&
									section.TextArea.Name.Equals(s.TextArea.Name, StringComparison.OrdinalIgnoreCase))
							{
								s.TextArea.Value = section.TextArea.Value;
							}

							if (section.CheckBox != null &&
									section.CheckBox.Name.Equals(s.CheckBox.Name, StringComparison.OrdinalIgnoreCase))
							{
								s.CheckBox.Value = section.CheckBox.Value;
							}

							if (section.Group != null && section.Group.Name.Equals(s.Group.Name, StringComparison.OrdinalIgnoreCase)
																				&& section.Group.DependencyField.Equals(s.Group.DependencyField,
																					StringComparison.OrdinalIgnoreCase))
							{
								if (section.Group.TextBox != null)
								{
									s.Group.TextBox.ForEach(textBox =>
									{
										section.Group.TextBox.ForEach(tb =>
										{
											if (textBox.Name.Equals(tb.Name, StringComparison.OrdinalIgnoreCase))
											{
												textBox.Value = tb.Value;
											}
										});
									});

								}

								if (section.Group.TextArea != null &&
										section.Group.TextArea.Name.Equals(s.Group.TextArea.Name, StringComparison.OrdinalIgnoreCase))
								{
									s.Group.TextArea.Value = section.Group.TextArea.Value;
								}

								if (section.Group.CheckBox != null &&
										section.Group.CheckBox.Name.Equals(s.Group.CheckBox.Name, StringComparison.OrdinalIgnoreCase))
								{
									s.Group.CheckBox.Value = section.Group.CheckBox.Value;
								}

							}
						}
					});
				});
			}

			return jsonObj;
		}

		public List<CustomNotificationChannel> GetCustomNotificationChannelSettings(GlobalPropertySchema schema)
		{
			var result = new List<CustomNotificationChannel>();
			foreach (var section in schema.PropGlobalProperties.Section)
			{
				var channel = new CustomNotificationChannel
				{
					Name = section.Name,
					DisplayName = section.DisplayName,
					Data = new List<CustomNotificationChannelSettings>()
				};

				//validating name
				section.Name = section.Name.RemoveHyphen().ToCamelCase();

				if (section.CheckBox != null)
				{
					section.CheckBox.Type = "checkbox";
					section.CheckBox.Name = section.CheckBox.Name.RemoveHyphen().ToCamelCase();
					var notificationChannelSettings = new CustomNotificationChannelSettings();
					_mapper.Map(section.CheckBox, notificationChannelSettings);
					channel.Data.Add(notificationChannelSettings);
				}

				if (section.TextArea != null)
				{
					section.TextArea.Name = section.TextArea.Name.RemoveHyphen().ToCamelCase();
					//The type has to be changed appropriately
					section.TextArea.Type = "textarea";
					var notificationChannelSettings = new CustomNotificationChannelSettings();
					_mapper.Map(section.TextArea, notificationChannelSettings);
					channel.Data.Add(notificationChannelSettings);
				}

				if (section.TextBox != null)
				{
					section.TextBox.Name = section.TextBox.Name.RemoveHyphen().ToCamelCase();
					section.TextBox.Type = "input";
					var notificationChannelSettings = new CustomNotificationChannelSettings();
					_mapper.Map(section.TextBox, notificationChannelSettings);
					channel.Data.Add(notificationChannelSettings);
				}

				if (section.Group?.CheckBox != null)
				{
					section.Group.CheckBox.Name = section.Group.CheckBox.Name.RemoveHyphen().ToCamelCase();
					section.Group.CheckBox.Type = "checkbox";
					var notificationChannelSettings = new CustomNotificationChannelSettings();
					_mapper.Map(section.Group.CheckBox, notificationChannelSettings);
					channel.Data.Add(notificationChannelSettings);
				}

				if (section.Group?.TextArea != null)
				{
					section.Group.TextArea.Type = "textarea";
					section.Group.TextArea.Type = "textArea";
					section.Group.TextArea.Name = section.Group.TextArea.Name.RemoveHyphen().ToCamelCase();
					var notificationChannelSettings = new CustomNotificationChannelSettings();
					_mapper.Map(section.Group.TextArea, notificationChannelSettings);
					channel.Data.Add(notificationChannelSettings);
				}

				if (section.Group?.TextBox != null)
				{
					foreach (var textBox in section.Group?.TextBox)
					{
						textBox.Type = "input";
						textBox.Name = textBox.Name.RemoveHyphen().ToCamelCase();
						var notificationChannelSettings = new CustomNotificationChannelSettings();
						_mapper.Map(textBox, notificationChannelSettings);
						channel.Data.Add(notificationChannelSettings);
					}
				}

				if (section.DropDownBox != null)
				{
					var notificationChannelSettings = new CustomNotificationChannelSettings { Type = "select" };
					foreach (var dropDownBox in section.DropDownBox)
					{
						_mapper.Map(dropDownBox, notificationChannelSettings);
						channel.Data.Add(notificationChannelSettings);
					}
        }

				if (section.KeyValuePairs != null)
				{
					var notificationChannelSettings = new CustomNotificationChannelSettings { Type = "keyValuePairs" };
					_mapper.Map(section.KeyValuePairs, notificationChannelSettings);
					channel.Data.Add(notificationChannelSettings);
				}

				result.Add(channel);
			}

			return result;
		}

		public List<CustomNotificationChannelSettings> GetAlarmPropertiesSchema(string alarmSchema)
		{
			var result = new List<CustomNotificationChannelSettings>();
			var jsonObj = JsonConvert.DeserializeObject<AlarmPropertySchema>(alarmSchema);
			if (jsonObj.PropAlarmProperties.CheckBox != null)
			{
				var settings = new CustomNotificationChannelSettings();
				_mapper.Map(jsonObj.PropAlarmProperties.CheckBox, settings);
				result.Add(settings);
			}

			if (jsonObj.PropAlarmProperties.TextArea != null)
			{
				jsonObj.PropAlarmProperties.TextArea.Type = "textarea";
				var settings = new CustomNotificationChannelSettings();
				_mapper.Map(jsonObj.PropAlarmProperties.TextArea, settings);
				result.Add(settings);
			}
			if (jsonObj.PropAlarmProperties.TextBox != null)
			{
				foreach (var textBox in jsonObj.PropAlarmProperties.TextBox)
				{
					textBox.Type = "input";
					var settings = new CustomNotificationChannelSettings();
					_mapper.Map(textBox, settings);
					result.Add(settings);
				}
			}

			return result;
		}
	}
}
