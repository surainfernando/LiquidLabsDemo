## Inroduction
This project is meant to expose endpoints to obtain Post data. Post data is obtained from 3rd party API's and stored locally in db.
The flowof the application is described in ## Endpoints

## Running Project
The Project can be run by configuring the startup project to LiquidLabsDemo.API
Further the ConnectionStrings.DefaultConnection should be set matching the local db configuration. 
Please set Login credentilas, Server Ip and Database name in appsettings.json and appsettings.development.json files.
Further the Post.sql script needs to be executed to crate the database and tables necessary for this project.

## Endpoints
The Project exposes 2 main endpoints
1.This endpoint
-attempts to retrieve record by Id from databse , if exists return the result.
- if it does not exist ,attempts to retrieve the records from jsonplaceholdder API  saves in db and then returns the Post
https://localhost:7071/api/post/1  //Set the preferred Id instad of 1

2. This endpoint retrieves a list of records with pagination from records stored in db
 https://localhost:7071/api/Post/GetList?pageSize=2&pageNumber=3  //Please set page size and page number

## Architechture descripion
N-tier architechture is used
1. LiquidLabsDemo.API- Presentaion layer
2. LiquidLabsDemo.BL -Business layer
3. LiquidLabsDemo.Service -Infrastructure layer/Service layer -> accesses repository and api manager to query data
4. LiquidLabsDemo.Repository -Repository layer
   LiquidLabsDemo.ApiManger -Repository layer -retrieves data from 3rd party API
5. LiquidLabsDemo.DTO-Shared models, stores DTO objects
