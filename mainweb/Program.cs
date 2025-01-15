/// <summary>
/// Create and configure the builder for the web application.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Add Razor Pages services to the container, enabling the app to use Razor Pages.
/// </summary>
builder.Services.AddRazorPages();

/// <summary>
/// Build the application.
/// </summary>
var app = builder.Build();

/// <summary>
/// Configure the HTTP request pipeline for production and development environments.
/// </summary>
if (!app.Environment.IsDevelopment())
{
    /// <summary>
    /// Use a custom error handler page in non-development environments.
    /// </summary>
    app.UseExceptionHandler("/Error");

    /// <summary>
    /// Enforce HTTP Strict Transport Security (HSTS) for production (recommended to be set for 30 days by default).
    /// More details: https://aka.ms/aspnetcore-hsts
    /// </summary>
    app.UseHsts();
}

/// <summary>
/// Redirect HTTP requests to HTTPS.
/// </summary>
app.UseHttpsRedirection();

/// <summary>
/// Enable the serving of static files (like images, CSS, JS, etc.)
/// </summary>
app.UseStaticFiles();

/// <summary>
/// Enable routing for the app.
/// </summary>
app.UseRouting();

/// <summary>
/// Enable authorization for routing (authorization policies can be applied).
/// </summary>
app.UseAuthorization();

/// <summary>
/// Map Razor Pages endpoints to the app.
/// </summary>
app.MapRazorPages();

/// <summary>
/// Run the application.
/// </summary>
app.Run();
