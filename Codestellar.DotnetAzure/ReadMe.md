# Dotnet Azure Samples

## 04/15/2020 Implementing Swagger
1. Created a blank API Project
2. Added [Swagger following this tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=netcore-cli)

## 04/16/2020 Implementing Services (using DataGenerator GenFu)
1. [Reference Link](https://asp.net-hacker.rocks/2017/09/27/testing-aspnetcore.html)
3. Added Codestellar.DotnetAzure.Business which serves the Business Logic and Services
4. Created an API Persons API with CRUD. Used GenFu for generating Data
5. Leveraged .Net Core DI in startup.cs. Initialized PersonService