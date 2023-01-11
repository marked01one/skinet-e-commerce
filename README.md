# SkiNET E-Commerce Store

**CAUTION:** This is only a proof of concept application, in order to practice full-stack development with .NET Core and Angular. 

***DO NOT ACTUALLY BUY FROM THE STORE. WE DO NOT OFFER ANY PRODUCTS OR SERVICES.***

## Getting Started

To fire up both the API and client servers, use this command in the project's root directory to call the associated Python script that will execute both.
```
C:\...\skinet-e-commerce> python dev.py
```
Alternatively, you can launch the API and client servers on two separate terminals as follows:

### API
```
C:\...\skinet-e-commerce> cd api
C:\...\skinet-e-commerce\API> dotnet run
```

### Client
```
C:\...\skinet-e-commerce> cd client
C:\...\skinet-e-commerce\API> ng serve
```

### Redis containers
```
C:\...\skinet-e-commerce> docker start skinet-e-commerce-redis-commander-1
C:\...\skinet-e-commerce\API> docker start skinet-e-commerce-redis-1
```

## API Documentation

For detailed documentation on the API itself, open `https://localhost:5001/swagger` after activating the API server.

## Technologies Used

### 👨‍💻 Programming & Markup Languages:
* C#
* TypeScript
* SCSS
* HTML
* Markdown

### 🧰 Frameworks, Databases & Other Tools:
* .NET
* AngularJS
* Bootstrap
* SQLite (development only)
* MySQL (will be deployed)
* Redis
* Postman
* Visual Studio Code

