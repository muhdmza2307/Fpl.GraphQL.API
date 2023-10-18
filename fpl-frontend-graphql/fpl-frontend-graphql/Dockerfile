FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS sdk
ARG Configuration=Release



ENV DOTNET_CLI_TELEMETRY_OPTOUT=true \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
WORKDIR /src
COPY "Fpl.Portal.GraphQL/Fpl.Portal.GraphQL.sln" "."
COPY "Fpl.Portal.GraphQ/*.csproj" "Prescient.Portal.GraphQL/"
COPY "Fpl.Portal.Common/*.csproj" "Prescient.Portal.Common/"
COPY "Fpl.Portal.Models/*.csproj" "Prescient.Portal.Models/"
COPY "Fpl.Portal.Mapping/*.csproj" "Prescient.Portal.Mapping/"
COPY "Fpl.Portal.Repository/*.csproj" "Prescient.Portal.Repository/"
COPY "Fpl.Portal.Handlers/*.csproj" "Prescient.Portal.Repository/"

RUN dotnet restore
COPY . .


RUN dotnet build "Fpl.Portal.GraphQL/Fpl.Portal.GraphQL.sln" --configuration $Configuration --no-restore
RUN dotnet publish "Fpl.Portal.GraphQL/Fpl.Portal.GraphQL.csproj" --configuration $Configuration --no-build --output /app


FROM base AS runtime
WORKDIR /app
COPY --from=sdk /app .
ENTRYPOINT ["dotnet", "Fpl.Portal.GraphQL.dll"]
