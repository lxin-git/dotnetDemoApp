
> working on progress

Typical steps:

docker run -d --hostname my-rabbit --name some-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management
RabbitMQ management UI: http://localhost:15672 (user/pass: guest/guest)


Copy all source code, including DemoApp.csproj, to the new host.
Download and install .NET 8 SDK or later if not already installed.
```
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

sample tests:
```
curl -X POST http://localhost:5000/items -H "Content-Type: application/json" -d "{\"name\": \"Sample Item2\"}"
curl http://localhost:5000/items
curl -X POST http://localhost:5000/items/send -H "Content-Type: application/json" -d "\"message4\""
```


dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package RabbitMQ.Client
dotnet restore
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
