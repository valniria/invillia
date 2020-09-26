#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DesafioInvillia/DesafioInvillia.csproj", "DesafioInvillia/"]
COPY ["AplicacaoService/AplicacaoService.csproj", "AplicacaoService/"]
COPY ["Aplicacao/Aplicacao.csproj", "Aplicacao/"]
COPY ["Compartilhado/Compartilhado.csproj", "Compartilhado/"]
COPY ["Dominio/Dominio.csproj", "Dominio/"]
COPY ["Infraestrutura/Infraestrutura.csproj", "Infraestrutura/"]
COPY ["EntityFramework/EntityFramework.csproj", "EntityFramework/"]
COPY ["Negocio/Negocio.csproj", "Negocio/"]
RUN dotnet restore "DesafioInvillia/DesafioInvillia.csproj"
COPY . .
WORKDIR "/src/DesafioInvillia"
RUN dotnet build "DesafioInvillia.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioInvillia.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioInvillia.dll"]