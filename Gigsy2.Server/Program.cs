using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Gigsy2.Data;
using Gigsy2.Data.Entities.User;
using Gigsy2.Server.Components;
using Gigsy2.Server.Components.Account;
using Microsoft.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Resources
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Localisation
var supportedCultures = new[] { "en", "es-ES" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

// Identity stuff
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

// Authentication 
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

// Database stuff
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Gigsy2DbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Link up Identity
builder.Services.AddIdentityCore<Gigsy2User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Gigsy2DbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// No-op email sender, for demo purposes only
builder.Services.AddSingleton<IEmailSender<Gigsy2User>, IdentityNoOpEmailSender>();

//
//
// Build everything
var app = builder.Build();
//
//

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Use localisation
app.UseRequestLocalization(localizationOptions);

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Static files, including the _framework files for Blazor
app.UseStaticFiles();
app.UseAntiforgery();

// Adds routing capabilities
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
