# CondingTestWebAPI

This project is created with .NET 8.0 and Visual Studio 2022.

## TestWebAPI

 This is web api backend project which has API to save the firstname and lastname to `UserData.json`. It will create a new file if not exists already and if file already exists it will add new records to it in a new line.

## GlobalExceptionHandler

GlobalExceptionHandler is global error handler to catch exception and bad requests which implements the .NET 8.0  `IExceptionHandler` , so we no longer need to handle global exceptions in a middleware since ASP.NET Core brought middleware.

## Services

Project uses services injected using dependecy injection to build loosly coupled and unit testable controller. IUserService is being injected to UserController which saves the user to simple file in json format.

## CORS Policy

In order to angular app call the web api and getting CORS error in browser a custom CORS policy is added in  `Program.cs` file.

## TestAPI.Test 

This project contains basic unit tests for UserController to test the valid and invlid requests. It uses Moq library to fake the IUserService in unit test. 


