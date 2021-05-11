# B360Migrator
This repo contains a simple `.NET` console app which will help you migrate your existing Notification Channel configurations from XML to JSON

## How to Consume the Service ?

- Open XML2JSON Solution in Visual Studio / VS Code
- You'll notice a file called `Teams.xml` & `TeamsValue.xml`
- You should replace the contents of the file following the below.
- Open database on `BizTalk360` and run the query 

```sql
select * from b360_alert_notify_GlobalNotificationChannel
```

- The list will contain all the channels that you have currently configured.

- `Teams.xml` contents can be obtained from `GlobalPropertySchema` & `TeamsValue.xml` contents from `GlobalPropertiesValues`

- Now if you run the solution you will find the `Output.json` folder under `XML2JSON\XML2JSON\bin\Debug\netcoreapp3.1`