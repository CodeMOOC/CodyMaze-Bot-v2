# ---
# First stage (build)
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
WORKDIR /app
RUN dotnet publish -c Release -o out

# ---
# Second stage (execution)
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime

# Add libgdiplus for System.Drawing.Common support
RUN apt-get update && apt-get install -y libgdiplus

WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "CodyMazeBot.dll"]
