# akqatest

## Web App ## 

This application uses Angular5/Ngrx-effect/Ngrx-Store as the web front. 
To run please, goto WebApp\Akqa directory and make sure you have install 

a) ng-cli 
b) npm install to get all the dependencies
c) finally run ng serve and browse  http:localhost:4200 

You should be able to see the username and amount render as you type. 

Proceed to save by clicking on "save". 

Might have to do separately :- npm install @angular-devkit/core --save-dev - in case you ran into some trouble. 

## Unit Test ##
To run unit test, please run ng test or npm test 

## WebApi - This project consists ##

a) Dataservices which uses - EF Core 1.2.x 
b) Database proeject deployment to target 
c - WebApi - which includes swagger ui - providing documentation and easy testing of web service.  It conforms to Http Response 
in all its responses for example returns 201 for resource creation. 

It also supports logging to console -> Please refer to 12 tenants of microservice for more info. 

d - Test project uses NSubstitute as a mocking framework to mock EF Core db context dependencies. 




