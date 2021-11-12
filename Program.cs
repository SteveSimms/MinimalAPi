using MinimalAPi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
// establishing DbContext through builder method
builder.Services.AddDbContext<BookContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
//MapGet uses endpoints
app.MapGet("/", () => "Hello Multiverse!");
var test = app.MapGet("/test", () => "Salam Sidi Asim");




//Adding below code is blocking the data from reaching the client somehow 

//if (app.Environment.IsDevelopment())
//{
//    app.UseSpa(builder =>
//    {

//        builder.UseProxyToSpaDevelopmentServer("http://localhost:3000/");




//    });

//}


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapDefaultControllerRoute();
//});
//app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

//------------------------------------------------
//CRUD OPS BELOW
//-------------------------------------------------
//Read/GET
var getAllBooks = app.MapGet("/api/books", async (BookContext db) => await db.Books.ToListAsync());
//Read/GET
var getBookById = app.MapGet("api/books/{id}", async (BookContext db, int id) => await db.Books.FindAsync(id));

//Create/POST
var postBook = app.MapPost("/api/books", async (BookContext db, Book book) =>
{
    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();
    Results.Accepted();
});

//Update/Edit
var updateBook = app.MapPut("api/books/{id}", async (BookContext db, int id, Book book) =>
{
    if (id != book.Id) return Results.BadRequest();
    db.Update(book);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


//DELETE
var deleteBookById = app.MapDelete("api/books/{id}", async (BookContext db, int id) =>
{
    var book = await db.Books.FindAsync(id);
    if (book == null) return Results.NotFound();

    db.Books.Remove(book);
    await db.SaveChangesAsync();

    return Results.NoContent();

});


app.Run();
//builder.Services.AddAuthentication();

//builder.Services.AddControllers();

//app.UseEndpoints(endpoints =>
//{
//endpoints.MapDefaultControllerRoute();
//});

//public class TestController : Controller
//{
//    public IActionResult Index()
//    {
//        return Ok("Salam Sidi Asim");
//    }
//}