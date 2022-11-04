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
```
