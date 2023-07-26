using EmptyProject.Filters;
using EmptyProject.Services;
using Microsoft.Extensions.FileProviders;

namespace EmptyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IServiceA, ServiceA1>();
            builder.Services.AddScoped<IServiceB, ServiceB>();
            builder.Services.AddScoped<SimpleActionFilter>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddMvc(options=> {
               // options.Filters.Add<SimpleActionFilter>();
            });
            var app = builder.Build();


            //  
           


            app.MapDefaultControllerRoute();
            

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
                RequestPath="/files"
            });

            app.UseStaticFiles();


            //app.Map("/map", (map) => {



            //    map.Use((context ,next) =>
            //    {

            //        context.Response.WriteAsync("Welcome from  map branch");

                   
            //        return next?.Invoke(context);
            //    }
            //    );

            //   // app.MapGet("/map/test101", () => "Hello World!");

            //});


            //app.Use((context, next) => {

            //    // how to  get  instance of service for midleware
            //   var  serviceA= app.Services.GetService<IServiceA>();
            //    context.Response.WriteAsync(serviceA.GetMsg());

            //    return next.Invoke();

            //});

            //app.Use( (context, next) => {

            //   // Thread.Sleep(1000);
            //    // how to  get  instance of service for midleware
            //    var serviceB = app.Services.GetService<IServiceB>();
            //    context.Response.WriteAsync(serviceB.GetMsg());

            //    return next.Invoke();

            //});

            //app.Use((context, next) => {


            //    context.Response.WriteAsync("Use Midleware  ");

            //    return next.Invoke();
            
            //});


            //app.Run((context) => context.Response.WriteAsync("Run Midleware !!"));




            app.Run();
        }
    }
}