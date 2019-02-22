# Build Stage
FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /webapi

# restore
COPY corewebapi/corewebapi.csproj ./corewebapi/
RUN dotnet restore corewebapi/corewebapi.csproj

COPY corewebapi.nunit/corewebapi.nunit.csproj ./corewebapi.nunit/
RUN dotnet restore corewebapi.nunit/corewebapi.nunit.csproj

# copy src
COPY . .

# test
ENV TEAMCITY_PROJECT_NAME=fake
RUN dotnet test corewebapi.nunit/corewebapi.nunit.csproj

# publish
RUN dotnet publish corewebapi/corewebapi.csproj -c Release -o /publish

# Runtime Image Stage
FROM microsoft/dotnet:2.2-aspnetcore-runtime 
COPY --from=build-env /publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet", "corewebapi.dll"]