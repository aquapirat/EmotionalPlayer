#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Src/WebUI/WebUI.csproj", "Src/WebUI/"]
COPY ["Src/Common/Common.csproj", "Src/Common/"]
COPY ["Src/Persistence/Persistence.csproj", "Src/Persistence/"]
COPY ["Src/Application/Application.csproj", "Src/Application/"]
COPY ["Src/Domain/Domain.csproj", "Src/Domain/"]
COPY ["Src/Infrastructure/Infrastructure.csproj", "Src/Infrastructure/"]
RUN dotnet restore "Src/WebUI/WebUI.csproj"
COPY . .
WORKDIR "/src/Src/WebUI"
RUN dotnet build "WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN echo ${ASPNETCORE_ENVIRONMENT}
ENTRYPOINT ["dotnet", "Player.WebUI.dll", "--environment=Docker"]