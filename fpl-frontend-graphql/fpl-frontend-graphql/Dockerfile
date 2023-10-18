FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS build

WORKDIR /source
COPY . .

RUN dotnet restore "./Fpl.Portal.GraphQL/Fpl.Portal.GraphQL.csproj" --disable-parallel
RUN dotnet publish "./Fpl.Portal.GraphQL/Fpl.Portal.GraphQL.csproj" -c release -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Fpl.Portal.GraphQL.dll"]
