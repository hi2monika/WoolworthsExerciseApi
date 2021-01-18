# Woolworths API Technical Test Solution

## Architecture
  - Clean Architecture
    - Core -- Contain Bussiness Logic, Domain Model
    - Infrastructure -- DataSource
    - Presentation -- API Controller
  - CQRS (Command Query Responsibility Segregation)
    - Provides code separation for complex structure, where each API endpoint require more handling, in terms of validation and service, and optimization.
    - MediatorR.
 - Automapper(object mapping)
 - Refit (automatic type-safe REST library)
 - Unit test (Xunit)
 
 ## Deployed At:
 https://woolworthstest.azurewebsites.net/swagger/index.html
 
## TODO :
- More Validation
- Custome Exception handling 
- More unit test.

Note: The sole purpose of the design is to demonstrate that CQRS can handle complex API. However other simpler patterns can be used in simpler use cases.
