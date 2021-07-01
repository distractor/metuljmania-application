# Metuljmania API
API for paragliding application forms.

## Compile and run

Obtain the `appsettings.json`.

## Running docker
First go to `root/` and run

```sh
docker build -t glista/dockerapi .
```

after the image is build run docker image with

```sh
docker run -p 8080:80 glista/dockerapi
```
