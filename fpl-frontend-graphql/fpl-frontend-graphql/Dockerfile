FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS sdk
ARG Configuration=Release



ENV DOTNET_CLI_TELEMETRY_OPTOUT=true \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
WORKDIR /src
COPY "Fpl.Portal.GraphQL/Fpl.Portal.GraphQL.sln" "Fpl.Portal.GraphQL/"
COPY "Fpl.Portal.GraphQL/*.csproj" "Fpl.Portal.GraphQL/"
COPY "Fpl.Portal.Common/*.csproj" "Fpl.Portal.Common/"
COPY "Fpl.Portal.Models/*.csproj" "Fpl.Portal.Models/"
COPY "Fpl.Portal.Mapping/*.csproj" "Fpl.Portal.Mapping/"
COPY "Fpl.Portal.Repository/*.csproj" "Fpl.Portal.Repository/"
COPY "Fpl.Portal.Handlers/*.csproj" "Fpl.Portal.Handlers/"

RUN dotnet restore
COPY . .


RUN dotnet build "Fpl.Portal.GraphQL/Fpl.Portal.GraphQL.sln" --configuration $Configuration --no-restore
RUN dotnet publish "Fpl.Portal.GraphQL/Fpl.Portal.GraphQL.csproj" --configuration $Configuration --no-build --output /app


FROM base AS runtime
WORKDIR /app
COPY --from=sdk /app .
ENTRYPOINT ["dotnet", "Fpl.Portal.GraphQL.dll"]
