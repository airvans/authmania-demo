using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                     .AddCookie(opt=>{
                        opt.LoginPath = "/sign-in";
                        opt.Cookie.Name = "kooudle";
                     }).AddOAuth("custom",opt=>{
                        
                        opt.SignInScheme = "cookie";
                        opt.ClientId = "8cba3ce6-5ad9-460e-82a8-c1268909de60";
                        opt.ClientSecret = "hell0";
                        opt.AuthorizationEndpoint = "/oauth/authorize";
                        opt.TokenEndpoint = "/oauth/token";
                        opt.CallbackPath = "/callback.test";
                                     
                     });
                     
                  
                
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/",()=>"welcome");

app.Run();

