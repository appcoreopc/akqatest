# Build it 
# docker build -t dotnetapp-prod  .

# Run it
# docker run -d -p 5050:5050 dotnetapp-prod

# Browse it 
# http://192.168.99.100:5050/hello/index

FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -r linux-x64 -o out

# build runtime image
FROM microsoft/dotnet:2.0-runtime 
WORKDIR /app
COPY --from=build-env /app/out ./

ENTRYPOINT ["dotnet", "ConnectCD-NetCoreWebApi.dll"]