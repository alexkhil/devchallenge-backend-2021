FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

EXPOSE 80

# Copy csproj files
COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do \
        echo $file \
        && mkdir -p src/${file%.*}/ \
        && mv $file src/${file%.*}/; \
    done

# Restore api csproj
RUN dotnet restore ./src/DevChallenge.Api/DevChallenge.Api.csproj

# Copy everything else and build
COPY . ./

# Publish to out folder
RUN dotnet publish ./src/DevChallenge.Api/DevChallenge.Api.csproj -c Release --no-restore --no-cache -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "DevChallenge.Api.dll"]
