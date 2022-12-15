FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Mandalina.Server/Mandalina.Server.csproj", "Mandalina.Server/"]
RUN dotnet restore "Mandalina.Server/Mandalina.Server.csproj"
COPY . .
WORKDIR "/src/Mandalina.Server"
RUN dotnet build "Mandalina.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mandalina.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mandalina.Server.dll"]
