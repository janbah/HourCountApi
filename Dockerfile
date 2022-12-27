FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HourCountApi/HourCountApi.csproj", "HourCountApi/"]
COPY ["CrossCutting/CrossCutting.csproj", "CrossCutting/"]
COPY ["WorkingTimeManagement/WorkingTimeManagement.csproj", "WorkingTimeManagement/"]
COPY ["DataStoring/DataStoring.csproj", "DataStoring/"]
RUN dotnet restore "HourCountApi/HourCountApi.csproj"
COPY . .
WORKDIR "/src/HourCountApi"
RUN dotnet build "HourCountApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HourCountApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HourCountApi.dll"]
