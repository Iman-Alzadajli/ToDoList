# 📝 ToDoList Application

A simple task management app built with **ASP.NET Core MVC** and **Entity Framework Core**.

---

## ⚙️ Key Features

- Create & delete categories  
- Add, edit, delete tasks  
- Toggle task status (completed / not completed)

---

## 📂 Models

- **Category**  
  - Id  
  - Name  
  - List of ToDos (tasks)

- **ToDo**  
  - Id  
  - Name  
  - Description  
  - Priority (High, Medium, Low)  >> This is enum 
  - Deadline  
  - IsFinished (status)  
  - CategoryId (foreign key)

---

## 🔄 Relationships

- One category has many tasks  
- Each task belongs to one category

---

## 🚀 How to Use

1. Run the application  
2. Open browser at `/Category/` (important!)  
3. Create categories  
4. Add tasks to categories  
5. Edit, delete, or toggle task status as needed

---

## 📦 Tech Requirements

- ASP.NET Core 6.0+  
- Entity Framework Core  
- SQL Server  

---

Feel free to ask if you need help setting up or running! 😊
