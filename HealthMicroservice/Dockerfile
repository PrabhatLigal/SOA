#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 3002
EXPOSE 3003

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["HealthMicroservice/HealthMicroservice.csproj", "HealthMicroservice/"]
RUN dotnet restore "HealthMicroservice/HealthMicroservice.csproj"
COPY . .
WORKDIR "/src/HealthMicroservice"
RUN dotnet build "HealthMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthMicroservice.dll"]
