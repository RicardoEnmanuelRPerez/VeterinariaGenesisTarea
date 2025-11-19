#nullable enable
using ClosedXML.Excel;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class HistorialClinicoForm : Form
{
    private readonly IHistorialRepository _historialRepository;
    private List<MascotaBusquedaDto> _mascotas = new();
    private List<HistorialClinicoDto> _historial = new();
    private MascotaBusquedaDto? _mascotaSeleccionada;

    public HistorialClinicoForm(IHistorialRepository historialRepository)
    {
        InitializeComponent();
        _historialRepository = historialRepository;
    }

    private void HistorialClinicoForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        ConfigurarDataGridViews();
        LimpiarDatosMascota();
        lblMensajeSinResultados.Visible = false;
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(240, 248, 255); // Azul muy claro
        
        // GroupBoxes con colores suaves
        gbxBusqueda.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxDatosMascota.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxHistorial.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
        // Botones con colores temáticos
        btnBuscar.BackColor = Color.FromArgb(255, 152, 0); // Naranja suave
        btnBuscar.ForeColor = Color.White;
        btnBuscar.FlatStyle = FlatStyle.Flat;
        btnBuscar.FlatAppearance.BorderSize = 0;
        
        btnLimpiar.BackColor = Color.FromArgb(158, 158, 158); // Gris
        btnLimpiar.ForeColor = Color.White;
        btnLimpiar.FlatStyle = FlatStyle.Flat;
        btnLimpiar.FlatAppearance.BorderSize = 0;
        
        btnExportarExcel.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnExportarExcel.ForeColor = Color.White;
        btnExportarExcel.FlatStyle = FlatStyle.Flat;
        btnExportarExcel.FlatAppearance.BorderSize = 0;
        
        // DataGridView con colores alternados suaves
        dgvMascotas.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvMascotas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvMascotas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
        dgvMascotas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvMascotas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvMascotas.EnableHeadersVisualStyles = false;
        
        dgvHistorial.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvHistorial.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
        dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvHistorial.EnableHeadersVisualStyles = false;
    }

    private void ConfigurarDataGridViews()
    {
        dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvMascotas.AllowUserToAddRows = false;
        dgvMascotas.ReadOnly = true;
        dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMascotas.SelectionChanged += DgvMascotas_SelectionChanged;

        dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvHistorial.AllowUserToAddRows = false;
        dgvHistorial.ReadOnly = true;
        dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private async void btnBuscar_Click(object? sender, EventArgs e)
    {
        // Validación con ErrorProvider
        errorProvider1.Clear();
        if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
        {
            errorProvider1.SetError(txtBusqueda, "Debe ingresar un criterio de búsqueda (nombre de mascota o propietario)");
            return;
        }

        await BuscarMascotasAsync();
    }

    private async Task BuscarMascotasAsync()
    {
        try
        {
            btnBuscar.Enabled = false;
            lblEstado.Text = "Buscando mascotas...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor; // Feedback visual
            Application.DoEvents();

            _mascotas = await _historialRepository.BuscarMascotasAsync(txtBusqueda.Text.Trim());
            dgvMascotas.DataSource = _mascotas;

            // Manejo de "Sin Resultados"
            if (_mascotas.Count == 0)
            {
                lblMensajeSinResultados.Text = $"No se encontraron mascotas con el criterio: '{txtBusqueda.Text}'";
                lblMensajeSinResultados.Visible = true;
                lblMensajeSinResultados.ForeColor = Color.Orange;
                LimpiarDatosMascota();
            }
            else
            {
                lblMensajeSinResultados.Visible = false;
                lblEstado.Text = $"Se encontraron {_mascotas.Count} mascota(s)";
                lblEstado.ForeColor = Color.Green;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al buscar mascotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al buscar mascotas";
            lblEstado.ForeColor = Color.Red;
            lblMensajeSinResultados.Visible = false;
        }
        finally
        {
            btnBuscar.Enabled = true;
            Cursor = Cursors.Default; // Restaurar cursor
        }
    }

    private async void DgvMascotas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvMascotas.SelectedRows.Count > 0 && dgvMascotas.SelectedRows[0] != null)
        {
            var cell = dgvMascotas.SelectedRows[0].Cells["ID_Mascota"];
            if (cell?.Value != null && int.TryParse(cell.Value.ToString(), out var id))
            {
                _mascotaSeleccionada = _mascotas.FirstOrDefault(m => m.ID_Mascota == id);
                if (_mascotaSeleccionada != null)
                {
                    CargarDatosMascota();
                    await CargarHistorialAsync(id);
                }
            }
        }
        else
        {
            LimpiarDatosMascota();
        }
    }

    private void CargarDatosMascota()
    {
        if (_mascotaSeleccionada == null) return;

        txtNombreMascota.Text = _mascotaSeleccionada.NombreMascota;
        txtEspecie.Text = _mascotaSeleccionada.Especie;
        txtRaza.Text = _mascotaSeleccionada.Raza ?? "N/A";
        txtFechaNacimiento.Text = _mascotaSeleccionada.Edad.HasValue ? $"{_mascotaSeleccionada.Edad.Value} años" : "N/A";
        txtPropietario.Text = _mascotaSeleccionada.NombrePropietario;
        txtTelefono.Text = _mascotaSeleccionada.Telefono ?? "N/A";
        txtDireccion.Text = _mascotaSeleccionada.Direccion ?? "N/A";
    }

    private async Task CargarHistorialAsync(int idMascota)
    {
        try
        {
            lblEstado.Text = "Cargando historial clínico...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            _historial = await _historialRepository.ObtenerHistorialPorMascotaAsync(idMascota);
            dgvHistorial.DataSource = _historial;

            // Aplicar colores según tipo de evento
            AplicarColoresPorTipoEvento();

            if (_historial.Count == 0)
            {
                lblMensajeSinResultados.Text = "Esta mascota no tiene historial clínico registrado.";
                lblMensajeSinResultados.Visible = true;
                lblMensajeSinResultados.ForeColor = Color.Orange;
            }
            else
            {
                lblMensajeSinResultados.Visible = false;
                lblEstado.Text = $"Historial cargado: {_historial.Count} evento(s) encontrado(s)";
                lblEstado.ForeColor = Color.Green;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al cargar historial";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void AplicarColoresPorTipoEvento()
    {
        foreach (DataGridViewRow row in dgvHistorial.Rows)
        {
            if (row.DataBoundItem is HistorialClinicoDto item)
            {
                // Colorear según tipo de evento
                switch (item.TipoEvento.ToUpper())
                {
                    case "CITA":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201); // Verde claro
                        break;
                    case "CIRUGÍA":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238); // Rojo claro
                        break;
                    case "TRATAMIENTO":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(227, 242, 253); // Azul claro
                        break;
                    case "HOSPITALIZACIÓN":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224); // Naranja claro
                        break;
                    case "VACUNA":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233); // Verde muy claro
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.White;
                        break;
                }
            }
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        txtBusqueda.Clear();
        errorProvider1.Clear();
        _mascotas.Clear();
        dgvMascotas.DataSource = null;
        LimpiarDatosMascota();
        _historial.Clear();
        dgvHistorial.DataSource = null;
        lblMensajeSinResultados.Visible = false;
        lblEstado.Text = "Listo";
        lblEstado.ForeColor = Color.Black;
    }

    private void LimpiarDatosMascota()
    {
        _mascotaSeleccionada = null;
        txtNombreMascota.Clear();
        txtEspecie.Clear();
        txtRaza.Clear();
        txtFechaNacimiento.Clear();
        txtPropietario.Clear();
        txtTelefono.Clear();
        txtDireccion.Clear();
    }

    private void btnExportarExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_historial.Count == 0)
            {
                MessageBox.Show("No hay historial para exportar. Busque y seleccione una mascota primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"HistorialClinico_{_mascotaSeleccionada?.NombreMascota ?? "Mascota"}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Historial Clínico");

                // Encabezados
                worksheet.Cell(1, 1).Value = "Tipo Evento";
                worksheet.Cell(1, 2).Value = "Fecha";
                worksheet.Cell(1, 3).Value = "Hora";
                worksheet.Cell(1, 4).Value = "Descripción";
                worksheet.Cell(1, 5).Value = "Veterinario";
                worksheet.Cell(1, 6).Value = "Costo";
                worksheet.Cell(1, 7).Value = "Estado";
                worksheet.Cell(1, 8).Value = "Observaciones";

                // Datos
                for (int i = 0; i < _historial.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _historial[i].TipoEvento;
                    worksheet.Cell(row, 2).Value = _historial[i].Fecha.ToString("dd/MM/yyyy");
                    worksheet.Cell(row, 3).Value = _historial[i].Hora?.ToString(@"hh\:mm") ?? "";
                    worksheet.Cell(row, 4).Value = _historial[i].Descripcion;
                    worksheet.Cell(row, 5).Value = _historial[i].Veterinario ?? "";
                    worksheet.Cell(row, 6).Value = _historial[i].Costo ?? 0;
                    worksheet.Cell(row, 7).Value = _historial[i].Estado ?? "";
                    worksheet.Cell(row, 8).Value = _historial[i].Observaciones ?? "";
                }

                // Formato de encabezados
                var headerRange = worksheet.Range(1, 1, 1, 8);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(76, 175, 80);
                headerRange.Style.Font.FontColor = XLColor.White;

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(saveDialog.FileName);

                MessageBox.Show($"Historial exportado exitosamente a:\n{saveDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void txtBusqueda_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            btnBuscar_Click(sender, e);
            e.Handled = true;
            e.SuppressKeyPress = true;
        }
    }
}

