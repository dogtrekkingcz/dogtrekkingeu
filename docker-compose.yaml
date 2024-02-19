version: '3.5'

services:
  # docker compose run --rm  certbot certonly --webroot --webroot-path /var/www/certbot/ -d petsontrail.eu
  certbot:
    image: certbot/certbot:latest
    volumes:
      - /petsontrail_data/data_certbot/www/:/var/www/certbot/:rw
      - /petsontrail_data/data_certbot/conf/:/etc/letsencrypt/:rw
    networks:
      - frontend
      - backend

  petsontrail_grpc:
    container_name: PetsOnTrail.gRPC
    build:
      context: .
      dockerfile: API.GRPCService/Dockerfile
    ports:
      - 4080:80
      - 4443:443
    environment:
      - ASPNETCORE_URLS=https://+:443;http://+:80
      - ASPNETCORE_Kestrel__Certificates__Default__Password=
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/app/petsontrail.eu.pfx
    volumes:
      - /petsontrail_data/certbot/conf/live/petsontrail.eu/petsontrail.eu.pfx:/app/petsontrail.eu.pfx:ro
    networks:
      - backend
      - frontend
      
  petsontrail_webapi:
    container_name: PetsOnTrail.WebApi
    build:
      context: .
      dockerfile: API.WebApiService/Dockerfile
    ports:
      - 3080:80
      - 3443:443
    environment:
      - ASPNETCORE_URLS=https://+:443;http://+:80
      - ASPNETCORE_Kestrel__Certificates__Default__Password=
      - ASPNETCORE_Kestrel__Certificates__Default__Path=/app/petsontrail.eu.pfx
    volumes:
      - /petsontrail_data/certbot/conf/live/petsontrail.eu/petsontrail.eu.pfx:/app/petsontrail.eu.pfx:ro
    networks:
      - frontend
      - backend
      
  petsontrail_app: 
    container_name: PetsOnTrail.App
    build:
      context: .
      dockerfile: frontend/PetsOnTrailApp/Dockerfile
    ports:
      - 443:443
      - 80:80
    networks:
      - frontend
      - backend
    volumes:
      - /petsontrail_data/certbot/conf/live/petsontrail.eu:/etc/nginx/ssl/live/petsontrail.eu:ro
      - /petsontrail_data/PetsOnTrail.App/appsettings.json:/usr/share/nginx/html/appsettings.json
      
  dtdata_db:
    image: mongo:latest
    container_name: PetsOnTrail.DB
    environment:
      MONGO_INITDB_ROOT_USERNAME: root
      MONGO_INITDB_ROOT_PASSWORD: password
      MONGO_INITDB_DATABASE: PetsOnTrailDb
    ports:
      - 27017:27017
    volumes:
      - /petsontrail_data/mongo_db:/data/db
    networks:
      - backend
    restart: always
   
  postgres:
    image: postgres
    container_name: PetsOnTrail.KeyCloakDB
    environment:
      POSTGRES_DB: keycl0ak
      POSTGRES_USER: keycl0ak
      POSTGRES_PASSWORD: password
    ports:
      - 5431:5431
    volumes:
      - /petsontrail_data/postgres_db:/var/lib/postgresql/data
    networks:
      - backend
    restart: always

  keycloak:
    image: jboss/keycloak
    container_name: PetsOnTrail.KeyCloak
    command: 
      - "-b 0.0.0.0 -Dkeycloak.import=/opt/jboss/keycloak/imports/realm-export.json"
    environment:
      DB_VENDOR: POSTGRES
      DB_ADDR: postgres
      DB_DATABASE: keycl0ak
      DB_USER: keycl0ak
      DB_PASSWORD: password
      KEYCLOAK_USER: administrat0r
      KEYCLOAK_PASSWORD: asc88a8c0ssssqs
    ports:
      - 8443:8443
    volumes:
      - /petsontrail_data/keycloak/imports:/opt/jboss/keycloak/imports
      - /petsontrail_data/certbot/conf/live/petsontrail.eu/fullchain.pem:/etc/x509/https/tls.crt
      - /petsontrail_data/certbot/conf/live/petsontrail.eu/privkey.pem:/etc/x509/https/tls.key
    depends_on:
      - postgres
    networks:
      - frontend
      - backend
    restart: always
      
  mail:
    image: bytemark/smtp
    restart: always

  # MessageQueue not necessary yet
  #mq:
  #  image: rabbitmq:management
  #  container_name: message-queue
  #  ports:
  #    - 15672:15672
  #    - 5672:5672
  #    - 5671:5671
  #  volumes:
  #    - data_mq:/var/lib/rabbitmq
      
volumes:
  data_petsontrail_db:
  data_mq:
  postgres_data:
      driver: local

networks:
  frontend:
    driver: bridge
  backend:
    driver: bridge
    
