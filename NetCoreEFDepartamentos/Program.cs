using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreEFDepartamentos.Data;
using NetCoreEFDepartamentos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreEFDepartamentos
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //DEBEMOS RECUPERAR EL FICHERO DE CONFIGURACION DE LA APP
            //AÑADIMOS EL NOMBRE DEL FICHERO A NUESTRA APP
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            //GENERAMOS EL FICHERO DE CONFIGURACION
            var configuration = builder.Build();
            //RECUPERAMOS NUESTRA CADENA DE CONEXION
            string connectionString =
                configuration.GetConnectionString("HospitalSQLServer");
            //PARA RESOLVER LAS DEPENDENCIAS (IoC) NECESITAMOS 
            //UN PROVEEDOR QUE SE LLAMA ServiceCollection
            //LOS REPOSITORIOS SIEMPRE DEBEN SER Transient
            var provider = new ServiceCollection()
                .AddTransient<RepositoryDepartamentos>()
                .AddDbContext<DepartamentosContext>
                (options => options.UseSqlServer(connectionString))
                .AddSingleton<Form1>()
                .BuildServiceProvider();
            //RECUPERAMOS LA CLASE FORM QUE ESTA EN LA APLICACION
            //PARA PODER LANZARLA EN EL MAIN
            var form = provider.GetService<Form1>();
            //LANZAMOS LA APLICACION CON NUESTRO FORMULARIO DE IoC
            Application.Run(form);
        }
    }
}
