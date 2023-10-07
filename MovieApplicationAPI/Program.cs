

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MovieAppAPI.Data;
using MovieAppAPI.Mapping;
//using MovieAppAPI.Middleware;
using MovieAppAPI.Services;
using MovieAppAppication.Interface.IRepository;
using MovieAppInfrastructure.Implementation.Repository;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace MovieApplicationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MovieDb>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MovieString")));
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value!)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });


            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
            });
            //app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}