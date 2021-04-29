# Synetec Basic .Net API assessement

All the projects uses .NET Core 3.1 just for consistency. The web solution could work with .NET 5 but I didn't test it. 

## About the solution

The code is a clean code with good separation of concerns it has margin for further improvements.

Just note a few part of the code:
- I used automapper for mapping model with DTOs
- Maybe with automapper is also possible to map the final object of the Bonus calculation but I didn't have time to implement it.
- I used the builder pattern in a fluent style as I considered the creation of the bonus object a bit complex and I tried to reduce complexity using this pattern.
- There is one extension method for mapping
- The Service class, probably do too much even if I splited the functionality in small methods. But there is margin for improvements here.

### Testing
- the testing is the basic minimum just for lack of time.
- I tested the controller and the service in one class. Normally, I will test the service to see if the return the expected results using inMemory database and I will   
  test in the controller just the http responses and I will mock the service when I am testing the controller.
  
### Final comments
The solution has a code refactorting, trying to get a clean code as much as I could in the available time, more improvements are possible.
The Bonus calculation method of the controller respects the two bad requested needed.
I tested the post using postman and passing this json:


{
"totalBonusPoolAmount": 120000,
"selectedEmployeeId": 1
}

If you remove the selectedEmployeeId or set it to 0, you will get a model validation error and bad request in the respose.
