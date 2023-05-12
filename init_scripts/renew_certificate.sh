SecretName=$(date +%Y-%m-%d)
OldSecretName=$(date --date yesterday +%Y-%m-%d)
DomainName=dogsontrail.eu
AppName=DogsOnTrailApp

cd /etc/letsencrypt/live/dogsontrail.eu/

openssl pkcs12 -export -out ${DomainName}.pfx -inkey privkey.pem -in cert.pem -certfile fullchain.pem -passin pass: -passout pass:

sudo docker secret create $SecretName /etc/letsencrypt/archive/$DomainName/${DomainName}.pfx

sudo docker service update --secret-add $SecretName --secret-rm $OldSecretName --env-add Kestrel__Certificates__Default__Path=/run/secrets/$SecretName $AppName
sudo docker service update --secret-add $SecretName --secret-rm $OldSecretName --env-add Kestrel__Certificates__Default__Path=/run/secrets/$SecretName dogsontrail_grpc
sudo docker service update --secret-add $SecretName --secret-rm $OldSecretName --env-add Kestrel__Certificates__Default__Path=/run/secrets/$SecretName dogsontrail_webapi

sudo docker secret rm $OldSecretName