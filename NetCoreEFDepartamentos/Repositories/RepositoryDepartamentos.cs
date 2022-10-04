using NetCoreEFDepartamentos.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NetCoreEFDepartamentos.Models;

namespace NetCoreEFDepartamentos.Repositories
{
    public class RepositoryDepartamentos
    {
        //UN REPOSITORY REALIZA LAS CONSULTAS LINQ SOBRE UN 
        //CONTEXT, CON LO CUAL, DEBEMOS INYECTAR EL CONTEXT
        //DENTRO DE LA CLASE REPOSITORY
        private DepartamentosContext context;
        
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        //AQUI TENDREMOS TODOS LOS METODOS PARA CONSUMIR LAS TABLAS DE BBDD
        //QUEREMOS DEVOLVER UN CONJUNTO DE DEPARTAMENTOS, ES DECIR, UNA 
        //COLECCION DE DEPARTAMENTOS CON LINQ
        public List<Departamento> GetDepartamentos()
        {
            //LAS CONSULTAS LINQ SON ALMACENADAS DENTRO DE 
            //VARIABLES GENERICAS  (var)
            var consulta = from datos in context.Departamentos
                           select datos;
            return consulta.ToList();
        }
    }
}
