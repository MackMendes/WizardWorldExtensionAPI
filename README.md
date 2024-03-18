# Wizard World Extension API

The goal of this repository was to create an API that allows a user to enter a set of ingredients they have available to discover the list of elixirs they can create from those ingredients. 

This information is fetched from the project's WizardWorldApi endpoint: https://wizard-world-api.herokuapp.com/swagger/index.html. The project for this endpoint is available on GitHub:  
https://github.com/MossPiglets/WizardWorldAPI. 

## Tech of Project

This API is using the .NET 8.0 version (https://dotnet.microsoft.com/en-us/download/dotnet/8.0). In addition, this project is using 100% Nuget packages. 


## Execute the project 

The goal of this session is to explain how to run the project via Visual Studio or the command line: 

### Visual Studio :: Startup project
- **Manually restore** solution packages
- Setup **Presentation.WebAPI** as **startup** project
- **Build** the solution

### Visual Studio :: Run tests

- With all the steps done successfully above, just **run all tests** in Visual Studio.

### Command line :: Startup project
- In the root of the project, run the following command line: 

``` cmd
dotnet  run --project ./src/Presentation.WebAPI/Presentation.WebAPI.csproj
```` 

- After that, open the following url on our browser: https://localhost:7264/swagger/index.html 

### Command line :: Run tests

- In the root of the project, run the following command line: 

``` cmd
dotnet test
```` 

## Notes

### Cache

The idea was to use in-memory caching to minimize the impact on the API. However, if the API grows, we can change this in-memory caching approach to use a more robust caching provider, e.g. Redis (https://redis.io/), Memcached (https://memcached.org/). 

### Integrations Tests

The idea was to create Test Server integrations tests and test all the endpoints, but I didn't have time.