# csharp-oracle-dblayer
Simple and fast helper class to interact with database

## Features

- support modern oracle driver
- mapping query result direct to object
- support sql parameters
- support anonimous blocks
- storing all quieries in xml files
- logging all database operation to file and console
- fast and simple
- can be adopted to other databases

## How to use

1. Open solution in Visual Studio. 
2. Examine [Program.cs](Program.cs) (contains sample usage), [Db/DbExecuter.cs](Db/DbExecuter.cs)
(all db layer code).
3. Copy content of project (do not forget App.config) to your project.
4. Implement own Model class (inherit IRow iterface) (see [Models/Dual.cs](Models/Dual.cs) for sample).
5. Add query to Sql folder (set 'Copy to Output Directory' in properties for xml file)
6. Use [Log/LogManager.cs](Log/LogManager.cs) class intead of Console.
