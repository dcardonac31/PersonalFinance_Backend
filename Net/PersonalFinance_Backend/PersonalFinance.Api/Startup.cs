using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PersonalFinance.Common.ApplicationInsights.ServiceCollections;
using PersonalFinance.Common.Configuration;
using PersonalFinance.Common.Dapper;
using PersonalFinance.Common.Proxy.Helpers;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Domain.Services;
using PersonalFinance.Infraestructure.DataAcces.Context;
using PersonalFinance.Infraestructure.DataAcces.Repository;
using PersonalFinance.Infraestructure.DataAcces.UnitOfWork;

namespace PersonalFinance.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            #region Context SQL Server

            // Inicializa DataConext con la cadena de conexión.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectPersonalFinance"),
                    providerOptions => providerOptions.EnableRetryOnFailure()));

            #endregion Context SQL Server

            #region Register (dependency injection)

            // DataContext de la base de datos.
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<ILogger, Logger<ApplicationDbContext>>();

            // CustomerRepository await UnitofWork parameter ctor explicit
            services.AddScoped<UnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IDapperHelper, DapperHelper>();
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();
            services.AddScoped<IBudgetTypeService, BudgetTypeService>();
            services.AddScoped<IThirdPartyService, ThirdPartyService>();
            services.AddScoped<IDebtService, DebtService>();
            services.AddScoped<IDebtDetailService, DebtDetailService>();
            services.AddScoped<IFinancialMovementService, FinancialMovementService>();
            services.AddScoped<IMonthlyBudgetService, MonthlyBudgetService>();
            services.AddScoped<IMovementTypeService, MovementTypeService>();
            services.AddScoped<ISavingService, SavingService>();
            services.AddScoped<ISavingDetailService, SavingDetailService>();

            // Infrastructure
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            #endregion Register (dependency injection)

            ConfigureCorsService(ref services);

            services.AddApplicationInsightsServiceCollection();

            services.AddDataProtection();

            services.AddBrowserDetection();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PersonalFinance.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonalFinance.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            ConfigureCorsApp(ref app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureCorsService(ref IServiceCollection services)
        {
            // Enables CORS and httpoptions
            services.AddCors(options =>
            {
                options.AddPolicy(CommonConfiguration.EnableCorsName, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.WithHeaders(CommonConfiguration.Authorization, CommonConfiguration.Accept, CommonConfiguration.ContentType, CommonConfiguration.Origin);
                    builder.SetIsOriginAllowed((_) => true);
                });
            });
            services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);
        }

        private void ConfigureCorsApp(ref IApplicationBuilder app)
        {
            app.UseCors(CommonConfiguration.EnableCorsName);
        }
    }
}
