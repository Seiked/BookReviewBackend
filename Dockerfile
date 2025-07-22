# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos de solución y proyectos
COPY BookReview.sln .
COPY BookReview.API/*.csproj ./BookReview.API/
COPY BookReview.Core/*.csproj ./BookReview.Core/
COPY BookReview.Infrastructure/*.csproj ./BookReview.Infrastructure/

# Restaurar dependencias
RUN dotnet restore

# Copiar el resto del código
COPY . .

# Publicar
RUN dotnet publish BookReview.API/BookReview.API.csproj -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Puerto que usará Railway (8080)
EXPOSE 8080

# Comando para iniciar
ENTRYPOINT ["dotnet", "BookReview.API.dll"]