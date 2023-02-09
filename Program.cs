var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
bool isHealthy = true;

app.MapGet("/", () => "Hello World!");

app.MapGet("/toggleHealth", () => {
    Console.WriteLine("/toggleHealth invoked. Variable = " + isHealthy);
    isHealthy = !isHealthy;
    return isHealthy;
} );

app.MapGet("/isHealthy", () => {
    Console.WriteLine("/isHealthy invoked. Variable = " + isHealthy);
    return isHealthy ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;
});

//app.UseHttpsRedirection();

app.Run();
