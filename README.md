# README 


## Setup

https://stackoverflow.com/questions/56824859/how-to-run-dockered-asp-net-core-app-generated-by-visual-studio-2019-on-linux-p
```
$ mkdir conf.d
$ dotnet dev-certs https --clean
$ dotnet dev-certs https -ep ./conf.d/https/dev_cert.pfx -p madison
$ dotnet dev-certs https --trust
```
## Run

```
$ docker-compose down # Down any previous setup
$ docker-compose up --build -d # Build and run containers
$ docker-compose ps # Check status of api..make sure its "up"

```