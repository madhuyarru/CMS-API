# Products CRUD API

Sample ASP.NET Core API with four endpoints, in-memory storage, and Swagger UI.

## Run

Requires the .NET 9 SDK.

```powershell
dotnet restore
dotnet run
```

Open http://localhost:5050/swagger. Expand an operation, select **Try it out**, enter any required values, then select **Execute**.

| Method | Route | Operation |
| --- | --- | --- |
| GET | /api/products | Read all products |
| POST | /api/products | Create a product |
| PUT | /api/products/{id} | Update a product |
| DELETE | /api/products/{id} | Delete a product |

Example POST or PUT body:

```json
{
  "name": "Keyboard",
  "price": 49.99
}
```

Names are required and limited to 100 characters. Prices are required and must be between 0.01 and 1000000. Invalid requests return 400; updating or deleting a missing product returns 404.

Data starts with two sample products and resets whenever the application restarts. No database or authentication is configured. Swagger is enabled only in the Development environment, which the launch profile selects automatically. The launch profile uses local HTTP for this demo.