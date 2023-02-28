using AviaModel.Model;
using AviaModel.Model.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/ping", async(context) =>
{
    await context.Response.WriteAsync("pong");
});

app.MapGet("avia/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Avias.ToListAsync();
});

app.MapGet("mark/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Marks.ToListAsync();
});

app.MapGet("country/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Countries.ToListAsync();
});


app.MapPost("avia/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Avia? avia = await context.Request.ReadFromJsonAsync<Avia>();

    if (avia != null)
    {
        db.Avias.Add(avia);
        db.SaveChanges();
    }
    return avia;
});

app.MapPost("country/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Country? country = await context.Request.ReadFromJsonAsync<Country>();

    if (country != null)
    {
        db.Countries.Add(country);
        db.SaveChanges();
    }
    return country;
});


app.MapPost("mark/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Mark? mark = await context.Request.ReadFromJsonAsync<Mark>();

    if (mark != null)
    {
        db.Marks.Add(mark);
        db.SaveChanges();
    }
    return mark;
});

app.MapPost("avia/update", async (HttpContext context, ApplicationDbContext db) =>
{
    Avia? avia = await context.Request.ReadFromJsonAsync<Avia>();

    if (avia != null)
    {
        db.Avias.Update(avia);
        db.SaveChanges();
    }
    return avia;
});

app.MapPost("mark/update", async (HttpContext context, ApplicationDbContext db) =>
{
    Mark? mark = await context.Request.ReadFromJsonAsync<Mark>();

    if (mark != null)
    {
        db.Marks.Update(mark);
        db.SaveChanges();
    }
    return mark;
});


app.MapPost("country/update", async (HttpContext context, ApplicationDbContext db) =>
{
    Country? country = await context.Request.ReadFromJsonAsync<Country>();

    if (country != null)
    {
        db.Countries.Update(country);
        db.SaveChanges();
    }
    return country;
});



app.MapPost("avia/delete", async (HttpContext context, ApplicationDbContext db) =>
{
    Avia? avia = await context.Request.ReadFromJsonAsync<Avia>();

    if (avia != null)
    {
        db.Avias.Remove(avia);
        db.SaveChanges();
    }
    return avia;
});

app.MapPost("mark/delete", async (HttpContext context, ApplicationDbContext db) => {
    Mark? mark = await context.Request.ReadFromJsonAsync<Mark>();

    if (mark != null)
    {
        db.Marks.Remove(mark);
        db.SaveChanges();
    }
    return mark;
});

app.MapPost("country/delete", async (HttpContext context, ApplicationDbContext db) => {
    Country? country = await context.Request.ReadFromJsonAsync<Country>();

    if (country != null)
    {
        db.Countries.Remove(country);
        db.SaveChanges();
    }
    return country;
});

app.Run();
