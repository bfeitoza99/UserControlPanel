#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserControlPanel.API/UserControlPanel.API.csproj", "UserControlPanel.API/"]
COPY ["UserControlPanel.Application/UserControlPanel.Application.csproj", "UserControlPanel.Application/"]
COPY ["UserControlPanel.CrossCutting/UserControlPanel.CrossCutting.csproj", "UserControlPanel.CrossCutting/"]
COPY ["UserControlPanel.Domain/UserControlPanel.Domain.csproj", "UserControlPanel.Domain/"]
COPY ["UserControlPanel.Data/UserControlPanel.Data.csproj", "UserControlPanel.Data/"]
RUN dotnet restore "UserControlPanel.API/UserControlPanel.API.csproj"
COPY . .
WORKDIR "/src/UserControlPanel.API"
RUN dotnet build "UserControlPanel.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserControlPanel.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserControlPanel.API.dll"]