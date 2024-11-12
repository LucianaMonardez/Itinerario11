using Business;
using Entity;

namespace Parcial_Lug
{
    public partial class Partidos : Form
    {
        private DeporteBusiness _deporteBusiness = new DeporteBusiness();
        private PartidoBusiness _partidoBusiness = new PartidoBusiness();
        private List<Partido> _partidosBorrador = new List<Partido>();

        public Partidos()
        {
            InitializeComponent();
            LlenarDeporteComboBox();
            ActualizarEntradasDataGridView();

        }

        #region ABM

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _partidosBorrador.Add(new Partido((int)deporteCombobox.SelectedValue, equipoLocalTxt.Text, equipoVisitanteTxt.Text, fechaPartidoDateTimePicker.Value));
                LimpiarCamposCreacionPartido();
                MessageBox.Show("El partido se agrego exitosamente al borrador");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error al intentar agregar el partido al borraodor");
            }
        }

        private void ValidarFormCreacionPartidos() 
        {
            if (!_partidosBorrador.Any())
                throw new Exception("No partidos para cargar, por favor ingrese partidos nuevos");
        }
        private void guardarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarFormCreacionPartidos();
                _partidoBusiness.CrearPartidos(_partidosBorrador);

                _partidosBorrador = new List<Partido>();
                LimpiarCamposCreacionPartido();
                ActualizarEntradasDataGridView();
                MessageBox.Show("El partido se creo exitosamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error al crear el partido: " + ex.Message);
            }
        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _partidoBusiness.EliminarPartido(eliminarTxt.Text);
                ActualizarEntradasDataGridView();
                eliminarTxt.Clear();
                MessageBox.Show("Partido eliminado exitosamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error al eliminar el partido: " + ex.Message);
            }
        }

        private void modificarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _partidoBusiness.ActualizarMarcadorPartido(actualizarIdTxt.Text, marcadorLocalTxt.Text, marcadorVisitanteTxt.Text);

                LimpiarCamposModificacionPartido();
                ActualizarEntradasDataGridView();
                MessageBox.Show("Partido actualizado exitosamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error al actualizar el partido: " + ex.Message);
            }
        }
        #endregion

        #region Util
        private void LlenarDeporteComboBox()
        {
            List<Deporte> deportes = _deporteBusiness.ObtenerDeportes();
            deporteCombobox.DataSource = deportes;
            deporteCombobox.DisplayMember = "Descripcion";
            deporteCombobox.ValueMember = "IdDeporte";
            deporteCombobox.SelectedIndex = -1;

        }
        private void ActualizarEntradasDataGridView()
        {
            try
            {
                partidosDataGridView.DataSource = null;
                partidosDataGridView.DataSource = _partidoBusiness.ObtenerPartidos();

                partidosDataGridView.Columns["Deporte"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar el programa, por favor comuniquese con el administrador");
                throw;
            }
        }

        private void LimpiarCamposCreacionPartido()
        {
            equipoLocalTxt.Clear();
            equipoVisitanteTxt.Clear();
            deporteCombobox.SelectedIndex = -1;
            fechaPartidoDateTimePicker.Value = DateTime.Now;

        }

        private void LimpiarCamposModificacionPartido()
        {
            marcadorLocalTxt.Clear();
            marcadorVisitanteTxt.Clear();
            actualizarIdTxt.Clear();
        }
        #endregion

        
    }
}
