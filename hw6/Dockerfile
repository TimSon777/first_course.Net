FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["hw6/hw6.csproj", "hw6/"]
RUN dotnet restore "hw6/hw6.csproj"
COPY . .
WORKDIR "/src/hw6"
RUN dotnet build "hw6.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "hw6.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "hw6.dll"]
