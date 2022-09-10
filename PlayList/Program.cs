using PlayList.DATOS;
using PlayList.DATOS.Repositorios;
using PlayList.NEGOCIO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ICalculo, Calculo>();
builder.Services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
builder.Services.AddScoped<IGeneroNegocio, GeneroNegocio>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
