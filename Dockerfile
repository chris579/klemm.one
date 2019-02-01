FROM microsoft/dotnet:3.0-sdk-alpine AS build-env
WORKDIR /app

COPY src/ ./
RUN dotnet publish Klemm.One/Klemm.One.Server -c Release -o out

# Build runtime image
FROM microsoft/dotnet:3.0-runtime-alpine
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Klemm.One.Server.dll"]