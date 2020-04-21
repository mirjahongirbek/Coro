using AuthModel;
using AuthModel.Interfaces;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Entity.Db;
using Entity.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoAuthService.Services;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using RepositoryCore.Interfaces;
using System;

namespace Commutator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            AuthService.AuthOptions.AddAuthSolutionService(services, "");
            services.AddHttpContextAccessor();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            AuthModalOption.CheckDeviceId = false;
            services.AddScoped<IRoleRepository<Role, string>, MongoRoleService<Role>>();
            services.AddScoped<IUserRoleRepository<User, Role, UserRole, string>, MongoUserRoleService<User, Role, UserRole>>();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            
            Service.Start.Builder(builder);
            SendRequest.Start.Builder(builder);
       

            builder.RegisterType<MongoContext>().As<IMongoContext>().WithParameter("connectionString", "mongodb://superAdmin:admin123@192.168.45.94:27017");
            builder.RegisterGeneric(typeof(MongoRepository<>)).As(typeof(IRepositoryCore<,>)).InstancePerDependency();
            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder => builder
              .WithOrigins("*")
              .AllowAnyMethod()
              .AllowAnyHeader());
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
