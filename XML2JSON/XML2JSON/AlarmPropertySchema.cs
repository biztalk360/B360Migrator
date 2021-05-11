namespace XML2JSON
{
  using System;
  using System.Collections.Generic;
  using Newtonsoft.Json;

  public class AlarmPropertySchema
  {
    [JsonProperty("prop:AlarmProperties")]
    public PropAlarmProperties PropAlarmProperties { get; set; }
  }

  public class PropAlarmProperties
  {
    [JsonProperty("@xmlns")]
    public Uri Xmlns { get; set; }

    [JsonProperty("@xmlns:prop")]
    public Uri XmlnsProp { get; set; }

    [JsonProperty("@Name")]
    public string Name { get; set; }

    [JsonProperty("@DisplayName")]
    public string DisplayName { get; set; }

    [JsonProperty("TextBox")]
    public List<Box> TextBox { get; set; }

    [JsonProperty("TextArea", NullValueHandling = NullValueHandling.Ignore)]
    public Box TextArea { get; set; }

    [JsonProperty("CheckBox", NullValueHandling = NullValueHandling.Ignore)]
    public Box CheckBox { get; set; }

    [JsonProperty("Label")]
    public Label Label { get; set; }
  }

  public class Label
  {
    [JsonProperty("@Name")]
    public string Name { get; set; }

    [JsonProperty("@DefaultValue")]
    public string DefaultValue { get; set; }

    [JsonProperty("@For")]
    public string For { get; set; }
  }
}
