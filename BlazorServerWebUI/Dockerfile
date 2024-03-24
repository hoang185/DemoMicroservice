#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BlazorServerWebUI/BlazorServerWebUI.csproj", "BlazorServerWebUI/"]
RUN dotnet restore "./BlazorServerWebUI/./BlazorServerWebUI.csproj"
COPY . .
WORKDIR "/src/BlazorServerWebUI"
RUN dotnet build "./BlazorServerWebUI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BlazorServerWebUI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorServerWebUI.dll"]