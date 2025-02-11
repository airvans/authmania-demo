using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                     .AddCookie(opt=>{
                        opt.LoginPath = "/login";
                        opt.Cookie.Name = "kooudle";
                     }).AddOAuth("custom",opt=>{
                        opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        opt.ClientId = "8cba3ce6";
                        opt.ClientSecret = "hell0";
                        opt.AuthorizationEndpoint = "http://localhost:5112/oauth/oauthcocsent";
                        opt.TokenEndpoint = "http://localhost:5112/oauth/token";
                        opt.CallbackPath = "/callback-test";    
                        opt.SaveTokens = true;
                                                    
                     });
                     
                  
                
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllers();

app.MapGet("/",()=>"welcome");

app.Run();

