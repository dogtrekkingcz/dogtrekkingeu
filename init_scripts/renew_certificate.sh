SecretName=$(date +%Y-%m-%d)
OldSecretName=$(date --date yesterday +%Y-%m-%d)
DomainName=dogsontrail.eu
AppName=DogsOnTrailApp

cd /dogsontrail_data/certbot/conf/live/dogsontrail.eu/

openssl pkcs12 -export -out ${DomainName}.pfx -inkey privkey.pem -in cert.pem -certfile fullchain.pem -passin pass: -passout pass:
chmod 775 /dogsontrail_data/certbot/conf/live/dogsontrail.eu/dogsontrail.eu.pfx

sudo docker secret create $SecretName /dogsontrail_data/certbot/conf/live/dogsontrail.eu/${DomainName}.pfx

sudo docker service update --secret-add $SecretName --secret-rm $OldSecretName --env-add Kestrel__Certificates__Default__Path=/run/secrets/$SecretName $AppName
sudo docker service update --secret-add $SecretName --secret-rm $OldSecretName --env-add Kestrel__Certificates__Default__Path=/run/secrets/$SecretName DogsOnTrail.gRPC
sudo docker service update --secret-add $SecretName --secret-rm $OldSecretName --env-add Kestrel__Certificates__Default__Path=/run/secrets/$SecretName DogsOnTrail.WebApi
sudo docker service update --secret-add $SecretName --secret-rm $OldSecretName --env-add Kestrel__Certificates__Default__Path=/run/secrets/$SecretName DogsOnTrail.App

sudo docker secret rm $OldSecretName