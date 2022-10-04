using Microsoft.EntityFrameworkCore;
using NetCoreEFDepartamentos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreEFDepartamentos.Data
{
    //UNA CLASE CONTEXT DEBE HEREDAR DE DbContext
    public class DepartamentosContext: DbContext
    {
        //NECESITAMOS TAMBIEN UN CONSTRUCTOR QUE RECIBIRA LAS 
        //OPCIONES DE LA BASE DE DATOS, INCLUIDA LA CADENA DE CONEXION
        //A DICHA BASE DE DATOS
        //PARA ELLO, SE REALIZA CON INYECCION DE DEPENDENCIAS
        public DepartamentosContext
            (DbContextOptions<DepartamentosContext> options): base(options)
        {}

        //NECESITAMOS UN DBSET POR CADA TABLA QUE VAYAMOS A CONSUMIR
        //DE LA BASE DE DATOS
        //EL DbSet ES OBLIGATORIO QUE SEA UNA PROPIEDAD
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
