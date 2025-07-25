var builder = WebApplication.CreateBuilder(args);

// services
builder.Services.AddControllers();              
builder.Services.AddEndpointsApiExplorer();     
builder.Services.AddSwaggerGen();               

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapGet("/", () => "green dot");
app.MapControllers();  
app.Run();
