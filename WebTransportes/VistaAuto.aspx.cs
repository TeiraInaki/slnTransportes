using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Datos;
using Entidades;

namespace WebTransportes
{
    public partial class VistaAuto : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarCombos();
                llenarGrid();
            }            
        }

        private void llenarCombos()
        {
            DataTable dt = AdmAuto.ListarMarcas();
            ddlMarca.DataSource = dt;
            ddlMarca.DataTextField = dt.Columns["Marca"].ToString();
            ddlMarca.DataValueField = dt.Columns["Marca"].ToString();
            ddlMarca.DataBind();

            DataTable dt2 = AdmAuto.ListarMarcas();

            DataRow Todas = dt2.NewRow();
            Todas["Marca"] = "[TODAS]";

            dt2.Rows.InsertAt(Todas,0);

            ddlBuscarPorMarca.DataSource = dt2;
            ddlBuscarPorMarca.DataTextField = dt2.Columns["Marca"].ToString();
            //ddlBuscarPorMarca.DataValueField = dt2.Columns["Marca"].ToString();
            ddlBuscarPorMarca.DataBind();
        }

        private void llenarGrid()
        {
            gridAutos.DataSource = AdmAuto.Listar();
            gridAutos.DataBind();
        }

        private void llenarGrid(string Marca)
        {
            gridAutos.DataSource = AdmAuto.Listar(Marca);
            gridAutos.DataBind();
        }

        protected void ddlBuscarPorMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

            string marca = ddlBuscarPorMarca.SelectedValue;

            if (marca == "[TODAS]")
            {
                llenarGrid();
            }
            else
            {
                llenarGrid(marca);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                Marca=ddlMarca.SelectedValue,
                Modelo=txtModelo.Text,
                Matricula=txtMatricula.Text,
                Precio=Convert.ToInt32(txtPrecio.Text)
            };

            int filasAfectadas = AdmAuto.Insertar(auto);

            if (filasAfectadas>0)
            {
                llenarGrid();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                Marca = ddlMarca.SelectedValue,
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToInt32(txtPrecio.Text),
                Id = Convert.ToInt32(txtId.Text)
            };

            int filasAfectadas = AdmAuto.Modificar(auto);

            if (filasAfectadas > 0)
            {
                llenarGrid();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text);

            int filasAfectadas = AdmAuto.Eliminar(Id);

            if (filasAfectadas > 0)
            {
                llenarGrid();
            }
        }

       
    }
}