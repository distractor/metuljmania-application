# Metuljmania API
API for paragliding application forms.

## Compile and run

Obtain the `appsettings.json`.

## Running docker
First go to `root/` and run

```sh
docker build -t metuljmania/dockerapi .
```

after the image is build run docker image with

```sh
docker run --name backend --mount type=bind,source=/home/mjancic/Documents/Uploads,target=/Uploads -p 8081:80 metuljmania/dockerapi
```
