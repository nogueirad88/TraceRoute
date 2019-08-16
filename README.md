# TraceRoute

.Net Core application to get cheapest route between two places

## Before you begin ##

In order to build and test the application, you need to install .Net Core SDK for your OS: [Download .Net SDK](https://dotnet.microsoft.com/download "Download .Net SDK")

## How to run the Console Application##
Open Linux/Windows Terminal, Go to **Console** folder and type the commands:
```shell
dotnet build
dotnet run -- path/to/your/file.csv
```
Type your destinarion and get your cheapest route ex:
```shell
please enter the route: GRU-CDG
best route: GRU - BRC - SCL - ORL - CDG > $40
```
## How to run the Web Application##
Go to **Routing.Api** folder and type the command:
```shell
dotnet run
```
The app will start listening on: http://localhost:5000

### How to get cheapest route ###
Request Method [GET]:
```shell
'http://localhost:5000/api/route?from=BRC&to=ORL'
```
Response: **200 OK**:
```shell
{
		"route":"BRC - SCL - ORL",
		"price":25.0
}
```
### How to save a new route ###
Request Method [POST]:
```shell
'http://localhost:5000/api/route'
```
Body:
```shell
{
  "From": "XPT",
  "To": "ATZ",
  "Cost": 12
}
```
Response: **201 Created**:
```shell
{
  "From": "XPT",
  "To": "ATZ",
  "Cost": 12
}
```
## Project Structure ##

+-- **Console**
+-- **Core**
¦   +-- Routing.Business -> The business logic to get the cheapest route.
¦   +-- Routing.Model -> Classes to represent route and itinerary objects.
¦   +-- Routing.Service -> Make the conversation possible between Business and Repository.
¦   +-- Routing.Repository -> Make access to resources direcly.
+-- **Routing.Api**
¦   +-- Controllers ->Represent the  api endpoints exposed.
¦   +-- RequestObjects -> Represent complex request body objects when necessary.
¦   +-- ResponseObjects -> Represent complex response body objects when necessary.
+- **Tests**
¦   +-- Routing.UnitTests ->Some tests to help debugging.
+-- 