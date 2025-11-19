#nullable enable
using ClosedXML.Excel;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class CitasForm : Form
{
    private readonly ICitaRepository _citaRepository;
    private readonly IPropietarioRepository _propietarioRepository;
    private readonly IMascotaRepository _mascotaRepository;
    private readonly IVeterinarioRepository _veterinarioRepository;
    private readonly IServicioRepository _servicioRepository;
    private List<CitaDto> _citas = new();
    private List<PropietarioDto> _propietarios = new();
    private List<MascotaDto> _mascotas = new();
    private List<VeterinarioDto> _veterinarios = new();
    private List<ServicioDto> _servicios = new();
    private CitaDto? _citaSeleccionada;
    private bool _modoEdicion = false;

    public CitasForm(ICitaRepository citaRepository, IPropietarioRepository propietarioRepository, IMascotaRepository mascotaRepository, IVeterinarioRepository veterinarioRepository, IServicioRepository servicioRepository)
    {
        InitializeComponent();
        _citaRepository = citaRepository;
        _propietarioRepository = propietarioRepository;
        _mascotaRepository = mascotaRepository;
        _veterinarioRepository = veterinarioRepository;
        _servicioRepository = servicioRepository;
    }

    private async void CitasForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        await CargarPropietariosAsync();
        await CargarVeterinariosAsync();
        await CargarServiciosAsync();
        dtpFechaBuscar.Value = DateTime.Today;
        ConfigurarModoEdicion(false);
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBoxes con colores suaves
        gbxBuscar.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxEditar.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
        // Botones con colores temáticos
        btnBuscarPorFecha.BackColor = Color.FromArgb(255, 152, 0); // Naranja suave
        btnBuscarPorFecha.ForeColor = Color.White;
        btnBuscarPorFecha.FlatStyle = FlatStyle.Flat;
        btnBuscarPorFecha.FlatAppearance.BorderSize = 0;
        
        btnActualizar.BackColor = Color.FromArgb(33, 150, 243); // Azul
        btnActualizar.ForeColor = Color.White;
        btnActualizar.FlatStyle = FlatStyle.Flat;
        btnActualizar.FlatAppearance.BorderSize = 0;
        
        btnCancelar.BackColor = Color.FromArgb(244, 67, 54); // Rojo suave
        btnCancelar.ForeColor = Color.White;
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.FlatAppearance.BorderSize = 0;
        
        btnLimpiar.BackColor = Color.FromArgb(158, 158, 158); // Gris
        btnLimpiar.ForeColor = Color.White;
        btnLimpiar.FlatStyle = FlatStyle.Flat;
        btnLimpiar.FlatAppearance.BorderSize = 0;
        
        btnExportarExcel.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnExportarExcel.ForeColor = Color.White;
        btnExportarExcel.FlatStyle = FlatStyle.Flat;
        btnExportarExcel.FlatAppearance.BorderSize = 0;
        
        // DataGridView con colores alternados suaves
        dgvCitas.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvCitas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0);
        dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvCitas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvCitas.EnableHeadersVisualStyles = false;
    }

    private async Task CargarPropietariosAsync()
    {
        try
        {
            _propietarios = await _propietarioRepository.ListarActivosAsync();
            cmbPropietario.DataSource = _propietarios.Select(p => new { 
                ID = p.ID_Propietario, 
                NombreCompleto = $"{p.Nombre} {p.Apellidos}" 
            }).ToList();
            cmbPropietario.DisplayMember = "NombreCompleto";
            cmbPropietario.ValueMember = "ID";
            cmbPropietario.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar propietarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void CmbPropietario_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cmbPropietario.SelectedItem != null)
        {
            var propItem = cmbPropietario.SelectedItem;
            var propId = propItem.GetType().GetProperty("ID")?.GetValue(propItem);
            if (propId != null && propId is int propIdInt)
            {
                await CargarMascotasAsync(propIdInt);
            }
        }
    }

    private async Task CargarMascotasAsync(int idPropietario)
    {
        try
        {
            _mascotas = await _mascotaRepository.ListarPorPropietarioAsync(idPropietario);
            var mascotasList = _mascotas.Select(m => new { 
                ID = m.ID_Mascota, 
                Nombre = m.Nombre 
            }).ToList();
            cmbMascota.DataSource = mascotasList;
            cmbMascota.DisplayMember = "Nombre";
            cmbMascota.ValueMember = "ID";
            cmbMascota.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar mascotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task CargarVeterinariosAsync()
    {
        try
        {
            _veterinarios = await _veterinarioRepository.ListarActivosAsync();
            var veterinariosList = _veterinarios.Select(v => new { 
                ID = v.ID_Veterinario, 
                NombreCompleto = $"{v.Nombre} {(string.IsNullOrEmpty(v.Especialidad) ? "" : $"({v.Especialidad})")}" 
            }).ToList();
            cmbVeterinario.DataSource = veterinariosList;
            cmbVeterinario.DisplayMember = "NombreCompleto";
            cmbVeterinario.ValueMember = "ID";
            cmbVeterinario.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar veterinarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task CargarServiciosAsync()
    {
        try
        {
            _servicios = await _servicioRepository.ListarAsync();
            clbServicios.Items.Clear();
            foreach (var servicio in _servicios)
            {
                clbServicios.Items.Add($"{servicio.Nombre} - ${servicio.Costo:F2}", false);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar servicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnBuscarPorFecha_Click(object? sender, EventArgs e)
    {
        try
        {
            btnBuscarPorFecha.Enabled = false;
            lblEstadoMensaje.Text = "Buscando citas...";
            lblEstadoMensaje.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            _citas = await _citaRepository.ListarPorFechaAsync(dtpFechaBuscar.Value);
            dgvCitas.DataSource = _citas;
            ConfigurarDataGridView();

            lblEstadoMensaje.Text = $"Se encontraron {_citas.Count} citas para la fecha seleccionada";
            lblEstadoMensaje.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al buscar citas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstadoMensaje.Text = "Error al buscar datos";
            lblEstadoMensaje.ForeColor = Color.Red;
        }
        finally
        {
            btnBuscarPorFecha.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private void ConfigurarDataGridView()
    {
        dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvCitas.AllowUserToAddRows = false;
        dgvCitas.ReadOnly = true;
        dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCitas.SelectionChanged += DgvCitas_SelectionChanged;
    }

    private void DgvCitas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvCitas.SelectedRows.Count > 0 && dgvCitas.SelectedRows[0] != null)
        {
            var cell = dgvCitas.SelectedRows[0].Cells["ID_Cita"];
            if (cell?.Value != null && cell.Value is int id)
            {
                _citaSeleccionada = _citas.FirstOrDefault(c => c.ID_Cita == id);
                if (_citaSeleccionada != null && !_modoEdicion)
                {
                    CargarDatosEnFormulario(_citaSeleccionada);
                }
            }
        }
    }

    private void CargarDatosEnFormulario(CitaDto cita)
    {
        // Cargar propietario
        var propietario = _propietarios.FirstOrDefault(p => p.ID_Propietario == cita.ID_Propietario);
        if (propietario != null)
        {
            var propItem = cmbPropietario.Items.Cast<object>().FirstOrDefault(item =>
            {
                var id = item.GetType().GetProperty("ID")?.GetValue(item);
                return id != null && id.Equals(propietario.ID_Propietario);
            });
            if (propItem != null)
            {
                cmbPropietario.SelectedItem = propItem;
            }
        }

        // Cargar mascota (se cargará automáticamente cuando se seleccione el propietario)
        // Esperar un momento para que se carguen las mascotas
        Application.DoEvents();
        if (cmbMascota.Items.Count > 0)
        {
            var mascotaItem = cmbMascota.Items.Cast<object>().FirstOrDefault(item =>
            {
                var id = item.GetType().GetProperty("ID")?.GetValue(item);
                return id != null && id.Equals(cita.ID_Mascota);
            });
            if (mascotaItem != null)
            {
                cmbMascota.SelectedItem = mascotaItem;
            }
        }

        // Cargar veterinario
        var veterinarioItem = cmbVeterinario.Items.Cast<object>().FirstOrDefault(item =>
        {
            var id = item.GetType().GetProperty("ID")?.GetValue(item);
            return id != null && id.Equals(cita.ID_Veterinario);
        });
        if (veterinarioItem != null)
        {
            cmbVeterinario.SelectedItem = veterinarioItem;
        }

        // Cargar servicio
        for (int i = 0; i < clbServicios.Items.Count; i++)
        {
            var texto = clbServicios.Items[i].ToString() ?? "";
            var nombreServicio = texto.Split('-')[0].Trim();
            var servicio = _servicios.FirstOrDefault(s => s.Nombre == nombreServicio && s.ID_Servicio == cita.ID_Servicio);
            clbServicios.SetItemChecked(i, servicio != null);
        }

        // Cargar fecha y hora
        dtpFechaEditar.Value = cita.Fecha;
        dtpHoraEditar.Value = new DateTime(cita.Fecha.Year, cita.Fecha.Month, cita.Fecha.Day).Add(cita.Hora);

        // Cargar estado
        cmbEstado.Text = cita.Estado;
    }

    private void ConfigurarModoEdicion(bool modoEdicion)
    {
        _modoEdicion = modoEdicion;
        cmbPropietario.Enabled = modoEdicion;
        cmbMascota.Enabled = modoEdicion;
        cmbVeterinario.Enabled = modoEdicion;
        clbServicios.Enabled = modoEdicion;
        dtpFechaEditar.Enabled = modoEdicion;
        dtpHoraEditar.Enabled = modoEdicion;
        cmbEstado.Enabled = modoEdicion;
        btnActualizar.Enabled = modoEdicion;
        btnLimpiar.Enabled = modoEdicion;
    }

    private void LimpiarFormulario()
    {
        cmbPropietario.SelectedIndex = -1;
        cmbMascota.DataSource = null;
        cmbMascota.Items.Clear();
        cmbVeterinario.SelectedIndex = -1;
        for (int i = 0; i < clbServicios.Items.Count; i++)
        {
            clbServicios.SetItemChecked(i, false);
        }
        dtpFechaEditar.Value = DateTime.Today;
        dtpHoraEditar.Value = DateTime.Now;
        cmbEstado.SelectedIndex = -1;
        _citaSeleccionada = null;
        ConfigurarModoEdicion(false);
    }

    private async void btnActualizar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_citaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una cita para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMascota.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una mascota.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbVeterinario.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un veterinario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener servicio seleccionado (solo uno para actualizar)
            int? idServicio = null;
            for (int i = 0; i < clbServicios.Items.Count; i++)
            {
                if (clbServicios.GetItemChecked(i))
                {
                    var texto = clbServicios.Items[i].ToString() ?? "";
                    var nombreServicio = texto.Split('-')[0].Trim();
                    var servicio = _servicios.FirstOrDefault(s => s.Nombre == nombreServicio);
                    if (servicio != null)
                    {
                        if (idServicio != null)
                        {
                            MessageBox.Show("Solo puede seleccionar un servicio para actualizar la cita.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        idServicio = servicio.ID_Servicio;
                    }
                }
            }

            if (idServicio == null)
            {
                MessageBox.Show("Debe seleccionar un servicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mascotaItem = cmbMascota.SelectedItem;
            if (mascotaItem == null)
            {
                MessageBox.Show("Debe seleccionar una mascota.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var mascotaId = mascotaItem.GetType().GetProperty("ID")?.GetValue(mascotaItem);
            if (mascotaId == null || !(mascotaId is int mascotaIdInt))
            {
                MessageBox.Show("Error al obtener el ID de la mascota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veterinarioItem = cmbVeterinario.SelectedItem;
            if (veterinarioItem == null)
            {
                MessageBox.Show("Debe seleccionar un veterinario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var veterinarioId = veterinarioItem.GetType().GetProperty("ID")?.GetValue(veterinarioItem);
            if (veterinarioId == null || !(veterinarioId is int veterinarioIdInt))
            {
                MessageBox.Show("Error al obtener el ID del veterinario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Debe seleccionar un estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnActualizar.Enabled = false;
            lblEstadoMensaje.Text = "Actualizando cita...";
            lblEstadoMensaje.ForeColor = Color.Blue;

            var dto = new CitaUpdateDto
            {
                ID_Cita = _citaSeleccionada.ID_Cita,
                Fecha = dtpFechaEditar.Value.Date,
                Hora = dtpHoraEditar.Value.TimeOfDay,
                ID_Mascota = mascotaIdInt,
                ID_Veterinario = veterinarioIdInt,
                ID_Servicio = idServicio.Value,
                Estado = cmbEstado.Text
            };

            await _citaRepository.ActualizarAsync(dto);
            MessageBox.Show("Cita actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            LimpiarFormulario();
            btnBuscarPorFecha_Click(sender, e);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar cita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnActualizar.Enabled = true;
        }
    }

    private void btnEditar_Click(object? sender, EventArgs e)
    {
        if (_citaSeleccionada == null)
        {
            MessageBox.Show("Seleccione una cita para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        ConfigurarModoEdicion(true);
        CargarDatosEnFormulario(_citaSeleccionada);
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        LimpiarFormulario();
    }

    private async void btnCancelar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_citaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una cita para cancelar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_citaSeleccionada.Estado == "Cancelada")
            {
                MessageBox.Show("La cita ya está cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"¿Está seguro de cancelar la cita del {_citaSeleccionada.Fecha:dd/MM/yyyy} a las {_citaSeleccionada.Hora:hh\\:mm}?",
                "Confirmar Cancelación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                btnCancelar.Enabled = false;
                lblEstadoMensaje.Text = "Cancelando cita...";
                lblEstadoMensaje.ForeColor = Color.Blue;

                await _citaRepository.CancelarAsync(_citaSeleccionada.ID_Cita);
                MessageBox.Show("Cita cancelada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBuscarPorFecha_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cancelar cita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnCancelar.Enabled = true;
        }
    }

    private void btnExportarExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_citas.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"Citas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Citas");

                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Fecha";
                worksheet.Cell(1, 3).Value = "Hora";
                worksheet.Cell(1, 4).Value = "Mascota";
                worksheet.Cell(1, 5).Value = "Propietario";
                worksheet.Cell(1, 6).Value = "Veterinario";
                worksheet.Cell(1, 7).Value = "Servicio";
                worksheet.Cell(1, 8).Value = "Estado";

                var headerRange = worksheet.Range(1, 1, 1, 8);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightYellow;

                for (int i = 0; i < _citas.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _citas[i].ID_Cita;
                    worksheet.Cell(row, 2).Value = _citas[i].Fecha;
                    worksheet.Cell(row, 3).Value = _citas[i].Hora.ToString(@"hh\:mm");
                    worksheet.Cell(row, 4).Value = _citas[i].Mascota ?? "";
                    worksheet.Cell(row, 5).Value = _citas[i].Propietario ?? "";
                    worksheet.Cell(row, 6).Value = _citas[i].Veterinario ?? "";
                    worksheet.Cell(row, 7).Value = _citas[i].Servicio ?? "";
                    worksheet.Cell(row, 8).Value = _citas[i].Estado;
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(saveDialog.FileName);
                MessageBox.Show($"Datos exportados exitosamente a:\n{saveDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

