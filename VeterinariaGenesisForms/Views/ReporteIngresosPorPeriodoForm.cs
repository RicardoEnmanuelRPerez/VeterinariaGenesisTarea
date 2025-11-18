#nullable enable
using ClosedXML.Excel;
using ScottPlot.WinForms;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class ReporteIngresosPorPeriodoForm : Form
{
    private readonly IReporteRepository _reporteRepository;
    private List<ReporteIngresoPeriodoDto> _datos = new();

    public ReporteIngresosPorPeriodoForm(IReporteRepository reporteRepository)
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
        dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(156, 39, 176);
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

            _datos = await _reporteRepository.ObtenerReporteIngresosPorPeriodoAsync(fechaInicio, fechaFin);

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

        if (dgvDatos.Columns["IngresosPagados"] != null)
            dgvDatos.Columns["IngresosPagados"].DefaultCellStyle.Format = "C2";
        if (dgvDatos.Columns["IngresosPendientes"] != null)
            dgvDatos.Columns["IngresosPendientes"].DefaultCellStyle.Format = "C2";
        if (dgvDatos.Columns["TotalFacturado"] != null)
            dgvDatos.Columns["TotalFacturado"].DefaultCellStyle.Format = "C2";
    }

    private void ActualizarGrafica()
    {
        formsPlot1.Plot.Clear();
        if (_datos.Count == 0) return;

        var fechas = _datos.Select(x => x.Fecha.ToOADate()).ToArray();
        var ingresos = _datos.Select(x => (double)x.IngresosPagados).ToArray();

        var scatter = formsPlot1.Plot.Add.Scatter(fechas, ingresos);
        scatter.Color = ScottPlot.Colors.Blue;
        scatter.LineWidth = 2;
        // El formato de fecha se aplicará automáticamente al usar ToOADate()
        formsPlot1.Plot.Title("Ingresos por Período");
        formsPlot1.Plot.Axes.Left.Label.Text = "Ingresos ($)";
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
                FileName = $"ReporteIngresosPorPeriodo_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Ingresos por Período");

                worksheet.Cell(1, 1).Value = "Fecha";
                worksheet.Cell(1, 2).Value = "Cantidad Facturas";
                worksheet.Cell(1, 3).Value = "Cantidad Clientes";
                worksheet.Cell(1, 4).Value = "Ingresos Pagados";
                worksheet.Cell(1, 5).Value = "Ingresos Pendientes";
                worksheet.Cell(1, 6).Value = "Total Facturado";

                var headerRange = worksheet.Range(1, 1, 1, 6);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;

                for (int i = 0; i < _datos.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _datos[i].Fecha;
                    worksheet.Cell(row, 2).Value = _datos[i].CantidadFacturas;
                    worksheet.Cell(row, 3).Value = _datos[i].CantidadClientes;
                    worksheet.Cell(row, 4).Value = _datos[i].IngresosPagados;
                    worksheet.Cell(row, 5).Value = _datos[i].IngresosPendientes;
                    worksheet.Cell(row, 6).Value = _datos[i].TotalFacturado;
                }

                worksheet.Column(4).Style.NumberFormat.Format = "$#,##0.00";
                worksheet.Column(5).Style.NumberFormat.Format = "$#,##0.00";
                worksheet.Column(6).Style.NumberFormat.Format = "$#,##0.00";
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

