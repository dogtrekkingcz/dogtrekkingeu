DomainName=dogsontrail.eu

cd /dogsontrail_data/certbot/conf/live/${DomainName}/

openssl pkcs12 -export -out ${DomainName}.pfx -inkey privkey.pem -in cert.pem -certfile fullchain.pem -passin pass: -passout pass:
chmod 775 /dogsontrail_data/certbot/conf/live/${DomainName}/${DomainName}.pfx

cp /dogsontrail_data/certbot/conf/archive/dogsontrail.eu/fullchain2.pem /dogsontrail_data/certbot/conf/live/${DomainName}/fullchain.pem
cp /dogsontrail_data/certbot/conf/archive/dogsontrail.eu/privkey2.pem /dogsontrail_data/certbot/conf/live/${DomainName}/privkey.pem

chmod 755 -R /dogsontrail_data/certbot/conf/live/