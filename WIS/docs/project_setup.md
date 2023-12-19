# Warehouse Inventory System (WIS) README
## Setup
1. New Project/Solution: Angular Stand alone project. Check to have integration for ASP.NET Core backend
2. Create new ASP>NET Core Web API	Project
3. Set Angular project properties Debugging to use launch.json Folder.
4. Set API project's launchSettings.json `"launchBrower"` to `false`
5. Replace Randomly generated HTTP & HTTPS port with fixed number ports. Dealers choice.
6. Set Solution for multi project startup with the API Starting up first. Each project action is `Start`
7. Set proxy.config.js in the Angular project to target the HTTPS port.

### Port Numbers

* HTTP : 58800
* HTTPS: 58801