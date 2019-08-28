# IdentityServer4 integration with ASP.NET Core 2.0 and ASP.NET MVC Full Framework

Here's the list of features already configured in client app and identity server app:
>Using ASP.NET Identity Core

>Using ASP.NET Identity Core Sql Server Database

>Response type to client apps: id token, token

>Response scopes to client apps: openid profile offline_access roles

>Use [Authorize] or [Authorize(Roles="RoleNameFromDatabase")] on client apps

>Login and logout from client app

>Redirect to client app after logout

>Logout from identity server when client logged out

**Note**: To run this app, please update database connection strings in IdentityServerAspNetIdentity (appsettings.json) file.
