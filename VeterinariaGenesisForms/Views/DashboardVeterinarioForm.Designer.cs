#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class DashboardVeterinarioForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxFiltros = null!;
    private CheckBox chkFechaInicio = null!;
    private CheckBox chkFechaFin = null!;
    private Label lblFechaInicio = null!;
    private Label lblFechaFin = null!;
    private DateTimePicker dtpFechaInicio = null!;
    private DateTimePicker dtpFechaFin = null!;
    private Button btnGenerar = null!;
    private GroupBox gbxCirugias = null!;
    private DataGridView dgvCirugias = null!;
    private ScottPlot.WinForms.FormsPlot formsPlotCirugias = null!;
    private GroupBox gbxCitas = null!;
    private ScottPlot.WinForms.FormsPlot formsPlotCitas = null!;
    private GroupBox gbxProductividad = null!;
    private DataGridView dgvProductividad = null!;
    private Button btnExportarExcel = null!;
    private Label lblEstado = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        gbxFiltros = new GroupBox();
        btnGenerar = new Button();
        dtpFechaFin = new DateTimePicker();
        dtpFechaInicio = new DateTimePicker();
        lblFechaFin = new Label();
        lblFechaInicio = new Label();
        chkFechaFin = new CheckBox();
        chkFechaInicio = new CheckBox();
        gbxCirugias = new GroupBox();
        formsPlotCirugias = new ScottPlot.WinForms.FormsPlot();
        dgvCirugias = new DataGridView();
        gbxCitas = new GroupBox();
        formsPlotCitas = new ScottPlot.WinForms.FormsPlot();
        gbxProductividad = new GroupBox();
        dgvProductividad = new DataGridView();
        btnExportarExcel = new Button();
        lblEstado = new Label();
        gbxFiltros.SuspendLayout();
        gbxCirugias.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCirugias).BeginInit();
        gbxCitas.SuspendLayout();
        gbxProductividad.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProductividad).BeginInit();
        SuspendLayout();
        // 
        // gbxFiltros
        // 
        gbxFiltros.Controls.Add(btnGenerar);
        gbxFiltros.Controls.Add(dtpFechaFin);
        gbxFiltros.Controls.Add(dtpFechaInicio);
        gbxFiltros.Controls.Add(lblFechaFin);
        gbxFiltros.Controls.Add(lblFechaInicio);
        gbxFiltros.Controls.Add(chkFechaFin);
        gbxFiltros.Controls.Add(chkFechaInicio);
        gbxFiltros.Font = new Font("Segoe UI", 10F);
        gbxFiltros.Location = new Point(12, 12);
        gbxFiltros.Name = "gbxFiltros";
        gbxFiltros.Size = new Size(1643, 80);
        gbxFiltros.TabIndex = 0;
        gbxFiltros.TabStop = false;
        gbxFiltros.Text = "Filtros";
        // 
        // btnGenerar
        // 
        btnGenerar.Location = new Point(832, 32);
        btnGenerar.Name = "btnGenerar";
        btnGenerar.Size = new Size(120, 30);
        btnGenerar.TabIndex = 6;
        btnGenerar.Text = "Generar Dashboard";
        btnGenerar.UseVisualStyleBackColor = true;
        btnGenerar.Click += btnGenerar_Click;
        // 
        // dtpFechaFin
        // 
        dtpFechaFin.Enabled = false;
        dtpFechaFin.Location = new Point(581, 32);
        dtpFechaFin.Name = "dtpFechaFin";
        dtpFechaFin.Size = new Size(200, 30);
        dtpFechaFin.TabIndex = 5;
        // 
        // dtpFechaInicio
        // 
        dtpFechaInicio.Enabled = false;
        dtpFechaInicio.Location = new Point(173, 32);
        dtpFechaInicio.Name = "dtpFechaInicio";
        dtpFechaInicio.Size = new Size(200, 30);
        dtpFechaInicio.TabIndex = 2;
        // 
        // lblFechaFin
        // 
        lblFechaFin.AutoSize = true;
        lblFechaFin.Location = new Point(479, 39);
        lblFechaFin.Name = "lblFechaFin";
        lblFechaFin.Size = new Size(85, 23);
        lblFechaFin.TabIndex = 4;
        lblFechaFin.Text = "Fecha Fin:";
        // 
        // lblFechaInicio
        // 
        lblFechaInicio.AutoSize = true;
        lblFechaInicio.Location = new Point(63, 35);
        lblFechaInicio.Name = "lblFechaInicio";
        lblFechaInicio.Size = new Size(104, 23);
        lblFechaInicio.TabIndex = 1;
        lblFechaInicio.Text = "Fecha Inicio:";
        lblFechaInicio.Click += lblFechaInicio_Click;
        // 
        // chkFechaFin
        // 
        chkFechaFin.AutoSize = true;
        chkFechaFin.Location = new Point(455, 42);
        chkFechaFin.Name = "chkFechaFin";
        chkFechaFin.Size = new Size(18, 17);
        chkFechaFin.TabIndex = 3;
        chkFechaFin.CheckedChanged += chkFechaFin_CheckedChanged;
        // 
        // chkFechaInicio
        // 
        chkFechaInicio.AutoSize = true;
        chkFechaInicio.Location = new Point(39, 39);
        chkFechaInicio.Name = "chkFechaInicio";
        chkFechaInicio.Size = new Size(18, 17);
        chkFechaInicio.TabIndex = 0;
        chkFechaInicio.CheckedChanged += chkFechaInicio_CheckedChanged;
        // 
        // gbxCirugias
        // 
        gbxCirugias.Controls.Add(formsPlotCirugias);
        gbxCirugias.Controls.Add(dgvCirugias);
        gbxCirugias.Font = new Font("Segoe UI", 10F);
        gbxCirugias.Location = new Point(12, 100);
        gbxCirugias.Name = "gbxCirugias";
        gbxCirugias.Size = new Size(826, 300);
        gbxCirugias.TabIndex = 1;
        gbxCirugias.TabStop = false;
        gbxCirugias.Text = "Cirugías por Veterinario";
        // 
        // formsPlotCirugias
        // 
        formsPlotCirugias.DisplayScale = 1.25F;
        formsPlotCirugias.Location = new Point(366, 29);
        formsPlotCirugias.Name = "formsPlotCirugias";
        formsPlotCirugias.Size = new Size(460, 260);
        formsPlotCirugias.TabIndex = 1;
        // 
        // dgvCirugias
        // 
        dgvCirugias.ColumnHeadersHeight = 29;
        dgvCirugias.Location = new Point(15, 30);
        dgvCirugias.Name = "dgvCirugias";
        dgvCirugias.RowHeadersWidth = 51;
        dgvCirugias.Size = new Size(358, 260);
        dgvCirugias.TabIndex = 0;
        // 
        // gbxCitas
        // 
        gbxCitas.Controls.Add(formsPlotCitas);
        gbxCitas.Font = new Font("Segoe UI", 10F);
        gbxCitas.Location = new Point(844, 100);
        gbxCitas.Name = "gbxCitas";
        gbxCitas.Size = new Size(811, 300);
        gbxCitas.TabIndex = 2;
        gbxCitas.TabStop = false;
        gbxCitas.Text = "Citas por Día de la Semana";
        // 
        // formsPlotCitas
        // 
        formsPlotCitas.DisplayScale = 1.25F;
        formsPlotCitas.Location = new Point(43, 30);
        formsPlotCitas.Name = "formsPlotCitas";
        formsPlotCitas.Size = new Size(774, 260);
        formsPlotCitas.TabIndex = 0;
        // 
        // gbxProductividad
        // 
        gbxProductividad.Controls.Add(dgvProductividad);
        gbxProductividad.Font = new Font("Segoe UI", 10F);
        gbxProductividad.Location = new Point(12, 410);
        gbxProductividad.Name = "gbxProductividad";
        gbxProductividad.Size = new Size(1543, 280);
        gbxProductividad.TabIndex = 3;
        gbxProductividad.TabStop = false;
        gbxProductividad.Text = "Productividad por Veterinario";
        // 
        // dgvProductividad
        // 
        dgvProductividad.ColumnHeadersHeight = 29;
        dgvProductividad.Location = new Point(30, 29);
        dgvProductividad.Name = "dgvProductividad";
        dgvProductividad.RowHeadersWidth = 51;
        dgvProductividad.Size = new Size(1507, 240);
        dgvProductividad.TabIndex = 0;
        // 
        // btnExportarExcel
        // 
        btnExportarExcel.Location = new Point(1077, 700);
        btnExportarExcel.Name = "btnExportarExcel";
        btnExportarExcel.Size = new Size(135, 30);
        btnExportarExcel.TabIndex = 4;
        btnExportarExcel.Text = "Exportar Excel";
        btnExportarExcel.UseVisualStyleBackColor = true;
        btnExportarExcel.Click += btnExportarExcel_Click;
        // 
        // lblEstado
        // 
        lblEstado.AutoSize = true;
        lblEstado.Font = new Font("Segoe UI", 10F);
        lblEstado.Location = new Point(12, 710);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(45, 23);
        lblEstado.TabIndex = 5;
        lblEstado.Text = "Listo";
        // 
        // DashboardVeterinarioForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1667, 750);
        Controls.Add(lblEstado);
        Controls.Add(btnExportarExcel);
        Controls.Add(gbxProductividad);
        Controls.Add(gbxCitas);
        Controls.Add(gbxCirugias);
        Controls.Add(gbxFiltros);
        FormBorderStyle = FormBorderStyle.None;
        Name = "DashboardVeterinarioForm";
        Text = "Dashboard de Rendimiento Veterinario";
        Load += DashboardVeterinarioForm_Load;
        gbxFiltros.ResumeLayout(false);
        gbxFiltros.PerformLayout();
        gbxCirugias.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCirugias).EndInit();
        gbxCitas.ResumeLayout(false);
        gbxProductividad.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvProductividad).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

