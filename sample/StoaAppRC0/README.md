# StoaApp

## scaffolding

```shell
mkdir StoaApp
cd StoaApp
dotnet new gitignore
touch README.md
echo -e "{\n\t\"folders\": [\n\t\t{\n\t\t\t\"path\": \".\"\n\t\t}\n\t],\n\t\"settings\": {}\n}" > StoaAppRC0.code-workspace
dotnet new web -o Stoa.Web
```
