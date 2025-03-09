using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

IdentityModelEventSource.ShowPII = true;
IdentityModelEventSource.LogCompleteSecurityArtifact = true;

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
                                                    
                     }).AddOpenIdConnect("next", opt =>{
                         opt.Authority = "http://localhost:5112/oidc";
                         opt.SignInScheme = "Cookies";
                         opt.ClientId = "8cba3ce6";
                         opt.ClientSecret = "hell0";
                         opt.SaveTokens = true;
                         
                         opt.GetClaimsFromUserInfoEndpoint = true;

                         opt.ResponseType = "code";
                         opt.CallbackPath = "/callback";
                         opt.RequireHttpsMetadata = false;
                         opt.UsePkce = false;

                         opt.TokenValidationParameters = new TokenValidationParameters
                           {

                                 ValidateIssuer = true,
                                 ValidIssuer = "http://localhost:5112/oidc",
                                 ValidateAudience = true,
                                 ValidAudience = "8cba3ce6",
                                 ValidateLifetime = true,
                                 IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String("yIZym5aDTZ2w1I7b9UBOMjJCj6Bp2VxcqLWRpnIVI0SeIm6oPo1Ts3BKaZ3EFCG7"))
                            };



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

