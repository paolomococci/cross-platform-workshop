# SampleApiSolution

## scaffolding

```shell
mkdir CleanApiSolution
cd CleanApi
echo "# SampleApiSolution" > README.md
dotnet new gitignore
dotnet new sln
dotnet new webapi --name CleanApiSolution.WebApi
dotnet sln add CleanApiSolution.WebApi/CleanApiSolution.WebApi.csproj
```
