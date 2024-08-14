var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/testGet", () => "This is a GET");
app.MapPost("/testPost", () => "This is a POST");
app.MapPut("/testPut", () => "This is a PUT");
app.MapDelete("/testDelete", () => "This is a DELETE");

app.Run();