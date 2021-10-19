FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["addTask1/addTask1.fsproj", "addTask1/"]
RUN dotnet restore "addTask1/addTask1.fsproj"
COPY . .
WORKDIR "/src/addTask1"
RUN dotnet build "addTask1.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "addTask1.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "addTask1.dll"]
