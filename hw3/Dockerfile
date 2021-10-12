FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["hw3/hw3.fsproj", "hw3/"]
RUN dotnet restore "hw3/hw3.fsproj"
COPY . .
WORKDIR "/src/hw3"
RUN dotnet build "hw3.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hw3.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hw3.dll"]
