# Frontpoint Individuals App
Built on Angular v18, .net 8, and sqlite.

Angular 18 has a dependency of node.js versions: v18.19.0 and newer ([see](https://angular.dev/reference/versions)).

## Start up
The solution is configured as a multiple start project, so just hitting start in Visual Studio should bring everything up. The first time may take longer to launch since it will create the db file and seed data. Consequently, the ui may need to be refreshed to show records (api retry will likely timeout).

## Architecture
The application adhears to [clean architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture).

For example, given a client makes a get request, it will route to the controller. A [query](https://deviq.com/design-patterns/cqrs-pattern) will be sent using a [mediator](https://refactoring.guru/design-patterns/mediator). This command will be received in the Use Cases layer, which ultimately is responsible for interfacing with abstractions that interact with infrastructure (eg [repository](https://deviq.com/design-patterns/repository-pattern)).
![cleanarchitecture](https://github.com/jabranner1/frontpoint/assets/126697836/b22a3c7a-c571-4faa-83e8-90db13e46e85)

## UI

The UI has 5 main functions: view all individuals, create an individual, view an individual, edit an individual, and delete an individual.

Main dashboard
![image](https://github.com/jabranner1/frontpoint/assets/126697836/69007a8a-5972-4bc6-bb4a-63c2407bbc03)

Create Individual
![image](https://github.com/jabranner1/frontpoint/assets/126697836/c0ed32a9-e3cf-4d08-8c8b-13a23f51565b)

View Individual
![image](https://github.com/jabranner1/frontpoint/assets/126697836/7cd69bd9-743c-4fa5-8919-e08929084924)

Edit Individual
![image](https://github.com/jabranner1/frontpoint/assets/126697836/6cb22a00-0a34-47d9-8289-9eee25fa4988)

Delete Individual
![image](https://github.com/jabranner1/frontpoint/assets/126697836/d40e3010-59d5-433c-91e0-9ccc5c58e5f4)

## Tests
The following levels of tests are included:
 - .net unit tests
 - .net integration tests
 - ui unit tests

Future testing opportunity:
 - .net functional tests
 - additional ui unit tests
 - e2e tests
