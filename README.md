# WebApp_UserManagement
UserManagement Application with docker.

Navigate to the directory where the docker-compose.yml file is located, then open CMD and run the following command:
docker-compose up --build

After the image is created, open CMD in the same directory and run the migration command.
docker-compose run --rm migrations


Check running containers
docker ps

Stop all the conatiners 
for /F "tokens=*" %i IN ('docker ps -q') DO docker stop %i
 
Push Application in Docker Hub 
docker tag webapplicationtest-webapplicationtest userName/webapplicationtest:latest
docker push userName/webapplicationtest:latest 