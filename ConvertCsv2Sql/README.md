ConvertCsv2Sql
====
Convert CSV Data to SQL

## Feature
- Convert csv contents to sql. 
  - Only support update SQL and MySQL DB

## How to build
- install dotnet dotnet sdk.
  - see [.NET Download Guid](https://dotnet.microsoft.com/download)

- execute `dotnet build` command.
```sh
cd ConvertCsv2Sql
dotnet build -c Release
```

## How to use
- Modify `settings.yaml` according to CSV columns
- execute dotnet run
```sh
dotnet run 
<Input CSV file path>
```

- `.sql` file output to `out` directory.

## Requirement
- dotnetcore 3.1 later 

