# BankingApp - (925/1/2)Team B / Garbage Collectors

## Features
* **Fund Transfers:** Transfer money to saved beneficiaries or new accounts.
* **Bill Payments:** Manage saved billers and execute utility/service payments.
* **Foreign Exchange (FX):** Convert currencies and set market rate alerts.

## Getting Started

Follow these steps to get the project running on your local machine.

### Prerequisites
* Visual Studio 2022 (with the **Windows application development** workload).
* Windows App SDK extension for Visual Studio.
* SQL Server Express or LocalDB (installed by default with Visual Studio data workloads).

### Step 1: Clone and Open
1. Clone the repository to your local machine.
2. Open the `BankingAppTeamB.sln` file in Visual Studio 2022.

### Step 2: Create the Local Database
Before running the app, you need an empty database for the app to connect to.
1. In Visual Studio, open the **SQL Server Object Explorer** (View -> SQL Server Object Explorer).
2. Expand **SQL Server** -> **(localdb)\MSSQLLocalDB** -> **Databases**.
3. Right-click on **Databases** and select **Add New Database**.
4. Name the new database exactly: **BankingAppTeamB** and click OK.

### Step 3: Configure the Connection String
1. Locate the `appsettings.json` file in the root of the `BankingAppTeamB` project.
2. Update the file to use your new local database. It should look like this:
   ```json
   {
     "ConnectionStrings": {
       "BankingApp": "Server=(localdb)\\mssqllocaldb;Database=BankingAppTeamB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```
3. Right-click `appsettings.json`, select **Properties**, and ensure **Copy to Output Directory** is set to **Copy if newer**.

### Step 4: Check Project Configuration (Troubleshooting)
Depending on your local Windows App SDK environment, you may need to adjust how the app is packaged.
1. Right-click the main `BankingAppTeamB` project (the C# project, not the Package project) and select **Edit Project File**.
2. Look for the `<PropertyGroup>` section.
3. Ensure the following tag exists. For most local debugging setups, it should be set to `false`. If you experience deployment errors, try changing it to `true`:
   ```xml
   <WindowsAppSDKSelfContained>false</WindowsAppSDKSelfContained>
   ```
4. Save and close the file.

### Step 5: Build and Run
1. At the top of Visual Studio, ensure the startup project is set to **BankingAppTeamB (Package)**.
2. Press **F5** or click the Play button to run the application.
3. *Note: You do not need to create the database tables manually. When the app launches for the first time, it will automatically run the SQL scripts in the `Database/` folder to create all necessary tables and insert default data.*

---

## Authors
* **Garbage Collectors** - UBB Software Engineering 2026