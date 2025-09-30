# Task Tracker (.NET 8)

Jednoduchá aplikácia na sledovanie úloh (taskov), ktorá pozostáva z dvoch hlavných častí: API projekt (backend) a MVC aplikácia (frontend).
Používa **.NET 8**, **Entity Framework Core** a **SQL Server**.

---

## 🚀 Ako spustiť projekt

### 1. Klonovanie repozitára
```bash
git clone https://github.com/Ados-developer/TaskTrackerWithApi.git
cd TaskTrackerWithApi
```
### 2. Databáza
  1. Otvor SQL Server Management Studio a vytvor novú databázu.
  2. Nastav pripojenie k databáze v appsettings.json v TaskTrackerApi projekte.
  3. Rebuild projektu a spustenie migrácií v priečinku API:
```bash
dotnet clean
dotnet build
dotnet ef database update
```
**Dôležité:** Spúšťaj migrácie v priečinku API.

### 3. Spustenie API
```bash
dotnet run
```
### 4. Nastavenie a spustenie MVC aplikácie
  1. Otvor TaskTrackerApp projekt vo Visual Studio.
  2. Skopíruj URL API do appsettings.json, aby sa vedela pripojiť k bežiacemu API.
### 5. Používanie aplikácie
  1. Vytváraj, upravuj, vymazávaj a zobrazuj všetky úlohy cez MVC aplikáciu, ktorá komunikuje s API backendom.

## Potrebné k spusteniu
1. [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
2. [SQL Server](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
