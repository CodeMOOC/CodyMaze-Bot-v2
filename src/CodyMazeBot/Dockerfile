# ---
# First stage (build)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o out

# ---
# Second stage (execution)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app
COPY --from=build /app/out ./

ENV Logging__Console__FormatterName=

ENTRYPOINT ["dotnet", "CodyMazeBot.dll"]
