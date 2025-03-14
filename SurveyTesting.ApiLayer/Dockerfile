#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SurveyTesting.ApiLayer/SurveyTesting.ApiLayer.csproj", "SurveyTesting.ApiLayer/"]
COPY ["SurveyTesting.ServiceLayer/SurveyTesting.ServiceLayer.csproj", "SurveyTesting.ServiceLayer/"]
COPY ["SurveyTesting.DataLayer/SurveyTesting.DataLayer.csproj", "SurveyTesting.DataLayer/"]
RUN dotnet restore "./SurveyTesting.ApiLayer/./SurveyTesting.ApiLayer.csproj"
COPY . .
WORKDIR "/src/SurveyTesting.ApiLayer"
RUN dotnet build "./SurveyTesting.ApiLayer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SurveyTesting.ApiLayer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurveyTesting.ApiLayer.dll"]