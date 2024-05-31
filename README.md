### Project Description

*CarModelsAPI* is a .NET Core Web API application that exposes a REST API to retrieve car models for a specific car make and manufacture year. 
The API leverages an external service, GetModelsForMakeIdYear, provided by the NHTSA (National Highway Traffic Safety Administration) to fetch the car models
based on the car make ID and year. The car make ID is obtained by reading a local CarMake.csv file, which maps car make names to their corresponding IDs.


### Step-by-Step Instructions to Start the Application Locally
#### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 8)
- A text editor or IDE (e.g., Visual Studio, Visual Studio Code)

#### Steps
1. *Clone the Repository*

   Clone the project repository to your local machine. git clone https://github.com/YazeedBaniAta/Car-Models.git,
   Then open the project with your preferred IDE

3. *Run the Application*
   
   You can start the application from your IDE (e.g., by pressing F5 in Visual Studio).

5. *Access the API*

   When the project runs successfully, it will automatically open a new browser window displaying the Swagger UI. From there, you can explore and test the API endpoints.
   You can use the Swagger UI to interact with the API by providing the car make and manufacture year and testing the endpoint.
