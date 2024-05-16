

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<CapitalProgramDbContext>(opt =>
{
    opt.UseCosmos(
        builder.Configuration["CosmosDbSetting:Account"],
        builder.Configuration["CosmosDbSetting:Key"],
        builder.Configuration["CosmosDbSetting:DatabaseName"]
        );

});
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "allowAllOrigins", policy =>
    {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.ResolveConflictingActions(apides => apides.First()));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployerProgramService, EmployerProgramService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IQuestionServices, QuestionService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalException();
app.UseCors("allowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
