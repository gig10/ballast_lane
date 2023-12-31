#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GameDatabase.API/GameDatabase.API.csproj", "GameDatabase.API/"]
RUN dotnet restore "GameDatabase.API/GameDatabase.API.csproj"
COPY . .
WORKDIR "/src/GameDatabase.API"
RUN dotnet build "GameDatabase.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameDatabase.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameDatabase.API.dll"]