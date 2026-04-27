## 🏦 The "Database Cheat Sheet" (Save this!):
- Whenever you build a database in the future, follow the 4-Step Blueprint:

- The Context (Data folder): Create the "Translator" file (DbContext).
- The Map (appsettings.json): Add the "Connection String" so the app knows where the file lives.
- The Registration (Program.cs): Tell the app to use the SQLite engine.
- The Execution (Terminal):
- dotnet ef migrations add [NAME] (The Blueprint) ==> watching Vanguad VantagePointDbContext
- dotnet ef database update (The Construction) 