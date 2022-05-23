FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app

COPY stateful.csproj ./ 
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/runtime:6.0.5
WORKDIR  /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "stateful.dll"]

