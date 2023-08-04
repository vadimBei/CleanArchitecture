# CleanArchitecture

## 0 Utils
	### Utils

## 1 Entities
	### Entities
	### DomainServices.Implementations
	### DomainServices.Interfaces

## 2 Infrastructure interfaces
	### DataAccess.Interfaces
	### Email.Interfaces
	### WebApp.Interfaces

## 3 UseCases
	### ApplicationServices.Implementations (Common services which can be used into different Use Cases)
	### ApplicationServices.Interfaces
	### UseCases

## 4  Infrastructure inmplementations
	### DataAccess.MsSQL: ORM, SQL scripts, DB init, Migrations
	### Email.MailHandler
	### Dependencies on a Web Engine


MSSQL db was used into example 

Hangfire library was used for background jobs