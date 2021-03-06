using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amor.API.Infrastructure.AutoMapper;
using Amor.API.Infrastructure.Extensions;
using Amor.Application.Services;
using Amor.Core.Interfaces;
using Amor.Infrastructure.Persistence;
using Amor.Infrastructure.Persistence.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Amor.API
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
            services.AddControllers()
                .AddFluentValidation(s =>
                {
                    s.RegisterValidatorsFromAssemblyContaining<Startup>();
                    s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            ConfigureJWT(services);

            ConfigureInjectionDependency(services);

            ConfigureDbContext(services);

            ConfigureAutoMapper(services);

            services.AddSwaggerDocumentation();
        }

        public void ConfigureJWT(IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });
        }

        public void ConfigureInjectionDependency(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHomelessRepository, HomelessRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IOngRepository, OngRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventParticipantsRepository, EventParticipantsRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<ISupporterRepository, SupporterRepository>();
            services.AddScoped<ICoreRepository, CoreRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHomelessService, HomelessService>();
            services.AddScoped<IOngService, OngService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICoreService, CoreService>();
        }

        public void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<AmorAppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfileConfiguration>(), typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
