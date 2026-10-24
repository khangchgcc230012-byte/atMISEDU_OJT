using Asp.Versioning;
using atMISEDU.Application.DependencyInjection.Extension;
using atMISEDU.Persistence.DependencyInjection.Extensions;
using atMISEDU.Presentation;

var builder = WebApplication.CreateBuilder(args);

// 1. Dang ky Controllers va Presentation Assembly
builder.Services.AddControllers()
                .AddApplicationPart(typeof(AssemblyReference).Assembly);

// 2. Dang ky API Versioning (Fix loi constraint 'apiVersion')
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// 3. Dang ky Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. Dang ky cac tang Clean Architecture
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// 5. Cấu hình Middleware Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "atMISEDU API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();