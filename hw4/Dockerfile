FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["hw4/hw4.fsproj", "hw4/"]
RUN dotnet restore "hw4/hw4.fsproj"
COPY . .
WORKDIR "/src/hw4"
RUN dotnet build "hw4.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hw4.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hw4.dll"]
