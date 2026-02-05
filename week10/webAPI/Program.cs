var builder = WebApplication.CreateBuilder(args);

// Add services to the container.(inject your dependencies)


//addxml helps in content neghotioation
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



WebApplication app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// Configure the HTTP request pipeline. these are the middlewares
app.UseHttpsRedirection();

app.UseAuthorization();



//app.Use(async (context, next) =>
//{
//    if (context.Request.Method == "POST")
//    {
//        await next();
//    }
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("req handled by the next middleware");
//});
// now it will not flow to the next middleware

app.MapControllers();

app.Run();
