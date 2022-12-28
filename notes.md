# SkiNET E-Commerce
This markdown contains notes for the proof-of-concept e-commerce project

## API - Basics


## API - Architecture


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

## Client - Angular Setup


## Client - Angular Basics


## Client - Building the UI