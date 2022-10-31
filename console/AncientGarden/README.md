# Ancient Garden project

## scaffolding

```shell
mkdir AncientGarden
cd AncientGarden
dotnet new gitignore
echo "# Ancient Garden project" > README.md
dotnet new classlib --name PetLibrary
dotnet new console -o PetApp
dotnet new console -o CloisterApp
dotnet new console -o HandlingApp
dotnet new console -o LabApp
echo "# PetLibrary belonging to Ancient Garden project" > PetLibrary/README.md
echo "# PetApp belonging to Ancient Garden project" > PetApp/README.md
echo "# CloisterApp belonging to Ancient Garden project" > CloisterApp/README.md
echo "# HandlingApp belonging to Ancient Garden project" > HandlingApp/README.md
echo "# LabApp belonging to Ancient Garden project" > LabApp/README.md
```
