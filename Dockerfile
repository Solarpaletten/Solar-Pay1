# Use the official .NET 8 SDK image as a base environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

# Set the working directory inside the container
WORKDIR /app

EXPOSE 8080
EXPOSE 8081

# Use the official .NET 8 SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /SRC

COPY ["solarpay_core/solarpay_core.csproj", "solarpay_core/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Data/Data.csproj", "Data/"]

RUN mkdir /keys
RUN dotnet restore "solarpay_core/solarpay_core.csproj"

COPY . .
WORKDIR "/src/solarpay_core"

RUN dotnet build "solarpay_core.csproj" -c Release -o /app/build
RUN dotnet publish "solarpay_core.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "solarpay_core.dll"]
