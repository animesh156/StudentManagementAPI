# Student Management API

A simple ASP.NET Core Web API for managing student records with JSON file storage.  
Supports CRUD operations, partial updates (PATCH), and JWT authentication for secure access.

---

## Features
- **Get all students** and **get student by ID**
- **Add new students**
- **Partially update** student fields (PATCH)
- **Delete** students
- **JWT-based authentication** to secure API endpoints
- Data stored in a local `students.json` file — no database needed

---

## Requirements
- [.NET 6 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
- [Visual Studio Code](https://code.visualstudio.com/) (or any C# IDE)
- [Postman](https://www.postman.com/) or similar API testing tool

---

## Project Structure

```
StudentManagementAPI/
│
├── Controllers/
│ ├── StudentsController.cs
│ └── AuthController.cs
│
├── Models/
│ └── Student.cs
│
├── Services/
│ └── StudentService.cs
│
├── Data/
│ └── students.json (auto-created)
│
├── appsettings.json
├── Program.cs
└── README.md
```

---

## Running the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/animesh156/StudentManagementAPI.git
   cd StudentManagementAPI
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the API:
   ```bash
   dotnet run
   ```

4. API will be available at:
   ```
   https://localhost:5001
   http://localhost:5000
   ```

---




## Authentication

### Obtain JWT token
```http
POST /api/auth/login
Content-Type: application/json
```

**Body:**
```json
    {
  "username": "admin",
  "password": "password"
}
```

**Response:**
```json
{
  "token": "<JWT_TOKEN>"
}

```
##### Use this token as a Bearer token in the Authorization header for all protected endpoints.




## API Endpoints

### 1. Get all students
```http
GET /api/students
```
**Response:**
```json
[
  {
    "id": 1,
    "fullName": "John Doe",
    "rollNumber": "R001",
    "class": "10A",
    "dateOfBirth": "2005-05-15T00:00:00",
    "contactNumber": "123456789"
  }
]
```

---

### 2. Get student by ID
```http
GET /api/students/{id}
```

---

### 3. Add a new student
```http
POST /api/students
Content-Type: application/json
```
**Body:**
```json
{
  "fullName": "Jane Smith",
  "rollNumber": "R002",
  "class": "10B",
  "dateOfBirth": "2006-04-20T00:00:00",
  "contactNumber": "123456789"
}
```

---

### 4. Partially update student (PATCH)
```http
PATCH /api/students/{id}
Content-Type: application/json
```
**Example Body:**
```json
{
  "class": "12A"
}
```
**Response:**
```json
{
  "message": "Student updated successfully"
}
```

---

### 5. Delete student
```http
DELETE /api/students/{id}
```
**Response (if deleted):**
```json
{
  "message": "Student deleted successfully"
}
```
**Response (if not found):**
```json
{
  "message": "Student not found"
}
```

---


