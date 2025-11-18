#nullable enable
using ClosedXML.Excel;
using ScottPlot.WinForms;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class ReporteCitasPorVeterinarioForm : Form
{
    private readonly IReporteRepository _reporteRepository;
    private List<ReporteCitaVeterinarioDto> _datos = new();

    public ReporteCitasPorVeterinarioForm(IReporteRepository reporteRepository)
    {
        InitializeComponent();
        _reporteRepository = reporteRepository;
        AplicarColoresVeterinaria();
    }

    private void AplicarColoresVeterinaria()
    {
        this.BackColor = Color.FromArgb(245, 250, 247);
        gbxFiltros.BackColor = Color.FromArgb(255, 255, 255);
        
        btnGenerar.BackColor = Color.FromArgb(76, 175, 80);
        btnGenerar.ForeColor = Color.White;
        btnGenerar.FlatStyle = FlatStyle.Flat;
        btnGenerar.FlatAppearance.BorderSize = 0;
        
        btnExportarExcel.BackColor = Color.FromArgb(76, 175, 80);
        btnExportarExcel.ForeColor = Color.White;
        btnExportarExcel.FlatStyle = FlatStyle.Flat;
        btnExportarExcel.FlatAppearance.BorderSize = 0;
        
        dgvDatos.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvDatos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0);
        dgvDatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvDatos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvDatos.EnableHeadersVisualStyles = false;
    }

    private void chkFechaInicio_CheckedChanged(object? sender, EventArgs e)
    {
        dtpFechaInicio.Enabled = chkFechaInicio.Checked;
    }

    private void chkFechaFin_CheckedChanged(object? sender, EventArgs e)
    {
        dtpFechaFin.Enabled = chkFechaFin.Checked;
    }

    private async void btnGenerar_Click(object? sender, EventArgs e)
    {
        try
        {
            btnGenerar.Enabled = false;
            lblEstado.Text = "Cargando datos...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            DateOnly? fechaInicio = chkFechaInicio.Checked ? DateOnly.FromDateTime(dtpFechaInicio.Value) : null;
            DateOnly? fechaFin = chkFechaFin.Checked ? DateOnly.FromDateTime(dtpFechaFin.Value) : null;

            _datos = await _reporteRepository.ObtenerReporteCitasPorVeterinarioAsync(fechaInicio, fechaFin);

            dgvDatos.DataSource = _datos;
            ConfigurarDataGridView();
            ActualizarGrafica();

            lblEstado.Text = $"Se encontraron {_datos.Count} registros";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al cargar datos";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnGenerar.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private void ConfigurarDataGridView()
    {
        dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvDatos.AllowUserToAddRows = false;
        dgvDatos.ReadOnly = true;
        dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        if (dgvDatos.Columns["TotalIngresos"] != null)
            dgvDatos.Columns["TotalIngresos"].DefaultCellStyle.Format = "C2";
    }

    private void ActualizarGrafica()
    {
        formsPlot1.Plot.Clear();
        if (_datos.Count == 0) return;

        var nombres = _datos.Select(x => x.NombreVeterinario.Length > 15 ? x.NombreVeterinario.Substring(0, 15) + "..." : x.NombreVeterinario).ToArray();
        var valores = _datos.Select(x => (double)x.CantidadCitas).ToArray();

        var bar = formsPlot1.Plot.Add.Bars(valores);
        bar.Color = ScottPlot.Colors.Orange;
        formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
        formsPlot1.Plot.Axes.Bottom.TickLabelStyle.FontSize = 8;
        
        // Simplificar: usar índices numéricos en lugar de etiquetas personalizadas
        // Las etiquetas personalizadas requieren una API más compleja
        formsPlot1.Plot.Title("Citas por Veterinario");
        formsPlot1.Plot.Axes.Left.Label.Text = "Cantidad de Citas";
        formsPlot1.Refresh();
    }

    private void btnExportarExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_datos.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar. Genere el reporte primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"ReporteCitasPorVeterinario_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Citas por Veterinario");

                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Veterinario";
                worksheet.Cell(1, 3).Value = "Especialidad";
                worksheet.Cell(1, 4).Value = "Cantidad Citas";
                worksheet.Cell(1, 5).Value = "Completadas";
                worksheet.Cell(1, 6).Value = "Canceladas";
                worksheet.Cell(1, 7).Value = "Programadas";
                worksheet.Cell(1, 8).Value = "Total Ingresos";

                var headerRange = worksheet.Range(1, 1, 1, 8);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 200, 150);

                for (int i = 0; i < _datos.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _datos[i].IdVeterinario;
                    worksheet.Cell(row, 2).Value = _datos[i].NombreVeterinario;
                    worksheet.Cell(row, 3).Value = _datos[i].Especialidad ?? "";
                    worksheet.Cell(row, 4).Value = _datos[i].CantidadCitas;
                    worksheet.Cell(row, 5).Value = _datos[i].CitasCompletadas;
                    worksheet.Cell(row, 6).Value = _datos[i].CitasCanceladas;
                    worksheet.Cell(row, 7).Value = _datos[i].CitasProgramadas;
                    worksheet.Cell(row, 8).Value = _datos[i].TotalIngresos;
                }

                worksheet.Column(8).Style.NumberFormat.Format = "$#,##0.00";
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(saveDialog.FileName);
                MessageBox.Show($"Reporte exportado exitosamente a:\n{saveDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

