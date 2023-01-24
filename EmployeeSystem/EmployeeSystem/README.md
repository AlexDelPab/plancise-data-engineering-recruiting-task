# Employee system

This application contains one API and returns a list of employees.

## Start application

To start the application, you need the .NET 6.0 SDK installed on your system.

Run following command in this directory to start the application `dotnet run`

## Get data from API

```
curl -X 'GET' \
  'https://localhost:7012/Employees' \
  -H 'accept: application/json'
``` 