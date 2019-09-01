FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Zip/Zip.csproj", "Zip/"]
RUN dotnet restore "Zip/Zip.csproj"
COPY . .
WORKDIR "/src/Zip"
RUN dotnet build "Zip.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Zip.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Zip.dll"]