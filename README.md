# OnlineTickets-EcomerceApp
This is an application for online ticket management. The application includes the following controllers:

**AccountController**: This controller is responsible for handling user-related functionality such as user registration, login, and logout. It utilizes the UserManager and SignInManager classes from ASP.NET Core Identity for user management and authentication.

**ActorsController**: This controller is used to manage actors in the ticketing system. It allows administrators to perform CRUD (Create, Read, Update, Delete) operations on actors. The controller is decorated with the [Authorize(Roles = UserRoles.Admin)] attribute, indicating that only users with the "Admin" role can access its actions.

**ProducersController**: Similar to the ActorsController, this controller is used to manage producers in the ticketing system. It provides actions for creating, reading, updating, and deleting producers. It is also decorated with the [Authorize(Roles = UserRoles.Admin)] attribute to restrict access to administrators.

These controllers interact with the underlying data through the AppDbContext and various service classes (IActorService and IProducersService). The application follows the Model-View-Controller (MVC) architectural pattern, utilizing views to render HTML templates and models to represent the data being displayed or manipulated.

Overall, this application allows users to register, log in, and log out, while administrators have additional capabilities to manage actors and producers within the ticketing system.

## Movies:
![image](https://github.com/GitMalmoer/OnlineTickets-EcomerceApp/assets/113827015/737bb971-7c9c-44ed-8630-196785e3c33b)
## Shopping cart:
![image](https://github.com/GitMalmoer/OnlineTickets-EcomerceApp/assets/113827015/8611afdd-242b-469f-a53c-1a0808840934)
## Cinemas:
![image](https://github.com/GitMalmoer/OnlineTickets-EcomerceApp/assets/113827015/1a58def2-75e3-496b-9a86-673fc329b323)
## Actors:
![image](https://github.com/GitMalmoer/OnlineTickets-EcomerceApp/assets/113827015/5652ad52-c173-4a8b-993e-27f783df26d3)
## Orders
![image](https://github.com/GitMalmoer/OnlineTickets-EcomerceApp/assets/113827015/e55deae3-1e26-43bf-896a-720b7126416a)
## Users
![image](https://github.com/GitMalmoer/OnlineTickets-EcomerceApp/assets/113827015/a0ea11c7-cbdf-4d17-8b4a-0feb3300afcb)

