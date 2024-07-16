using Bank.Infrastructure;
using Bank.Persistance;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddCors(options => options.AddDefaultPolicy(policy=>
//policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
//));



builder.Services.AddPersistanceServices();
builder.Services.AddInfrastactureServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("Customer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,  // hangi sitelerin kabul edildi�i yer  sitenin linki
            ValidateAudience = true,  // hangi api da��tt���n� ifade eder  api linki
            ValidateLifetime = true,  // olu�turulan token�n s�resini kontrol eder.
            ValidateIssuerSigningKey = true, // toke�n�n bizim uygulamaya ait olup olmad���n� kontrol eder.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),

        };
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
