# SkiNET E-Commerce
This markdown contains notes for the proof-of-concept e-commerce project

## API - Basics
* Entities
* Configurations
* DbContext
* 

## API - Unit of Work

#### Current - Separate Db Repositorys
<table>
  <tr style="text-align: center;">
    <td>Pros</td>
    <td>Cons</td>
  </tr>
  <tr>
    <td>
      <ul>
        <li>No need for additional Repos</li>
        <li>Specification pattern is clear & flexible</li>
      </ul>
    </td>
    <td>
      <ul>
        <li>Cpuld end up with partial updates</li>
        <li>INjecting 3 Repos into a single controller!</li>
        <li>Each repository 'owns' its own DbContext instance</li>
      </ul>
    </td>
  </tr>
</table>

### Future - Unit of Work
* Unit of Work (UoW) creates only one DbContext instance for all
* UoW creates repositories as needed
* All repos share a DbContext
* **Example:**
```csharp
using UoW;

UoW.Repository<Product>.Add(product);
UoW.Repository<ProductBrand>.Add(productBrand);

UoW.Conplete();
```


## API - Generic Repository


## API - Error Handling


## API - Paging, Filtering, Sorting & Searching
### Pagination
* Only return a small amount of query results back at any one time
* Mainly for performance reasons.
* Parameters example: `/api/products?pageNumber=2&pageSize=5`
* Page size should be limited (i.e., 16 items per page)
* Always page results.

### Deferred Execution
* Deferring executing on query until a query of desired items is created
* Query commands are stored in a variable
* `IQueryable<T>` creates an expression tree
* Execution:
  * `ToList()` `ToArray()` `ToDictionary()`
  * `Count()` or other singleton queries


## API - Basket
* Set up & configure Redis for saving customer basket in server memory
* Create Basket repository & controller

## API - Identity
* ASP.NET Identity
  * Issue tokens to client, which can be used to authenticate against the methods & classes inside our API

* Context boundary
* Using the `UserManager` & `SignInManager`
* Extension methods
* JSON Web Tokens (JWTs)


### Redis
* Typically use for caching; very fast & persistent in-memory storage
* Supports strings, hashes, sets,...
* Key / Value store
* Stored in-memory and not in hard drives --> very fast
* Persist data by using snapshots every minute
* Data can be given an expiry date


## Client - Angular Setup

### Observables
* A sequence of items that arrive asynchronously
* Typically in JS frameworks, "promises" were used instead of observables to halt script execution.

<table>
  <tr style="text-align: center;">
    <td>Promises</td>
    <td>Observables</td>
  </tr>
  <tr>
    <td>
      <ul>
        <li>One pipeline</li>
        <li>Used w/ async data return</li>
        <li>Non-cancellable</li>
      </ul>
    </td>
    <td>
      <ul>
        <li>Cancellable</li>
        <li>Multiple pipelines</li>
        <li>Array-like operations (map, filter,...)</li>
        <li>Created from other sources like event</li>
        <li>Can be subscribed to (listening to result)</li>
      </ul>
    </td>
  </tr>
</table>

### HTTP, Obersevables and RxJS
1. HTTP `GET` request from `ShopService`
2. Receive Observable --> cast to `Products` array
3. Subscribe to Observable from component --> Initiate API requests and retrieve data
4. Assign `Products` array to local variable to use on components template

### RxJS
* JS reactive exntensions
* Utility library for working with observables
* Uses `pipe()` method to chain RxJS operators together

### TypeScript

<table>
  <tr style="text-align: center;">
    <td>Advantages</td>
    <td>Drawbacks</td>
  </tr>
  <tr>
    <td>
      <ul>
        <li>Strong Typing</li>
        <li>Object-oriented</li>
        <li>Better Intellisense & autocomplete</li>
        <li>Access Modifiers (i.e., public private)</li>
        <li>Future JS features, i.e. decorators</li>
        <li>Catches mistakes & development</li>
        <li>Third-party support</li>
        <li>Easy if you already know JS</li>
      </ul>
    </td>
    <td>
      <ul>
        <li>More upfront code</li>
        <li>Not all third-parties supports TS</li>
        <li>TS Strict Mode requires types for everything</li>
      </ul>
    </td>
  </tr>
</table>


## Client - Routing

### Routing
* Single-page applications (SPA) need routers to route users to other components, instead of another page
* Angular router will load a component when route is activated
* `<RouterOutlet>`


## Client - Error Handling
* Https interceptors
* Toast notifications

## Client - Angular Forms

### `FormsModule`
* HTML Template-driven:
  * Easy to use
  * Good for simple scenarios
  * 2-way binding (uses ngModel)
  * Minimal component code
  * Automatic tracking by Angular
  * Testing is hard

### `ReactiveFormsModule`
* Reactive driven using Observables:
  * More flexible
  * Good for any scenario
  * Immutable data model
  * More component code / less markup
  * Reactive transformations (debounce) - good for async validation
  * Testing is easier

Building blocks of forms: 
* `FormControl` 
  * Value
  * Validation status
  * User interactions
  * Events

* `FormGroup` 
* `FormArray`