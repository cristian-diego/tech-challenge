using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TechChallenge.API.Application.DTOs;
using TechChallenge.API.Configuration;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Interfaces;
using TechChallenge.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure Supabase settings
builder.Services.Configure<SupabaseSettings>(builder.Configuration.GetSection("Supabase"));

// Register services and repositories
builder.Services.AddSingleton<SupabaseConnection>(sp =>
{
    var supabaseSettings = sp.GetRequiredService<IOptions<SupabaseSettings>>().Value;
    return new SupabaseConnection(supabaseSettings.Url, supabaseSettings.ApiKey);
});

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();


app.MapGet("/contact", ([FromServices] IContactService contactService) =>
{
    return contactService.GetContacts();
})
.WithName("GetContacts")
.WithOpenApi();

app.MapGet("/contact/ddd/{ddd}", async (string ddd, [FromServices] IContactService contactService) =>
{
    var contacts = await contactService.GetContactsByDDD(ddd);
    return Results.Ok(contacts);
})
.WithName("GetContactsByDDD")
.WithOpenApi();


app.MapPost("/contact", async ([FromBody] AddContactDto contact, [FromServices] IContactService contactService) =>
{
    await contactService.AddContact(contact);
    return Results.Created();
});

app.Run();

