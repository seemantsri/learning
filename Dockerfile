FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["TestWebApi.csproj", "./"]
RUN dotnet restore "TestWebApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TestWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestWebApi.dll"]
