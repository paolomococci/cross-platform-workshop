# SampleRestSolution

## scaffolding

```shell
mkdir SampleRestSolution
cd SampleRestSolution
echo "# SampleRestSolution" > README.md
dotnet new gitignore
dotnet new sln
dotnet new webapi --name SampleRestSolution.WebApi
dotnet sln add SampleRestSolution.WebApi/SampleRestSolution.WebApi.csproj
cd SampleRestSolution.WebApi
dotnet run SampleRestSolution.WebApi.csproj
```

## open your preferred browser

Now you need to know exactly which port the API is listening on.
To do this you have to open the file launchSettings.json and look for the entry applicationUrl under profiles.

```text
https://localhost:7101/weatherforecast
```

Obtaining something similar to the following answer:

```text
[{"date":"2022-11-05T22:51:05.0801121+01:00","temperatureC":-18,"temperatureF":0,"summary":"Mild"},{"date":"2022-11-06T22:51:05.081702+01:00","temperatureC":50,"temperatureF":121,"summary":"Hot"},{"date":"2022-11-07T22:51:05.0817236+01:00","temperatureC":23,"temperatureF":73,"summary":"Balmy"},{"date":"2022-11-08T22:51:05.0817243+01:00","temperatureC":-16,"temperatureF":4,"summary":"Bracing"},{"date":"2022-11-09T22:51:05.0817247+01:00","temperatureC":48,"temperatureF":118,"summary":"Mild"}]
```
