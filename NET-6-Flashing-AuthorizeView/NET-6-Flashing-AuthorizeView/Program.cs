using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NET_6_Flashing_AuthorizeView.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("TaskDelayPolicy", policy =>
    {
        policy.Requirements.Add(new Requirements.TaskDelayRequirement());
    });

    config.AddPolicy("InstantPolicy", policy =>
    {
        policy.Requirements.Add(new Requirements.InstantRequirement());
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, Handlers.TaskDelayHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, Handlers.InstantHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
