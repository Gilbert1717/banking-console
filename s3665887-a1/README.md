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

#### DTOs

> g) [1 mark] Implement and use a class library in your project. You must justify its use and
provide an explanation in the readme file.  

answer for g)

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