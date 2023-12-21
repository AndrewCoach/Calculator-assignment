# Simple Web Calculator

## Assignment Overview

The task is to create a web page featuring a simple calculator. This calculator should support basic arithmetic operations (addition, subtraction, multiplication, division) on two numbers with decimal places. A significant aspect of this calculator is its ability to display a history of the last ten operations upon page load.

### Objectives

- **Sustainability**: Treat this project as if it were a part of a larger, expanding project. Focus on the sustainability and scalability of the code.
- **Technology**: Utilize Visual Studio for development. You're free to use any C# project template and technology (MVC, Razor Pages, WebForms, etc.).

## Functional Requirements

1. **No Page Reload**: Interactions with the calculator must not trigger a page reload.
2. **Database Logging**: Each calculation performed must be logged in a database.
3. **Display Results**: Upon clicking "calculate", display the result on the screen and log the entire calculation in the history.
4. **Application Layering**: The application should be well-layered and structured.
5. **Modular Logic**: Separate the calculator logic to facilitate its integration into other projects and ensure it can return error messages through the method: `void SendError(Exception exception);`
6. **Number Formatting**: Include an option to set the calculator to return whole numbers.

## Non-Functional Requirements

1. **Data Layer Separation**: Implement a distinct data layer for the application.

## What You Do Not Need to Address

1. **Appearance**: While a graphical enhancement of the calculator would be appreciated, it is not the main focus. The calculator's appearance does not need to adhere to any specific design.
2. **Error State Logging**: You are not required to log the application's error states. Only collect errors into the `SendError` method, which will not execute any actions.

## Additional Challenges

1. **Unit Testing**: Develop a Unit test for the calculation logic.
2. **Error Logging**: Implement functionality to log error messages to a file.
