# ITI Examination System

A robust, object-oriented examination system built in C# for managing subjects, students, and various types of exams (Practice and Final).

## Features

- **Subject Management**: Create subjects and enroll students.
- **Exam Types**: Support for both `Practice` and `Final` exams.
- **Question Types**: Supports multiple question formats including:
  - `True/False`
  - `Choose One` (Multiple Choice)
  - `Choose All` (Multiple Response)
- **Automatic Grading**: Calculates student scores based on correct answers.
- **Extensible Architecture**: Built with clear separation of concerns for future scalability.

## Design Decisions

### 1. Object-Oriented Principles
- **Inheritance**: Used a base `Question` class and `Exam` class to provide common functionality while allowing specialized behavior in derived types (e.g., `TrueFalseQuestion`, `FinalExam`).
- **Polymorphism**: The system treats all questions uniformly through the `Question` base class, allowing for a flexible `QuestionList`.
- **Encapsulation**: Domain logic is encapsulated within models like `Subject`, `Student`, and `Exam`.

### 2. Project Structure & Namespaces
The project is organized into logical namespaces to ensure a clear separation of concerns:
- `Model`: Contains the core domain entities (Questions, Answers, Exams, Students, Subjects).
- `Interface`: Defines contracts for shared behaviors (e.g., `IExamBehavior`).
- `Repository`: Handles data persistence and retrieval (currently using a file-based mock repository).
- `Enum`: Defines system-wide constants for question types and exam modes.

### 3. Collection Management
- Used custom collection classes like `QuestionList` and `AnswerList` to provide domain-specific methods rather than relying purely on generic `List<T>`, improving readability and maintainability.

### 4. Exam Lifecycle
- The exam process follows a defined sequence: `Registration` -> `Start` -> `Submission` -> `Grading` -> `Finish`. This ensures data integrity and a consistent user experience.


## Project Structure Overview
```text
ITI_Exam/
├── Model/           # Core business logic and entities
├── Interface/       # Common interfaces
├── Repository/      # Data access layer
├── Enum/            # Constants and enumerations
└── Program.cs       # Application entry point
```
