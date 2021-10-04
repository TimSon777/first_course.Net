FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["hw2/hw2.csproj", "hw2/"]
RUN dotnet restore "hw2/hw2.csproj"
COPY . .
WORKDIR "/src/hw2"
RUN dotnet build "hw2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hw2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hw2.dll"]
