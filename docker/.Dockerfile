FROM microsoft/dotnet:2.1-sdk
COPY ../App/TopTrumps/TopTrumps.WebApp .
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 80/tcp
