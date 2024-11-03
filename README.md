# gcp-cloud-run

Command:

cd src\Web.Api
docker build -t my-app:v1 .
docker run -p 8080:8080 -p 8081:8081 my-app:v1