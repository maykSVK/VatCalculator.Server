
# VAT Calculator Web Server

This repository contains the server-side code for the VAT Calculator web application. The server handles the business logic to calculate Net, Gross, and VAT amounts for purchases in Austria based on the user's input.

## Features

- API to calculate missing Net, Gross, or VAT amounts.
- Validates input for correct VAT rates (10%, 13%, 20%).
- Returns meaningful error messages for invalid or missing inputs.
- Supports communication with the client via RESTful API.

## Installation and Setup

### Prerequisites

- Visual Studio 2019/2022 or newer.
- .NET Core SDK (if using .NET Core).
  
### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/maykSVK/VatCalculator.Server.git
   ```

2. Open the solution in Visual Studio:
   - Navigate to the cloned directory and open the `.sln` file.

3. Build the solution:
   - In Visual Studio, click on **Build** > **Build Solution** or press `Ctrl+Shift+B`.

4. Run the server:
   - Set VatCalculator.Server project as a startu project. 
   - Click the **IIS Express** or **Start Debugging (F5)** button at the top of Visual Studio.
   - The server should now be running, and the API will be accessible at `http://localhost:5000`.

## API Endpoints

### POST /calculate

- **Description**: Calculates the missing Net, Gross, or VAT amounts based on the user's input.
- **Request body**:
  - `amount`: Number (Net, Gross, or VAT).
  - `type`: AmountType (0 - Unknown, 1 - Net, 2 - Gross, 3 - VAT)
  - `vatRate`: Number (must be one of 10, 13, or 20).
- **Response**:
  - 200: Success (returns calculated values).
  - 400: Invalid input (returns error message).
  
Example request:

```json
{
  "amount": 100,
  "type": 1
  "vatRate": 20
}
```

## Error Handling

- The API will return a 400 error if:
  - The VAT rate is missing or invalid.
  - The amount is missing, zero, or non-numeric.
