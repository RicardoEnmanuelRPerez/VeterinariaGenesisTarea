#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class RecordatoriosVacunacionForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxFiltros = null!;
    private Label lblDiasAnticipacion = null!;
    private NumericUpDown numDiasAnticipacion = null!;
    private Button btnGenerar = null!;
    private GroupBox gbxResultados = null!;
    private DataGridView dgvRecordatorios = null!;
    private Button btnExportarExcel = null!;
    private Label lblEstado = null!;
    private Label lblMensajeSinResultados = null!;

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
        lblDiasAnticipacion = new Label();
        numDiasAnticipacion = new NumericUpDown();
        btnGenerar = new Button();
        gbxResultados = new GroupBox();
        dgvRecordatorios = new DataGridView();
        btnExportarExcel = new Button();
        lblEstado = new Label();
        lblMensajeSinResultados = new Label();
        gbxFiltros.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(numDiasAnticipacion)).BeginInit();
        gbxResultados.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(dgvRecordatorios)).BeginInit();
        SuspendLayout();
        
        // gbxFiltros
        gbxFiltros.Controls.Add(btnGenerar);
        gbxFiltros.Controls.Add(numDiasAnticipacion);
        gbxFiltros.Controls.Add(lblDiasAnticipacion);
        gbxFiltros.Font = new Font("Segoe UI", 10F);
        gbxFiltros.Location = new Point(12, 12);
        gbxFiltros.Name = "gbxFiltros";
        gbxFiltros.Size = new Size(1200, 80);
        gbxFiltros.TabIndex = 0;
        gbxFiltros.TabStop = false;
        gbxFiltros.Text = "Filtros";
        
        // lblDiasAnticipacion
        lblDiasAnticipacion.AutoSize = true;
        lblDiasAnticipacion.Location = new Point(15, 35);
        lblDiasAnticipacion.Name = "lblDiasAnticipacion";
        lblDiasAnticipacion.Size = new Size(200, 19);
        lblDiasAnticipacion.TabIndex = 0;
        lblDiasAnticipacion.Text = "Días de Anticipación:";
        
        // numDiasAnticipacion
        numDiasAnticipacion.Location = new Point(220, 32);
        numDiasAnticipacion.Minimum = 1;
        numDiasAnticipacion.Maximum = 365;
        numDiasAnticipacion.Name = "numDiasAnticipacion";
        numDiasAnticipacion.Size = new Size(100, 25);
        numDiasAnticipacion.TabIndex = 1;
        
        // btnGenerar
        btnGenerar.Location = new Point(340, 30);
        btnGenerar.Name = "btnGenerar";
        btnGenerar.Size = new Size(120, 30);
        btnGenerar.TabIndex = 2;
        btnGenerar.Text = "Generar Reporte";
        btnGenerar.UseVisualStyleBackColor = true;
        btnGenerar.Click += btnGenerar_Click;
        
        // gbxResultados
        gbxResultados.Controls.Add(lblMensajeSinResultados);
        gbxResultados.Controls.Add(btnExportarExcel);
        gbxResultados.Controls.Add(dgvRecordatorios);
        gbxResultados.Font = new Font("Segoe UI", 10F);
        gbxResultados.Location = new Point(12, 100);
        gbxResultados.Name = "gbxResultados";
        gbxResultados.Size = new Size(1200, 600);
        gbxResultados.TabIndex = 1;
        gbxResultados.TabStop = false;
        gbxResultados.Text = "Recordatorios de Vacunación";
        
        // dgvRecordatorios
        dgvRecordatorios.Location = new Point(15, 30);
        dgvRecordatorios.Name = "dgvRecordatorios";
        dgvRecordatorios.Size = new Size(1170, 520);
        dgvRecordatorios.TabIndex = 0;
        
        // btnExportarExcel
        btnExportarExcel.Location = new Point(1050, 560);
        btnExportarExcel.Name = "btnExportarExcel";
        btnExportarExcel.Size = new Size(135, 30);
        btnExportarExcel.TabIndex = 1;
        btnExportarExcel.Text = "Exportar Excel";
        btnExportarExcel.UseVisualStyleBackColor = true;
        btnExportarExcel.Click += btnExportarExcel_Click;
        
        // lblMensajeSinResultados
        lblMensajeSinResultados.AutoSize = true;
        lblMensajeSinResultados.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblMensajeSinResultados.Location = new Point(15, 565);
        lblMensajeSinResultados.Name = "lblMensajeSinResultados";
        lblMensajeSinResultados.Size = new Size(0, 21);
        lblMensajeSinResultados.TabIndex = 2;
        
        // lblEstado
        lblEstado.AutoSize = true;
        lblEstado.Font = new Font("Segoe UI", 10F);
        lblEstado.Location = new Point(12, 710);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(40, 19);
        lblEstado.TabIndex = 2;
        lblEstado.Text = "Listo";
        
        // RecordatoriosVacunacionForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1224, 750);
        Controls.Add(lblEstado);
        Controls.Add(gbxResultados);
        Controls.Add(gbxFiltros);
        FormBorderStyle = FormBorderStyle.None;
        Name = "RecordatoriosVacunacionForm";
        Text = "Recordatorios de Vacunación";
        Load += RecordatoriosVacunacionForm_Load;
        gbxFiltros.ResumeLayout(false);
        gbxFiltros.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(numDiasAnticipacion)).EndInit();
        gbxResultados.ResumeLayout(false);
        gbxResultados.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(dgvRecordatorios)).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

