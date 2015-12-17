Ran the Enable-Migrations command in Package Manager Console

This command has added a Migrations folder to our project, this new folder contains two files:
Migrations Folder can be deleted if migration need not be tracked



Add-Migration will scaffold the next migration based on changes you have made to your model since the last migration was created
Update-Database will apply any pending migrations to the database