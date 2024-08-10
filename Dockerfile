
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App
COPY . ./
RUN dotnet publish projetoPizza/projetoPizza.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Definir a variável como argumento
ARG DB_HOST
ARG DB_USER
ARG DB_PASSWORD
ARG DB_PORT
ARG DB_NAME

# Definir a variável de ambiente
ENV DB_HOST=${DB_HOST}
ENV DB_USER=${DB_USER}
ENV DB_PASSWORD=${DB_PASSWORD}
ENV DB_PORT=${DB_PORT}
ENV DB_NAME=${DB_NAME}

WORKDIR /App
COPY --from=build-env /App/out .

ENTRYPOINT ["dotnet", "projetoPizza.dll"]