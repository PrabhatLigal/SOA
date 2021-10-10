#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 3000
EXPOSE 3001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BirthMicroservice/BirthMicroservice.csproj", "BirthMicroservice/"]
RUN dotnet restore "BirthMicroservice/BirthMicroservice.csproj"
COPY . .
WORKDIR "/src/BirthMicroservice"
RUN dotnet build "BirthMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BirthMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BirthMicroservice.dll"]
