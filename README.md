# .NET Angular Interview Test

This project is developed for interview testing.

### Structure overview

-   Frontend - **Angular**
-   Backend - **.NET**
-   Database - **MS SQL Server**

### Running the app

```bash
# all services
$ docker compose up

# frontend
$ docker compose up frontend

# backend
$ docker compose up backend

# database
$ docker compose up db
```

### Database Structure

Use Entity Framework (Code-First) for database design.

```
User {
    id: int (primary);
    hn: string (indexed);
    firstname: string;
    lastname: string;
    phoneNumber: string;
    email: string;
}
```

### Backend Design Pattern

Split the app to 4 layers.

-   **Middleware** - Some action before route to controller and some action after response from controller.
-   **Controller** - Check request and manage response status.

-   **Service** - App logical layer. (Exclude database)

-   **Repository** - Data query layer. (Database connection)

### Frontend Design Pattern

-   **Server Side Rendering with client hydration**
-   **Modular**

-   **Lazy loading**

-   **Bootstrap and my CSS**
