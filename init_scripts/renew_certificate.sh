DomainName=petsontrail.eu

cd /petsontrail_data/certbot/conf/live/${DomainName}/

openssl pkcs12 -export -out ${DomainName}.pfx -inkey privkey.pem -in cert.pem -certfile fullchain.pem -passin pass: -passout pass:
chmod 775 /petsontrail_data/certbot/conf/live/${DomainName}/${DomainName}.pfx

cp /petsontrail_data/certbot/conf/archive/petsontrail.eu/fullchain2.pem /petsontrail_data/certbot/conf/live/${DomainName}/fullchain.pem
cp /petsontrail_data/certbot/conf/archive/petsontrail.eu/privkey2.pem /petsontrail_data/certbot/conf/live/${DomainName}/privkey.pem

chmod 755 -R /dogsontrail_data/certbot/conf/live/