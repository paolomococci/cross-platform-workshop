# DummyRosterBlazorWasmVanilla

## Scaffolding of DummyRosterBlazorWasmVanilla workspace

```shell
mkdir DummyRosterBlazorWasmVanilla
cd DummyRosterBlazorWasmVanilla
echo "# DummyRosterBlazorWasmVanilla" > README.md
dotnet new gitignore
```

### Scaffolding of DummyRoster.BlazorWasm project

From the main workspace I type the following commands:

```shell
dotnet new blazorwasm --pwa --hosted --name DummyRoster.BlazorWasm
cd DummyRoster.BlazorWasm/Server
dotnet clear
dotnet build
dotnet run
```
