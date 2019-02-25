# Build Stage
FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /corewebapi

# restore
COPY corewebapi/corewebapi.csproj ./corewebapi/
RUN dotnet restore corewebapi/corewebapi.csproj

#COPY corewebapi.teamcitylogger/corewebapi.teamcitylogger.csproj ./corewebapi.teamcitylogger/
#RUN dotnet restore corewebapi.teamcitylogger/corewebapi.teamcitylogger.csproj

COPY corewebapi.nunit/corewebapi.nunit.csproj ./corewebapi.nunit/
RUN dotnet restore corewebapi.nunit/corewebapi.nunit.csproj


#RUN dotnet build corewebapi.teamcitylogger/corewebapi.teamcitylogger.csproj -c Release

#RUN cp corewebapi.teamcitylogger/bin/Release/netcoreapp2.2/corewebapi.teamcitylogger.dll /usr/share/dotnet/sdk/2.2.104/Extensions/
#RUN chmod 777 /usr/share/dotnet/sdk/2.2.104/Extensions/corewebapi.teamcitylogger.dll

#RUN ls /usr/share/dotnet/sdk/2.2.104/Extensions/
#COPY corewebapi.nunit/corewebapi.nunit.csproj ./corewebapi.nunit/
#RUN dotnet restore corewebapi.nunit/corewebapi.nunit.csproj


# copy src
COPY . .

# test
ENV TEAMCITY_PROJECT_NAME=fake
RUN dotnet test corewebapi.nunit/corewebapi.nunit.csproj 
# Run the tests:

# publish
RUN dotnet publish corewebapi/corewebapi.csproj -c Release -o /publish

# Runtime Image Stage
FROM microsoft/dotnet:2.2-aspnetcore-runtime 
COPY --from=build-env /publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet", "corewebapi.dll"]