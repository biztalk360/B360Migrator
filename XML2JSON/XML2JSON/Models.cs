using System.Collections.Generic;

namespace XML2JSON
{
  using Newtonsoft.Json;

  public class CustomNotificationChannel
  {
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayName { get; set; }

    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public List<CustomNotificationChannelSettings> Data { get; set; }
  }

  public class CustomNotificationChannelSettings
  {
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("displayName", NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayName { get; set; }

    [JsonProperty("isMandatory", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(BooleanConverter))]
    public bool? IsMandatory { get; set; }

    [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(BooleanConverter))]
    public bool? Disabled { get; set; }

    [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
    public string Tooltip { get; set; }

    [JsonProperty("defaultValue", NullValueHandling = NullValueHandling.Ignore)]
    public string DefaultValue { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [JsonProperty("maxLength", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(LongConverter))]
    public long? MaxLength { get; set; }

    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public string Value { get; set; }

    [JsonProperty("Items")]
    public List<LabelValues> Items { get; set; }

    public CustomNotificationChannelSettings()
    {
      Items = new List<LabelValues>();
    }
  }

  public class LabelValues
  {
    public string Label { get; set; }
    public string Value { get; set; }
  }
}
