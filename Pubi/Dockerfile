FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Pubi/Pubi.csproj", "Pubi/"]
COPY ["Contracts/", "Contracts/"]
RUN dotnet restore "Pubi/Pubi.csproj"

COPY Pubi/ Pubi/.
RUN dotnet publish -c Release -o /app Pubi/Pubi.csproj 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS publish
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Pubi.dll"]