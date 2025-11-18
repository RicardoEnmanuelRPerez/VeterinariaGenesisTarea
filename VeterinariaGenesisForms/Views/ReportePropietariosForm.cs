#nullable enable
using ClosedXML.Excel;
using ScottPlot.WinForms;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class ReportePropietariosForm : Form
{
    private readonly IReporteRepository _reporteRepository;
    private List<ReportePropietarioDto> _datos = new();

    public ReportePropietariosForm(IReporteRepository reporteRepository)
    {
        InitializeComponent();
        _reporteRepository = reporteRepository;
        AplicarColoresVeterinaria();
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBox con color suave
        gbxFiltros.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
        // Botones con colores temáticos
        btnGenerar.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnGenerar.ForeColor = Color.White;
        btnGenerar.FlatStyle = FlatStyle.Flat;
        btnGenerar.FlatAppearance.BorderSize = 0;
        
        btnExportarExcel.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnExportarExcel.ForeColor = Color.White;
        btnExportarExcel.FlatStyle = FlatStyle.Flat;
        btnExportarExcel.FlatAppearance.BorderSize = 0;
        
        // DataGridView con colores alternados suaves
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

            DateOnly? fechaInicio = dtpFechaInicio.Checked ? DateOnly.FromDateTime(dtpFechaInicio.Value) : null;
            DateOnly? fechaFin = dtpFechaFin.Checked ? DateOnly.FromDateTime(dtpFechaFin.Value) : null;

            _datos = await _reporteRepository.ObtenerReportePropietariosAsync(fechaInicio, fechaFin);

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

        // Formatear columnas numéricas
        if (dgvDatos.Columns["TotalPagado"] != null)
            dgvDatos.Columns["TotalPagado"].DefaultCellStyle.Format = "C2";
        if (dgvDatos.Columns["TotalPendiente"] != null)
            dgvDatos.Columns["TotalPendiente"].DefaultCellStyle.Format = "C2";
    }

    private void ActualizarGrafica()
    {
        formsPlot1.Plot.Clear();

        if (_datos.Count == 0) return;

        var top10 = _datos.OrderByDescending(x => x.TotalPagado).Take(10).ToList();
        var nombres = top10.Select(x => x.NombreCompleto.Length > 20 ? x.NombreCompleto.Substring(0, 20) + "..." : x.NombreCompleto).ToArray();
        var valores = top10.Select(x => (double)x.TotalPagado).ToArray();

        var bar = formsPlot1.Plot.Add.Bars(valores);
        bar.Color = ScottPlot.Colors.Blue;
        formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
        formsPlot1.Plot.Axes.Bottom.TickLabelStyle.FontSize = 8;
        
        // Simplificar: usar índices numéricos en lugar de etiquetas personalizadas
        // Las etiquetas personalizadas requieren una API más compleja
        formsPlot1.Plot.Title("Top 10 Propietarios por Total Pagado");
        formsPlot1.Plot.Axes.Left.Label.Text = "Total Pagado ($)";
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
                FileName = $"ReportePropietarios_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Reporte Propietarios");

                // Encabezados
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre Completo";
                worksheet.Cell(1, 3).Value = "Teléfono";
                worksheet.Cell(1, 4).Value = "Dirección";
                worksheet.Cell(1, 5).Value = "Cantidad Facturas";
                worksheet.Cell(1, 6).Value = "Total Pagado";
                worksheet.Cell(1, 7).Value = "Total Pendiente";
                worksheet.Cell(1, 8).Value = "Cantidad Mascotas";

                // Estilo de encabezados
                var headerRange = worksheet.Range(1, 1, 1, 8);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;

                // Datos
                for (int i = 0; i < _datos.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _datos[i].IdPropietario;
                    worksheet.Cell(row, 2).Value = _datos[i].NombreCompleto;
                    worksheet.Cell(row, 3).Value = _datos[i].Telefono ?? "";
                    worksheet.Cell(row, 4).Value = _datos[i].Direccion ?? "";
                    worksheet.Cell(row, 5).Value = _datos[i].CantidadFacturas;
                    worksheet.Cell(row, 6).Value = _datos[i].TotalPagado;
                    worksheet.Cell(row, 7).Value = _datos[i].TotalPendiente;
                    worksheet.Cell(row, 8).Value = _datos[i].CantidadMascotas;
                }

                // Formato de moneda
                worksheet.Column(6).Style.NumberFormat.Format = "$#,##0.00";
                worksheet.Column(7).Style.NumberFormat.Format = "$#,##0.00";

                // Ajustar ancho de columnas
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

