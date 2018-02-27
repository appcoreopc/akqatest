# akqatest

## Web App ## 

This application uses Angular5/Ngrx-effect/Ngrx-Store as the web front. Ngrx-store is similiar to redux but reactive way of doing t. We uses it to dispatch status which in turn display makes the app 'fluent'. 

To run please, goto WebApp\Akqa directory and make sure you have install.

a) ng-cli 
b) execute npm install to get all the dependencies
c) finally run ng serve 
d) Browse  http:localhost:4200

You should be able to see the username and amount render as you type. 

Proceed to save by clicking on "save". 

Might have to do separately :- npm install @angular-devkit/core --save-dev - in case you ran into some trouble. 

## Unit Test ##
To run unit test, please run ng test or npm test 

## WebApi - This project consists ##

a) Dataservices which uses - EF Core 1.2.x 
b) Database proeject deployment to target 
c) WebApi - which includes swagger ui - providing documentation and easy testing of web service. You can access swagger ui by browsing : http://localhost:5050/swagger/

WebApi conforms to Http Response in all its responses for example returns 201 for resource creation. 

It also supports logging to console -> Please refer to 12 tenants of microservice for more info. 

d) Test project uses NSubstitute as a mocking framework to mock EF Core db context dependencies. 






