FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["hw12.benchmark/hw12.benchmark.csproj", "hw12.benchmark/"]
RUN dotnet restore "hw12.benchmark/hw12.benchmark.csproj"
COPY . .
WORKDIR "/src/hw12.benchmark"
RUN dotnet build "hw12.benchmark.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hw12.benchmark.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hw12.benchmark.dll"]
