FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PQ_API.csproj", "./"]
RUN dotnet restore "PQ_API.csproj"
COPY . .
RUN dotnet build "PQ_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PQ_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PQ_API.dll"]
