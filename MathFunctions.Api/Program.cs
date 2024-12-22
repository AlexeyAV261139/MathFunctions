using Core;
using Core.Services;
using DAL.Repositories;
using ISOCI.DAL;
using Microsoft.AspNetCore.CookiePolicy;

namespace Authentication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<ApplicationContext>();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<JwtProvider>();
        builder.Services.AddSingleton<UserRepository>();
        builder.Services.AddSingleton<PasswordHasher>();

        builder.Services.AddApiAuthentication();


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCookiePolicy(new CookiePolicyOptions
        {
            MinimumSameSitePolicy = SameSiteMode.Strict,
            HttpOnly = HttpOnlyPolicy.Always,
            Secure = CookieSecurePolicy.Always
        });

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
