using Blazored.Toast;
using EcommerceDBProject.Components;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBlazoredToast();


builder.Services.AddScoped<ICommonInterface, CommonService>();
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IInventoryItemInterface, InventoryItemService>();
builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<ISellerInterface, SellerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
