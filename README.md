# aura Admin Panel

aura is an admin panel which is currently being used by ~60 local companies to view their daily incomes and more.
It was build on top of a legacy Point of Sale system for Restaurants and Cafeterias to allow managers and owners to check the daily income without being on-site. 
The project is hosted via AWS EC2 instance and IIS services paired with nginx to simulate a reverse proxy.

The below description is made with the current tools used to create the software. I'm a solo programmer on this project which was also initiated by me, so I had to implement a lot of new concepts within a short time-frame.

I'm currently updating the app to work as a WebAssembly app (currently works Server-side). Besides that, i'm also reconstructing the communication between client and server to share data with a better API process (REST), up until now the communication was via WebSocket programming.

## Tools used to create this project
 `FRONT END`
-
- Blazor 
- Bootstrap
- [MudBlazor Component Library](https://mudblazor.com/docs/overview)
- PWA

`BACK END`
- 
- AWS EC2 instance running Windows Server
- IIS Manager 10
- nginx for reverse proxy
- [winacme](https://www.win-acme.com/) for getting SSL certifications to allow https hosting
- .NET Framework 4.8 for creating console apps on the client side and server side to allow communication via WebSocket programming


## Diagram on how the architecture works

To help decipher the below diagram:

Starting from Client, there is a Console app that gets data from the .mdb file(db) installed locally on the client computer. It is then transferring that data to another Console app which is hosted on the Server and is constantly listening to incoming requests. 

Both clients in this case have separate Console apps on client side and are communicating to the same Server side Console app. When accepting requests, the servers also accepts the name of the client which is sending the data

The Console app on the Server side then generates a JSON file which will be later read by the WebPage to generate the data to show to the client (im currently working on changing this part to a better solution using API calls)

Whenever the user wants to connect to one of the databases, a reverse proxy is set up in between the user and server to redirect to the corresponding port which the web page is hosted.

![aura-architecture](https://user-images.githubusercontent.com/13669142/188190971-d107b6f3-ef8a-4c9d-ba85-4713566e2918.png)



## [Check out 'aura' live here](https://blazor.intouch-ks.com/)

