using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                     .AddCookie(opt=>{
                        opt.LoginPath = "/sign-in";
                        opt.Cookie.Name = "kooudle";
                     }).AddOAuth("custom",opt=>{
                        opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        opt.ClientId = "8cba3ce6";
                        opt.ClientSecret = "hell0";
                        opt.AuthorizationEndpoint = "http://localhost:5112/oauth/authorize";
                        opt.TokenEndpoint = "http://localhost:5112/oauth/token";
                        opt.CallbackPath = "/callback-test";    
                        opt.SaveTokens = true;
                                                    
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

