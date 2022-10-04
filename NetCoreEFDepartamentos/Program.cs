using Microsoft.EntityFrameworkCore;
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
            //ESCRIBIMOS NUESTRA CADENA DE CONEXION
            string connectionString =
                @"Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=12345";
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
