FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GeekStore.ProductApi/GeekStore.ProductApi.csproj", "GeekStore.ProductApi/"]
COPY ["GeekStore.ProductApi.Infrastructure/GeekStore.ProductApi.Infrastructure.csproj", "GeekStore.ProductApi.Infrastructure/"]
COPY ["GeekStore.ProductApi.Domain/GeekStore.ProductApi.Domain.csproj", "GeekStore.ProductApi.Domain/"]
RUN dotnet restore "GeekStore.ProductApi/GeekStore.ProductApi.csproj"
COPY . .
WORKDIR "/src/GeekStore.ProductApi"
RUN dotnet build "./GeekStore.ProductApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GeekStore.ProductApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekStore.ProductApi.dll"]
