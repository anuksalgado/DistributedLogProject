📄 README: **DSSystem & DSMAUI**
--------------------------------

### 🗂️ Overview

This project is a cross-platform system combining:

*   **DSSystem**: A backend RESTful API built with ASP.NET Core, using Entity Framework Core with a SQL database. It manages receipts and items with proper relational integrity.
    
*   **DSMAUI**: A mobile frontend application built with .NET MAUI, providing a clean UI for selecting items, adjusting quantities, and generating receipts.
    

The system supports:✅ Creating receipts with multiple items✅ Validating user input and database integrity✅ Robust ETL practices for handling missing or inconsistent data before saving to SQL✅ Clean architecture separating UI, business logic, and data persistence

### ⚙️ Project Structure

LayerTechnologyPurpose**Frontend**.NET MAUICross-platform mobile UI for selecting items and creating receipts**Backend**ASP.NET Core Web APIProvides REST endpoints for managing receipts and items**Database**SQL (via EF Core)Stores receipts and related items with proper foreign key constraints

### 🧩 Core Features

✅ **Item Selection**: Users can browse and select items dynamically loaded from the backend.✅ **Quantity Adjustment**: Each item can have a custom quantity using a stepper UI element.✅ **Receipt Generation**: A receipt is generated and stored in the database, ensuring unique IDs and consistency.✅ **Receipt Details**: Users can view full details of a generated receipt, including item list, prices, and quantities.

### 🔄 ETL & Data Quality

This project implements a simple ETL pipeline for inserting and updating SQL data:

Data pipeline has been taken from another repository i developed [Data Engineering Pipeline] (https://github.com/anuksalgado/Data-Pipeline)

### 📚 How to Run

#### 1️⃣ Start the backend API

1.  Navigate to the DSSystem project directory.
    
2.  bashCopyEditdotnet ef database update
    
3.  bashCopyEditdotnet run
    

The API will listen on https://localhost:{port}/api/Receipt.

#### 2️⃣ Run the mobile app

1.  Open the DSMAUI project in Visual Studio or VS Code.
    
2.  Choose your target platform (Android Emulator, iOS Simulator, or Windows).
    
3.  Build and run the app.
