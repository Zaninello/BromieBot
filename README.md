🤖 BromieBot: Telegram Todo Bot
===============================

* * *

📝 Description
------------

The **BromieBot** is a simple Telegram bot designed to manage your tasks (To-Do List). It allows users to add, view, edit, delete, and complete tasks directly through the Telegram chat, using text commands. The bot uses **Entity Framework Core** for data persistence in a **SQL Server** database.

 **🛠️ Technologies Used**

--------------------------

* **Language:** C#

* **Framework:** .NET

* **Bot API:** [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot)

* **ORM:** Entity Framework Core

* **Database:** SQL Server

🚀 How to Run
----------------

#### Access Telegram and search for the user name "Brom1eBot", access the TaskBot chat, and start your task manager with the command /Menu.

-------------------

The bot is controlled by simple text commands. Type `/Menu` in the chat to see the command list.

| **Command**     | **Description**                                        | **Usage Example**                                    |
| --------------- | ---------------------------------------------------- | ----------------------------------------------------- |
| **`/Menu`**     | Displays the complete list of commands and syntax.   | `/Menu`                                               |
| **`/add`**      | Adds a new task to your list.                        | `/add Supermarket_Shopping: buy bread and milk`      |
| **`/show`**     | Lists all pending tasks for your user.               | `/show`                                               |
| **`/edit`**     | Edits the description of an existing task.           | `/edit Supermarket_Shopping: buy only whole-wheat bread`|
| **`/delete`**   | Removes a task from the list.                        | `/delete Supermarket_Shopping`                        |
| **`/complete`** | Marks a task as complete.                            | `/complete Shopping`                                  |

* * *

📦 Code Structure
----------------------

The code is organized into layers for better maintenance and separation of concerns:

* **`BromieBot`:** Contains the main entry point (`Program.cs`) and the logic for processing Telegram updates.

* **`Repository`:** Defines the interfaces (`ITodoRepository`, `IUserRepository`) and data access implementations (`TodoRepository`, `UserRepository`), using the `TelegramBotContex`.

* **`Models`:** Contains the data model classes (`Todo`, `Usuario`) that map the database tables.

* **`DataBase`:** Contains the `TelegramBotContex` class, responsible for configuring and managing connections with Entity Framework Core.

* **`Functions`:** Contains the service classes (`TodoData`, `UserData`) that encapsulate business logic and orchestrate repository operations.
