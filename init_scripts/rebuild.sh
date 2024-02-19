rm -rf ./petsontrail.eu
git clone https://github.com/kotesovecr/petsontrail.eu.git

cd petsontrail.eu

docker stop $(docker ps -aq)
docker rmi -f $(docker images -aq)

rm ./docker-compose.yaml
git pull
git checkout -f

cp /petsontrail_data/PetsOnTrail.App/appsettings.json frontend/PetsOnTrailApp/wwwroot/
cp ./docker-compose.production.yaml ./docker-compose.yaml
docker-compose down --remove-orphans
docker-compose up --build

