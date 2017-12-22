# hangfire-autofac
Hangfire in a Windows Service using dependency injection via Autofac

This simple Visual Studio Demo Projekt shows how to integrate a Webapplication with Hanfire (hostet in the same Webapplication or in a Windows Service) using Autofac.

To Start the Demmo App, adjust the .config files in the WebApi and in the HangfireService with your Connection String and just Build the Solution and run it, this will start the Webapplication.
To start the Windows Service you need to execute the .exe located in the bin/Debug folder of the HangfireService Project.

The Hangfire Dashboard is running under http://localhost:59188/hangfire and to fire a background job just hit the http://localhost:59188/api/values page

Thanks
