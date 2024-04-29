using Blazored.Toast;
using EcommerceDBProject.Components;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;
using Syncfusion.Blazor;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IProductInterface, ProductService>();
builder.Services.AddScoped<ISellerInterface, SellerService>();
builder.Services.AddScoped<IOrderInterface, OrderService>();
builder.Services.AddScoped<IOrderReturnReviewInterface, OrderReturnReviewService>();
builder.Services.AddScoped<ICommonInterface, CommonService>();
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IInventoryItemInterface, InventoryItemService>();

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
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
                "NzE3NDUyQDMyMzAyZTMyMmUzMFNuelhLb0dOVlgxMSsxMUdZMTJlaWdKTjJFV3ZvV2FvRHpGdmR6MjZ6Mms9");