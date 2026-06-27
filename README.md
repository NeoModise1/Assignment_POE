# Assignment_POE
# Cybersecurity Awareness Bot

A WPF chatbot application built in C# for the **Cybersecurity Awareness assignment**.  
This project demonstrates conversational flow, database integration with EF Core, and interactive features such as quizzes, task management, NLP simulation, and activity logging.

---

## 📌 Features

- **Conversation Flow**
  - Chat interface with user and bot messages.
  - Timestamped responses for clarity.

- **Memory Management**
  - Stores user details (Name, Birthday, Location).
  - Sidebar shows memory values.
  - Clear Memory button resets stored values.

- **Quick Topics**
  - One-click buttons for cybersecurity topics:
    - Passwords, Phishing, Malware, VPN, 2FA, Safe Browsing, Scams, Privacy, Cybersecurity.

- **Quiz Scoring**
  - Start quiz with multiple-choice questions.
  - Submit answers and receive feedback.
  - Final score saved in `QuizResults` table.
  - Activity log records quiz completion.

- **Task Management**
  - Add tasks with reminders.
  - View tasks stored in SQLite.
  - Mark tasks as complete.
  - Tasks saved in `Tasks` table.

- **Activity Log**
  - Logs all major actions: quiz answers, task creation, completions, bot responses.
  - Viewable via sidebar button.

- **NLP Simulation**
  - Keyword detection for commands like “add task”, “quiz”, “log”.
  - Fallback to general chatbot responses.

---

## ⚙️ Setup Instructions

1. **Install dependencies**
   - Ensure you have .NET 8 SDK installed.
   - Install EF Core packages:
     ```powershell
     Install-Package Microsoft.EntityFrameworkCore -Version 8.0.6
     Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version 8.0.6
     Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.6
     ```

2. **Run migrations**
   ```powershell
   Add-Migration InitialCreate
   Update-Database
