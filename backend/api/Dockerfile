FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["api.csproj", "."]
RUN dotnet restore "api.csproj"
COPY . .
RUN dotnet publish "api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
ENV DOTNET_ENVIRONMENT=Development
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
