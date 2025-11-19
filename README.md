# clothes_app

A Management System for Clothes, developed using the C# language.

## Key Features & Benefits

*   **Product Management:**  Add, view, update, and delete clothing products.
*   **Data Persistence:** Product data is stored in a `product_data.json` file.
*   **Service Layer:**  The `ProductService` class provides an abstraction layer for interacting with product data.
*   **Simple Architecture:** Easy to understand and extend, making it suitable for small to medium-sized clothing businesses.

## Prerequisites & Dependencies

*   [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) (or later):  Required to compile and run the application.
*   An IDE (Integrated Development Environment) such as:
    *   [Visual Studio](https://visualstudio.microsoft.com/)
    *   [Visual Studio Code](https://code.visualstudio.com/) with the C# extension

## Installation & Setup Instructions

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/Rifqihamza/clothes_app.git
    cd clothes_app
    ```

2.  **Restore NuGet Packages:**

    If you are using Visual Studio, this should happen automatically upon opening the solution (`clothes_app.sln`).
    If you are using the .NET CLI, run:

    ```bash
    dotnet restore
    ```

3.  **Build the project:**

    ```bash
    dotnet build
    ```

4.  **Run the application:**

    ```bash
    dotnet run
    ```

## Usage Examples & API Documentation

The application is a console application.

Basic Product Operations:

*   **Adding a product:**

    The console app will prompt you to enter product details (Name, Price, etc.)
    that are then saved to the `product_data.json` file.

*   **Viewing Products:**

    The console app will display the list of product information currently stored.

*   **Updating a product:**

    The console app will allow you to select a product and modify its details.

*   **Deleting a product:**

    The console app will allow you to remove a product from the list.

## Configuration Options

The application reads and writes product data to `Data/product_data.json`.  You can modify this file directly (though it's not recommended while the application is running). No other configuration options exist at this time.

## Contributing Guidelines

We welcome contributions to improve the `clothes_app` project!

1.  **Fork the repository.**
2.  **Create a new branch for your feature or bug fix:** `git checkout -b feature/your-feature-name`
3.  **Make your changes and commit them:** `git commit -am 'Add some feature'`
4.  **Push to the branch:** `git push origin feature/your-feature-name`
5.  **Create a new Pull Request.**

Please ensure your code adheres to the existing coding style and includes appropriate tests.

## License Information

License not specified. All rights reserved.

## Acknowledgments

This project utilizes the .NET framework.