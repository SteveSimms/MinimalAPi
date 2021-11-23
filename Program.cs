using MinimalAPi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc;

// Establishing A web applicatiom
var builder = WebApplication.CreateBuilder(args);
//Configure Services
// establishing DbContext through builder method
builder.Services.AddDbContext<BookContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors();

var app = builder.Build();
// Setting CORS POLICY 
app.UseCors(bldr => bldr
   .WithOrigins("http://localhost:3000")
   .AllowAnyHeader()
   .AllowAnyMethod()
   .AllowCredentials()
    );
//Using Routing and Serving SPA as static File and pointiing to index.html as the static (fall back) file to be served
app.UseRouting();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");
//MapGet uses endpoints
app.MapGet("/", () => "Hello Multiverse!");
var test = app.MapGet("/test", () => "Salam Sidi Asim");


//Need to organize config and services need to estab lish cors policy

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
//API (In place of controllers)CRUD OPS BELOW
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


//POST image 
//var postBook = app.MapPost("/api/books", async (BookContext db, Book book, IImageService imageservice) =>
//{

//    if (book.ImageFile != null)
//    {
//        book.ImageData = await imageservice.ConvertFileToByteArrayAsync(book.ImageFile);
//        book.ImageType = book.ImageFile.ContentType;
//    }
//    await db.Books.AddAsync(book);
//    await db.SaveChangesAsync();
//    Results.Accepted();
//});



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
//public interface IImageService
//{
//    public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);

//    public string ConvertByteArrayToFile(byte[] fileData, string extension);
//}


//builder.Services.AddAuthentication();



