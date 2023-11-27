using libreriaC.libreriaDataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace libreriaC
{
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private int IDuser = 0,tipo_User=0;
        private string con="";
        private int modCategoria=0;
        private string modEditorial = "";
        private int modCliente = 0;
        private int modPago = 0;
        private int modDepartamento = 0;
        private int modPuesto = 0;
        private int modFormato = 0;
        private string modLibro = "";
        private string modAutor = "";
        private int modUsuario = 0;
        private string modcon = "";
        private int modVenta = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreoLogin.Text)) {
                txtCorreoLogin.Select();
                MessageBox.Show("Favor de llenar todos los campos solicitados");
            }
            else if (string.IsNullOrEmpty(txtContraLogin.Text)) {
                txtContraLogin.Select();
                MessageBox.Show("Favor de llenar todos los campos solicitados");
            }
            else {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        string consulta = "Select Id_Usuario,Id_Tipo_Usuario from Usuario where Email='" + txtCorreoLogin.Text + "'and Contraseña='" + Encriptado(txtContraLogin.Text) + "'";

                    cmd = new SqlCommand(consulta, sql);
                    SqlDataReader lector;
                    lector = cmd.ExecuteReader();
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            IDuser = (int)lector[0];
                            tipo_User = (int)lector[1];
                            MessageBox.Show("Se inicio la sesion");
                        }
                        if (tipo_User == 1)
                        {
                            Menu.Enabled = true;
                            Menu.Visible = true;
                        }
                        else
                        {
                            UsuariosToolStripMenuItem.Visible = false;
                            UsuariosToolStripMenuItem.Enabled = false;
                            CatalogosToolStripMenuItem.Visible = false;
                            CatalogosToolStripMenuItem.Visible = false;
                            Menu.Enabled = true;
                            Menu.Visible = true;
                        }
                        txtContraLogin.Clear();
                        PanelLogin.Enabled = false;
                        PanelLogin.Visible = false;
                        LogsAceptable("Iniciar Sesion", "Logs");

                    }
                    else
                    {
                        txtContraLogin.Clear();
                        txtCorreoLogin.Clear();
                        MessageBox.Show("El usuario no existe o datos incorrectos");
                    }
                    
                }
                }
                catch(Exception ex) { MessageBox.Show("Error en conexion"); }
            }
        }
        private string Encriptado(string co)
        {
            using (var sha256 = new SHA256Managed())
            {
                return BitConverter.ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(co))).Replace("-", "");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {            
            cerrarPaneles();
            Menu.Visible=false;
            Menu.Enabled=false;
            PanelLogin.Enabled = true;
            PanelLogin.Visible= true;
        }
        private void LogsAceptable(string accion,string tabla ) {
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    cmd = new SqlCommand("CreateLogs", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id_Usuario", IDuser));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Hora", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Accion", accion));
                    cmd.Parameters.Add(new SqlParameter("@Tabla", tabla));
                    cmd.Parameters.Add(new SqlParameter("@Estatus", 1));
                    cmd.Parameters.Add(new SqlParameter("@Id_Nivel", 1));
                    cmd.ExecuteReader();
                }

            }
            catch (Exception ex)
            {
            }
        }
        private void Label4_Click(object sender, EventArgs e)
        {

        }
        private void cerrarPaneles() {
            PanelRegistra.Enabled  = false;
            PanelRegistra.Visible= false;
            PanelCateEditor.Visible = false;
            PanelCateEditor.Enabled = false;
            gbCategoria.Enabled = false;
            gbCategoria.Visible = false;
            gbEditorial.Visible = false;
            gbEditorial.Enabled = false;
            pTiClienteTiPago.Enabled = false;
            pTiClienteTiPago.Visible = false;
            gbClientes.Visible = false;
            gbClientes.Enabled = false;
            gpPago.Visible = false;
            gpPago.Enabled = false;
            PanelDepartamentosPuestos.Visible = false;
            PanelDepartamentosPuestos.Enabled = false;
            gbPuestos.Enabled = false;
            gbPuestos.Visible = false;
            gbDepartamento.Enabled = false;
            gbDepartamento.Visible = false;
            panelLibrosFormatos.Enabled = false;
            panelLibrosFormatos.Visible = false;
            gbFormato.Enabled = false;
            gbFormato.Visible = false;
            panelLibros.Enabled = false;
            panelLibros.Visible = false;
            PanelAutor.Enabled = false;
            PanelAutor.Visible = false;
            panelUsuarioAM.Enabled = false;
            panelUsuarioAM.Visible = false;
            panelVentaRegistro.Enabled = false;
            panelVentaRegistro.Visible = false;
            PanelDetalleVenta.Enabled = false;
            PanelDetalleVenta.Visible = false;
            PanelVentas.Enabled = false;
            PanelVentas.Visible = false;
            PanelUsuarios.Enabled = false;
            PanelUsuarios.Visible = false;
            PanelHistorial.Enabled = false;
            PanelHistorial.Visible = false;
            PanelAutorAM.Enabled = false;
            PanelAutorAM.Visible = false;
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            Menu.Visible = false;
            Menu.Enabled= false;
            MessageBox.Show("Sesión cerrada");
            PanelLogin.Enabled = true;
            PanelLogin.Visible = true;
            txtContraLogin.Clear();
            txtCorreoLogin.Clear();
            IDuser = 0;
            tipo_User = 0;
            
        }
        private void txtContraMiCuenta_Enter(object sender, EventArgs e)
        {
            txtContraMiCuenta.Text = "";
        }
        private void btnGuardarReg_Click(object sender, EventArgs e)
        { 
            if (!(string.IsNullOrEmpty(txtContraMiCuenta.Text) || string.IsNullOrWhiteSpace(txtContraMiCuenta.Text)) && !(txtContraMiCuenta.Text.Equals(con)))
            {
                con = Encriptado(txtContraMiCuenta.Text);
            }
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    string consulta = "update Usuario set Nombre_Usuario='" + txtUsuarioMiCuenta.Text + "',Nombre='" + txtNombreMiCuenta.Text + "'," +
                    "Contraseña='" + con + "',Apellido_Paterno='" + txtApellidoPMiCuenta.Text + "',Apellido_Materno='" + txtApellidoMMiCuenta.Text +
                    "',Email='" + txtCorreoMiCuenta.Text + "',Telefono='" + txtTelefMiCuenta.Text + "',Id_Usuario_Modificacion=" + IDuser.ToString() +
                    ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") +
                    "' where Id_Usuario=" + IDuser.ToString();

                    cmd = new SqlCommand(consulta, sql);
                    cmd.ExecuteReader();
                    PanelRegistra.Visible = true;
                    PanelRegistra.Enabled = true;
                    LogsAceptable("Modificar mi perfil", "Usuario");
                    sql.Close();
                    MessageBox.Show("Guardado");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error en conexion"); }


        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void btnAgregCate_Click(object sender, EventArgs e)
        {
            gbCategoria.Visible = true;
            gbCategoria.Enabled=true;
            gbCategoria.BringToFront();
            txtUpCreNombreCat.Text = "";
            ckbCat.Checked = true;
            modCategoria = 0;

        }
        private void btnUpdCat_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count == 1) {
                modCategoria =(int) dgvCategoria.SelectedCells[0].Value;
                txtUpCreNombreCat.Text = (string)dgvCategoria.SelectedCells[1].Value;
                if ((bool)dgvCategoria.SelectedCells[2].Value) {
                ckbCat.Checked = true;
                }
                else {
                    ckbCat.Checked = false;
                }
                gbCategoria.Visible = true;
                gbCategoria.Enabled = true;
                gbCategoria.BringToFront();
            }
            else { MessageBox.Show("Seleccione una categoria."); }
        }
        private void recargaCatalogoCategoria() {
            DataTable dt = new DataTable();
            try {
                using (SqlConnection sql= new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd= new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Categoria,Nombre,Estatus from Categoria";
                        using (SqlDataAdapter da =new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dgvCategoria.DataSource = dt;
            
            //dgvCategoria.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCategoria.Columns["Id_Categoria"].Visible = false;
            dgvCategoria.Columns["Estatus"].Visible = false;
        }
        private void recargaCatalogoEditorial()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT e.Nombre AS Editorial, e.Año_Inauguracion, e.Id_Ciudad, c.Nombre AS Ciudad,  es.Nombre AS Estado, p.Nombre AS Pais, c.Id_Estado, es.Id_Pais, e.Id_Editorial, e.Estatus FROM Editorial e INNER JOIN Ciudad c ON e.Id_Ciudad = c.Id_Ciudad INNER JOIN Estado es ON c.Id_Estado = es.Id_Estado INNER JOIN Pais p ON es.Id_Pais = p.Id_Pais";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvEditorial.DataSource = dt;

            //dgvEditorial.Columns["Editorial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEditorial.Columns["Id_Ciudad"].Visible = false;
            dgvEditorial.Columns["Id_Estado"].Visible = false;
            dgvEditorial.Columns["Id_Pais"].Visible = false;
            dgvEditorial.Columns["Id_Editorial"].Visible = false;
            dgvEditorial.Columns["Estatus"].Visible = false;
        }
        private void recargaCatalogoTipoCliente()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "  select Id_Tipo_Cliente,Nombre,Estatus from Tipo_Cliente";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgCliente.DataSource = dt;

            dgCliente.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgCliente.Columns["Id_Tipo_Cliente"].Visible = false;
            dgCliente.Columns["Estatus"].Visible = false;
        }
        private void recargaHistorial() {
                DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select l.Fecha_Hora,u.Nombre_Usuario,concat(u.Nombre, ' ', u.Apellido_Paterno, ' ', u.Apellido_Materno) Nombre_Completo,l.Accion, l.Tabla,n.Valor from Logs l left join Usuario u on l.Id_Usuario = u.Id_Usuario left join Nivel n on l.Id_Nivel = n.Id_Nivel order by l.Fecha_Hora";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvHistorial.DataSource = dt;

        }
        private void recargaCatalogoTipoPago()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Tipo_Pago,Nombre,Estatus from Tipo_Pago";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvPago.DataSource = dt;

            dgvPago.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPago.Columns["Id_Tipo_Pago"].Visible = false;
            dgvPago.Columns["Estatus"].Visible = false;
        }
        private void recargaCatalogoTipoFormato()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Tipo_Formato,Nombre,Estatus from Tipo_Formato";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvFormatos.DataSource = dt;

            dgvFormatos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFormatos.Columns["Id_Tipo_Formato"].Visible = false;
            dgvFormatos.Columns["Estatus"].Visible = false;
        }
        private void recargaCatalogoAutor()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select a.Id_Autor,a.Nombre,a.Apellido,CONCAT(a.Nombre,' ',a.Apellido) Nombre_Completo,a.Fecha_Nacimiento,a.Id_Pais,p.Nacionalidad,a.Estatus from Autor a left join Pais p on a.Id_Pais=p.Id_Pais";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvAutor.DataSource = dt;

            //dgvAutor.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAutor.Columns["Id_Autor"].Visible = false;
            dgvAutor.Columns["Nombre"].Visible = false;
            dgvAutor.Columns["Apellido"].Visible = false;
            dgvAutor.Columns["Id_Pais"].Visible = false;
            dgvAutor.Columns["Estatus"].Visible = false;
        }
        private void recargaCatalogoLibro()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select l.Id_Libro_ISBN,l.Titulo,l.Id_Categoria,c.Nombre Categoria,isnull(l.Volumen,'') Volumen,l.Id_Tipo_Formato,f.Nombre Formato,l.Id_Editorial, e.Nombre Editorial,isnull(l.Fecha_Publicacion,'') [Fecha de publicacion],isnull(l.Paginas,'') Paginas,l.Precio,l.Id_Rating,r.Valor Rating,l.Estatus from Libro l left join Categoria c on l.Id_Categoria=c.Id_Categoria left join Tipo_Formato f on l.Id_Tipo_Formato=f.Id_Tipo_Formato left join Editorial e on l.Id_Editorial= e.Id_Editorial left join Rating r on l.Id_Rating=r.Id_Rating\r\n";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvLibros.DataSource = dt;

            dgvLibros.Columns["Id_Libro_ISBN"].Visible = false;
            dgvLibros.Columns["Id_Categoria"].Visible = false;
            dgvLibros.Columns["Id_Tipo_Formato"].Visible = false;
            dgvLibros.Columns["Id_Editorial"].Visible = false;
            dgvLibros.Columns["Id_Rating"].Visible = false;
            dgvLibros.Columns["Estatus"].Visible = false;
        }
        private void recargaCatalogoDepartamento()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Departamento,Departamento,Estatus from Departamento";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvDepartamentos.DataSource = dt;

            dgvDepartamentos.Columns["Departamento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDepartamentos.Columns["Id_Departamento"].Visible = false;
            dgvDepartamentos.Columns["Estatus"].Visible = false;
        }
        private void recargaCatalogoUsuario()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select u.Id_Usuario,u.Nombre_Usuario,u.Nombre,u.Contraseña,u.Apellido_Paterno,u.Apellido_Materno,u.Email,u.Telefono,u.Id_Puesto,p.Nombre Puesto,u.Id_Departamento,d.Departamento,u.Id_Tipo_Usuario,t.Nombre [Tipo de Usuario],u.Estatus from Usuario u left join Puesto p on u.Id_Puesto=p.Id_Puesto left join Departamento d on u.Id_Departamento=d.Id_Departamento left join Tipo_Usuario t on u.Id_Tipo_Usuario=t.Id_Tipo_Usuario\r\n";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvUsuarios.DataSource = dt;
            dgvUsuarios.Columns["Id_Usuario"].Visible = false;
            dgvUsuarios.Columns["Contraseña"].Visible = false;
            dgvUsuarios.Columns["Id_Puesto"].Visible = false;
            dgvUsuarios.Columns["Id_Departamento"].Visible = false;
            dgvUsuarios.Columns["Id_Tipo_Usuario"].Visible = false;
            dgvUsuarios.Columns["Estatus"].Visible = false;
        }
        private void recargaCatalogoPuestos()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Puesto,Nombre,Estatus from Puesto";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvPuestos.DataSource = dt;

            dgvPuestos.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPuestos.Columns["Id_Puesto"].Visible = false;
            dgvPuestos.Columns["Estatus"].Visible = false;
        }
        private void cargacombosUsuarios()
        {
            DataTable t = new DataTable();
            DataTable de = new DataTable();
            DataTable p = new DataTable();
            
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Tipo_Usuario, Nombre from Tipo_Usuario";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(t);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbTipoUsuarioUAM.DataSource = t;
            cbTipoUsuarioUAM.DisplayMember = "Nombre";
            cbTipoUsuarioUAM.ValueMember = "Id_Tipo_Usuario";
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Departamento,Departamento from Departamento where Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(de);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbDepartamentoUAM.DataSource = de;
            cbDepartamentoUAM.DisplayMember = "Departamento";
            cbDepartamentoUAM.ValueMember = "Id_Departamento";
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Puesto,Nombre from Puesto where Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(p);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbPuestoUAM.DataSource = p;
            cbPuestoUAM.DisplayMember = "Nombre";
            cbPuestoUAM.ValueMember = "Id_Puesto";

        }
        private void cargaCombosVentaLibros()
        {
            DataTable l = new DataTable();
            DataTable c = new DataTable();
            DataTable p = new DataTable();

            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select l.Id_Libro_ISBN,CONCAT(l.Titulo,', ',f.Nombre) Nombre from Libro l left join Tipo_Formato f on l.Id_Tipo_Formato=f.Id_Tipo_Formato where l.Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(l);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbLibrosCaja.DataSource = l;
            cbLibrosCaja.DisplayMember = "Nombre";
            cbLibrosCaja.ValueMember = "Id_Libro_ISBN";
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Tipo_Cliente,Nombre from Tipo_Cliente where Estatus=1\r\n";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(c);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbClienteCaja.DataSource = c;
            cbClienteCaja.DisplayMember = "Nombre";
            cbClienteCaja.ValueMember = "Id_Tipo_Cliente";
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Tipo_Pago,Nombre from Tipo_Pago where Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(p);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbPagoCaja.DataSource = p;
            cbPagoCaja.DisplayMember = "Nombre";
            cbPagoCaja.ValueMember = "Id_Tipo_Pago";
        }
        private void cargacombosLibros() {
            DataTable cat = new DataTable();
            DataTable Ed = new DataTable();
            DataTable ra = new DataTable();
            DataTable fo = new DataTable();
            DataTable au = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Categoria,Nombre from Categoria where Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(cat);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbCategoriaLibro.DataSource = cat;
            cbCategoriaLibro.DisplayMember = "Nombre";
            cbCategoriaLibro.ValueMember = "Id_Categoria";
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Editorial,Nombre from Editorial where Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(Ed);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbEditorialLibro.DataSource = Ed;
            cbEditorialLibro.DisplayMember = "Nombre";
            cbEditorialLibro.ValueMember = "Id_Editorial";
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Rating,Valor from Rating where Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ra);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbRatingLibro.DataSource = ra;
            cbRatingLibro.DisplayMember = "Valor";
            cbRatingLibro.ValueMember = "Id_Rating";
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Tipo_Formato,Nombre from Tipo_Formato where Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(fo);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbFormatoLibro.DataSource = fo;
            cbFormatoLibro.DisplayMember = "Nombre";
            cbFormatoLibro.ValueMember = "Id_Tipo_Formato";
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select a.Id_Autor,CONCAT(a.Nombre,' ',a.Apellido) Nombre_Completo from Autor a where a.Estatus=1\r\n";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(au);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbAutoresLibro.DataSource = au;
            cbAutoresLibro.DisplayMember = "Nombre_Completo";
            cbAutoresLibro.ValueMember = "Id_Autor";
        }
        private void CategoriasYEditorialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            PanelCateEditor.Visible = true;
            PanelCateEditor.Enabled= true;
            recargaCatalogoCategoria();
            recargaCatalogoEditorial();
        }
        private void btnElimCate_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteCategoria", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvCategoria.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Categoria", "Categoria");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoCategoria();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }

            }
            else { MessageBox.Show("Seleccione una categoria."); }
        }
        private void btnUpdEdit_Click(object sender, EventArgs e)
        {
            if (dgvEditorial.SelectedRows.Count == 1)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = sql;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "SELECT c.Id_Ciudad, concat(c.Nombre,', ',es.Nombre,', ',p.Nombre) as localizacion FROM Ciudad c  INNER JOIN Estado es ON c.Id_Estado = es.Id_Estado INNER JOIN Pais p ON es.Id_Pais = p.Id_Pais";
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                        sql.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string año = "2023";
                if (!string.IsNullOrEmpty((string)dgvEditorial.SelectedCells[1].Value)) {
                    año = (string)dgvEditorial.SelectedCells[1].Value;
                }
                cbCiudadEditorial.DataSource = dt;
                cbCiudadEditorial.DisplayMember = "localizacion";
                cbCiudadEditorial.ValueMember = "Id_Ciudad";
                cbCiudadEditorial.SelectedValue= (int)dgvEditorial.SelectedCells[2].Value;
                modEditorial = (string)dgvEditorial.SelectedCells[8].Value;
                txtNombreEditorial.Text = (string)dgvEditorial.SelectedCells[0].Value;
                dtañoinaguracionEditorial.Value=new DateTime(Convert.ToInt32(año),1,1);
                if ((bool)dgvEditorial.SelectedCells[9].Value)
                {
                    chkEditorial.Checked = true;
                }
                else
                {
                    chkEditorial.Checked = false;
                }
                gbEditorial.Visible = true;
                gbEditorial.Enabled = true;
                gbEditorial.BringToFront();
            }
            else { MessageBox.Show("Seleccione una Editorial."); }
        }
        private string SiglaEditExis(string nombre) {
            string siglas = "";
            for (int i=0; i<nombre.Length-1;i++) {
                if (i == 0) {
                    siglas = siglas + nombre.Substring(i, 1);
                }
                if (nombre.Substring(i,1).Equals(" ")){
                    siglas = siglas + nombre.Substring(i+1, 1);
                }
            }
            if (siglas.Length > 3){
                siglas = siglas.Substring(0, 3);
            }
            return siglas.ToUpper();
        }
        private void btnElimEdit_Click(object sender, EventArgs e)
        {
            if (dgvEditorial.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteEditorial", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvEditorial.SelectedCells[8].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Editorial", "Editorial");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoEditorial();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione una Editorial."); }
        }
        private void btnAgregaEdit_Click(object sender, EventArgs e)
        {
            gbEditorial.Visible = true;
            gbEditorial.Enabled = true;
            gbEditorial.BringToFront();
            txtNombreEditorial.Text = "";
            dtañoinaguracionEditorial.Value = DateTime.Now;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT c.Id_Ciudad, concat(c.Nombre,', ',es.Nombre,', ',p.Nombre) as localizacion FROM Ciudad c  INNER JOIN Estado es ON c.Id_Estado = es.Id_Estado INNER JOIN Pais p ON es.Id_Pais = p.Id_Pais";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbCiudadEditorial.DataSource = dt;
            cbCiudadEditorial.DisplayMember = "localizacion";
            cbCiudadEditorial.ValueMember = "Id_Ciudad";

            chkEditorial.Checked = true;
            modEditorial = "0";
        }
        private void categ0ToolStripButton_Click(object sender, EventArgs e)
        {

        }
        private void btnGuarModCat_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtUpCreNombreCat.Text) || string.IsNullOrWhiteSpace(txtUpCreNombreCat.Text)) {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string a = "0";
                if (ckbCat.Checked)
                {
                    a = "1";
                }
                if (modCategoria == 0)
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            cmd = new SqlCommand("CreateCategoria", sql);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Nombre", txtUpCreNombreCat.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Categoria", "Categoria");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbCategoria.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            string consulta = "Update Categoria set Nombre='" + txtUpCreNombreCat.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() +
                            ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "' where id_Categoria=" + modCategoria.ToString();
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar categorias", "Categoria");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbCategoria.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoCategoria();
            }
 
        }
        private void btnModInsEditorial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreEditorial.Text) || string.IsNullOrWhiteSpace(txtNombreEditorial.Text)||string.IsNullOrEmpty(cbCiudadEditorial.Text)||string.IsNullOrWhiteSpace(cbCiudadEditorial.Text) || string.IsNullOrEmpty(dtañoinaguracionEditorial.Text) || string.IsNullOrWhiteSpace(dtañoinaguracionEditorial.Text))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string a = "0";
                if (chkEditorial.Checked)
                {
                    a = "1";
                }
                if (modEditorial.Equals("0"))
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            //
                            sql.Open();
                            cmd = new SqlCommand("CreateEditorial", sql);
                            cmd.CommandType = CommandType.StoredProcedure;    
                            cmd.Parameters.Add(new SqlParameter("@Id_Editorial", SiglaEditExis(txtNombreEditorial.Text)));
                            cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombreEditorial.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Ciudad", cbCiudadEditorial.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("@Año_Inaguracion", dtañoinaguracionEditorial.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Editorial", "Editorial");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbEditorial.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            //ciudad año inaugura
                            string consulta = "Update Editorial set Nombre='" + txtNombreEditorial.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() + ",Año_Inauguracion='" +dtañoinaguracionEditorial.Text+ "', Id_Ciudad=" + cbCiudadEditorial.SelectedValue.ToString() + ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff")  + "' where Id_Editorial='" + modEditorial+"'";
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Editorial", "Editorial");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbEditorial.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoEditorial();
            }
        }
        private void btnAgregaCliente_Click(object sender, EventArgs e)
        {
            gbClientes.Visible = true;
            gbClientes.Enabled = true;
            gbClientes.BringToFront();
            txtNombreCliente.Text = "";      
            chkTiCliente.Checked = true;
            modCliente = 0;
        }
        private void btnModCliente_Click(object sender, EventArgs e)
        {
            if (dgCliente.SelectedRows.Count == 1)
            {
                txtNombreCliente.Text = (string)dgCliente.SelectedCells[1].Value;
                if ((bool)dgCliente.SelectedCells[2].Value)
                {
                    chkTiCliente.Checked = true;
                }
                else
                {
                    chkTiCliente.Checked = false;
                }
                modCliente = (int)dgCliente.SelectedCells[0].Value;
                gbClientes.Visible = true;
                gbClientes.Enabled = true;
                gbClientes.BringToFront();
            }
            else { MessageBox.Show("Seleccione un Tipo de Cliente."); }

        }
        private void btnEliminaCliente_Click(object sender, EventArgs e)
        {
            if (dgCliente.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteTipo_Cliente", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgCliente.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Tipo Cliente", "Tipo_Cliente");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoTipoCliente();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione un Tipo de Cliente."); }

        }
        private void btnAgregaPago_Click(object sender, EventArgs e)
        {
            gpPago.Visible = true;
            gpPago.Enabled = true;
            gpPago.BringToFront();
            txtNombrePago.Text = "";
            chkPago.Checked = true;
            modPago = 0;
        }
        private void btnModificaPago_Click(object sender, EventArgs e)
        {
            if (dgvPago.SelectedRows.Count == 1)
            {
                txtNombrePago.Text = (string)dgvPago.SelectedCells[1].Value;
                if ((bool)dgvPago.SelectedCells[2].Value)
                {
                    chkPago.Checked = true;
                }
                else
                {
                    chkPago.Checked = false;
                }
                modPago = (int)dgvPago.SelectedCells[0].Value;
                gpPago.Visible = true;
                gpPago.Enabled = true;
                gpPago.BringToFront();
            }
            else { MessageBox.Show("Seleccione una Forma de Pago."); }

        }
        private void btnEliminaPago_Click(object sender, EventArgs e)
        {
            if (dgvPago.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteTipo_Pago", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvPago.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Tipo de Pago", "Tipo_Pago");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoTipoPago();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione un Tipo de Pago."); }
        }
        private void TiposDeClientesYTiposDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            pTiClienteTiPago.Visible = true;
            pTiClienteTiPago.Enabled = true;
            recargaCatalogoTipoPago();
            recargaCatalogoTipoCliente();
        }
        private void btnAgregaModificaPago_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombrePago.Text) || string.IsNullOrWhiteSpace(txtNombrePago.Text))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string a = "0";
                if (chkPago.Checked)
                {
                    a = "1";
                }
                if (modPago == 0)
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            cmd = new SqlCommand("CreateTipoPago", sql);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombrePago.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Forma de Pago", "Tipo_Pago");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbCategoria.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            string consulta = "Update Tipo_Pago set Nombre='" + txtNombrePago.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() +
                            ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "' where Id_Tipo_Pago=" + modPago.ToString();
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Forma de Pago", "Tipo_Pago");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbCategoria.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
               recargaCatalogoTipoPago();
            }
        }
        private void btnAgregaModificaTiCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreCliente.Text) || string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string a = "0";
                if (chkTiCliente.Checked)
                {
                    a = "1";
                }
                if (modCliente == 0)
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            cmd = new SqlCommand("CreateTipoCliente", sql);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombreCliente.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Tipo de Cliente", "Tipo_Cliente");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbCategoria.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            string consulta = "Update Tipo_Cliente set Nombre='" + txtNombreCliente.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() +
                            ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "' where id_Tipo_Cliente=" + modCliente.ToString();
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Tipo de Cliente", "Tipo_Cliente");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbCategoria.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoTipoCliente();
            }
        }
        private void LibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            panelLibrosFormatos.Visible = true;
            panelLibrosFormatos.Enabled = true;
            recargaCatalogoTipoFormato();
            recargaCatalogoLibro();

        }
        private void DepartamentosYPuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            PanelDepartamentosPuestos.Visible = true;
            PanelDepartamentosPuestos.Enabled = true;
            recargaCatalogoPuestos();
            recargaCatalogoDepartamento();
        }
        private void btnAgregaDepartamento_Click(object sender, EventArgs e)
        {
            gbDepartamento.Visible = true;
            gbDepartamento.Enabled = true;
            gbDepartamento.BringToFront();
            txtNombreDepartamento.Text = "";
            chkDepartamento.Checked = true;
            modDepartamento = 0;
        }
        private void btnAgregaPuestos_Click(object sender, EventArgs e)
        {
            gbPuestos.Visible = true;
            gbPuestos.Enabled = true;
            gbPuestos.BringToFront();
            txtNombrePuestos.Text = "";
            chkPuesto.Checked = true;
            modPuesto = 0;
        }
        private void btnAgregaModificaDepartamento_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreDepartamento.Text) || string.IsNullOrWhiteSpace(txtNombreDepartamento.Text))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string a = "0";
                if (chkDepartamento.Checked)
                {
                    a = "1";
                }
                if (modDepartamento == 0)
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            cmd = new SqlCommand("CreateDepartamento", sql);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Departamento", txtNombreDepartamento.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Departamento", "Departamento");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbDepartamento.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            string consulta = "Update Departamento set Departamento='" + txtNombreDepartamento.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() +
                            ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "' where Id_Departamento=" + modDepartamento.ToString();
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Departamento", "Departamento");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbDepartamento.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoDepartamento();
            }

        }
        private void btnAgregaModificaPuesto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombrePuestos.Text) || string.IsNullOrWhiteSpace(txtNombrePuestos.Text))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string a = "0";
                if (chkPuesto.Checked)
                {
                    a = "1";
                }
                if (modPuesto == 0)
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            cmd = new SqlCommand("CreatePuesto", sql);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombrePuestos.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Puesto", "Puesto");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbPuestos.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            string consulta = "Update Puesto set Nombre='" + txtNombrePuestos.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() +
                            ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "' where Id_Puesto=" + modPuesto.ToString();
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Puesto", "Puesto");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbPuestos.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoPuestos();
            }
        }
        private void btnModificaDepartamento_Click(object sender, EventArgs e)
        {
            if (dgvDepartamentos.SelectedRows.Count == 1)
            {
                txtNombreDepartamento.Text = (string)dgvDepartamentos.SelectedCells[1].Value;
                if ((bool)dgvDepartamentos.SelectedCells[2].Value)
                {
                    chkDepartamento.Checked = true;
                }
                else
                {
                    chkDepartamento.Checked = false;
                }
                modDepartamento = (int)dgvDepartamentos.SelectedCells[0].Value;
                gbDepartamento.Visible = true;
                gbDepartamento.Enabled = true;
                gbDepartamento.BringToFront();
            }
            else { MessageBox.Show("Seleccione un Departamento."); }

        }
        private void btnModificaPuestos_Click(object sender, EventArgs e)
        {
            if (dgvPuestos.SelectedRows.Count == 1)
            {
                txtNombrePuestos.Text = (string)dgvPuestos.SelectedCells[1].Value;
                if ((bool)dgvPuestos.SelectedCells[2].Value)
                {
                    chkPuesto.Checked = true;
                }
                else
                {
                    chkPuesto.Checked = false;
                }
                modPuesto = (int)dgvPuestos.SelectedCells[0].Value;
                gbPuestos.Visible = true;
                gbPuestos.Enabled = true;
                gbPuestos.BringToFront();
            }
            else { MessageBox.Show("Seleccione un Puesto."); }
        }
        private void btnEliminaDepartamento_Click(object sender, EventArgs e)
        {
            if (dgvDepartamentos.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteDepartamento", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvDepartamentos.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Departamento", "Departamento");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoDepartamento();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione un Departamento."); }
        }
        private void btnEliminaPuestos_Click(object sender, EventArgs e)
        {
            if (dgvPuestos.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeletePuesto", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvPuestos.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Puesto", "Puesto");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoPuestos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione un Puesto."); }
        }
        private void btnAgregaFormatos_Click(object sender, EventArgs e)
        {
            gbFormato.Visible = true;
            gbFormato.Enabled = true;
            gbFormato.BringToFront();
            txtNombreFormato.Text = "";
            chkFormato.Checked = true;
            modFormato = 0;

        }
        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            dgvAutoresLibro.Rows.Clear();
            panelLibros.Visible = true;
            panelLibros.Enabled = true;
            panelLibros.BringToFront();
            txtISBN.Text = "";
            txtISBN.Enabled =true;
            txtTitulo.Text = "";
            cargacombosLibros();
            chkLibro.Checked = true;
            modLibro = "0";
            txtVolumenLibro.Text = "";
            dtFechaLibro.Value = DateTime.Now;
            txtPaginasLibro.Text = "";
            txtPrecioLibro.Text = "";
            dgvAutoresLibro.DataSource = null;
        }
        private void btnModificaFormato_Click(object sender, EventArgs e)
        {
            if (dgvFormatos.SelectedRows.Count == 1)
            {
                txtNombreFormato.Text = (string)dgvFormatos.SelectedCells[1].Value;
                if ((bool)dgvFormatos.SelectedCells[2].Value)
                {
                    chkFormato.Checked = true;
                }
                else
                {
                    chkFormato.Checked = false;
                }
                modFormato = (int)dgvFormatos.SelectedCells[0].Value;
                gbFormato.Visible = true;
                gbFormato.Enabled = true;
                gbFormato.BringToFront();
            }
            else { MessageBox.Show("Seleccione un Formato."); }

        }
        private void cargaLibrosAutoresTabla(string isbn) {
            dgvAutoresLibro.Rows.Clear();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select l.Id_Autor,CONCAT(a.Nombre,' ',a.Apellido) Nombre_Completo from Libro_Autores l left join Autor a on l.Id_Autor=a.Id_Autor where l.Id_Libro_ISBN='"+isbn+"'";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvAutoresLibro.Rows.Add(dt.Rows[i]["Id_Autor"].ToString(), dt.Rows[i]["Nombre_Completo"].ToString());
            }
            }
        private void btnModificaLibro_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 1)
            {
                cargacombosLibros();
                txtISBN.Text = (string)dgvLibros.SelectedCells[0].Value;
                txtISBN.Enabled =false;
                cargaLibrosAutoresTabla(txtISBN.Text);
                txtTitulo.Text= (string)dgvLibros.SelectedCells[1].Value;
                cbCategoriaLibro.SelectedValue= (int)dgvLibros.SelectedCells[2].Value;
                txtVolumenLibro.Text= (string)dgvLibros.SelectedCells[4].Value;
                cbFormatoLibro.SelectedValue = (int)dgvLibros.SelectedCells[5].Value;
                cbEditorialLibro.SelectedValue = (string)dgvLibros.SelectedCells[7].Value;
                dtFechaLibro.Value=(DateTime)dgvLibros.SelectedCells[9].Value;
                txtPaginasLibro.Text= ((int)dgvLibros.SelectedCells[10].Value).ToString();
                txtPrecioLibro.Text = ((decimal)dgvLibros.SelectedCells[11].Value).ToString();
                cbRatingLibro.SelectedValue = (int)dgvLibros.SelectedCells[12].Value;
                if ((bool)dgvLibros.SelectedCells[14].Value)
                {
                    chkLibro.Checked = true;
                }
                else
                {
                    chkLibro.Checked = false;
                }
                modLibro = (string)dgvLibros.SelectedCells[0].Value;
                panelLibros.Visible = true;
                panelLibros.Enabled = true;
                panelLibros.BringToFront();
            }
            else { MessageBox.Show("Seleccione un Libro."); }
        }
        private void btnEliminaFormato_Click(object sender, EventArgs e)
        {
            if (dgvFormatos.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteTipo_Formato", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvFormatos.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Formato", "Tipo_Formato");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoTipoFormato();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione un Formato."); }
        }
        private void btnEliminaLibro_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteLibro", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvLibros.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Libro", "Libro");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoLibro();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione un Libro."); }
        }
        private void btnAgregarModificarFormato_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreFormato.Text) || string.IsNullOrWhiteSpace(txtNombreFormato.Text))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string a = "0";
                if (chkFormato.Checked)
                {
                    a = "1";
                }
                if (modFormato == 0)
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            cmd = new SqlCommand("CreateTipoFormato", sql);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombreFormato.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Formato", "Tipo_Formato");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbFormato.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            string consulta = "Update Tipo_Formato set Nombre='" + txtNombreFormato.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() +
                            ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "' where Id_Tipo_Formato=" + modFormato.ToString();
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Formato", "Tipo_Formato");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            gbFormato.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoTipoFormato();
            }
        }
        private void btnAgregarModificarLibro_Click(object sender, EventArgs e)
        {         
            if (string.IsNullOrEmpty(txtISBN.Text) || string.IsNullOrWhiteSpace(txtISBN.Text)
                || string.IsNullOrEmpty(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtTitulo.Text) ||
                string.IsNullOrEmpty(txtPrecioLibro.Text) || string.IsNullOrWhiteSpace(txtPrecioLibro.Text) ||
                string.IsNullOrEmpty(cbCategoriaLibro.Text) || string.IsNullOrWhiteSpace(cbCategoriaLibro.Text) ||
                string.IsNullOrEmpty(cbFormatoLibro.Text) || string.IsNullOrWhiteSpace(cbFormatoLibro.Text) ||
                string.IsNullOrEmpty(cbEditorialLibro.Text) || string.IsNullOrWhiteSpace(cbEditorialLibro.Text) ||
                string.IsNullOrEmpty(cbRatingLibro.Text) || string.IsNullOrWhiteSpace(cbRatingLibro.Text))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string vol = null;
                string f = null;
                string pag = null;
                if (!(string.IsNullOrEmpty(txtVolumenLibro.Text) || string.IsNullOrWhiteSpace(txtVolumenLibro.Text))) {
                    vol = txtVolumenLibro.Text;
                }
                if (!(dtFechaLibro.Text.Equals(""))) {
                    f = dtFechaLibro.Value.ToShortDateString();
                }
                if (!(txtPaginasLibro.Text.Equals(""))) {
                    pag = txtPaginasLibro.Text;
                }
                    string a = "0";
                if (chkLibro.Checked)
                {
                    a = "1";
                }
                if (modLibro.Equals("0"))
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            cmd = new SqlCommand("CreateLibro", sql);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Id_Libro_ISBN", txtISBN.Text));
                            cmd.Parameters.Add(new SqlParameter("@Titulo", txtTitulo.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Categoria", cbCategoriaLibro.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("@Volumen",vol ));
                            cmd.Parameters.Add(new SqlParameter("@Id_Tipo_Formato", cbFormatoLibro.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("@Id_Editorial", cbEditorialLibro.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Publicacion",f));
                            cmd.Parameters.Add(new SqlParameter("@Paginas",pag));
                            cmd.Parameters.Add(new SqlParameter("@Precio",txtPrecioLibro.Text));
                            cmd.Parameters.Add(new SqlParameter("@Id_Rating", cbRatingLibro.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            EliminaTodosAutoresLibro(txtISBN.Text);

                            for (int i = 0; i < dgvAutoresLibro.Rows.Count; i++)
                            {
                                if (!(dgvAutoresLibro.Rows[i].Cells["Id_Autor"].Value.ToString()).Equals(""))
                                {
                                    agregarAutoresLibro(txtISBN.Text, dgvAutoresLibro.Rows[i].Cells["Id_Autor"].Value.ToString());
                                }
                            }

                            LogsAceptable("Insertar Libro", "Libro");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            panelLibros.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();

                            if (!(string.IsNullOrEmpty(txtVolumenLibro.Text) || string.IsNullOrWhiteSpace(txtVolumenLibro.Text)))
                            {
                                vol ="'"+txtVolumenLibro.Text+"'";
                            }
                            else {
                                vol = "NULL";
                            }
                            if (!(dtFechaLibro.Text.Equals("")))
                            {
                                f = "'" + dtFechaLibro.Value.ToShortDateString() + "'";
                            }
                            else {
                                f = "NULL";
                            }
                            if (!(txtPaginasLibro.Text.Equals("")))
                            {
                                pag = txtPaginasLibro.Text;
                            }
                            else {
                                pag = "NULL";
                            }
                            string consulta = "Update Libro set Titulo='" + txtTitulo.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() +
                            ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "',"+
                            "Id_Categoria="+ cbCategoriaLibro.SelectedValue.ToString()+",Volumen="+vol+","+
                            "Paginas="+pag+ ",Id_Tipo_Formato="+cbEditorialLibro.SelectedValue.ToString() + ",Id_Editorial="+cbEditorialLibro.SelectedValue.ToString() +
                            ",Id_Rating="+cbRatingLibro.SelectedValue.ToString()+ ",Precio="+txtPrecioLibro.Text+ ",Fecha_Publicacion="+f +
                            " where Id_Libro_ISBN='" + modLibro.ToString()+"'";
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Libro", "Libro");
                            EliminaTodosAutoresLibro(txtISBN.Text);
                            for (int i = 0; i < dgvAutoresLibro.Rows.Count; i++)
                            {
                                if (!(dgvAutoresLibro.Rows[i].Cells["Id_Autor"].Value.ToString()).Equals(""))
                                {
                                    agregarAutoresLibro(txtISBN.Text, dgvAutoresLibro.Rows[i].Cells["Id_Autor"].Value.ToString());
                                }
                            }
                            
                            sql.Close();
                            MessageBox.Show("Guardado");
                            panelLibros.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoLibro();
            }
        }
        private void AutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            PanelAutor.Visible = true;
            PanelAutor.Enabled = true;
            recargaCatalogoAutor();
        }
        private void btnagregaAutorLibro_Click(object sender, EventArgs e)
        {   bool existe = false;
   
            string id=cbAutoresLibro.SelectedValue.ToString();
                for (int i=0;i< dgvAutoresLibro.Rows.Count;i++) {
                if ((dgvAutoresLibro.Rows[i].Cells["Id_Autor"].Value.ToString()).Equals(id)) {
                    existe = true;
                }
                }
            if (!existe){
                dgvAutoresLibro.Rows.Add(id, cbAutoresLibro.Text);
            }                   
        }
        private void agregarAutoresLibro(string isbn, string autor) {
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    cmd = new SqlCommand("CreateLibroAutores", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id_Libro_ISBN", isbn));
                    cmd.Parameters.Add(new SqlParameter("@Id_Autor", autor));
                    cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Estatus", "1"));
                    cmd.ExecuteReader();
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void btnQuitarLibroAutores_Click(object sender, EventArgs e)
        {
            if (dgvAutoresLibro.SelectedRows.Count == 1)
            {
                dgvAutoresLibro.Rows.Remove(dgvAutoresLibro.SelectedRows[0]);
            }
            else { MessageBox.Show("Seleccione un Autor."); }
        }
        private void EliminaTodosAutoresLibro(string isbn)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    string consulta = "delete from Libro_Autores where Id_Libro_ISBN='" + isbn + "'";
                    cmd = new SqlCommand(consulta, sql);
                    cmd.ExecuteReader();
                    sql.Close();
                }
            }
            catch (Exception ex) { throw; }
        }
        private void HistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            PanelHistorial.Visible = true;
            PanelHistorial.Enabled = true;
            recargaHistorial();
        }

        private void btnAgregaAutor_Click(object sender, EventArgs e)
        {
            PanelAutorAM.Visible = true;
            PanelAutorAM.Enabled = true;
            PanelAutorAM.BringToFront();
            txtNombreAutor.Text = "";
            txtApellidoAutor.Text = "";
            dtNacioAutor.Value = DateTime.Now;
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select Id_Pais,Nacionalidad from Pais";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbNacionalidadAutor.DataSource = dt;
            cbNacionalidadAutor.DisplayMember = "Nacionalidad";
            cbNacionalidadAutor.ValueMember = "Id_Pais";

            chkAutor.Checked = true;
            modAutor = "0";
        }

        private void btnModificaAutor_Click(object sender, EventArgs e)
        {
            if (dgvAutor.SelectedRows.Count == 1)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = sql;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select Id_Pais,Nacionalidad from Pais";
                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                        sql.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cbNacionalidadAutor.DataSource = dt;
                cbNacionalidadAutor.DisplayMember = "Nacionalidad";
                cbNacionalidadAutor.ValueMember = "Id_Pais";
                cbNacionalidadAutor.SelectedValue=(int)dgvAutor.SelectedCells[5].Value;
                if ((bool)dgvAutor.SelectedCells[7].Value)
                {
                    chkAutor.Checked = true;
                }
                else
                {
                    chkAutor.Checked = false;
                }
                txtNombreAutor.Text = (string)dgvAutor.SelectedCells[1].Value; ;
                txtApellidoAutor.Text = (string)dgvAutor.SelectedCells[2].Value;
                dtNacioAutor.Value = (DateTime)dgvAutor.SelectedCells[4].Value;
                modAutor = (string)dgvAutor.SelectedCells[0].Value;
                PanelAutorAM.Visible = true;
                PanelAutorAM.Enabled = true;
                PanelAutorAM.BringToFront();
            }
            else { MessageBox.Show("Seleccione un Autor."); }
        }

        private void btnEliminaAutor_Click(object sender, EventArgs e)
        {
            if (dgvAutor.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteAutor", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvAutor.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Autor", "Autor");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoAutor();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione un Autor."); }

        }

        private void btnAgregarModificarAutor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreAutor.Text) || string.IsNullOrWhiteSpace(txtNombreAutor.Text) || string.IsNullOrEmpty(txtApellidoAutor.Text) || string.IsNullOrWhiteSpace(txtApellidoAutor.Text) || string.IsNullOrEmpty(dtNacioAutor.Text) || string.IsNullOrWhiteSpace(dtNacioAutor.Text))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                string a = "0";
                if (chkAutor.Checked)
                {
                    a = "1";
                }
                if (modAutor.Equals("0"))
                {
                    string f = null;
                    string p = null;
                    if (!(cbNacionalidadAutor.Text.Equals(""))) {
                        p = cbNacionalidadAutor.SelectedValue.ToString();
                    }
                    if (!(dtNacioAutor.Text.Equals(""))) {
                        f = dtNacioAutor.Value.ToShortDateString();
                    }
                    try
                    {
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            
                            sql.Open();
                            cmd = new SqlCommand("CreateAutor", sql);
                            cmd.CommandType = CommandType.StoredProcedure;  
                            cmd.Parameters.Add(new SqlParameter("@Id_Autor", SiglaAutor(txtNombreAutor.Text,txtApellidoAutor.Text, dtNacioAutor.Value.ToString("ddMMyyyy"))));
                            cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombreAutor.Text));
                            cmd.Parameters.Add(new SqlParameter("@Apellido", txtApellidoAutor.Text));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Nacimiento", f));
                            cmd.Parameters.Add(new SqlParameter("@Id_Pais",p ));

                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Autor", "Autor");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            PanelAutorAM.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        string f = "NULL";
                        string p = "NULL";
                        if (!(cbNacionalidadAutor.Text.Equals("")))
                        {
                            p = cbNacionalidadAutor.SelectedValue.ToString();
                        }
                        if (!(dtNacioAutor.Text.Equals("")))
                        {
                            f ="'"+ dtNacioAutor.Value.ToShortDateString()+ "'";
                        }
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            //ciudad año inaugura
                            string consulta = "Update Autor set Nombre='" + txtNombreAutor.Text + "',Estatus=" + a + ",Id_Usuario_Modificacion=" + IDuser.ToString() + ",Apellido='" + txtApellidoAutor.Text + "',Fecha_Nacimiento="+f+", Id_Pais=" +p + ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "' where Id_Autor='" + modAutor + "'";
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Autor", "Autor");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            PanelAutorAM.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoAutor();
            }

        }
        private string SiglaAutor(string nombre,string apellido, string fecha_nacimiento) {
            string resul="";
            resul = nombre.Substring(0, 1) + apellido.Substring(0,1) + fecha_nacimiento;
            return resul.ToUpper();
        }

        private void UsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            PanelUsuarios.Visible = true;
            PanelUsuarios.Enabled = true;
            recargaCatalogoUsuario();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            PanelVentas.Visible = true;
            PanelVentas.Enabled = true;
            recargaCatalogoVentas();
        }

        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarPaneles();
            panelVentaRegistro.Visible = true;
            panelVentaRegistro.Enabled = true;
            cargaCombosVentaLibros();
        }

        private void btnAgregaUsuario_Click(object sender, EventArgs e)
        {
            cargacombosUsuarios();
            panelUsuarioAM.Visible = true;
            panelUsuarioAM.Enabled = true;
            panelUsuarioAM.BringToFront();
            txtNombreUsuarioUAM.Text = "";
            txtNombreUAM.Text = "";
            txtContraseñaUAM.Text = "";
            txtApellidoPatUAM.Text = "";
            txtApellidoMatUAM.Text = "";
            txtCorreoUAM.Text = "";
            txtTelefonoUAM.Text = "";
            chkUsuarioUAM.Checked = true;
            modUsuario = 0;
            modcon = "";
        }

        private void btnModificaUsuario_Click(object sender, EventArgs e)
        {
            
            if (dgvUsuarios.SelectedRows.Count == 1)
            {
                cargacombosUsuarios();
                txtNombreUsuarioUAM.Text = (string)dgvUsuarios.SelectedCells[1].Value;
                txtNombreUAM.Text = (string)dgvUsuarios.SelectedCells[2].Value;
                txtContraseñaUAM.Text = (string)dgvUsuarios.SelectedCells[3].Value;
                modcon = txtContraseñaUAM.Text;
                txtApellidoPatUAM.Text = (string)dgvUsuarios.SelectedCells[4].Value;
                txtApellidoMatUAM.Text = (string)dgvUsuarios.SelectedCells[5].Value;
                txtCorreoUAM.Text = (string)dgvUsuarios.SelectedCells[6].Value;
                txtTelefonoUAM.Text = (string)dgvUsuarios.SelectedCells[7].Value;
                cbPuestoUAM.SelectedValue = (int)dgvUsuarios.SelectedCells[8].Value;
                cbDepartamentoUAM.SelectedValue = (int)dgvUsuarios.SelectedCells[10].Value;
                cbTipoUsuarioUAM.SelectedValue = (int)dgvUsuarios.SelectedCells[12].Value;
                if ((bool)dgvUsuarios.SelectedCells[14].Value)
                {
                    chkUsuarioUAM.Checked = true;
                }
                else
                {
                    chkUsuarioUAM.Checked = false;
                }
                modUsuario = (int)dgvUsuarios.SelectedCells[0].Value;
                panelUsuarioAM.Visible = true;
                panelUsuarioAM.Enabled = true;
                panelUsuarioAM.BringToFront();
            }
            else { MessageBox.Show("Seleccione un Usuario."); }

        }

        private void btnEliminaUsuario_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteUsuario", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvUsuarios.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Usuario", "Usuario");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoUsuario();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione un Usuario."); }

        }

        private void btnAgregarModificarUsuario_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(txtNombreUAM.Text) || string.IsNullOrWhiteSpace(txtNombreUAM.Text)
                || string.IsNullOrEmpty(txtNombreUsuarioUAM.Text) || string.IsNullOrWhiteSpace(txtNombreUsuarioUAM.Text)
                || string.IsNullOrEmpty(txtApellidoPatUAM.Text) || string.IsNullOrWhiteSpace(txtApellidoPatUAM.Text)
                || string.IsNullOrEmpty(txtCorreoUAM.Text) || string.IsNullOrWhiteSpace(txtCorreoUAM.Text)
                || string.IsNullOrEmpty(cbPuestoUAM.Text) || string.IsNullOrWhiteSpace(cbPuestoUAM.Text)
                || string.IsNullOrEmpty(cbDepartamentoUAM.Text) || string.IsNullOrWhiteSpace(cbDepartamentoUAM.Text)
                || string.IsNullOrEmpty(cbTipoUsuarioUAM.Text) || string.IsNullOrWhiteSpace(cbTipoUsuarioUAM.Text)
                || ((string.IsNullOrEmpty(txtContraseñaUAM.Text) || string.IsNullOrWhiteSpace(txtContraseñaUAM.Text))
                && (string.IsNullOrEmpty(modcon) || string.IsNullOrWhiteSpace(modcon))))
            {
                MessageBox.Show("Ingrese los datos solicitados");
            }
            else
            {
                if (!(string.IsNullOrEmpty(txtContraseñaUAM.Text) || string.IsNullOrWhiteSpace(txtContraseñaUAM.Text)) && !(txtContraseñaUAM.Text.Equals(modcon)))
                {
                    modcon = Encriptado(txtContraseñaUAM.Text);
                }
                string mater = "NULL";
                string telef = "NULL";
                
                string a = "0";
                if (chkUsuarioUAM.Checked)
                {
                    a = "1";
                }
                if (modUsuario == 0)
                {
                    try
                    {
                        if (!(string.IsNullOrEmpty(txtApellidoMatUAM.Text) || string.IsNullOrWhiteSpace(txtApellidoMatUAM.Text)))
                        {
                            mater =txtApellidoMatUAM.Text;
                        }
                        if (!(string.IsNullOrEmpty(txtTelefonoUAM.Text) || string.IsNullOrWhiteSpace(txtTelefonoUAM.Text)))
                        {
                            telef =  txtTelefonoUAM.Text;
                        }
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            cmd = new SqlCommand("CreateTipoCliente", sql);
                            cmd.CommandType = CommandType.StoredProcedure; 
                            cmd.Parameters.Add(new SqlParameter("@Nombre", txtNombreUAM.Text));
                            cmd.Parameters.Add(new SqlParameter("@Contraseña", modcon));
                            cmd.Parameters.Add(new SqlParameter("@Nombre_Usuario", txtNombreUsuarioUAM.Text));
                            cmd.Parameters.Add(new SqlParameter("@Apellido_Paterno", txtApellidoPatUAM.Text));
                            cmd.Parameters.Add(new SqlParameter("@Apellido_Materno", mater));
                            cmd.Parameters.Add(new SqlParameter("@Email", txtCorreoUAM.Text));
                            cmd.Parameters.Add(new SqlParameter("@Telefono",telef ));
                            cmd.Parameters.Add(new SqlParameter("@Id_Puesto", cbPuestoUAM.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("@Id_Departamento", cbDepartamentoUAM.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("@Id_Tipo_usuario", cbTipoUsuarioUAM.SelectedValue));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                            cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@Estatus", a));

                            cmd.ExecuteReader();
                            LogsAceptable("Insertar Usuario", "Usuario");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            panelUsuarioAM.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de conexion");
                    }

                }
                else
                {
                    try
                    {
                        if (!(string.IsNullOrEmpty(txtApellidoMatUAM.Text) || string.IsNullOrWhiteSpace(txtApellidoMatUAM.Text)))
                        {
                            mater = "'" + txtApellidoMatUAM.Text + "'";
                        }
                        if (!(string.IsNullOrEmpty(txtTelefonoUAM.Text) || string.IsNullOrWhiteSpace(txtTelefonoUAM.Text)))
                        {
                            telef = "'" + txtTelefonoUAM.Text + "'";
                        }
                        using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                        {
                            sql.Open();
                            string consulta = "update Usuario set Nombre_Usuario='" + txtNombreUsuarioUAM.Text + "',Nombre='" + txtNombreUAM.Text + "'," +
            "Contraseña='" + modcon + "',Apellido_Paterno='" + txtApellidoPatUAM.Text + "',Apellido_Materno=" + mater +
            ",Email='" + txtCorreoUAM.Text + "',Telefono=" + telef + ",Id_Usuario_Modificacion=" + IDuser.ToString() +
            ",Fecha_Hora_Modificacion= '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") +
            "',Estatus="+a+ ",Id_Puesto="+ cbPuestoUAM.SelectedValue.ToString() + ",Id_Departamento="+ cbDepartamentoUAM.SelectedValue.ToString()+
            ",Id_Tipo_Usuario="+ cbTipoUsuarioUAM.SelectedValue.ToString()+ " where Id_Usuario=" + modUsuario.ToString();
                            cmd = new SqlCommand(consulta, sql);
                            cmd.ExecuteReader();
                            LogsAceptable("Modificar Usuario", "Usuario");
                            sql.Close();
                            MessageBox.Show("Guardado");
                            panelUsuarioAM.Visible = false;
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error en conexion"); }

                }
                recargaCatalogoUsuario();
            }


            
        }

        private void btnVerVenta_Click(object sender, EventArgs e)
        {
            if (dgvVerVentas.SelectedRows.Count == 1)
            {
                cargaDetalleVenta((int)dgvVerVentas.SelectedCells[0].Value);
                PanelDetalleVenta.Visible = true;
                PanelDetalleVenta.Enabled = true;
                PanelDetalleVenta.BringToFront();
            }
            else { MessageBox.Show("Seleccione una Venta."); }


        }

        private void btnDetalleVentaRegresar_Click(object sender, EventArgs e)
        {
            PanelDetalleVenta.Visible = false;
        }
        private void cargaDetalleVenta(int venta)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select l.Titulo,(de.Porcentaje*100) Descuento,l.Precio from Detalle_Venta d left join Libro l on d.Id_Libro_ISBN=l.Id_Libro_ISBN left join Descuento de on d.Id_Descuento= de.id_Descuento where d.Id_Venta="+venta.ToString();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvDetalleVenta.DataSource = dt;

        }
        private void recargaCatalogoVentas()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select v.Id_Venta Venta,v.Fecha_Hora_Creacion Fecha, u.Nombre_Usuario,c.Nombre Cliente,p.Nombre [Forma de Pago] from venta v left join Tipo_Cliente c on v.Id_Tipo_Cliente=c.Id_Tipo_Cliente left join Usuario u on v.Id_Usuario_Creacion=u.Id_Usuario left join Tipo_Pago p on v.Id_Tipo_Pago=p.Id_Tipo_Pago where v.Estatus=1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dgvVerVentas.DataSource = dt;

        }

        private void btnEliminaVenta_Click(object sender, EventArgs e)
        {
            if (dgvVerVentas.SelectedRows.Count == 1)
            {
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        cmd = new SqlCommand("DeleteVenta", sql);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", dgvVerVentas.SelectedCells[0].Value));
                        cmd.ExecuteReader();
                        LogsAceptable("Eliminar Venta", "Venta");
                        sql.Close();
                        MessageBox.Show("Eliminada");
                        recargaCatalogoVentas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexion");
                }
            }
            else { MessageBox.Show("Seleccione una Venta."); }
            
        }

        private void btnBuscaCaja_Click(object sender, EventArgs e)
        {
            bool existe = false;

            string id = cbLibrosCaja.SelectedValue.ToString();
            for (int i = 0; i < dgvCaja.Rows.Count; i++)
            {
                if ((dgvCaja.Rows[i].Cells["ISBN"].Value.ToString()).Equals(id))
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                string ti = "";
                decimal pre = 0;
               
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        string consulta = "select l.Id_Libro_ISBN ISBN,CONCAT(l.Titulo,', ',f.Nombre) Titulo,l.Precio from Libro l left join Tipo_Formato f on l.Id_Tipo_Formato=f.Id_Tipo_Formato where l.Id_Libro_ISBN='" + id+"'";

                        cmd = new SqlCommand(consulta, sql);
                        SqlDataReader lector;
                        lector = cmd.ExecuteReader();
                        if (lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                ti = (string)lector[1];
                                pre = (decimal)lector[2];   
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error en conexion"); }
                
                dgvCaja.Rows.Add(id, ti,pre,"0");
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvCaja.SelectedRows.Count == 1)
            {
                dgvCaja.Rows.Remove(dgvCaja.SelectedRows[0]);
            }
            else { MessageBox.Show("Seleccione un Libro."); }
        }

        private void btnLimpiaCaja_Click(object sender, EventArgs e)
        {
            dgvCaja.Rows.Clear();
        }

        private void btnRegistraVentaCaja_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    cmd = new SqlCommand("CreateVenta", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id_Tipo_Cliente", cbClienteCaja.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@Id_Tipo_Pago", cbPagoCaja.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Estatus", "1"));
                    cmd.ExecuteReader();
                    sql.Close();
                }
                LogsAceptable("Insertar Venta", "Venta");
                try
                {
                    using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                    {
                        sql.Open();
                        string consulta = "select top(1) id_Venta from Venta order by Id_Venta desc";

                        cmd = new SqlCommand(consulta, sql);
                        SqlDataReader lector;
                        lector = cmd.ExecuteReader();
                        if (lector.HasRows)
                        {
                            while (lector.Read())
                            {
                                modVenta = (int)lector[0];
                            
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error en conexion"); }
                for (int i = 0; i < dgvCaja.Rows.Count; i++)
                {
                    if (!(dgvCaja.Rows[i].Cells["ISBN"].Value.ToString()).Equals(""))
                    {
                        string d = "0";
                        if (string.IsNullOrEmpty(dgvCaja.Rows[i].Cells["Descuento"].Value.ToString()) || string.IsNullOrWhiteSpace(dgvCaja.Rows[i].Cells["Descuento"].Value.ToString()))
                        {
                            d = "0";
                        }
                        else {
                            d = dgvCaja.Rows[i].Cells["Descuento"].Value.ToString();
                        }
                        agregarDetalleVentaLibros(dgvCaja.Rows[i].Cells["ISBN"].Value.ToString(),d);
                        LogsAceptable("Insertar Detalle", "Detalle_Venta");
                    }
                }

            
            
            MessageBox.Show("Guardado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en conexion");
            }
        }
        private void agregarDetalleVentaLibros(string isbn, string descuento)
        {
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    cmd = new SqlCommand("CreateDetalleVenta", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id_Venta", modVenta));
                    cmd.Parameters.Add(new SqlParameter("@Id_Descuento", descuento));
                    cmd.Parameters.Add(new SqlParameter("@Id_Libro_ISBN", isbn));
                    cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Creacion", IDuser));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Creacion", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Id_Usuario_Modificacion", IDuser));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_Hora_Modificacion", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Estatus", "1"));
                    cmd.ExecuteReader();
                    sql.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void MiCuentaToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            int id = 0;
            cerrarPaneles();
            try
            {
                using (SqlConnection sql = new SqlConnection("Data Source=DESKTOP-CUOAPA9\\SQLEXPRESS;Initial Catalog=libreria;Integrated Security=True"))
                {
                    sql.Open();
                    string consulta = "select Nombre_Usuario,Nombre,Contraseña,Apellido_Paterno,Apellido_Materno,Email,Telefono,Puesto,Departamento from VRegistroUsuarios where Id_Usuario=" + IDuser.ToString();

                    cmd = new SqlCommand(consulta, sql);
                    SqlDataReader lector;
                    lector = cmd.ExecuteReader();
                    if (lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            txtUsuarioMiCuenta.Text = (string)lector[0];
                            txtNombreMiCuenta.Text = (string)lector[1];
                            txtContraMiCuenta.Text = (string)lector[2];
                            txtApellidoPMiCuenta.Text = (string)lector[3];
                            txtApellidoMMiCuenta.Text = (string)lector[4];
                            txtCorreoMiCuenta.Text = (string)lector[5];
                            txtTelefMiCuenta.Text = (string)lector[6];
                            txtPuestoMiCuenta.Text = (string)lector[7];
                            txtDepartMiCuenta.Text = (string)lector[8];
                            con = (string)lector[2];
                        }
                        PanelRegistra.Visible = true;
                        PanelRegistra.Enabled = true;
                    }
                    else
                    {
                        PanelRegistra.Visible = false;
                        PanelRegistra.Enabled = false;
                        MessageBox.Show("El usuario no existe o datos incorrectos");
                    }
                    sql.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error en conexion"); }
            

        }
    }
   
}
