
using System.Configuration;
using JWT.Models;
using JWT.Services;
using Microsoft.AspNetCore.Identity;
using JWT.Helpers;
using JWT.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string myTxt = "txt";
            // Add services to the container.


            //cors policy
            //builder.Services.AddCors();

            //builder.Services.AddC
            builder.Services.AddCors(o =>
            {
                o.AddPolicy(myTxt, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    
                });
            });



            //mapping between my defined class and jwt in appsettings
            builder.Services.Configure<JWTC>(builder.Configuration.GetSection("JWT"));

            // add service of using identity
            //builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>();


            // for mapping service used for login and registeration
            builder.Services.AddScoped<IAuthService, AuthService>();

            //services of using conection string
            builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));


            //service of using jwt Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestJWT", Version = "v1" });
            });




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(myTxt);
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();





        }




        ///////



















        
        }
    }
