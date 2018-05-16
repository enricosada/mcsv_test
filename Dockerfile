FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

COPY data.csv data_msft.csv Program.fs mcsv.fsproj ./

RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/dotnet:2.0-runtime 
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "mcsv.dll"]
