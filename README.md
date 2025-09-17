# PokedexApp

This app allows users to search for their favorite Pokemon.  
The app consists of two parts.

C# .NET is used as a reverse proxy. This part of the program communicates with the server API, sending requests to retrieve data and storing the answers.  
The front end makes requests to the backend using the user's input. Users can enter a Pokemon ID or name. The app then displays the Pokemon's name and image.  
If a Pokemon is not found (error 404), users get information.


## Page Screenshots

**Home page**  
![Screenshot](/PokedexApp/Assets/1.png)

**Search result**  
![Screenshot](/PokedexApp/Assets/2.png)

**No matching Pokemon**  
![Screenshot](/PokedexApp/Assets/3.png)



## Running the App

1. Start the backend program by clicking the green play button in VS.  
2. Start the frontend by running `npm run start`.






