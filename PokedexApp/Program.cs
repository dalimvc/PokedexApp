using PokedexApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//to enable CORS for the React app running on localhost:3000
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
      builder =>
      {
          builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
                     .AllowAnyHeader()
           .AllowAnyMethod();
      });
});

///////////////
///////////////
///////////////
//added for http client
builder.Services.AddHttpClient();
builder.Services.AddScoped<PokemonService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//to allow CORS and enable HTTPS redirection and authorization
//!!!!!important
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
