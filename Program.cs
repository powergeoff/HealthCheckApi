using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

bool isHealthy = true;

app.Logger.LogInformation(DateTime.Now.ToString() +  " Adding Routes");
app.MapGet("/", () => "Hello World!");

app.MapGet("/toggleHealth", () => {
    isHealthy = !isHealthy;
    app.Logger.LogInformation(DateTime.Now.ToString() +  " Toggle invoked. Variable = " + isHealthy);
    return isHealthy;
} );


app.MapGet("/isHealthy", () => {
    app.Logger.LogInformation(DateTime.Now.ToString() + " Health Check Invoked isHealthy = " + isHealthy);
    return isHealthy ? new HttpResponseMessage(System.Net.HttpStatusCode.OK) : throw new BadHttpRequestException("app not healthy", 500);
});

//app.UseHttpsRedirection();

app.Logger.LogInformation(DateTime.Now.ToString() +  " Starting the app");
app.Run();


