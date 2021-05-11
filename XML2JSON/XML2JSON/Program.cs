using System;

namespace XML2JSON
{
	using System.IO;
  using System.Xml;

	using Newtonsoft.Json;

	class Program
	{
		static void Main(string[] args)
		{
      Console.WriteLine("Starting Migration");
			var teams = File.OpenText(@"Teams.xml").ReadToEnd();
			var xmlDoc = new XmlDocument();
			xmlDoc.LoadXml(teams);
			var globalPropertySchema = JsonConvert.SerializeXmlNode(xmlDoc);

			var teamsValue = File.OpenText(@"TeamsValue.xml").ReadToEnd();
			var xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(teamsValue);

      var globalPropertyValue = JsonConvert.SerializeXmlNode(xmlDocument);

      var alarmXml = File.OpenText(@"AlarmSchema.xml").ReadToEnd();
			var xDoc = new XmlDocument();
			xDoc.LoadXml(alarmXml);

      var alarmSchema = JsonConvert.SerializeXmlNode(xDoc);

			var service = new NotificationChannelMigrationService();
			var schemaJson = service.GetSchemaWithValue(globalPropertySchema,globalPropertyValue);

			//Final JSON RESULT 
      var customNotificationChannelSettings = JsonConvert.SerializeObject(service.GetCustomNotificationChannelSettings(schemaJson));
      var alarmProperties = service.GetAlarmPropertiesSchema(alarmSchema);

      using (StreamWriter writetext = new StreamWriter("Output.json"))
      {
        writetext.WriteLine(customNotificationChannelSettings);
      }
			// File.WriteAllText(@"Output.json",customNotificationChannelSettings);
      Console.WriteLine("Migration Completed");
			Console.ReadLine();
		}
	}
}
