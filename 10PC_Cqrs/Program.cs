using _10PC_Cqrs.AIImplementation;
using _10PC_Cqrs.Context;
using _10PC_Cqrs.CQRSPattern.Handlers.AboutHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.BookingHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.CarHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.EmployeeHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.FeatureHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.LocationHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.MessageHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.ServiceHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.SliderHandlers;
using _10PC_Cqrs.CQRSPattern.Handlers.TestimonialHandlers;
using _10PC_Cqrs.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CqrsContext>();

builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBookingQueryHandler>();
builder.Services.AddScoped<GetBookingByIdQueryHandler>();
builder.Services.AddScoped<CreateBookingCommandHandler>();
builder.Services.AddScoped<UpdateBookingCommandHandler>();
builder.Services.AddScoped<RemoveBookingCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();

builder.Services.AddScoped<GetEmployeeQueryHandler>();
builder.Services.AddScoped<GetEmployeeByIdQueryHandler>();
builder.Services.AddScoped<CreateEmployeeCommandHandler>();
builder.Services.AddScoped<UpdateEmployeeCommandHandler>();
builder.Services.AddScoped<RemoveEmployeeCommandHandler>();

builder.Services.AddScoped<GetFeatureQueryHandler>();
builder.Services.AddScoped<GetFeatureByIdQueryHandler>();
builder.Services.AddScoped<CreateFeatureCommandHandler>();
builder.Services.AddScoped<UpdateFeatureCommandHandler>();
builder.Services.AddScoped<RemoveFeatureCommandHandler>();

builder.Services.AddScoped<GetLocationQueryHandler>();
builder.Services.AddScoped<GetLocationByIdQueryHandler>();
builder.Services.AddScoped<CreateLocationCommandHandler>();
builder.Services.AddScoped<UpdateLocationCommandHandler>();
builder.Services.AddScoped<RemoveLocationCommandHandler>();

builder.Services.AddScoped<GetMessageQueryHandler>();
builder.Services.AddScoped<GetMessageByIdQueryHandler>();
builder.Services.AddScoped<CreateMessageCommandHandler>();
builder.Services.AddScoped<UpdateMessageCommandHandler>();
builder.Services.AddScoped<RemoveMessageCommandHandler>();

builder.Services.AddScoped<GetServiceQueryHandler>();
builder.Services.AddScoped<GetServiceByIdQueryHandler>();
builder.Services.AddScoped<CreateServiceCommandHandler>();
builder.Services.AddScoped<UpdateServiceCommandHandler>();
builder.Services.AddScoped<RemoveServiceCommandHandler>();

builder.Services.AddScoped<GetSliderQueryHandler>();
builder.Services.AddScoped<GetSliderByIdQueryHandler>();
builder.Services.AddScoped<CreateSliderCommandHandler>();
builder.Services.AddScoped<UpdateSliderCommandHandler>();
builder.Services.AddScoped<RemoveSliderCommandHandler>();

builder.Services.AddScoped<GetTestimonialQueryHandler>();
builder.Services.AddScoped<GetTestimonialByIdQueryHandler>();
builder.Services.AddScoped<CreateTestimonialCommandHandler>();
builder.Services.AddScoped<UpdateTestimonialCommandHandler>();
builder.Services.AddScoped<RemoveTestimonialCommandHandler>();

builder.Services.AddScoped<GetTotalBookingsQueryHandler>();
builder.Services.AddScoped<GetTotalCarsQueryHandler>();
builder.Services.AddScoped<GetRecentBookingsQueryHandler>();
builder.Services.AddScoped<GetAverageCarReviewQueryHandler>();
builder.Services.AddScoped<GetCarModelCountQueryHandler>();
builder.Services.AddScoped<GetCarBrandAveragePriceQueryHandler>();
builder.Services.AddScoped<GetLast10BookingsQueryHandler>();
builder.Services.AddScoped<GetCarFuelTypeByModelQueryHandler>();



builder.Services.AddHttpClient<RapidAPIAirportsService>();
builder.Services.AddScoped<HelsinkiNPLTranslation>();
builder.Services.AddScoped<DeepSeekChatService>();
builder.Services.AddHttpClient<DeepSeekChatService>();
builder.Services.AddTransient<RapidAPIFuelPrice>();
builder.Services.AddHttpClient<RapidAPIDistanceAirportsService>();
builder.Services.AddScoped<RapidAPIChatBotService>();
builder.Services.AddScoped<GeminiChatBotService>();



builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
