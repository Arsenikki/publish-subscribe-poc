FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Subi/Subi.csproj", "Subi/"]
COPY ["Contracts/", "Contracts/"]
RUN dotnet restore "Subi/Subi.csproj"

COPY Subi/ Subi/.
RUN dotnet publish -c Release -o /app Subi/Subi.csproj 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS publish
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Subi.dll"]