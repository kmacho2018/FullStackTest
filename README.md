# Full Stack Test

Description: Full Stack Test Project for FullStack Developer Vacant

#### WebAPI Help
https://localhost:44351/swagger/index.html
#
#

#### Movies
* GET Movies
#### Get All Movies
### ``` https://localhost:44351/api/Movie/GetAllMovies ```
#### Get All Movies Take 2 and Sort and Search By Movie Name
### ``` https://localhost:44351/api/Movie/GetAllMovies?Take=2&Sort=Asc&MovieName=Av ```
#
* GET Movies By Name
#### Retreive Movies By name
### ``` https://localhost:44351/api/Movie/GetMovieByName?name=Avenger ```
#
* PUT Disable Movie
#### Disable Movie
### ``` https://localhost:44351/api/Movie/DisableMovie?movieId=1 ```
#
* POST Create Movie
#### Create Movie
### ``` https://localhost:44351/api/Movie/CreateMovie ```
#

#### Review
* GET Review
#### Get Review By Movie
### ``` https://localhost:44351/api/Review/GetReviewsByMovie?movieId=1 ```
#
* POST Create Review
#### Create a Review
### ``` https://localhost:44351/api/Review/AddReview ```
#

## Instalation

1. Clone the project

	``` git clone https://github.com/kmacho2018/FullStackTest.git```

2. Install all the dependencies

	``` SQL Server Express 2019 ```
	#
	``` Microsoft Visual Studio 2022 Comunity Edition ```
	#
	``` Run scriptdb.sql on Microsoft SQL Server DataBase```
	#
	``` Verify ..\FullStackTest.Api\appsettings.json file and check the connectionString ```


3. Start the project

	```Open Visual Studio  -> Run```

## Thats it

yes, the project's ready!.

## Credits
Created by Juan Camacho  

## License

	Copyright 2022 Juan Camacho
	
	Licensed under the Apache License, Version 2.0 (the "License");
	you may not use this file except in compliance with the License.
	You may obtain a copy of the License at
	
	   http://www.apache.org/licenses/LICENSE-2.0
	
	Unless required by applicable law or agreed to in writing, software
	distributed under the License is distributed on an "AS IS" BASIS,
	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	See the License for the specific language governing permissions and
	limitations under the License.