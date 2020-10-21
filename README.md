# DDD-PhoneBook-POC
This repository contains requirements, codes, test and docs for PhoneBook Microservices. It contains phone book microservice and reporting microservice as a poc of some DDD practices and infra implementations.
## Technical Specifications:
* .NET Core 3.1
* ASp.Net Core WebApi as Restful Service
* Postgres as Database 
* EF Core As ORM
* RabbitMQ as message queue
* Masstransit as message broker
* Docker as containerization

## Requirements:
Two microservices which communicates with each other should be designed to create a simple phonebook application.

### PhoneBook Microservice Requirements
#### Person Aggregate Requirements
* Add the person to the phonebook
  1. Person should contain 
      1. PersonId - UUID
      2. Name
      3. Surname
      4. Company Name
* Remove the person from the phonebook
* List the people within the phonebook

#### Contact Aggregate Requirements
* Add the contact info to the person in the phonebook.
  1. Contact should contain 
      1. Contact ID - UUID 
      2. Contact Type
          * Phone Number
          * E-Mail Address
          * Location
      3. Content
* Remove the contact info from the person in the phonebook.
* List the contact details for a selected person

### Reporting Microservice Requirements
#### Location Report Aggregate Requirements
* A report request that holds location statistics
  1. Report should contain 
      1. Report ID - UUID
      1. Location Info
      2. Registered people count in that location
      3. Registered phone number count in that location
      4. Report Request Date
      5. Report Status
          * Requested
          * Preparing
          * Completed
* List the reports
* Get the report details 
