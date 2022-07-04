#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nikan.Services/nuget.config", "Nikan.Services/"]
COPY ["Nikan.Services/src/WebApi/WebApi.csproj", "Nikan.Services/src/WebApi/"]
COPY ["Nikan.Services/src/Infrastructure/Infrastructure.csproj", "Nikan.Services/src/Infrastructure/"]
COPY ["Nikan.Services/src/SharedKernel/SharedKernel.csproj", "Nikan.Services/src/SharedKernel/"]
COPY ["Nikan.Services/src/Core/Core.csproj", "Nikan.Services/src/Core/"]
RUN dotnet restore "Nikan.Services/src/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/Nikan.Services/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nikan.Services.BasicData.WebApi.dll"]