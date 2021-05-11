namespace XML2JSON
{
	using System;
	using System.Collections.Generic;

	using Newtonsoft.Json;

	public class GlobalPropertySchema
	{
		[JsonProperty("prop:GlobalProperties", NullValueHandling = NullValueHandling.Ignore)]
		public PropGlobalProperties PropGlobalProperties { get; set; }
	}
	public class PropGlobalProperties
	{
		[JsonProperty("@xmlns:bsd", NullValueHandling = NullValueHandling.Ignore)]
		public Uri XmlnsBsd { get; set; }

		[JsonProperty("@xmlns", NullValueHandling = NullValueHandling.Ignore)]
		public Uri Xmlns { get; set; }

		[JsonProperty("@xmlns:prop", NullValueHandling = NullValueHandling.Ignore)]
		public Uri XmlnsProp { get; set; }

		[JsonProperty("Section", NullValueHandling = NullValueHandling.Ignore)]
		public List<Section> Section { get; set; }
	}

	public class Section
	{
		[JsonProperty("@Name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("@DisplayName", NullValueHandling = NullValueHandling.Ignore)]
		public string DisplayName { get; set; }

		[JsonProperty("TextBox", NullValueHandling = NullValueHandling.Ignore)]
		public Box TextBox { get; set; }

		[JsonProperty("TextArea", NullValueHandling = NullValueHandling.Ignore)]
		public Box TextArea { get; set; }

		[JsonProperty("CheckBox", NullValueHandling = NullValueHandling.Ignore)]
		public Box CheckBox { get; set; }

		[JsonProperty("Group", NullValueHandling = NullValueHandling.Ignore)]
		public Group Group { get; set; }

		[JsonProperty("DropDownBox", NullValueHandling = NullValueHandling.Ignore)]
		public List<DropDownBox> DropDownBox { get; set; }

		[JsonProperty("KeyValuePairs", NullValueHandling = NullValueHandling.Ignore)]
		public KeyValuePairs KeyValuePairs { get; set; }

	}
	public class KeyValuePairs
	{
		[JsonProperty("@Name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("@DisplayName", NullValueHandling = NullValueHandling.Ignore)]
		public string DisplayName { get; set; }

		[JsonProperty("@Tooltip", NullValueHandling = NullValueHandling.Ignore)]
		public string Tooltip { get; set; }

		[JsonProperty("@IsMandatory", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(BooleanConverter))]
		public bool? IsMandatory { get; set; }

		[JsonProperty("@selectedOption", NullValueHandling = NullValueHandling.Ignore)]
		public string SelectedOption { get; set; }

		[JsonProperty("Item", NullValueHandling = NullValueHandling.Ignore)]
		public List<KeyValuePairsItem> Item { get; set; }
	}
  public class KeyValuePairsItem
  {
    [JsonProperty("Key", NullValueHandling = NullValueHandling.Ignore)]
    public string Key { get; set; }

    [JsonProperty("Value", NullValueHandling = NullValueHandling.Ignore)]
    public string Value { get; set; }
  }

	public class Box
	{
		[JsonProperty("@Name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("@DisplayName", NullValueHandling = NullValueHandling.Ignore)]
		public string DisplayName { get; set; }

		[JsonProperty("@IsMandatory", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(BooleanConverter))]
		public bool? IsMandatory { get; set; }

		[JsonProperty("@DefaultValue", NullValueHandling = NullValueHandling.Ignore)]
		public string DefaultValue { get; set; }

		[JsonProperty("@Disabled", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(BooleanConverter))]
		public bool? Disabled { get; set; }

		[JsonProperty("@Tooltip", NullValueHandling = NullValueHandling.Ignore)]
		public string Tooltip { get; set; }

		[JsonProperty("@Value", NullValueHandling = NullValueHandling.Ignore)]
		public string Value { get; set; }

		[JsonProperty("@Type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }

		[JsonProperty("@MaxLength", NullValueHandling = NullValueHandling.Ignore)]
		//[JsonConverter(typeof(FluffyParseStringConverter))]
		public long? MaxLength { get; set; }
	}

	public class Group
	{
		[JsonProperty("@Name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("@DisplayName", NullValueHandling = NullValueHandling.Ignore)]
		public string DisplayName { get; set; }

		[JsonProperty("@DependencyType", NullValueHandling = NullValueHandling.Ignore)]
		public string DependencyType { get; set; }

		[JsonProperty("@DependencyField", NullValueHandling = NullValueHandling.Ignore)]
		public string DependencyField { get; set; }

		[JsonProperty("TextBox", NullValueHandling = NullValueHandling.Ignore)]
		public List<Box> TextBox { get; set; }

		[JsonProperty("CheckBox", NullValueHandling = NullValueHandling.Ignore)]
		public Box CheckBox { get; set; }

		[JsonProperty("TextArea", NullValueHandling = NullValueHandling.Ignore)]
		public Box TextArea { get; set; }

		[JsonProperty("DropDownBox", NullValueHandling = NullValueHandling.Ignore)]
		public List<DropDownBox> DropDownBox { get; set; }

	}

	public class DropDownBox
	{
		[JsonProperty("@Name")]
		public string Name { get; set; }

		[JsonProperty("@DisplayName")]
		public string DisplayName { get; set; }

		[JsonProperty("Items")]
		public Items Items { get; set; }
	}

	public class Items
	{
		[JsonProperty("Item")]
		public List<ItemElement> Item { get; set; }
	}

	public class ItemElement
	{
		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Value")]
		public string Value { get; set; }
	}

}
