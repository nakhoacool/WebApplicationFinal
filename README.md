# Supplement Facts Ordering System

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Getting Started](#getting-started)
- [Dependencies](#dependencies)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The Supplement Facts Ordering System is designed to provide users with a platform to view supplement facts, place orders for items, and select payment methods. It also includes features for agents to check the status of their orders.

## Features

- **Supplement Facts Viewer:**
  - Browse and search for supplement facts.
  - View detailed information about supplements.

- **Order Placement:**
  - Add items to the shopping cart.
  - Specify quantity and select products.
  - Proceed to checkout.

- **Payment Methods:**
  - Choose from multiple payment methods, including Cash, Bank Transfer, Momo, etc.
  - Secure payment processing.


## Getting Started

To get started with this project, follow these steps:

1. Clone the repository
2. Open the project in Visual Studio (or your preferred IDE).
3. Build and run the application.
4. Configure the database connection string in the project settings to connect to your SQL Server database.
5. Ensure that all required dependencies and packages are installed.
6. Access the application through a web browser.

**Webform:**

- Change the connection string `"data source"` to your SQL Server in `Web.config`.

  **Warning**: If you encounter a problem such as "Could not find a part of the path ... bin\roslyn\csc.exe," follow these steps:
  1. Go to `Tools` -> `Nuget Package Manager` -> `Package Manager Console`.
  2. Paste the following command in the command prompt: `Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`.
  3. You should be good to go.

## Dependencies

- ASP.NET MVC Framework
- Entity Framework (for database interaction)
- Bootstrap (for styling)
- ...

## Contributing

If you'd like to contribute to this project, please follow the standard GitHub flow:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
