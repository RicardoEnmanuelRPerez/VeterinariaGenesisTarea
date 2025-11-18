#nullable enable
using ClosedXML.Excel;
using ScottPlot.WinForms;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class ReporteServiciosVendidosForm : Form
{
    private readonly IReporteRepository _reporteRepository;
    private List<ReporteServicioVendidoDto> _datos = new();

    public ReporteServiciosVendidosForm(IReporteRepository reporteRepository)
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
        dgvDatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
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

            _datos = await _reporteRepository.ObtenerReporteServiciosVendidosAsync(fechaInicio, fechaFin);

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

        if (dgvDatos.Columns["PrecioUnitario"] != null)
            dgvDatos.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
        if (dgvDatos.Columns["TotalIngresos"] != null)
            dgvDatos.Columns["TotalIngresos"].DefaultCellStyle.Format = "C2";
    }

    private void ActualizarGrafica()
    {
        formsPlot1.Plot.Clear();
        if (_datos.Count == 0) return;

        var top10 = _datos.OrderByDescending(x => x.CantidadVendida).Take(10).ToList();
        var nombres = top10.Select(x => x.NombreServicio.Length > 20 ? x.NombreServicio.Substring(0, 20) + "..." : x.NombreServicio).ToArray();
        var valores = top10.Select(x => (double)x.CantidadVendida).ToArray();

        var bar = formsPlot1.Plot.Add.Bars(valores);
        bar.Color = ScottPlot.Colors.Green;
        formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
        formsPlot1.Plot.Axes.Bottom.TickLabelStyle.FontSize = 8;
        
        // Simplificar: usar índices numéricos en lugar de etiquetas personalizadas
        // Las etiquetas personalizadas requieren una API más compleja
        formsPlot1.Plot.Title("Top 10 Servicios Más Vendidos");
        formsPlot1.Plot.Axes.Left.Label.Text = "Cantidad Vendida";
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
                FileName = $"ReporteServiciosVendidos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Servicios Vendidos");

                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre Servicio";
                worksheet.Cell(1, 3).Value = "Descripción";
                worksheet.Cell(1, 4).Value = "Precio Unitario";
                worksheet.Cell(1, 5).Value = "Cantidad Vendida";
                worksheet.Cell(1, 6).Value = "Total Ingresos";
                worksheet.Cell(1, 7).Value = "Cantidad Facturas";

                var headerRange = worksheet.Range(1, 1, 1, 7);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGreen;

                for (int i = 0; i < _datos.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _datos[i].IdServicio;
                    worksheet.Cell(row, 2).Value = _datos[i].NombreServicio;
                    worksheet.Cell(row, 3).Value = _datos[i].Descripcion ?? "";
                worksheet.Cell(row, 4).Value = _datos[i].PrecioUnitario;
                worksheet.Cell(row, 5).Value = _datos[i].CantidadVendida;
                worksheet.Cell(row, 6).Value = _datos[i].TotalIngresos;
                worksheet.Cell(row, 7).Value = _datos[i].CantidadFacturas;
            }

                worksheet.Column(4).Style.NumberFormat.Format = "$#,##0.00";
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

