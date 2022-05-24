using ScheduleApi.Adapters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var theScheduleAdapter = new ScheduleAdapter(); // we'll pay the perf hit BEFORE the application starts.
builder.Services.AddSingleton(theScheduleAdapter); 



// ConfigureServices in Startup -- setting up the stuff that happens behind the scenes before we start it.
var app = builder.Build();
// all "middleware" - the stuff here will see the incoming requests, and the outgoing responses.

// Configure Method Startup
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
Console.WriteLine("Before App Run");
app.Run(); // a blocking forever while loop.
Console.WriteLine("After App Run");