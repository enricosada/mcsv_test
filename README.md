## For editor (like vscode):

do `dotnet restore` before opening the editor

## normally

Do a publish

```
dotnet publish -o out
```

now from any OS with .net core runtime installed you can use that `out` dir

```
cd out
dotnet mcsv.dll
```
