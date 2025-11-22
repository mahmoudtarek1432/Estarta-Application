Hello Estarta 

This is my solution for the task you guys sent me, thank you for inviting me

The project is using clean architecture for maintaining the application's layers

DDD is used to handle the business logic

some patterns were used like repository, REPR, factory... (I'll find them out haha)

I would like to note that I've found some of the requirements not following what I believe are the best practices 
like using POST request with (GetEmpStatus) as well as sending the National Number through the body as it should be sent 
as a query param.

bouns features that I've implemented are: 
- Validation Guards
- centralized exception handling
- database seeding
- database InMemory Caching
- Retry mechanism using poly
- User login/register
- authorization token

you'll find a post man collection containing the endpoints in the .net api project
I included a seeding function so no script is needed.

that's it, thank you
