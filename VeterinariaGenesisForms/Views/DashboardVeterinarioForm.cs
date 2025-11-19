#nullable enable
using ClosedXML.Excel;
using ScottPlot.WinForms;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class DashboardVeterinarioForm : Form
{
    private readonly IDashboardRepository _dashboardRepository;
    private List<DashboardCirugiasDto> _cirugias = new();
    private List<DashboardCitasDiaSemanaDto> _citasPorDia = new();
    private List<DashboardProductividadDto> _productividad = new();

    public DashboardVeterinarioForm(IDashboardRepository dashboardRepository)
    {
        InitializeComponent();
        _dashboardRepository = dashboardRepository;
    }

    private void DashboardVeterinarioForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        ConfigurarDataGridViews();
        chkFechaInicio.Checked = false;
        chkFechaFin.Checked = false;
        dtpFechaInicio.Enabled = false;
        dtpFechaFin.Enabled = false;
        dtpFechaInicio.Value = DateTime.Today.AddMonths(-1);
        dtpFechaFin.Value = DateTime.Today;
    }

    private void AplicarColoresVeterinaria()
    {
        this.BackColor = Color.FromArgb(240, 248, 255);
        
        gbxFiltros.BackColor = Color.FromArgb(255, 255, 255);
        gbxCirugias.BackColor = Color.FromArgb(255, 255, 255);
        gbxCitas.BackColor = Color.FromArgb(255, 255, 255);
        gbxProductividad.BackColor = Color.FromArgb(255, 255, 255);
        
        btnGenerar.BackColor = Color.FromArgb(76, 175, 80);
        btnGenerar.ForeColor = Color.White;
        btnGenerar.FlatStyle = FlatStyle.Flat;
        btnGenerar.FlatAppearance.BorderSize = 0;
        
        btnExportarExcel.BackColor = Color.FromArgb(76, 175, 80);
        btnExportarExcel.ForeColor = Color.White;
        btnExportarExcel.FlatStyle = FlatStyle.Flat;
        btnExportarExcel.FlatAppearance.BorderSize = 0;
        
        // DataGridViews
        dgvCirugias.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvCirugias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvCirugias.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 152, 0);
        dgvCirugias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvCirugias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvCirugias.EnableHeadersVisualStyles = false;
        
        dgvProductividad.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvProductividad.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvProductividad.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
        dgvProductividad.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvProductividad.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvProductividad.EnableHeadersVisualStyles = false;
    }

    private void ConfigurarDataGridViews()
    {
        dgvCirugias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvCirugias.AllowUserToAddRows = false;
        dgvCirugias.ReadOnly = true;
        dgvCirugias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        
        dgvProductividad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvProductividad.AllowUserToAddRows = false;
        dgvProductividad.ReadOnly = true;
        dgvProductividad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        
        if (dgvProductividad.Columns["IngresosGenerados"] != null)
            dgvProductividad.Columns["IngresosGenerados"].DefaultCellStyle.Format = "C2";
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
        await CargarDatosAsync();
    }

    private async Task CargarDatosAsync()
    {
        try
        {
            btnGenerar.Enabled = false;
            lblEstado.Text = "Cargando datos del dashboard...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            DateOnly? fechaInicio = chkFechaInicio.Checked ? DateOnly.FromDateTime(dtpFechaInicio.Value) : null;
            DateOnly? fechaFin = chkFechaFin.Checked ? DateOnly.FromDateTime(dtpFechaFin.Value) : null;

            // Cargar todos los datos en paralelo
            var taskCirugias = _dashboardRepository.ObtenerCirugiasPorVeterinarioAsync(fechaInicio, fechaFin);
            var taskCitas = _dashboardRepository.ObtenerCitasPorDiaSemanaAsync(fechaInicio, fechaFin);
            var taskProductividad = _dashboardRepository.ObtenerProductividadVeterinarioAsync(fechaInicio, fechaFin);

            await Task.WhenAll(taskCirugias, taskCitas, taskProductividad);

            _cirugias = await taskCirugias;
            _citasPorDia = await taskCitas;
            _productividad = await taskProductividad;

            // Actualizar DataGridViews
            dgvCirugias.DataSource = _cirugias;
            dgvProductividad.DataSource = _productividad;

            // Actualizar gráficas
            ActualizarGraficaCirugias();
            ActualizarGraficaCitas();

            lblEstado.Text = $"Dashboard actualizado: {_cirugias.Count} veterinario(s) con cirugías, {_productividad.Count} veterinario(s) con actividad";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos del dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al cargar datos";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnGenerar.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private void ActualizarGraficaCirugias()
    {
        formsPlotCirugias.Plot.Clear();
        if (_cirugias.Count == 0) return;

        var nombres = _cirugias.Select(x => x.NombreVeterinario.Length > 15 ? x.NombreVeterinario.Substring(0, 15) + "..." : x.NombreVeterinario).ToArray();
        var valores = _cirugias.Select(x => (double)x.CantidadCirugias).ToArray();

        // Usar gráfico de barras vertical en lugar de pie chart para mejor compatibilidad
        var bar = formsPlotCirugias.Plot.Add.Bars(valores);
        bar.Color = ScottPlot.Colors.Orange;
        formsPlotCirugias.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
        formsPlotCirugias.Plot.Axes.Bottom.TickLabelStyle.FontSize = 8;
        formsPlotCirugias.Plot.Title("Cirugías por Veterinario");
        formsPlotCirugias.Plot.Axes.Left.Label.Text = "Cantidad de Cirugías";
        formsPlotCirugias.Refresh();
    }

    private void ActualizarGraficaCitas()
    {
        formsPlotCitas.Plot.Clear();
        if (_citasPorDia.Count == 0) return;

        var dias = _citasPorDia.Select(x => x.DiaSemana).ToArray();
        var valores = _citasPorDia.Select(x => (double)x.CantidadCitas).ToArray();

        var bar = formsPlotCitas.Plot.Add.Bars(valores);
        bar.Color = ScottPlot.Colors.Blue;
        formsPlotCitas.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
        formsPlotCitas.Plot.Axes.Bottom.TickLabelStyle.FontSize = 8;
        formsPlotCitas.Plot.Title("Citas por Día de la Semana");
        formsPlotCitas.Plot.Axes.Left.Label.Text = "Cantidad de Citas";
        formsPlotCitas.Refresh();
    }

    private void btnExportarExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_cirugias.Count == 0 && _productividad.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar. Genere el dashboard primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"DashboardVeterinario_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                using var workbook = new XLWorkbook();

                // Hoja 1: Cirugías
                if (_cirugias.Count > 0)
                {
                    var wsCirugias = workbook.Worksheets.Add("Cirugías por Veterinario");
                    wsCirugias.Cell(1, 1).Value = "Veterinario";
                    wsCirugias.Cell(1, 2).Value = "Especialidad";
                    wsCirugias.Cell(1, 3).Value = "Cantidad Cirugías";
                    wsCirugias.Cell(1, 4).Value = "Porcentaje Total";

                    for (int i = 0; i < _cirugias.Count; i++)
                    {
                        var row = i + 2;
                        wsCirugias.Cell(row, 1).Value = _cirugias[i].NombreVeterinario;
                        wsCirugias.Cell(row, 2).Value = _cirugias[i].Especialidad ?? "";
                        wsCirugias.Cell(row, 3).Value = _cirugias[i].CantidadCirugias;
                        wsCirugias.Cell(row, 4).Value = _cirugias[i].PorcentajeTotal;
                    }
                    wsCirugias.Columns().AdjustToContents();
                }

                // Hoja 2: Productividad
                if (_productividad.Count > 0)
                {
                    var wsProductividad = workbook.Worksheets.Add("Productividad");
                    wsProductividad.Cell(1, 1).Value = "Veterinario";
                    wsProductividad.Cell(1, 2).Value = "Especialidad";
                    wsProductividad.Cell(1, 3).Value = "Total Citas";
                    wsProductividad.Cell(1, 4).Value = "Total Cirugías";
                    wsProductividad.Cell(1, 5).Value = "Total Tratamientos";
                    wsProductividad.Cell(1, 6).Value = "Ingresos Generados";

                    for (int i = 0; i < _productividad.Count; i++)
                    {
                        var row = i + 2;
                        wsProductividad.Cell(row, 1).Value = _productividad[i].NombreVeterinario;
                        wsProductividad.Cell(row, 2).Value = _productividad[i].Especialidad ?? "";
                        wsProductividad.Cell(row, 3).Value = _productividad[i].TotalCitas;
                        wsProductividad.Cell(row, 4).Value = _productividad[i].TotalCirugias;
                        wsProductividad.Cell(row, 5).Value = _productividad[i].TotalTratamientos;
                        wsProductividad.Cell(row, 6).Value = _productividad[i].IngresosGenerados;
                    }
                    wsProductividad.Columns().AdjustToContents();
                }

                workbook.SaveAs(saveDialog.FileName);
                MessageBox.Show($"Dashboard exportado exitosamente a:\n{saveDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

