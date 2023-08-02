FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["_TESODEV_Project1/_TESODEV_Project1.csproj", "_TESODEV_Project1/"]
RUN dotnet restore "_TESODEV_Project1/_TESODEV_Project1.csproj"
COPY . .
WORKDIR "/src/_TESODEV_Project1"
RUN dotnet build "_TESODEV_Project1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "_TESODEV_Project1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "_TESODEV_Project1.dll"]
