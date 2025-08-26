## Backend (ASP.NET Core 9 + MySql)
```bash
cd backend
dotnet ef migrations add Init
dotnet ef database update
dotnet run

## FrontEnd (NextJs)

cd frontend/productapi
npm run dev