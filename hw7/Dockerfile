FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["hw7/hw7.csproj", "hw7/"]
RUN dotnet restore "hw7/hw7.csproj"
COPY . .
WORKDIR "/src/hw7"
RUN dotnet build "hw7.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hw7.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hw7.dll"]
