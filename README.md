# JeromeLecky

This is simple MVC demo project which allows the user to perform CRUD operations via Web Api.

You will need to run the following scripts from here: https://github.com/JayLecky/JeromeLecky/tree/master/JeromeLecky.Api/Sql_Scripts

1. CreateDb.sql
2. dbo_Products.sql
3. DataUpload.sql

I used my local sql database to persist the data. You may need to change the connection string in https://github.com/JayLecky/JeromeLecky/blob/master/JeromeLecky.Api/Web.config

The entry point to the Application is the following url:  [host]/ProductList/AllProducts
