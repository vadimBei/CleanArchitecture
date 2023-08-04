# CleanArchitecture

## Utils
    0.1 Utils

## Entities
	1.1 Entities
	1.2 DomainServices.Implementations
	1.3 DomainServices.Interfaces

## Infrastructure interfaces
	2.1 DataAccess.Interfaces
	2.2 Email.Interfaces
	2.3 WebApp.Interfaces

## UseCases
	3.1 ApplicationServices.Implementations (Common services which can be used into different Use Cases)
	3.2 ApplicationServices.Interfaces
	3.3 UseCases (CQRS commands and queries)

## Infrastructure inmplementations
	4.1 DataAccess.MsSQL: ORM, SQL scripts, DB init, Migrations
	4.2 Email.MailHandler
	4.3 Dependencies on a Web Engine


MSSQL db was used into example 

Hangfire library was used for background jobs