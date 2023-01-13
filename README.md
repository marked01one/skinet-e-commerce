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
* MySQL (for storing product and user data)
* Redis (for caching and storing user-generated product baskets)
* Postman
* Visual Studio Code

