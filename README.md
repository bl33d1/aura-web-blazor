# aura Admin Panel


aura is a Admin Panel created to help gastronomy business owners to have an insight on their daily sales report remotely via a web app. It was created as a add-on to an existing POS software which is active for more than 15 years on hundred of local businesses. 

The legacy code of the POS software is written in VB.NET for Applications using Access 2003, so there are a lot of work-arounds in order to find a working solution. This is the third version of this app, the first two were created using Web Forms from .NET Framework 4.8. It was upgraded to a SPA technology for performance reasons and scalability but also was interested knowing how it works. 
#
## [Check out 'aura'](https://blazor.intouch-ks.com/)  



## Tools used to create this project
### FRONT END

- [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
- Bootstrap 5
- [MudBlazor Component Library](https://mudblazor.com/docs/overview)
- PWA

### BACK END

- AWS EC2 instance running Windows Server
- IIS Manager 10
- [nginx Reverse Proxy](https://docs.nginx.com/nginx/admin-guide/web-server/reverse-proxy/)
- [winacme](https://www.win-acme.com/) for getting SSL certifications to allow https hosting
- .NET Core 6.0 Web API
- Entity Framework
- MSSQL Server


## Architecture Diagram

Since the client's database is a locally installed as a .mdb file using Access 2003, there is a .net console app running as a process on the client computer which is grabbing the new data that has not been trasnferred and sending them to the API as a POST request.
The API on the server is then accepting and saving the data to an MSSQL Database, which is read by the API whenever there is a request made from a specific user. 



## Architecture diagram
![image](https://user-images.githubusercontent.com/13669142/188333839-c59b3973-71a3-4ece-ac1b-76292bb3c1f6.png)


