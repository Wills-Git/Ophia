using Azure.Communication.CallAutomation;

var builder = WebApplication.CreateBuilder(args);

// services
builder.Services.AddControllers();              
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new CallAutomationClient(
    builder.Configuration["ACS:ConnectionString"]
));
builder.Services.AddSingleton<CallService>();             

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
