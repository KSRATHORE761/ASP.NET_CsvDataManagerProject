# CsvDataManager Project

## Prerequisites
- .NET Core SDK
- SQL Server or SQL Server Express
- Visual Studio or Visual Studio Code

## Steps to Restore the Database
1. Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.
2. Right-click on "Databases" and select "Restore Database...".
3. Choose "Device" and then select the `.bak` file located in the `DatabaseBackup` directory of this project.
4. Click "OK" to restore the database.

## Steps to Run the Project
1. Open the project in Visual Studio or Visual Studio Code.
2. Update the connection string in `appsettings.json` to point to your SQL Server instance.
3. Open the Package Manager Console and run the following commands to apply any pending migrations: Update-Database

4. Run the project by pressing `F5` in Visual Studio or by using the command: dotnet run

## Contact
For any issues or questions, please contact Kuldeep at rathore.kuldeep761@gmail.com.

