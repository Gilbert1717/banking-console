Internet Banking
================

- Full name: **Yiqi DU**
- Student ID: **s3665887**
- URL to GitHub repository: https://github.com/rmit-wdt-fs-2023/s3665887-a1

### Important Notes

- A updated SQL `CreateTables.sql` is used for the assignment and has been included in the git repository
    - the `Amount` field constraint of the `Transaction` table has been updated to be `!= 0`

### Application Structure

    .
    ├── /IOs                             # Menus managing input and output
    ├── /Models                          # Business objects and DTOs
    ├── /Repositories                    # Database communication
    │   ├── /SqlRepositories             # SQL implementation of the respective repository
    │   ├── IAccountRepository.cs        # Interface for AccountRepository 
    │   ├── ICustomerRepository.cs       # Interface for CustomerRepository 
    │   ├── ILoginRepository.cs          # Interface for LoginRepository 
    │   └── ITransactionRepository.cs    # Interface for TransactionRepository
    ├── /Services                        # Feature implementation
    ├── Program.cs                       # Main method - start of the program
    └── README.md

### Answers for Part 4: Design and Implementation [7 marks]

> f)  [3  marks]  Implementation of two design patterns in the project and an analytical
> justification in the readme file. One of the design patterns must be the Dependency
> Injection design pattern. The remaining design pattern is up to you.
>
> The analytical justification should cover the following points for both design patterns:
>
> - Short summary of the design patterns.
> - Brief explanation of the purpose and advantage the design patterns offer to the project.
> - Succinctly discuss your implementation of the design patterns.
> - Where in the code, i.e., which file(s)  and code within those file(s)  that are implementing the design patterns.
> - Include any other points you feel are important.

#### <u>Dependency Injection</u>

Dependency injection separates the construction and usage of an object. The "injector" takes care of constructing such
object while classes that utilise such object can use it without knowing how to construct it. This allows the program
to be more configurable and extendable as replacing the underlying implementation of an object can be done in the
injector level instead of where it is used.

In this program, we used dependency injection for the repositories. Each repository has its own interface where the
method signatures are defined. In the implementation class of such interface, in this case - SQL - further details such
as SQL queries and parameters required are then specified. The classes that utilise repositories do not need to
construct the SQL implementation, but instead, just call the methods defined in the interface. This means, if the
database for this program were to swapped to non-SQL tomorrow, it could be easily updated without changing most of the
classes.

Repository interfaces sit in `Repositories/` while the SQL implementations are placed in `Repositories/SqlRepositories`.
Repositories are used in `Services/MenuService.cs` and `Services/DataLoading.cs`, but the dependency is injected in
`IOs/Menu.cs` and `IOs/MenuController.cs` respectively.

#### <u>DTOs</u>

DTOs (Data Transfer Objects) are objects that can be used to carry data provided by API and are subsequently transfer
into business objects that can be used by the program.

The advantage of using DTOs is that the business objects will not need to be matched with the provided data format,
which will reduce the risk caused by changing them frequently. Also, using DTO design pattern allows flexible data
format for system integration.

The DTO classes for the JSON retrieved from the API have been instantiated in `Models/DTOs.cs`, these DTO classes are
created following the format of the JSON and converted to the business object when loading the data
in  `Services/DataLoading.cs`


> g) [1 mark] Implement and use a class library in your project. You must justify its use and
> provide an explanation in the readme file.

A database class library `Database.SqlConnection` has been implemented. It can be used to save, query and update data in
the Azure database. Since database communication is widely used. All the business objects will need to be saved in the
database. The program also needs to retrieve them from the database to implement the task and update them according to
the changes. Thus, a SQL connection library has been built so all the methods related to database communication can be
easily called from this library.

> h) [1 mark] Use C#’s required keyword for a property in your implementation. The readme
> file should include:
>
> - Brief explanation of the purpose and advantage to using this keyword within the
    context it has been used.
> - Where in the code, i.e., which file(s) and code within those file(s) that are using
    this keyword.

The "required" keyword has been added to 2 properties in `Models/Login.cs`, namely, `LoginID` and `PasswordHash`.

This keyword ensures non-null values are always provided for essential fields when initializing the object. In this
case, a `Login` object will always have valid `LoginID` and `PasswordHash` to make sure the authentication process is
valid.


> i)  [2  marks]  Use C#’s asynchronous keywords async and await in your implementation.
> The readme file should include:
>
> - Brief explanation of the purpose and advantage to using these keywords within
    the context they have been used.
> - Discuss how using these keywords change or benefit your design, for example
    the change to method behaviour or program interaction / execution.
> - Where in the code, i.e., which file(s) and code within those file(s) that are using
    these keywords.

Asynchronous implementation provides the environment with the ability to run different tasks in parallel. It will
consume more computing power but with multiple tasks running at the same time, it can reduce unnecessary wait time
used to process different tasks

Using this program as an example, when we first run the program, it will need to load data from the API. This data is
only used after the customer input the user ID and password. If we do not have an asynchronous implementation, the
customer will either wait for the data to be loaded before inputting the user details, or wait for the program to load
data after providing the user details. Despite customer authentication requiring data to be loaded in advance, the
loading process does not affect the customer inputting user details. Thus, we can use an asynchronous implementation
to handle this situation. With asynchronous implementation, the system will be able to load the data while the
customer is inputting their login details. As a result, the system could use this time more efficiently as well. Since
customer authentication can only happen after the data is fully loaded, I used the `await` keyword before
authentication to make sure it does not happen before the data loading finishes (In case the customer inputs the
details too fast or it takes too much time to load the data).

The async `Preloading()` method is written in `Services/DataLoading.cs` and it is called in `UseMenu()`
in `IOs/MenuController.cs` Method.
