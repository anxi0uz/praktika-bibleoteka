
using ApiBookStore.Abstractions;
using ApiBookStore.DataAccess;
using ApiBookStore.Repositories;
using ApiBookStore.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiBookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer("Data Source=PK452-8\\SQLEXPRESS;Initial Catalog=biblioteka923YA2;Integrated Security=True;Encrypt=False;"));
            //builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer("Data Source=DESKTOP-NJGEGMS;Initial Catalog=biblioteka923YA2;Integrated Security=True;Encrypt=False;"));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<ITicketRepository,TicketRepository>();
            builder.Services.AddScoped<IAuthorRepository,AuthorRepository>();
            builder.Services.AddScoped<IBookRepository,BookRepository>();
            builder.Services.AddScoped<IAuthorizationService,AuthorizationService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
