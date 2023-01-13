Internet Banking
================

- Full name: **Yiqi DU**
- Student ID: **s3665887**
- URL to GitHub repository: https://github.com/rmit-wdt-fs-2023/s3665887-a1

### Important Notes

- A updated SQL is used for the assignment and has been included in the repository 
  -  the Amount field constraint of the Transaction table has been updated to be != 0

### About Internet Banking

What this application do...

### Application Structure

    .
    ├── /Models                          # Business objects and DTOs
    ├── /Repositories                    # Database communication
    │   ├── /SqlRepositories             # SQL implementation of the respective repository
    │   ├── IAccountRepository.cs        # Interface for AccountRepository 
    │   ├── ICustomerRepository.cs       # Interface for CustomerRepository 
    │   ├── ILoginRepository.cs          # Interface for LoginRepository 
    │   └── ITransactionRepository.cs    # Interface for TransactionRepository
    ├── /Services                        # Feature implementation
    └── /Trello                          # Trello board screenshots

### Answers for Part 4: Design and Implementation [7 marks]

> f)  [3  marks]  Implementation  of  two  design  patterns  in  the  project  and  an  analytical
justification  in  the  readme  file.  One  of  the  design  patterns  must  be  the  Dependency
Injection design pattern. The remaining design pattern is up to you.
>
> The analytical justification should cover the following points for both design patterns:
>
> - Short summary of the design patterns.
> -  Brief explanation of the purpose and advantage the design patterns offer to the project.
> -  Succinctly discuss your implementation of the design patterns.
> -  Where  in  the  code,  i.e.,  which  file(s)  and  code  within  those  file(s)  that  are implementing the design patterns.
> -  Include any other points you feel are important. 
 
#### Dependency Injection

Using dependency injection could provide a consistent class and method structure 
which will benefit to future migration and integration


#### DTO

DTO(Data Transfer Object) is a design pattern that can carry the data information provided by API 
and transfer them to the Business object that can be used by the program.

The advantage of using DTO is that the business objects will not need to be matched with the provided data format, 
which will reduce the risk caused by changing them frequently. Also, using DTO design pattern could provide flexible 
data format for system integration.

The DTO classes for the JSON retrieved from the API have been instantiated in `Models.DTOs.cs`, these DTO classes are created
following the format of the JSON and converted to the business object when loading the data in  `Services.DataLoading.cs`


> g) [1 mark] Implement and use a class library in your project. You must justify its use and
provide an explanation in the readme file.  

A database class library has been implemented. It can be used to insert, save and update data to the Azure database.

> h) [1 mark] Use C#’s required keyword for a property in your implementation. The readme
file should include:
>
> - Brief explanation of the purpose and advantage to using this keyword within the
context it has been used.
> - Where in the code, i.e., which file(s) and code within those file(s) that are using
this keyword.

The "required" keyword has been added to 2 properties in `Login.cs`, namely, `LoginID` and `PasswordHash`.

This keyword ensures non-null values are always provided for essential fields when initializing the object. In this case,
a `Login` object will always have valid `LoginID` and `PasswordHash` to make sure the authentication process is valid.

> i)  [2  marks]  Use  C#’s  asynchronous  keywords  async  and  await  in  your  implementation.
The readme file should include:
>
> - Brief explanation of the purpose and advantage to using these keywords within
the context they have been used.
> - Discuss how using these keywords change or benefit your design, for example
the change to method behaviour or program interaction / execution.
> - Where in the code, i.e., which file(s) and code within those file(s) that are using
these keywords. 

answer for i)

- Asynchronization provides the environment that different task can be run parallelly. It will consume more computing power 
but with multiple task run at the same time, it can reduce unnecessary waiting time which used to process different tasks.


- Take this program as an example, when we first run the program, it will need to load data from the API. These data is only needed
after customer input the user ID and password. If we do not implement asynchronization, customer will either waiting all the data
has been loaded to input the user details or wait the program to load data after provide the user details. However, for customer 
anthentication, it only requires the result after the data has been loaded, and the loading process does not affect customer input
user details. Thus, we can use asynchronization to handle this situation. With the asynchronization system will be able to load 
the data while customer inputting their login details, as a result, system could use this time more efficiently as well. Since
customer authorization can only happen after data has been fully loaded, I used await keywords before authorization to make sure
it does not happen before data loading finishing(In case customer input the details too fast or it takes too much time to load the data).

- The async `Preloading()` method is written in `Services.DataLoading.cs` and it is called in `UseMenu()` in `IOs.MenuController.cs` Method.