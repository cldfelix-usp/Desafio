FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar todos os arquivos de projeto e restaurar as dependências
COPY ["server/ApiDesafio/ApiDesafio.csproj", "ApiDesafio/"]
COPY ["server/ApiDesafio.Presentation/ApiDesafio.Presentation.csproj", "ApiDesafio.Presentation/"]
COPY ["server/Contracts/Contracts.csproj", "Contracts/"]
COPY ["server/Entities/Entities.csproj", "Entities/"]
COPY ["server/LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["server/Repository/Repository.csproj", "Repository/"]
COPY ["server/Service/Service.csproj", "Service/"]
COPY ["server/Service.Contracts/Service.Contracts.csproj", "Service.Contracts/"]
COPY ["server/Shared/Shared.csproj", "Shared/"]

# Restaurar as dependências para todos os projetos
RUN dotnet restore "ApiDesafio/ApiDesafio.csproj"
RUN dotnet restore "ApiDesafio.Presentation/ApiDesafio.Presentation.csproj"
RUN dotnet restore "Contracts/Contracts.csproj"
RUN dotnet restore "Entities/Entities.csproj"
RUN dotnet restore "LoggerService/LoggerService.csproj"
RUN dotnet restore "Repository/Repository.csproj"
RUN dotnet restore "Service/Service.csproj"
RUN dotnet restore "Service.Contracts/Service.Contracts.csproj"
RUN dotnet restore "Shared/Shared.csproj"

# Copiar todo o código fonte
COPY ["server/ApiDesafio/ApiDesafio.csproj", "ApiDesafio/"]
COPY ["server/ApiDesafio.Presentation/ApiDesafio.Presentation.csproj", "ApiDesafio.Presentation/"]
COPY ["server/Contracts/Contracts.csproj", "Contracts/"]
COPY ["server/Entities/Entities.csproj", "Entities/"]
COPY ["server/LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["server/Repository/Repository.csproj", "Repository/"]
COPY ["server/Service/Service.csproj", "Service/"]
COPY ["server/Service.Contracts/Service.Contracts.csproj", "Service.Contracts/"]
COPY ["server/Shared/Shared.csproj", "Shared/"]

# Compilar o projeto principal e seus dependentes
WORKDIR "/src/ApiDesafio"
RUN dotnet build "ApiDesafio.csproj" -c Release -o /app/build
#RUN dotnet build "./WebApplication1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
# Publicar o projeto principal
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ApiDesafio.csproj" c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final - imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish . /p:UseAppHost=false


