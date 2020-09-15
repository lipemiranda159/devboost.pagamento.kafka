FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["Infra/ServiceBus/api/devboost.dronedelivery.sb.consumer.api/devboost.dronedelivery.sb.consumer.api.csproj", "Infra/ServiceBus/api/devboost.dronedelivery.sb.consumer.api/"]
COPY ["Infra/ServiceBus/domain/devboost.dronedelivery.sb.service/devboost.dronedelivery.sb.service.csproj", "Infra/ServiceBus/domain/devboost.dronedelivery.sb.service/"]
COPY ["Infra/ServiceBus/domain/devboost.dronedelivery.sb.domain/devboost.dronedelivery.sb.domain.csproj", "Infra/ServiceBus/domain/devboost.dronedelivery.sb.domain/"]
COPY ["Core/Domain/devboost.dronedelivery.core.domain.csproj", "Core/Domain/"]
COPY ["Core/Services/devboost.dronedelivery.core.services/devboost.dronedelivery.core.services.csproj", "Core/Services/devboost.dronedelivery.core.services/"]
COPY ["Infra/Security/Domain/devboost.dronedelivery.security.domain/devboost.dronedelivery.security.domain.csproj", "Infra/Security/Domain/devboost.dronedelivery.security.domain/"]
COPY ["Infra/ServiceBus/application/devboost.dronedelivery.sb.application/devboost.dronedelivery.sb.application.csproj", "Infra/ServiceBus/application/devboost.dronedelivery.sb.application/"]
COPY ["Delivery/Services/devboost.dronedelivery.Services.csproj", "Delivery/Services/"]
COPY ["Delivery/Domain/devboost.dronedelivery.domain/devboost.dronedelivery.domain.csproj", "Delivery/Domain/devboost.dronedelivery.domain/"]
RUN dotnet restore "Infra/ServiceBus/api/devboost.dronedelivery.sb.consumer.api/devboost.dronedelivery.sb.consumer.api.csproj"
COPY . .
WORKDIR "/src/Infra/ServiceBus/api/devboost.dronedelivery.sb.consumer.api"
RUN dotnet build "devboost.dronedelivery.sb.consumer.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "devboost.dronedelivery.sb.consumer.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "devboost.dronedelivery.sb.consumer.api.dll"]