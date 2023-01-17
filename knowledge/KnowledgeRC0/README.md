# KnowledgeRC0

Web application that offers access to machine learning features.

## Scaffolding

### I start by creating the directory that will house the entire project

```shell
mkdir KnowledgeRC0
cd KnowledgeRC0
```

### I create the file that defines the workspace

```shell
cat <<EOF | tee KnowledgeRC0.code-workspace
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

### I continue to define the root of the whole project

```shell
dotnet new gitignore
echo -e "# KnowledgeRC0" > README.md
```

### Knowledge.Common project

```shell
dotnet new classlib -o Knowledge.Common
cd Knowledge.Common
rm Class1.cs
dotnet add package ClosedXML --version 0.100.3
dotnet add package Microsoft.ML --version 3.0.0-preview.22621.2
mkdir Models
```
