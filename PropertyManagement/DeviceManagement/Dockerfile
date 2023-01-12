FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DeviceManagement/DeviceManagement.csproj", "DeviceManagement/"]
RUN dotnet restore "DeviceManagement/DeviceManagement.csproj"
COPY . .
WORKDIR "/src/DeviceManagement"
RUN dotnet build "DeviceManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeviceManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeviceManagement.dll"]
