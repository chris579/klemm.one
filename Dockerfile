FROM microsoft/dotnet:3.0.100-preview2-sdk-alpine AS build-env
WORKDIR /app

COPY src/ ./
RUN dotnet publish Klemm.One/Klemm.One.Server -c Release -o out

# Build runtime image
FROM microsoft/dotnet:3.0.0-preview2-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "Klemm.One.Server.dll"]