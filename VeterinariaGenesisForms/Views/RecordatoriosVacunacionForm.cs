#nullable enable
using ClosedXML.Excel;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class RecordatoriosVacunacionForm : Form
{
    private readonly IVacunaRepository _vacunaRepository;
    private List<RecordatorioVacunacionDto> _recordatorios = new();

    public RecordatoriosVacunacionForm(IVacunaRepository vacunaRepository)
    {
        InitializeComponent();
        _vacunaRepository = vacunaRepository;
    }

    private void RecordatoriosVacunacionForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        ConfigurarDataGridView();
        numDiasAnticipacion.Value = 30;
        lblMensajeSinResultados.Visible = false;
    }

    private void AplicarColoresVeterinaria()
    {
        this.BackColor = Color.FromArgb(240, 248, 255);
        
        gbxFiltros.BackColor = Color.FromArgb(255, 255, 255);
        gbxResultados.BackColor = Color.FromArgb(255, 255, 255);
        
        btnGenerar.BackColor = Color.FromArgb(76, 175, 80);
        btnGenerar.ForeColor = Color.White;
        btnGenerar.FlatStyle = FlatStyle.Flat;
        btnGenerar.FlatAppearance.BorderSize = 0;
        
        btnExportarExcel.BackColor = Color.FromArgb(76, 175, 80);
        btnExportarExcel.ForeColor = Color.White;
        btnExportarExcel.FlatStyle = FlatStyle.Flat;
        btnExportarExcel.FlatAppearance.BorderSize = 0;
        
        dgvRecordatorios.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvRecordatorios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvRecordatorios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
        dgvRecordatorios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvRecordatorios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvRecordatorios.EnableHeadersVisualStyles = false;
    }

    private void ConfigurarDataGridView()
    {
        dgvRecordatorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvRecordatorios.AllowUserToAddRows = false;
        dgvRecordatorios.ReadOnly = true;
        dgvRecordatorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private async void btnGenerar_Click(object? sender, EventArgs e)
    {
        await CargarRecordatoriosAsync();
    }

    private async Task CargarRecordatoriosAsync()
    {
        try
        {
            btnGenerar.Enabled = false;
            lblEstado.Text = "Cargando recordatorios...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            var diasAnticipacion = (int)numDiasAnticipacion.Value;
            _recordatorios = await _vacunaRepository.ObtenerRecordatoriosAsync(diasAnticipacion);
            dgvRecordatorios.DataSource = _recordatorios;

            // Aplicar colores según estado
            AplicarColoresPorEstado();

            // Manejo de "Sin Resultados"
            if (_recordatorios.Count == 0)
            {
                lblMensajeSinResultados.Text = $"No hay vacunas vencidas o por vencer en los próximos {diasAnticipacion} días.";
                lblMensajeSinResultados.Visible = true;
                lblMensajeSinResultados.ForeColor = Color.Green;
                lblEstado.Text = "No hay recordatorios pendientes";
                lblEstado.ForeColor = Color.Green;
            }
            else
            {
                lblMensajeSinResultados.Visible = false;
                var vencidas = _recordatorios.Count(r => r.Estado == "Vencida");
                var porVencer = _recordatorios.Count(r => r.Estado == "Por vencer");
                lblEstado.Text = $"Se encontraron {_recordatorios.Count} recordatorio(s): {vencidas} vencida(s), {porVencer} por vencer";
                lblEstado.ForeColor = vencidas > 0 ? Color.Red : Color.Orange;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar recordatorios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al cargar recordatorios";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnGenerar.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private void AplicarColoresPorEstado()
    {
        foreach (DataGridViewRow row in dgvRecordatorios.Rows)
        {
            if (row.DataBoundItem is RecordatorioVacunacionDto item)
            {
                switch (item.Estado.ToUpper())
                {
                    case "VENCIDA":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 238); // Rojo claro
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(198, 40, 40); // Rojo oscuro
                        break;
                    case "POR VENCER":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224); // Naranja claro
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(230, 126, 34); // Naranja oscuro
                        break;
                    case "VIGENTE":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 201); // Verde claro
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(27, 94, 32); // Verde oscuro
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }
    }

    private void btnExportarExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_recordatorios.Count == 0)
            {
                MessageBox.Show("No hay recordatorios para exportar. Genere el reporte primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"RecordatoriosVacunacion_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Recordatorios de Vacunación");

                // Encabezados
                worksheet.Cell(1, 1).Value = "Mascota";
                worksheet.Cell(1, 2).Value = "Especie";
                worksheet.Cell(1, 3).Value = "Raza";
                worksheet.Cell(1, 4).Value = "Propietario";
                worksheet.Cell(1, 5).Value = "Teléfono";
                worksheet.Cell(1, 6).Value = "Dirección";
                worksheet.Cell(1, 7).Value = "Vacuna";
                worksheet.Cell(1, 8).Value = "Dosis";
                worksheet.Cell(1, 9).Value = "Fecha Aplicación";
                worksheet.Cell(1, 10).Value = "Próxima Dosis";
                worksheet.Cell(1, 11).Value = "Estado";
                worksheet.Cell(1, 12).Value = "Días Restantes";

                // Datos
                for (int i = 0; i < _recordatorios.Count; i++)
                {
                    var row = i + 2;
                    var item = _recordatorios[i];
                    worksheet.Cell(row, 1).Value = item.NombreMascota;
                    worksheet.Cell(row, 2).Value = item.Especie;
                    worksheet.Cell(row, 3).Value = item.Raza ?? "";
                    worksheet.Cell(row, 4).Value = item.NombrePropietario;
                    worksheet.Cell(row, 5).Value = item.Telefono ?? "";
                    worksheet.Cell(row, 6).Value = item.Direccion ?? "";
                    worksheet.Cell(row, 7).Value = item.NombreVacuna;
                    worksheet.Cell(row, 8).Value = item.Dosis ?? "";
                    worksheet.Cell(row, 9).Value = item.FechaAplicacion.ToString("dd/MM/yyyy");
                    worksheet.Cell(row, 10).Value = item.FechaProximaDosis?.ToString("dd/MM/yyyy") ?? "N/A";
                    worksheet.Cell(row, 11).Value = item.Estado;
                    worksheet.Cell(row, 12).Value = item.DiasRestantes?.ToString() ?? "N/A";
                }

                // Formato de encabezados
                var headerRange = worksheet.Range(1, 1, 1, 12);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(76, 175, 80);
                headerRange.Style.Font.FontColor = XLColor.White;

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(saveDialog.FileName);

                MessageBox.Show($"Recordatorios exportados exitosamente a:\n{saveDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}

