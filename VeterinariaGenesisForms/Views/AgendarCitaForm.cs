#nullable enable
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class AgendarCitaForm : Form
{
    private readonly ICitaRepository _citaRepository;
    private readonly IPropietarioRepository _propietarioRepository;
    private readonly IMascotaRepository _mascotaRepository;
    private readonly IVeterinarioRepository _veterinarioRepository;
    private readonly IServicioRepository _servicioRepository;
    private List<PropietarioDto> _propietarios = new();
    private List<MascotaDto> _mascotas = new();
    private List<VeterinarioDto> _veterinarios = new();
    private List<ServicioDto> _servicios = new();

    public AgendarCitaForm(ICitaRepository citaRepository, IPropietarioRepository propietarioRepository, IMascotaRepository mascotaRepository, IVeterinarioRepository veterinarioRepository, IServicioRepository servicioRepository)
    {
        InitializeComponent();
        _citaRepository = citaRepository;
        _propietarioRepository = propietarioRepository;
        _mascotaRepository = mascotaRepository;
        _veterinarioRepository = veterinarioRepository;
        _servicioRepository = servicioRepository;
    }

    private async void AgendarCitaForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        ConfigurarDataGridViews();
        await CargarPropietariosAsync();
        await CargarVeterinariosAsync();
        await CargarServiciosAsync();
        dtpFecha.Value = DateTime.Today;
        dtpFecha.MinDate = DateTime.Today; // No permitir fechas pasadas
        dtpHora.Value = DateTime.Now;
        dtpFecha.ValueChanged += DtpFecha_ValueChanged; // Validar cuando cambie la fecha
    }

    private void ConfigurarDataGridViews()
    {
        ConfigurarDataGridViewPropietarios();
        ConfigurarDataGridViewMascotas();
        ConfigurarDataGridViewVeterinarios();
    }

    private void ConfigurarDataGridViewPropietarios()
    {
        dgvPropietarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvPropietarios.AllowUserToAddRows = false;
        dgvPropietarios.ReadOnly = true;
        dgvPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPropietarios.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvPropietarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvPropietarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
        dgvPropietarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvPropietarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        dgvPropietarios.EnableHeadersVisualStyles = false;
    }

    private void ConfigurarDataGridViewMascotas()
    {
        dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvMascotas.AllowUserToAddRows = false;
        dgvMascotas.ReadOnly = true;
        dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMascotas.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvMascotas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvMascotas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
        dgvMascotas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvMascotas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        dgvMascotas.EnableHeadersVisualStyles = false;
    }

    private void ConfigurarDataGridViewVeterinarios()
    {
        dgvVeterinarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvVeterinarios.AllowUserToAddRows = false;
        dgvVeterinarios.ReadOnly = true;
        dgvVeterinarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvVeterinarios.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvVeterinarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvVeterinarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0);
        dgvVeterinarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvVeterinarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        dgvVeterinarios.EnableHeadersVisualStyles = false;
    }

    private void DtpFecha_ValueChanged(object? sender, EventArgs e)
    {
        // Si la fecha seleccionada es hoy, validar que la hora no sea pasada
        if (dtpFecha.Value.Date == DateTime.Today)
        {
            var horaActual = DateTime.Now.TimeOfDay;
            if (dtpHora.Value.TimeOfDay < horaActual)
            {
                MessageBox.Show("No se pueden agendar citas para horas pasadas en el día de hoy.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpHora.Value = DateTime.Now;
            }
        }
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBoxes con colores suaves
        gbxDatos.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
        // Botones con colores temáticos
        btnAgendar.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnAgendar.ForeColor = Color.White;
        btnAgendar.FlatStyle = FlatStyle.Flat;
        btnAgendar.FlatAppearance.BorderSize = 0;
        
        btnLimpiar.BackColor = Color.FromArgb(158, 158, 158); // Gris
        btnLimpiar.ForeColor = Color.White;
        btnLimpiar.FlatStyle = FlatStyle.Flat;
        btnLimpiar.FlatAppearance.BorderSize = 0;
        
        // TextBoxes de búsqueda
        txtBuscarPropietario.BackColor = Color.White;
        txtBuscarPropietario.ForeColor = Color.Black;
        txtBuscarMascota.BackColor = Color.White;
        txtBuscarMascota.ForeColor = Color.Black;
        txtBuscarVeterinario.BackColor = Color.White;
        txtBuscarVeterinario.ForeColor = Color.Black;
    }

    private async Task CargarPropietariosAsync()
    {
        try
        {
            _propietarios = await _propietarioRepository.ListarActivosAsync();
            dgvPropietarios.DataSource = _propietarios;
            txtBuscarPropietario.Clear();
            
            // Asegurar que la columna ID_Propietario esté visible
            if (dgvPropietarios.Columns["ID_Propietario"] != null)
            {
                dgvPropietarios.Columns["ID_Propietario"].Visible = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar propietarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TxtBuscarPropietario_TextChanged(object? sender, EventArgs e)
    {
        try
        {
            var textoBusqueda = txtBuscarPropietario.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                // Si no hay texto, mostrar todos los propietarios
                dgvPropietarios.DataSource = _propietarios;
            }
            else
            {
                // Filtrar propietarios por nombre o apellidos (búsqueda parcial, case-insensitive)
                var propietariosFiltrados = _propietarios.Where(p => 
                    (p.Nombre ?? "").Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    (p.Apellidos ?? "").Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    $"{p.Nombre} {p.Apellidos}".Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase)
                ).ToList();
                
                dgvPropietarios.DataSource = propietariosFiltrados;
            }
            
            // Asegurar que la columna ID_Propietario esté visible
            if (dgvPropietarios.Columns["ID_Propietario"] != null)
            {
                dgvPropietarios.Columns["ID_Propietario"].Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblEstado.Text = $"Error al filtrar: {ex.Message}";
            lblEstado.ForeColor = Color.Red;
        }
    }

    private async void DgvPropietarios_SelectionChanged(object? sender, EventArgs e)
    {
        try
        {
            if (dgvPropietarios.SelectedRows.Count > 0 && dgvPropietarios.SelectedRows[0] != null)
            {
                var propietarioCell = dgvPropietarios.SelectedRows[0].Cells["ID_Propietario"];
                if (propietarioCell?.Value != null && int.TryParse(propietarioCell.Value.ToString(), out var propIdInt))
                {
                    await CargarMascotasAsync(propIdInt);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al seleccionar propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task CargarMascotasAsync(int idPropietario)
    {
        try
        {
            _mascotas = await _mascotaRepository.ListarPorPropietarioAsync(idPropietario);
            dgvMascotas.DataSource = _mascotas;
            txtBuscarMascota.Clear();
            
            // Asegurar que la columna ID_Mascota esté visible
            if (dgvMascotas.Columns["ID_Mascota"] != null)
            {
                dgvMascotas.Columns["ID_Mascota"].Visible = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar mascotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TxtBuscarMascota_TextChanged(object? sender, EventArgs e)
    {
        try
        {
            var textoBusqueda = txtBuscarMascota.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                // Si no hay texto, mostrar todas las mascotas
                dgvMascotas.DataSource = _mascotas;
            }
            else
            {
                // Filtrar mascotas por nombre (búsqueda parcial, case-insensitive)
                var mascotasFiltradas = _mascotas.Where(m => 
                    (m.Nombre ?? "").Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    (m.Especie ?? "").Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    (m.Raza ?? "").Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase)
                ).ToList();
                
                dgvMascotas.DataSource = mascotasFiltradas;
            }
            
            // Asegurar que la columna ID_Mascota esté visible
            if (dgvMascotas.Columns["ID_Mascota"] != null)
            {
                dgvMascotas.Columns["ID_Mascota"].Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblEstado.Text = $"Error al filtrar: {ex.Message}";
            lblEstado.ForeColor = Color.Red;
        }
    }

    private void DgvMascotas_SelectionChanged(object? sender, EventArgs e)
    {
        // La selección de mascota se maneja cuando se agenda la cita
    }

    private async Task CargarVeterinariosAsync()
    {
        try
        {
            _veterinarios = await _veterinarioRepository.ListarActivosAsync();
            dgvVeterinarios.DataSource = _veterinarios;
            txtBuscarVeterinario.Clear();
            
            // Asegurar que la columna ID_Veterinario esté visible
            if (dgvVeterinarios.Columns["ID_Veterinario"] != null)
            {
                dgvVeterinarios.Columns["ID_Veterinario"].Visible = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar veterinarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TxtBuscarVeterinario_TextChanged(object? sender, EventArgs e)
    {
        try
        {
            var textoBusqueda = txtBuscarVeterinario.Text.Trim();
            
            if (string.IsNullOrWhiteSpace(textoBusqueda))
            {
                // Si no hay texto, mostrar todos los veterinarios
                dgvVeterinarios.DataSource = _veterinarios;
            }
            else
            {
                // Filtrar veterinarios por nombre o especialidad (búsqueda parcial, case-insensitive)
                var veterinariosFiltrados = _veterinarios.Where(v => 
                    (v.Nombre ?? "").Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase) ||
                    (v.Especialidad ?? "").Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase)
                ).ToList();
                
                dgvVeterinarios.DataSource = veterinariosFiltrados;
            }
            
            // Asegurar que la columna ID_Veterinario esté visible
            if (dgvVeterinarios.Columns["ID_Veterinario"] != null)
            {
                dgvVeterinarios.Columns["ID_Veterinario"].Visible = true;
            }
        }
        catch (Exception ex)
        {
            lblEstado.Text = $"Error al filtrar: {ex.Message}";
            lblEstado.ForeColor = Color.Red;
        }
    }

    private void DgvVeterinarios_SelectionChanged(object? sender, EventArgs e)
    {
        // La selección de veterinario se maneja cuando se agenda la cita
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

    private async void btnAgendar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (dgvMascotas.SelectedRows.Count == 0 || dgvMascotas.SelectedRows[0] == null)
            {
                MessageBox.Show("Debe seleccionar una mascota del listado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvVeterinarios.SelectedRows.Count == 0 || dgvVeterinarios.SelectedRows[0] == null)
            {
                MessageBox.Show("Debe seleccionar un veterinario del listado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener servicios seleccionados
            var serviciosSeleccionados = new List<int>();
            for (int i = 0; i < clbServicios.Items.Count; i++)
            {
                if (clbServicios.GetItemChecked(i))
                {
                    var texto = clbServicios.Items[i].ToString() ?? "";
                    var nombreServicio = texto.Split('-')[0].Trim();
                    var servicio = _servicios.FirstOrDefault(s => s.Nombre == nombreServicio);
                    if (servicio != null)
                    {
                        serviciosSeleccionados.Add(servicio.ID_Servicio);
                    }
                }
            }

            if (serviciosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un servicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID de la mascota seleccionada
            var mascotaIdCell = dgvMascotas.SelectedRows[0].Cells["ID_Mascota"];
            if (mascotaIdCell?.Value == null || !int.TryParse(mascotaIdCell.Value.ToString(), out var mascotaIdInt))
            {
                MessageBox.Show("Error al obtener el ID de la mascota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el ID del veterinario seleccionado
            var veterinarioIdCell = dgvVeterinarios.SelectedRows[0].Cells["ID_Veterinario"];
            if (veterinarioIdCell?.Value == null || !int.TryParse(veterinarioIdCell.Value.ToString(), out var veterinarioIdInt))
            {
                MessageBox.Show("Error al obtener el ID del veterinario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnAgendar.Enabled = false;
            lblEstado.Text = "Agendando citas...";
            lblEstado.ForeColor = Color.Blue;

            // Validar que la fecha no sea pasada
            var fecha = dtpFecha.Value.Date;
            var hora = dtpHora.Value.TimeOfDay;
            
            if (fecha < DateTime.Today)
            {
                MessageBox.Show("No se pueden agendar citas para fechas pasadas.", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si la fecha es hoy, validar que la hora no sea pasada
            if (fecha == DateTime.Today)
            {
                var horaActual = DateTime.Now.TimeOfDay;
                if (hora < horaActual)
                {
                    MessageBox.Show("No se pueden agendar citas para horas pasadas en el día de hoy.", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            int citasCreadas = 0;
            int errores = 0;

            // Crear una cita por cada servicio seleccionado
            foreach (var idServicio in serviciosSeleccionados)
            {
                try
                {
                    var dto = new CitaCreateDto
                    {
                        Fecha = fecha,
                        Hora = hora,
                        ID_Mascota = mascotaIdInt,
                        ID_Veterinario = veterinarioIdInt,
                        ID_Servicio = idServicio
                    };

                    await _citaRepository.AgendarAsync(dto);
                    citasCreadas++;
                }
                catch (Exception ex)
                {
                    errores++;
                    // Continuar con los demás servicios aunque uno falle
                }
            }

            if (citasCreadas > 0)
            {
                var mensaje = $"Se agendaron {citasCreadas} cita(s) exitosamente.";
                if (errores > 0)
                {
                    mensaje += $"\n{errores} cita(s) no pudieron ser agendadas.";
                }
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("No se pudo agendar ninguna cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al agendar cita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnAgendar.Enabled = true;
            lblEstado.Text = "";
        }
    }

    private void LimpiarFormulario()
    {
        dgvPropietarios.ClearSelection();
        txtBuscarPropietario.Clear();
        dgvMascotas.DataSource = null;
        _mascotas.Clear();
        dgvMascotas.ClearSelection();
        txtBuscarMascota.Clear();
        dgvVeterinarios.ClearSelection();
        txtBuscarVeterinario.Clear();
        for (int i = 0; i < clbServicios.Items.Count; i++)
        {
            clbServicios.SetItemChecked(i, false);
        }
        dtpFecha.Value = DateTime.Today;
        dtpHora.Value = DateTime.Now;
        lblEstado.Text = "";
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        LimpiarFormulario();
    }
}

