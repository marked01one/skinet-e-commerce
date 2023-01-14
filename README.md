# SkiNET E-Commerce Store

**CAUTION:** This is only a proof of concept application, in order to practice full-stack development with .NET Core and Angular. 

***DO NOT ACTUALLY BUY FROM THE STORE. WE DO NOT OFFER ANY PRODUCTS OR SERVICES.***

## Getting Started

To activate, API, client, and Redis container servers, run this command in the project's root directory:
```
python dev.py run_all
```
Alternatively, you can launch the API and client servers on separately as follows:
* API: `python dev.py api`
* Client: `python dev.py client`
* Redis containers: `python dev.py redis`

**NOTE:** Download [Docker Desktop](https://www.docker.com/products/docker-desktop/) before activate the Redis containers 

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
* [.NET](https://dotnet.microsoft.com/en-us/)
* [AngularJS](https://angular.io)
* [Bootstrap](https://getbootstrap.com/docs/4.6/getting-started/introduction/)
* [SQLite](https://sqlite.com/index.html) <sup id="a1">[1](#f1)</sup>
* [MySQL](http://mysql.com) <sup id="a2">[2](#f2)</sup>
* [Redis](https://redis.io) <sup id="a3">[2](#f3)</sup>
* [Docker](https://www.docker.com/products/docker-desktop/)
* [Postman](https://www.postman.com)
* [Visual Studio Code](https://code.visualstudio.com)

## Footnotes

<h6>

  <a id="#f1">1.</a> SQLite is used during development only [↩](#a1) 

  <a id="#f2">2.</a> MySQL is used for storing product and user data during deployment [↩](#a2)

  <a id="#f3">3.</a> Redis is used for caching and storing user-generated product baskets [↩](#a3)
</h6>