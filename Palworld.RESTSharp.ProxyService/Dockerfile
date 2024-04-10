version: '3'
services:
  webapp:
    image: your-app-image
    environment:
      - PalworldRESTSharpProxyConfig__ServerRESTUrl=http://example.com
      - PalworldRESTSharpProxyConfig__PalworldServerAdminPass=secret
      - ASPNETCORE_URLS=https://+:7135
    ports:
      - "7135:7135"