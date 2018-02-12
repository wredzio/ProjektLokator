FROM microsoft/aspnetcore-build:2.0.0


COPY ./ /app  

WORKDIR /app
RUN dotnet restore ProjektLokator.sln

WORKDIR /app/ProjectLocator.Web
RUN dotnet build

WORKDIR /app
EXPOSE 80/tcp

ENTRYPOINT dotnet run
