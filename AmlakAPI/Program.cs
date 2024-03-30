

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region //SMS Settings.

//var smsConfig = configuration.GetSection("SMSSettings")
//    .Get<SmsConfiguration>();
//builder.Services.AddScoped<ISmsConfiguration, smsConfig>();

builder.Services.Configure<SmsConfiguration>(builder.Configuration.GetSection("SMSSettings"));



 builder.Services.AddScoped<ISmsService, SmsService>();


#endregion //SMS Settings.

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
