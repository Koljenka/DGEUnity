# OAuth2

**This package includes:**
 - A [oauth2](https://oauth.net/2/) authorization server
 - A [MySQL](https://www.mysql.com/) database in which the user data as well as the oauth data is stored
 - A [angular](https://angular.io/) webapp for administrative tasks
 
## Startup
 
This package is supposed to be deployed with docker. If you don't know how to use docker, read [this](https://docs.docker.com/get-started/).

There is a `docker-compose.yml` in the `/docker` directory.

First of all you have to declare the [environment variables](#environment-variables) inside of the `docker-compose.yml`.


Then you can run `docker-comopse up --build` inside the `/docker` directory. This may take a while. On the first startup the Database will probably crash. This is normal as the database setup takes longer than the startup of the oauth server, which than tries to access the database.
But if it crashes, you just have to stop the running process and run `docker-compose up --build` again, then everything should be fine.

Now you can navigate to `http://localhost:5001/` and click the green login button.
If everything is working this should redirect you to a login page.
There you can login using the user `root` and the password `root` **-DISCLAIMER: CHANGE THIS USER IMMEDIATELY-**.

And now you can access the database using the support tool.

## Environment Variables

### oauth2tomcat:
- `DB_HOST` 
    - The host of the database you want to access.
    Only if you use another database than the docker container, you have to change this
- `DB_PORT` 
    - The port of the database you want to access. u.s
- `DB_DATABASE`
    - This is the name of the database you want to access.
    This has to be the same as `MYSQL_DATABASE`
- `DB_USER`
    - The user with which the oauth server connects to the database.
    If you change this, you need to specify `MYSQL_USER`
- `DB_PASSWORD`
    - The password with which the oauth server connects to the database.
    If you use the user "root", it has to be the same as `MYSQL_ROOT_PASSWORD`.
    Otherwise, you need to specify `MYSQL_PASSWORD`
- `OAUTH_CLIENT_ID`
    - These client information are inserted into the database in the initial startup.
    If you want to use the support tool, you should leave them as they are, or change the [oauth2support](#oauth2support) args 
- `OAUTH_CLIENT_SECRET` 
    - u.s
- `OAUTH_REDIRECT_URI` 
    - u.s
- `OAUTH_INTERN_REDIRECT_PROTOCOL` 
    - The protocol with which the server redirects internally. If you run the oauth server on a https webserver, you have to change this.
- `OAUTH_INTERN_REDIRECT_PORT`
    - The port with which the server redirects internally. This needs to be the same as the forwarded port in the `ports` section
- `ALLOW_FACEBOOK_LOGIN`
    - If you set this to `true` a _Login with Facebook_ button will appear on the login window.
    If you want to use this you will have to set the following attributes.
- `FACEBOOK_CLIENT_ID` 
    - You will get this ID from the Facebook developer console, where you have to add this application.
- `FACEBOOK_CLIENT_SECRET`
    - u.s
- `ALLOW_GOOGLE_LOGIN`
    - u.s
- `GOOGLE_CLIENT_ID`
    - u.s
- `GOOGLE_CLIENT_SECRET`
    - u.s
- `ALLOW_INSTAGRAM_LOGIN`
    - u.s
- `INSTAGRAM_CLIENT_ID`
    - u.s
- `INSTAGRAM_CLIENT_SECRET`
    - u.s
- `ALLOW_TWITTER_LOGIN`
    - u.s
- `TWITTER_CLIENT_ID`
    - u.s
- `TWITTER_CLIENT_SECRET`
    - u.s
- `DEFAULT_SCOPES`
    - These are the scopes, which can be accessed in the Swagger UI
    
### oauth2mysql

- `MYSQL_ROOT_PASSWORD`
    - The password of the root user. Needs to be the same as `DB_PASSWORD`, if the root user is used
- `MYSQL_DATABASE`
    - The default database. Needs to be the same as `DB_DATABASE`

### oauth2support

_These aren't environment variables, but they serve the same purpose_

- `clientId`
    - The clientId of the support tool
- `clientSecret`
    - The clientSecret of the support tool
- `clientName`
    - The clientName of the support tool
- `redirectUri`
    - The redirectUri of the support tool
- `authUrl`
    - The authorization URL of the authorization server.
    If you change the location of the server, you have to change this accordingly
- `tokenUrl`
    - u.s
- `apiBasePath`
    - u.s
- `configuration`
    - The [angular configuration](https://github.com/angular/angular-cli/wiki/stories-application-environments) used to build the webapp
