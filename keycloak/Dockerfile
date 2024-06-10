FROM quay.io/keycloak/keycloak:24.0.5 as builder
# Latest from version 25 - has any problem with defining hostname when starting
# FROM quay.io/keycloak/keycloak:latest as builder


# Enable health and metrics support
ENV KC_HEALTH_ENABLED=true
ENV KC_METRICS_ENABLED=true

# Configure a database vendor
ENV KC_DB=postgres

WORKDIR /opt/keycloak
RUN /opt/keycloak/bin/kc.sh build

FROM quay.io/keycloak/keycloak:latest
COPY --from=builder /opt/keycloak/ /opt/keycloak/

# change these values to point to a running postgres instance
ENV KC_DB=postgres
ENV KC_DB_URL: jdbc:postgresql://keycloakdb:5432/keycl0ak
ENV KC_DB_USERNAME: keycl0ak
ENV KC_DB_PASSWORD: password
ENV KC_HOSTNAME_URL=https://petsontrail.eu:8443/
ENTRYPOINT ["/opt/keycloak/bin/kc.sh"]