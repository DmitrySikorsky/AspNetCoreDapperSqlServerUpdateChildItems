# ASP.NET Core, Dapper, and Microsoft SQL Server: Update the Child Items Using the MERGE Statement
This is a demo web application for the
“[ASP.NET Core, Dapper, and Microsoft SQL Server: Update the Child Items Using the MERGE Statement](https://medium.com/@dmitry.a.sikorsky/asp-net-core-dapper-and-microsoft-sql-server-update-the-child-items-using-the-merge-statement-30498fb1abf0)”
post on the [Dmitry Sikorsky’s blog](https://medium.com/@dmitry.a.sikorsky). It demonstrates how to use the MERGE statement
to perform insert, update, or delete operations on a target table based on the results of a join with a source table.

## Using the Application

1. Create a database and run the db.sql to create its structure.
2. Fix the connection string inside the appsettings.json.
3. Run and debug the application.
4. Check the database.