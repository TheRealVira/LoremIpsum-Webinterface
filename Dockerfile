FROM microsoft/dotnet:2.1-aspnetcore-runtime-stretch-slim AS base

# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_6.x | bash - && \
    apt-get install -y build-essential nodejs
# End setup
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:sdk AS build
WORKDIR /src
COPY LoremIpsum.csproj ./
RUN apt-get update && apt-get install -y libcurl3
RUN dotnet restore LoremIpsum.csproj
COPY . .
RUN dotnet build "LoremIpsum.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoremIpsum.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoremIpsum.dll"]