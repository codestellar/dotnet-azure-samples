#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Codestellar.MultiContainers.Api/Codestellar.MultiContainers.Api.csproj", "Codestellar.MultiContainers.Api/"]
RUN dotnet restore "Codestellar.MultiContainers.Api/Codestellar.MultiContainers.Api.csproj"
COPY . .
WORKDIR "/src/Codestellar.MultiContainers.Api"
RUN dotnet build "Codestellar.MultiContainers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Codestellar.MultiContainers.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Codestellar.MultiContainers.Api.dll"]
