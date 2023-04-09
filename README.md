# Converting a Monolithic Application into Microservices in ASP.NET Core

Breaking out a microservice from an existing monolithic demo application

## Producer project

1. Install **RabbitMQ Docker** image
```
docker run -d --hostname my-rabbit  --name ecomm-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```

2. Go to http://localhost:15672 and give credentials guest / guest

<img src="/pictures/rabbitmq.png" title="rabbitmq on creation"  width="400">
<img src="/pictures/rabbitmq2.png" title="rabbitmq on creation"  width="800">
