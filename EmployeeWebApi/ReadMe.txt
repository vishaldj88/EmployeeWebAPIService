1:
Database Folder has the Database.mdf file which need to be setup in ssms 
2:
change connection string in the webconfig 
3:
Update the nuget packages and run the application 

4:
http://localhost:50751/swagger will load the API with Swagger UI.

Solution :
1:Each Layer talks to other layer via Dependency injection . 
2:Autofac is used to impliment DI 
3:Swashuckle is used to implement the Swagger documentation 
4:NUnit is used to do unit testing

TestResults :
Has the screen shot of Unit testing using swagger .



