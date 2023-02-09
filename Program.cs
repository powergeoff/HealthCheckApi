var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
bool isHealthy = true;

app.MapGet("/", () => "Hello World!");

app.MapGet("/toggleHealth", () => {
    isHealthy = !isHealthy;
    return isHealthy;
} );

app.MapGet("/isHealthy", () => {
    return isHealthy ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;
});

app.UseHttpsRedirection();

app.Run();
