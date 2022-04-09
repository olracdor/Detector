# Detector

Detector API detects faces in images

## Getting Started

Assuming we've freshly checkout the source, make sure you've installed
already the following tools. (Don't run the commands when you've already 
done it before)

### Install Global Tools

* Install git
    * https://git-scm.com/book/en/v2/Getting-Started-Installing-Git

* Download and install dotnet SDK
    * https://dotnet.microsoft.com/download

* Download and install docker 
    * Windows - https://docs.docker.com/docker-for-windows/install/
    * Ubuntu - https://docs.docker.com/engine/install/ubuntu/
    * Mac - https://docs.docker.com/docker-for-mac/install/

* Clone Detector API 
    * git clone https://github.com/olracdor/Detector.git

**Update the connectionString configuration in appsettings.json**
    
### Build the API

On the root folder, run below commands in terminal/bash

Build the dotnet API 

```bash
dotnet publish -c Release
```

Build the docker image 

```bash
docker build -t  <YOUR CONTAINER REGISTRY NAME>/detector-docker .
```
** container registry sample**

```bash
docker build -t  detector.gcp.io/detector-docker .
```

## Run and Test

Run the docker image locally

```bash
docker run -p <PREFERED PORT>:80 <YOUR CONTAINER REGISTRY NAME>/detector-docker
```

**Sample Command**
```bash
docker run -p 5001:80 detector.gcp.io/detector-docker
```

### Testing the API

**Assuming you're using port 5001** - you can test the newly created docker image using below commands.

Detect faces
```bash
curl --request POST \
  --url http://localhost:5001/api/v1/Detector/Face \
  --header 'content-type: application/json' \
  --data '{
    "Id": 123,
    "ImageBase64": "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQEASABIAAD/4gv4SUNDX1BST0ZJTEUAAQEAAAvoAAAAAAIAAABtbnRyUkdCIFhZWiAH2QADABsAFQAkAB9hY3NwAAAAAAAAAAAAAAAAAAAAAAAAAAEAAAAAAAAAAAAA9tYAAQAAAADTLQAAAAAp+D3er/JVrnhC"
}'
```

**Sample Response**

```json
{
  "Count": 2,
  "Detected": true
}
```