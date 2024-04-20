FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /
COPY BinaryTreeService.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /dist

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /dist
COPY --from=build /dist .
ENTRYPOINT ["dotnet", "BinaryTreeService.dll"]