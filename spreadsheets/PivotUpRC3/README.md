# PivotUpRC3

## Scaffolding

### I start by creating the directory that will house the entire project

```shell
mkdir PivotUpRC3
cd PivotUpRC3
```

### I create the file that defines the workspace

```shell
cat <<EOF | tee PivotUpRC3.code-workspace
{
	"folders": [
		{
			"path": "."
		}
	],
	"settings": {}
}
EOF
```

### main project

```shell
dotnet new gitignore
touch README.md
```

### Pivot.Common project

```shell
dotnet new classlib -o Pivot.Common
cd Pivot.Common
rm Class1.cs
dotnet add package ClosedXML --version 0.97.0
mkdir Models
echo -e "namespace Pivot.Common.Models;\n\npublic class LedgerModel {}" > Models/LedgerModel.cs
echo -e "namespace Pivot.Common.Models;\n\npublic class ItemModel {}" > Models/ItemModel.cs
mkdir Templates
echo -e "namespace Pivot.Common.Templates;\n\npublic class PinnedSheetTemplate {}" > Templates/PinnedSheetTemplate.cs
```

### Pivot.Mvc.Feather project

```shell
dotnet new web -o Pivot.Mvc.Feather
cd Pivot.Mvc.Feather
```
