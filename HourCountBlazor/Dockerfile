FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HourCountBlazor/HourCountBlazor.csproj", "HourCountBlazor/"]
RUN dotnet restore "HourCountBlazor/HourCountBlazor.csproj"
COPY . .
WORKDIR "/src/HourCountBlazor"
RUN dotnet build "HourCountBlazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HourCountBlazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HourCountBlazor.dll"]
