FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["addTask1_csharp/addTask1_csharp.csproj", "addTask1_csharp/"]
RUN dotnet restore "addTask1_csharp/addTask1_csharp.csproj"
COPY . .
WORKDIR "/src/addTask1_csharp"
RUN dotnet build "addTask1_csharp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "addTask1_csharp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "addTask1_csharp.dll"]
