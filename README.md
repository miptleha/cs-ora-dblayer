Simple and fast helper class to interact with Oracle database

## Features

- use modern oracle driver
- mapping query result direct to object
- support sql parameters
- support anonimous blocks
- storing all quieries in xml files (no sql queries in code! also support dynamic queries)
- logging all database operation to file and console
- fast and simple
- can be adopted to work with other databases

## How to use

1. Open solution in Visual Studio. 
2. Examine [Program.cs](Program.cs) (contains sample usage), [Db/DbExecuter.cs](Db/DbExecuter.cs)
(all db layer code).
3. Copy content of project (do not forget content of App.config) to your project.
4. Implement own Model class (inherit IRow iterface) (see [Models/Dual.cs](Models/Dual.cs) for sample).
5. Create one or many xml files with your queries in 'Sql' folder (set 'Copy to Output Directory' in properties for xml file)
6. Use [Log/LogManager.cs](Log/LogManager.cs) class instead of Console.
