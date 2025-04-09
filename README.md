# CloudQA Developer Internship - Form Test

This project is a C# Selenium test script that validates three fields on the [CloudQA Automation Practice Form](https://app.cloudqa.io/home/AutomationPracticeForm):

- First Name input field
- Last Name input field
- Gender (Male) radio button

### How to Run
- Requires .NET and ChromeDriver installed
- Run `dotnet test` or execute via Visual Studio Test Explorer

### Objective
The test ensures robustness against changes in position or HTML properties by using stable attributes like `name` and `value` for selectors.
