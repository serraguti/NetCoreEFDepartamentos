using NetCoreEFDepartamentos.Models;
using NetCoreEFDepartamentos.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreEFDepartamentos
{
    public partial class Form1 : Form
    {
        //NECESITAMOS EL REPOSITORIO PARA PODER RECUPERAR
        //LOS DATOS
        //EL REPOSITORIO IRA CON INYECCION DE DEPENDENCIAS
        private RepositoryDepartamentos repo;

        //INYECTAMOS EL REPOSITORIO
        public Form1(RepositoryDepartamentos repo)
        {
            InitializeComponent();
            //RESOLVEMOS LAS DEPENDENCIAS
            this.repo = repo;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //RECUPERAMOS LOS DATOS DE DEPARTAMENTOS DESDE EL 
            //REPOSITORIO
            List<Departamento> departamentos =
                this.repo.GetDepartamentos();
            //DIBUJAMOS EN LA LISTA LA COLECCION DE DEPARTAMENTOS
            this.lstDepartamentos.Items.Clear();
            foreach (Departamento dept in departamentos)
            {
                string datos = dept.Numero + " - " + dept.Nombre + " - " + dept.Localidad;
                this.lstDepartamentos.Items.Add(datos);
            }
        }
    }
}
