# EmotionalPlayer

EmotionalPlayer is an application built using ASP.NET Core and Entity Framework Core.
It processes users' voice and is able to adjust music to his current mood.

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* Docker

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory build project and image by running:
     ```
     docker-compose build
     ```
  3. Then start the application by using:
	 ```
	 docker-compose up
	 ```
  4. Launch [https://localhost:44376/api](http://localhost:44376/api) in your browser to view the API

## Technologies
* .NET Core 3
* ASP.NET Core 3
* Entity Framework Core 3
