# Warehouse Invetory System
## Summary
Warehouse Inventory System (WIS) is a partial rebuild of an existing .NET application. This program is intended to copy core functionality into a web app. When designing the web app, I wanted to keep the forms and hierarchy as similar as possible.

Operators check in truck loads.

Loads are attached to Weight Sheets.

Inbound weight sheets contain loads which farmers bring in.

Transfer weight sheets contain loads from other elevators in the company.

Inbound weight sheets are attached to a farmer's lot (field) Therefor, lots have 0 to many weight sheets. Weight sheets have 0 to many loads.

## Features
* Create Lots, Inbound and Transfer Weight Sheet, Loads.
* View Lots, Weight Sheets and Loads.
* Edit Lots, Inbound and Transfer Weight Sheet, Loads.
* Generate basic daily reports exportable to PDF or Excel.

## Tech Stack
* Angular
	- TypeScript
	- HTML
	- CSS
* DotNet v6
* ASP.NET Core v6.5.0
* Entity Framework v7.0.14
* SQL Server
