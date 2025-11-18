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
    private List<CitaDto> _citas = new();
    private List<PropietarioDto> _propietarios = new();
    private List<MascotaDto> _mascotas = new();
    private CitaDto? _citaSeleccionada;

    public CitasForm(ICitaRepository citaRepository, IPropietarioRepository propietarioRepository, IMascotaRepository mascotaRepository)
    {
        InitializeComponent();
        _citaRepository = citaRepository;
        _propietarioRepository = propietarioRepository;
        _mascotaRepository = mascotaRepository;
    }

    private async void CitasForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        await CargarPropietariosAsync();
        dtpFechaBuscar.Value = DateTime.Today;
        cmbPropietario.SelectedIndexChanged += CmbPropietario_SelectedIndexChanged;
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBoxes con colores suaves
        gbxBuscar.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxAgendar.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
        // Botones con colores temáticos
        btnBuscarPorFecha.BackColor = Color.FromArgb(255, 152, 0); // Naranja suave
        btnBuscarPorFecha.ForeColor = Color.White;
        btnBuscarPorFecha.FlatStyle = FlatStyle.Flat;
        btnBuscarPorFecha.FlatAppearance.BorderSize = 0;
        
        btnAgendar.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnAgendar.ForeColor = Color.White;
        btnAgendar.FlatStyle = FlatStyle.Flat;
        btnAgendar.FlatAppearance.BorderSize = 0;
        
        btnCancelar.BackColor = Color.FromArgb(244, 67, 54); // Rojo suave
        btnCancelar.ForeColor = Color.White;
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.FlatAppearance.BorderSize = 0;
        
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

    private async void btnBuscarPorFecha_Click(object? sender, EventArgs e)
    {
        try
        {
            btnBuscarPorFecha.Enabled = false;
            lblEstado.Text = "Buscando citas...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            _citas = await _citaRepository.ListarPorFechaAsync(dtpFechaBuscar.Value);
            dgvCitas.DataSource = _citas;
            ConfigurarDataGridView();

            lblEstado.Text = $"Se encontraron {_citas.Count} citas para la fecha seleccionada";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al buscar citas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al buscar datos";
            lblEstado.ForeColor = Color.Red;
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
            }
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

            if (string.IsNullOrWhiteSpace(txtIDVeterinario.Text) || !int.TryParse(txtIDVeterinario.Text, out var idVeterinario))
            {
                MessageBox.Show("Debe ingresar un ID de veterinario válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIDServicio.Text) || !int.TryParse(txtIDServicio.Text, out var idServicio))
            {
                MessageBox.Show("Debe ingresar un ID de servicio válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var idMascota = mascotaIdInt;

            var dto = new CitaCreateDto
            {
                Fecha = dtpFechaAgendar.Value.Date,
                Hora = dtpHoraAgendar.Value.TimeOfDay,
                ID_Mascota = idMascota,
                ID_Veterinario = idVeterinario,
                ID_Servicio = idServicio
            };

            btnAgendar.Enabled = false;
            lblEstado.Text = "Agendando cita...";
            lblEstado.ForeColor = Color.Blue;

            await _citaRepository.AgendarAsync(dto);
            MessageBox.Show("Cita agendada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnBuscarPorFecha_Click(sender, e);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al agendar cita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnAgendar.Enabled = true;
        }
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
                lblEstado.Text = "Cancelando cita...";
                lblEstado.ForeColor = Color.Blue;

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

