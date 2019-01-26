FROM microsoft/dotnet:2.2-sdk-alpine AS build-dev
COPY . /dist
WORKDIR /dist
RUN ["apk", "add", "--update", "npm"]
RUN ["npm", "--version"]
RUN ["dotnet", "restore"]
RUN ["dotnet", "publish", "-c", "Release", "-o", "out"]
RUN dotnet publish -c Release -o /out

FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
COPY --from=build-dev out .
ENTRYPOINT ["dotnet", "entrusted.web.dll"]