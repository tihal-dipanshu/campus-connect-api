#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore
#
#COPY . ./
#RUN dotnet publish -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#COPY --from=build-env /app/out .
#
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet YourAppName.dll


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY CamppusConnect.API/*.csproj ./CampusConnect.API/
COPY CamppusConnect.Business/*.csproj ./CamppusConnect.Business/
COPY CamppusConnect.Common/*.csproj ./CamppusConnect.Common/
COPY CamppusConnect.DataAccess/*.csproj ./CamppusConnect.DataAccess/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Project.API.dll"]
