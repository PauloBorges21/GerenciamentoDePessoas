# Etapa base com runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Etapa de build com SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GerenciamentoDePessoas.csproj", "."]
RUN dotnet restore "GerenciamentoDePessoas.csproj"
COPY . .
RUN dotnet build "GerenciamentoDePessoas.csproj" -c Release -o /app/build

# Etapa para migrações
FROM build AS migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "GerenciamentoDePessoas.csproj" -c Release -o /app

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GerenciamentoDePessoas.dll"]