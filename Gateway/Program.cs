using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

const string SecurityKey = "mMdAhocQbIAa1/4iD8W5BiDCD9Lxg9ULp4qROgJVN8oRZommyAsnRalnNlzWGbKGJItr/kh2jVd2d9brhSBAJttV7NE47dvyX6n36cFKlnz3k9AodqqVgH/S52oQMYamtI+HsQqBmsvZMqOE+oGlEIzJG9tmDZ1JE/qJHq+bXo3RCEuBf26dGuIG4DWpjh+G4xTVC7ZoByCmq5zTUUyTlFZCQ2483iJe1Thkem9mlzt3cOy8O5SYJBafIb0xdIBYEoHl56Z805fO/W4eAw+M5stSCUdJTBUtWbCiId9zSapmilb20sCg4l5xYTsaJImTfHlo0t9kF1o/RXwr1cw3zCPoyt9tjWhZ83LMsi1ydBg=";
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", false, false);

// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(
    JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey))
        };
    }
);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOcelot().Wait();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();