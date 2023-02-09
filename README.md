# Publish-Subscribe PoC 

## Overview

Some notable tools utilized in this PoC:

- k3s - Very lightweight Kubernetes distribution running in Docker
- .NET 6/7 Minimal APIs
- RabbitMQ - Message queue
- MassTransit - Abstraction for messaging with RabbitMQ
- KEDA - Kubernetes autoscaler
- k6 - Load testing tooling used to stress test the system

## Installation

1. Create the cluster:
    ```
    k3d cluster create -c local-setup/k3d.config.yaml
    ```

2. Build the `pubi` and `subi` services:

    ```
    docker-compose build
    ```

3. Import the images from local Docker to the k3d cluster:

    ```
    k3d image import pubisubi_subi pubisubi_pubi -c local-k3s
    ```

4. Install rabbitmq operator

5. Deploy `pubi` and `subi` services:

    ```
    kubectl apply -f .\local-setup\subi\ -f .\local-setup\pubi\
    ```

## API Load Testing

```
docker-compose up -d influxdb grafana
```

```
docker-compose run -v $PWD/scripts:/scripts k6 run /scripts/work-script.js
```
