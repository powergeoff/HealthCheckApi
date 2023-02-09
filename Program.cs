var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

bool isHealthy = true;

app.Logger.LogInformation("Adding Routes");
app.MapGet("/", () => "Hello World!");

app.MapGet("/toggleHealth", () => {
    isHealthy = !isHealthy;
    app.Logger.LogInformation("/toggleHealth invoked. Variable = " + isHealthy);
    return isHealthy;
} );


app.MapGet("/isHealthy", () => {
    var response = new HttpResponseMessage(); 
    app.Logger.LogInformation("/isHealthy invoked. Variable = " + isHealthy);
    return isHealthy ? new HttpResponseMessage(System.Net.HttpStatusCode.OK) : new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
});

//app.UseHttpsRedirection();

app.Logger.LogInformation("Starting the app");
app.Run();
