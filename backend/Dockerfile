# =========================
# Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# =========================
# Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia apenas os arquivos de projeto primeiro (melhora cache)
COPY ["GastosResidenciais/GastosResidenciais.API/GastosResidenciais.API.csproj", "GastosResidenciais.API/"]

# Restore das dependências
RUN dotnet restore "GastosResidenciais.API/GastosResidenciais.API.csproj"

# Copia o restante do código
COPY . .

# Entra na pasta do projeto
WORKDIR "/src/GastosResidenciais.API"

# Build
RUN dotnet build "GastosResidenciais.API.csproj" -c Release -o /app/build

# =========================
# Publish
# =========================
FROM build AS publish
RUN dotnet publish "GastosResidenciais.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# =========================
# Final
# =========================
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "GastosResidenciais.API.dll"]