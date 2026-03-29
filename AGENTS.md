# AGENTS.md

## Cursor Cloud specific instructions

### Project Overview

This is a C# Windows Forms (.NET Framework 4.6.1) Hotel Management desktop application. It is built and run on Linux using Mono. The database backend is SQL Server 2017 running in Docker.

### Build

```
cd "Source code/C# script/HotelManager"
msbuild HotelManager.sln
```

Output: `Source code/C# script/HotelManager/HotelManager/bin/Debug/HotelManager.exe`

### Run

```
cd "Source code/C# script/HotelManager/HotelManager/bin/Debug"
mono HotelManager.exe
```

Login credentials: username `admin`, password `123456`.

### Database

SQL Server 2017 runs in a Docker container named `sqlserver` on port 1433. Credentials: `sa` / `HotelMgmt123!`. Database name: `HotelManagement`.

To start the container (if stopped):
```
sudo dockerd &>/tmp/dockerd.log &
sleep 5
sudo docker start sqlserver
```

To query the database:
```
sudo docker exec sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'HotelMgmt123!' -d HotelManagement -Q "SELECT ..."
```

To reinitialize the database from scratch:
```
sudo docker exec sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'HotelMgmt123!' -Q "DROP DATABASE HotelManagement; CREATE DATABASE HotelManagement"
sudo docker cp "Source code/SQL script/SQL script.sql" sqlserver:/tmp/init.sql
sudo docker exec sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 'HotelMgmt123!' -d HotelManagement -i /tmp/init.sql
```

### Key Caveats

- **Bunifu UI controls** are stubbed (see `Source code/C# script/HotelManager/lib/BunifuStub.cs`). The original `Bunifu_UI_v1.52.dll` is a proprietary library not available on NuGet. The stub provides type signatures for compilation but UI rendering of Bunifu controls (textboxes, buttons, datepickers) is limited under Mono.
- **Excel interop** is also stubbed (`lib/ExcelInteropStub.cs`). Export-to-Excel functionality requires Microsoft Office COM, which is not available on Linux.
- **Connection string** is configured in `DAO/DataProvider.cs` and `App.config`. It points to `localhost` with `sa` / `HotelMgmt123!`.
- **No automated tests** exist in this codebase. Testing is manual via the GUI.
- Some forms using **MetroFramework.Controls.MetroComboBox** may have rendering issues under Mono. The core application structure (login, dashboard, room/booking management) works.
