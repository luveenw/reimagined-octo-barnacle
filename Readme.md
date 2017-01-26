# Testing the C# Requirements (Plus a Side Note)
1. Open CMCS.sln, also located in this folder, in Visual Studio.
2. To run unit tests, select the appropriate option in the Test menu.
3. [Side Note] While this solution was also tested in Visual Studio, it was primarily developed using IntelliJ's Rider 1.0 EAP, which is currently in beta, but fully featured for active development and dependency management using NuGet. This solution ported with zero changes across both IDEs. You may notice a folder called `.idea`, which I left in as an easter egg of sorts.

# Setup Instructions for Testing the SQL Requirements
## Prerequisites
1. Install SQL Local DB (https://download.microsoft.com/download/8/D/D/8DD7BDBA-CEF7-4D8E-8C16-D9F69527F909/ENU/x64/SqlLocalDB.MSI)
2. Install SQL Command Line Utilities (http://go.microsoft.com/fwlink/?LinkID=239649&clcid=0x409)
3. Create a database instance in a command-line terminal by invoking the following commands:
```
SqlLocalDb create -s "MyInstance"
cd "c:\Program Files\Microsoft SQL Server\110\Tools\Binn"
sqlcmd -S (localdb)\MyInstance
```

## Create the Database Schema
Run create_schema.sql, also located in this folder.

## Load the Data Set
Run insert_data.sql, also located in this folder.

## Done!
You are now ready to run the queries listed in SQL.txt. For a compendium of the SQL queries listed here, refer SalesQueries.sql.