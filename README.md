# EmployeeWebAPIService

1:
Database Folder has the Database.mdf file which need to be setup in ssms

2:
change connection string in the webconfig 

3:
Update the nuget packages and run the application 

4:
http://localhost:50751/swagger will load the API with Swagger UI.

Solution :

1:Dapper is used to connect with Database(ORM connection) 

2:Dependency injection is used to interact between each layer. 

3:Autofac is used to impliment DI 

4:Swashuckle is used to implement the Swagger documentation 

5:NUnit is used to do unit testing

6: TestResults : Has the screen shot of Unit testing using swagger .

7: Axo Cover Code Coverage Tool Integration

![Alt text](EmployeeWebApi/TestResults/axo_screenshot.jpg?raw=true "Axo Cover Code Coverage Tool")

Find the tool here :https://github.com/axodox/AxoCover/releases

8:Nunit Test Cases 

![Alt text](EmployeeWebApi/TestResults/TestExplorer.jpg?raw=true "N Unit test Cases ")

