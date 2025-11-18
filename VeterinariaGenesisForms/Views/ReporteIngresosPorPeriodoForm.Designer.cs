#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class ReporteIngresosPorPeriodoForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxFiltros = null!;
    private Label lblFechaInicio = null!;
    private Label lblFechaFin = null!;
    private DateTimePicker dtpFechaInicio = null!;
    private DateTimePicker dtpFechaFin = null!;
    private CheckBox chkFechaInicio = null!;
    private CheckBox chkFechaFin = null!;
    private Button btnGenerar = null!;
    private DataGridView dgvDatos = null!;
    private Button btnExportarExcel = null!;
    private Label lblEstado = null!;
    private ScottPlot.WinForms.FormsPlot formsPlot1 = null!;
    private Panel pnlGrafica = null!;

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
        this.gbxFiltros = new GroupBox();
        this.chkFechaFin = new CheckBox();
        this.chkFechaInicio = new CheckBox();
        this.lblFechaFin = new Label();
        this.lblFechaInicio = new Label();
        this.dtpFechaFin = new DateTimePicker();
        this.dtpFechaInicio = new DateTimePicker();
        this.btnGenerar = new Button();
        this.dgvDatos = new DataGridView();
        this.btnExportarExcel = new Button();
        this.lblEstado = new Label();
        this.pnlGrafica = new Panel();
        this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
        this.gbxFiltros.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
        this.pnlGrafica.SuspendLayout();
        this.SuspendLayout();

        this.gbxFiltros.Controls.Add(this.chkFechaFin);
        this.gbxFiltros.Controls.Add(this.chkFechaInicio);
        this.gbxFiltros.Controls.Add(this.lblFechaFin);
        this.gbxFiltros.Controls.Add(this.lblFechaInicio);
        this.gbxFiltros.Controls.Add(this.dtpFechaFin);
        this.gbxFiltros.Controls.Add(this.dtpFechaInicio);
        this.gbxFiltros.Controls.Add(this.btnGenerar);
        this.gbxFiltros.Font = new Font("Segoe UI", 10F);
        this.gbxFiltros.Location = new Point(12, 12);
        this.gbxFiltros.Name = "gbxFiltros";
        this.gbxFiltros.Size = new Size(1200, 80);
        this.gbxFiltros.TabIndex = 0;
        this.gbxFiltros.TabStop = false;
        this.gbxFiltros.Text = "Filtros";

        this.chkFechaInicio.AutoSize = true;
        this.chkFechaInicio.Location = new Point(15, 25);
        this.chkFechaInicio.Name = "chkFechaInicio";
        this.chkFechaInicio.Size = new Size(15, 14);
        this.chkFechaInicio.TabIndex = 0;
        this.chkFechaInicio.CheckedChanged += new EventHandler(this.chkFechaInicio_CheckedChanged);

        this.lblFechaInicio.AutoSize = true;
        this.lblFechaInicio.Location = new Point(35, 25);
        this.lblFechaInicio.Name = "lblFechaInicio";
        this.lblFechaInicio.Size = new Size(85, 19);
        this.lblFechaInicio.TabIndex = 1;
        this.lblFechaInicio.Text = "Fecha Inicio:";

        this.dtpFechaInicio.Enabled = false;
        this.dtpFechaInicio.Format = DateTimePickerFormat.Short;
        this.dtpFechaInicio.Location = new Point(125, 22);
        this.dtpFechaInicio.Name = "dtpFechaInicio";
        this.dtpFechaInicio.Size = new Size(150, 25);
        this.dtpFechaInicio.TabIndex = 2;

        this.chkFechaFin.AutoSize = true;
        this.chkFechaFin.Location = new Point(300, 25);
        this.chkFechaFin.Name = "chkFechaFin";
        this.chkFechaFin.Size = new Size(15, 14);
        this.chkFechaFin.TabIndex = 3;
        this.chkFechaFin.CheckedChanged += new EventHandler(this.chkFechaFin_CheckedChanged);

        this.lblFechaFin.AutoSize = true;
        this.lblFechaFin.Location = new Point(320, 25);
        this.lblFechaFin.Name = "lblFechaFin";
        this.lblFechaFin.Size = new Size(70, 19);
        this.lblFechaFin.TabIndex = 4;
        this.lblFechaFin.Text = "Fecha Fin:";

        this.dtpFechaFin.Enabled = false;
        this.dtpFechaFin.Format = DateTimePickerFormat.Short;
        this.dtpFechaFin.Location = new Point(395, 22);
        this.dtpFechaFin.Name = "dtpFechaFin";
        this.dtpFechaFin.Size = new Size(150, 25);
        this.dtpFechaFin.TabIndex = 5;

        this.btnGenerar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnGenerar.Location = new Point(570, 20);
        this.btnGenerar.Name = "btnGenerar";
        this.btnGenerar.Size = new Size(150, 35);
        this.btnGenerar.TabIndex = 6;
        this.btnGenerar.Text = "&Generar Reporte";
        this.btnGenerar.UseVisualStyleBackColor = true;
        this.btnGenerar.Click += new EventHandler(this.btnGenerar_Click);

        this.dgvDatos.AllowUserToAddRows = false;
        this.dgvDatos.AllowUserToDeleteRows = false;
        this.dgvDatos.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvDatos.Location = new Point(12, 110);
        this.dgvDatos.Name = "dgvDatos";
        this.dgvDatos.ReadOnly = true;
        this.dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvDatos.Size = new Size(800, 400);
        this.dgvDatos.TabIndex = 1;

        this.btnExportarExcel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        this.btnExportarExcel.Font = new Font("Segoe UI", 10F);
        this.btnExportarExcel.Location = new Point(1050, 480);
        this.btnExportarExcel.Name = "btnExportarExcel";
        this.btnExportarExcel.Size = new Size(162, 35);
        this.btnExportarExcel.TabIndex = 2;
        this.btnExportarExcel.Text = "&Exportar a Excel";
        this.btnExportarExcel.UseVisualStyleBackColor = true;
        this.btnExportarExcel.Click += new EventHandler(this.btnExportarExcel_Click);

        this.lblEstado.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.lblEstado.AutoSize = true;
        this.lblEstado.Font = new Font("Segoe UI", 9F);
        this.lblEstado.Location = new Point(12, 520);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(0, 15);
        this.lblEstado.TabIndex = 3;

        this.pnlGrafica.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right)));
        this.pnlGrafica.Controls.Add(this.formsPlot1);
        this.pnlGrafica.Location = new Point(820, 110);
        this.pnlGrafica.Name = "pnlGrafica";
        this.pnlGrafica.Size = new Size(392, 400);
        this.pnlGrafica.TabIndex = 4;

        this.formsPlot1.Dock = DockStyle.Fill;
        this.formsPlot1.Location = new Point(0, 0);
        this.formsPlot1.Name = "formsPlot1";
        this.formsPlot1.Size = new Size(392, 400);
        this.formsPlot1.TabIndex = 0;

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1224, 545);
        this.Controls.Add(this.pnlGrafica);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.btnExportarExcel);
        this.Controls.Add(this.dgvDatos);
        this.Controls.Add(this.gbxFiltros);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(1240, 584);
        this.Name = "ReporteIngresosPorPeriodoForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Reporte de Ingresos por Período - Veterinaria Genesis";
        this.gbxFiltros.ResumeLayout(false);
        this.gbxFiltros.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
        this.pnlGrafica.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

