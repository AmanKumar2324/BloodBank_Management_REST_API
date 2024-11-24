# Blood Bank Management REST API
This project is a RESTful API for managing a blood bank system, built using ASP.NET Core. The API provides endpoints for creating, retrieving, updating, deleting, filtering, and sorting blood bank entries.

## Table of content
- Feature
- Technology Used
- Setup Instructions
- API Endpoints
  - CRUD Operation
  - Pagination
  - Filtering
  - Sorting
- Sample JSON Payloads
- Swagger Documentation
- Video Demonstration
- Screenshots

## Features
- Create, read, update, and delete blood bank entries.
- Filter entries by blood type, donor name, or status.
- Paginate results for large data sets.
- Sort entries by blood type or collection date.
- Interactive API documentation using Swagger.
  
## Technologies Used
- Language: C#
- Framework: ASP.NET Core
- Tools: Visual Studio, Postman, Swagger
- In-Memory Data Storage: List<BloodBankEntry>
- API Documentation: Swashbuckle (Swagger)

## Setup Instructions
- Clone the repository
  ```
   git clone https://github.com/AmanKumar2324/BloodBank_Management_REST_API.git
   cd BloodBank_Management_REST_API
- Open the project in Visual Studio.
- Build the solution using
  ```
  dotnet build
- Run the Project using 
  ```
  dotnet run
- The API will be available at https://localhost:7179/swagger/index.html

## API Endpoints

### CRUD Operations
#### Create Entry
- Endpoint: `POST /api/bloodbank`
- Description: Add a new blood bank entry.
- Sample Request Body:
  ```
  {
    "donorName": "John Doe",
    "age": 30,
    "bloodType": "A+",
    "contactInfo": "john.doe@example.com",
    "quantity": 500,
    "collectionDate": "2024-11-15T00:00:00",
    "expirationDate": "2024-12-15T00:00:00",
    "status": "Available"
  }
#### Read all entries 
- Endpoint: `GET /api/bloodbank`
- Description: Retrieve all blood bank entries.

#### Read entries by id
- Endpoint: `GET /api/bloodbank/{id}`
- Description: Retrieve a specific blood bank entry by ID.

#### Update entries
- Endpoint: `PUT /api/bloodbank/{id}`
- Description: Update an existing entry.
- Sample Request Body:
  ```
  {
    "donorName": "Jane Smith",
    "age": 25,
    "bloodType": "O-",
    "contactInfo": "jane.smith@example.com",
    "quantity": 450,
    "collectionDate": "2024-11-10T00:00:00",
    "expirationDate": "2024-12-10T00:00:00",
    "status": "Requested"
  }

#### Delete Entry
- Endpoint: `DELETE /api/bloodbank/{id}`
- Description: Remove a blood bank entry by ID.

#### Pagination
- Endpoint: `GET /api/bloodbank?page={pageNumber}&size={pageSize}`
- Description: Retrieve paginated results.
- Example:
  - Request: `GET /api/bloodbank?page=1&size=2`
  - Response:
    ```
    {
    "totalItems": 3,
    "data": [
        { /* First entry */ },
        { /* Second entry */ }
    ]
    }
#### Filtering
- Endpoint: `GET /api/bloodbank/filter`
- Query Parameters:
  - bloodType: Filter by blood type (e.g., A+).
  - status: Filter by status (e.g., Available).
  - donorName: Filter by donor name (partial match).
- Example:
- Request: `GET /api/bloodbank/filter?bloodType=A+&status=Available`

#### Sorting
- Endpoint: `GET /api/bloodbank/sort`
- Query Parameters:
  - sortBy: Field to sort by (bloodType, collectionDate).
  - descending: true for descending order, false for ascending.
- Example:
- Request: `GET /api/bloodbank/sort?sortBy=collectionDate&descending=true`

## Sample JSON Payloads

#### Create Entry
```
{
    "donorName": "John Doe",
    "age": 30,
    "bloodType": "A+",
    "contactInfo": "john.doe@example.com",
    "quantity": 500,
    "collectionDate": "2024-11-15T00:00:00",
    "expirationDate": "2024-12-15T00:00:00",
    "status": "Available"
}
```
## Swagger Documentation

- Access Swagger at (https://localhost:7179/swagger/index.html).
- View and interact with all endpoints.

## Video Demonstration

- Video Link: https://drive.google.com/file/d/1_31tJBcVlcVwwI0_O3N6bxk4M4Pc00xq/view?usp=sharing

## Screenshots

![image](https://github.com/user-attachments/assets/3b2c4fab-cd76-44df-805d-c1f8351444ea)



