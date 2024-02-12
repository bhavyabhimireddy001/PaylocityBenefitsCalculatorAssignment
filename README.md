# What is this?

A project seed for a C# dotnet API ("PaylocityBenefitsCalculator").  It is meant to get you started on the Paylocity BackEnd Coding Challenge by taking some initial setup decisions away.

The goal is to respect your time, avoid live coding, and get a sense for how you work.

# Coding Challenge

**Show us how you work.**

Each of our Paylocity product teams operates like a small startup, empowered to deliver business value in
whatever way they see fit. Because our teams are close knit and fast moving it is imperative that you are able
to work collaboratively with your fellow developers. 

This coding challenge is designed to allow you to demonstrate your abilities and discuss your approach to
design and implementation with your potential colleagues. You are free to use whatever technologies you
prefer but please be prepared to discuss the choices you’ve made. We encourage you to focus on creating a
logical and functional solution rather than one that is completely polished and ready for production.

The challenge can be used as a canvas to capture your strengths in addition to reflecting your overall coding
standards and approach. There’s no right or wrong answer.  It’s more about how you think through the
problem. We’re looking to see your skills in all three tiers so the solution can be used as a conversation piece
to show our teams your abilities across the board.

Requirements will be given separately.


# Payroll Calculation System

## Intoduction:

This backend solution offers a thorough method that accounts for different deductions for both employees and their dependents when calculating employee paychecks over the course of a year. It conforms to clean architecture and design patterns for scalability and maintainability, permits displaying employee details along with their dependents, and calculates paychecks with certain rules about benefit expenses.

## Features

### 1. Employee and Dependents Management: 
View employees along with their dependents. An employee may have one spouse or partner and an unlimited number of children.
### 2. Paycheck Calculation: 
Calculate and view an employee's paycheck, with rules for deductions and benefits costs applied across 26(biweek paychecks) pay periods per year.
* Base cost of $1,000 per month for employee benefits, which means for each biweekly paycheck $500 will be incurred. 
* An additional $600 per month for each dependent, which means for each biweekly paycheck $300 will be incurred based on number of dependents.
* If there is any dependent whose age is greater than 50 years there will be extra 200$ deduction every month, which means 100$ dedcution per paycheck.
* Extra deductions for high earners whose salary is greater than $80,000 per annum, there will be an extra 2% deduction.
* Also made sure to include state(8% standard) and federal(10% standard) taxes to imitate original payroll structure.

## Technology Stack
* __Programming Language__: _C#_
* __Framework__ : _.NET_
* __Database__: _SQL Database (with EF 6 as ORM for interaction)._
* __Logging__ : _Serilog for comprehensive logging._
* __Design Patterns__ : _Single Responsibility Principle, Dependency Injection, Abstract Pattern, and Repository Pattern implemented for optimal architecture._


## Installation and Usage
* __Clone the repository__:
     
    ```
  git clone https://github.com/bhavyabhimireddy001/PaylocityBenefitsCalculatorAssignment.git
    ```
    
* Navigate after cloning:
   ```  
    cd PaylocityBenefitsCalculatorAssignment
    ```
* Start the application( you will see a Swagger hosting the application in your local)
* Excute a json to enter new employee to the database.
* Excute another json to calucate the paychecks.
