# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar el .csproj del proyecto principal
COPY ["GymProjectBackend/GymProjectBackend.csproj", "GymProjectBackend/"]
RUN dotnet restore "GymProjectBackend/GymProjectBackend.csproj"

# Copiar todo el código
COPY . .

# Build desde la carpeta del proyecto
WORKDIR "/src/GymProjectBackend"
RUN dotnet build "GymProjectBackend.csproj" -c Release -o /app/build

# Etapa 2: Publish
FROM build AS publish
RUN dotnet publish "GymProjectBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Render usa la variable PORT
ENV ASPNETCORE_URLS=http://+:${PORT:-10000}

ENTRYPOINT ["dotnet", "GymProjectBackend.dll"]
