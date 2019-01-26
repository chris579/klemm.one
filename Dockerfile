FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

COPY src/ ./
RUN dotnet publish Klemm.One.Server -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/Klemm.One.Server/out .

ENTRYPOINT ["dotnet", "Klemm.One.Server.dll"]