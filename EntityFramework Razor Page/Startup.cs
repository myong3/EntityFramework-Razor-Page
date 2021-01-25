using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework_Razor_Page.Models.dbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntityFramework_Razor_Page
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
            services.AddRazorPages();
            //���U DB Context�A���w�ϥ� SQL ��Ʈw
            services.AddDbContextPool<JournalDBContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                //�z�L�غc���Ѽƨ��o DBContext (�̿�`�J�[�c���зǰ��k)
                JournalDBContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            //�ˬd��ƪ�O�_�w�g�s�b�A�Y���s�b�۰ʫإߡF�Y��ƪ�s�b���������²ūh�۰ʧ�s�C
            //�b�������Ҧ۰ʧ�sSchema���I�i�ȡA�ڥ[�F���wLocalDB���檺�w����
            if (dbContext.Database.GetDbConnection().ConnectionString.Contains("MSSQLLocalDB"))
            {
                dbContext.Database.Migrate();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
