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
        await CargarPropietariosAsync();
        await CargarVeterinariosAsync();
        await CargarServiciosAsync();
        dtpFecha.Value = DateTime.Today;
        dtpFecha.MinDate = DateTime.Today; // No permitir fechas pasadas
        dtpHora.Value = DateTime.Now;
        cmbPropietario.SelectedIndexChanged += CmbPropietario_SelectedIndexChanged;
        dtpFecha.ValueChanged += DtpFecha_ValueChanged; // Validar cuando cambie la fecha
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

    private async void btnAgendar_Click(object? sender, EventArgs e)
    {
        try
        {
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
        cmbPropietario.SelectedIndex = -1;
        cmbMascota.DataSource = null;
        cmbMascota.Items.Clear();
        cmbVeterinario.SelectedIndex = -1;
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

