# 🎓 EduCore – E-Learning Platform  
A Modular Clean Architecture .NET 8 E-Learning System

EduCore is a scalable and modular **E-Learning Platform** built with enterprise-grade **Clean Architecture**, supporting course creation, multimedia hosting, quizzes, certifications, payments, and multi-role access.  
The system is structured using separation of concerns, plug-and-play modules, and cloud-ready integrations.

---

## 🚀 System Features

### 👤 User Roles
- **Admin** – manages all system operations  
- **Instructor** – creates courses, uploads media, manages students  
- **Student** – enrolls, learns, takes quizzes, earns certificates  

---

### 🎓 Learning Management
- Create and publish courses  
- Organize course sections  
- Upload multimedia content (videos, documents, quizzes)  
- Cloud-hosted course content  
- Student enrollment & activation  
- Course progress tracking  
- Learning analytics  

---

### 🧪 Quiz & Assessment System
- Create quizzes with multiple questions & options  
- Identify correct answers  
- Student quiz attempts  
- Auto-grading  
- Store grading history  

---

### ⭐ Reviews & Ratings
- Students can rate and review courses  
- Automatic:  
  - Average rating  
  - Rating count  
  - Enrolled student count  

---

### 🛒 E-Commerce Integration
- Add/remove courses from cart  
- Checkout with order & order items  
- Track payment status  
- Price captured at purchase  
- Secure workflow for activation  

---

### 📜 Certification
- Auto-generate certificates after completion  
- Unique certificate verification URL  
- Stored per student  

---

## 🛠️ Technology Stack

### **Backend**
- **.NET 9 Web API**
- **Modular Clean Architecture**
- **Entity Framework Core 8**
- **MediatR (CQRS)**
- **AutoMapper**
- **FluentValidation**
- **Localization (Multi-language API responses)**
- **JWT Authentication**

### **Cloud & Storage**
- **Cloudinary**
  - Image hosting  
  - Video hosting  
  - Document hosting  
  - CDN optimization  

### **Utility Features**
- Global Exception Handling Middleware  
- Standardized API Result Wrappers  
- Pagination Utilities  
- Custom Pipeline Behaviors  

---

## 🏛️ Architecture Overview

EduCore uses **Modular Clean Architecture**, separating the solution into clear independent layers:

📦 EduCore.API
├── Controllers
├── Base
├── appsettings.json
├── Program.cs

📦 EduCore.Core
├── Dependencies
├── Imports
├── Bases
├── Behaviors (Pipeline behaviors)
├── Features (Use cases)
├── Mapping (AutoMapper profiles)
├── Middleware
├── Resources (localization)
├── Wrappers (Responses, Pagination)

📦 EduCore.Data
├── Entities
├── Enums
├── Helpers
├── Requests (DTOs in)
├── Results (DTOs out)
├── Common Utilities
├── AppMetaData

📦 EduCore.Infrastructure
├── Persistence (DbContext + EF configurations)
├── Migrations
├── Implementations (Cloudinary, Auth, etc.)
├── InfrastructureBases
├── Seeder

📦 EduCore.Service
├── AuthServices
├── Abstracts (Interfaces)
├── Implementation (Business logic)
├── ModuleServiceDependencies

markdown
Copy code

### ✔ Architecture Benefits
- Highly maintainable  
- Easy to test  
- Fully modular  
- Infrastructure can be replaced without touching business rules  
- Organized by features (vertical slices)  
- Ready for high scalability  

---

## ⚙ Additional Features

### 🌍 Localization
- Multi-language support (EN / AR)  
- Localized API responses  
- Localized validation messages  

### ✔ Fluent Validation
- Clean, readable validation rules  
- Request-level validation  
- Integrates with pipeline behaviors  

### 🔄 AutoMapper
- Maps Entities ↔ Requests ↔ Results  
- Reduces boilerplate  
- Centralized mapping  

### 🔢 Pagination
Standardized paginated output:

```json
{
  "items": [],
  "pageNumber": 1,
  "pageSize": 10,
  "totalCount": 120,
  "totalPages": 12
}
🧩 Wrappers
Unified API response format

Success & failure responses

Validation error structure

🚦 Behaviors
Validation Behavior

Logging Behavior

Performance Behavior

🤝 Contributing
Pull requests are welcome.
Please open an issue first to discuss major changes.
