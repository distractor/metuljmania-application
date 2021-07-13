#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["MetuljmaniaDatabase.csproj", "."]
RUN dotnet restore "./MetuljmaniaDatabase.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MetuljmaniaDatabase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MetuljmaniaDatabase.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT="Development"
ENTRYPOINT ["dotnet", "MetuljmaniaDatabase.dll"]
