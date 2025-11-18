#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class CitasForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxBuscar = null!;
    private Label lblFechaBuscar = null!;
    private DateTimePicker dtpFechaBuscar = null!;
    private Button btnBuscarPorFecha = null!;
    private GroupBox gbxAgendar = null!;
    private Label lblPropietario = null!;
    private Label lblMascota = null!;
    private Label lblFechaAgendar = null!;
    private Label lblHoraAgendar = null!;
    private Label lblIDVeterinario = null!;
    private Label lblIDServicio = null!;
    private ComboBox cmbPropietario = null!;
    private ComboBox cmbMascota = null!;
    private DateTimePicker dtpFechaAgendar = null!;
    private DateTimePicker dtpHoraAgendar = null!;
    private TextBox txtIDVeterinario = null!;
    private TextBox txtIDServicio = null!;
    private Button btnAgendar = null!;
    private DataGridView dgvCitas = null!;
    private Button btnCancelar = null!;
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
        this.gbxBuscar = new GroupBox();
        this.lblFechaBuscar = new Label();
        this.dtpFechaBuscar = new DateTimePicker();
        this.btnBuscarPorFecha = new Button();
        this.gbxAgendar = new GroupBox();
        this.lblPropietario = new Label();
        this.lblMascota = new Label();
        this.lblFechaAgendar = new Label();
        this.lblHoraAgendar = new Label();
        this.lblIDVeterinario = new Label();
        this.lblIDServicio = new Label();
        this.cmbPropietario = new ComboBox();
        this.cmbMascota = new ComboBox();
        this.dtpFechaAgendar = new DateTimePicker();
        this.dtpHoraAgendar = new DateTimePicker();
        this.txtIDVeterinario = new TextBox();
        this.txtIDServicio = new TextBox();
        this.btnAgendar = new Button();
        this.dgvCitas = new DataGridView();
        this.btnCancelar = new Button();
        this.btnExportarExcel = new Button();
        this.lblEstado = new Label();
        this.gbxBuscar.SuspendLayout();
        this.gbxAgendar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
        this.SuspendLayout();

        // gbxBuscar
        this.gbxBuscar.Controls.Add(this.lblFechaBuscar);
        this.gbxBuscar.Controls.Add(this.dtpFechaBuscar);
        this.gbxBuscar.Controls.Add(this.btnBuscarPorFecha);
        this.gbxBuscar.Font = new Font("Segoe UI", 10F);
        this.gbxBuscar.Location = new Point(12, 12);
        this.gbxBuscar.Name = "gbxBuscar";
        this.gbxBuscar.Size = new Size(600, 70);
        this.gbxBuscar.TabIndex = 0;
        this.gbxBuscar.TabStop = false;
        this.gbxBuscar.Text = "Buscar Citas";

        this.lblFechaBuscar.AutoSize = true;
        this.lblFechaBuscar.Location = new Point(15, 30);
        this.lblFechaBuscar.Name = "lblFechaBuscar";
        this.lblFechaBuscar.Size = new Size(48, 19);
        this.lblFechaBuscar.TabIndex = 0;
        this.lblFechaBuscar.Text = "Fecha:";

        this.dtpFechaBuscar.Format = DateTimePickerFormat.Short;
        this.dtpFechaBuscar.Location = new Point(70, 27);
        this.dtpFechaBuscar.Name = "dtpFechaBuscar";
        this.dtpFechaBuscar.Size = new Size(150, 25);
        this.dtpFechaBuscar.TabIndex = 1;

        this.btnBuscarPorFecha.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnBuscarPorFecha.Location = new Point(240, 25);
        this.btnBuscarPorFecha.Name = "btnBuscarPorFecha";
        this.btnBuscarPorFecha.Size = new Size(150, 30);
        this.btnBuscarPorFecha.TabIndex = 2;
        this.btnBuscarPorFecha.Text = "&Buscar";
        this.btnBuscarPorFecha.UseVisualStyleBackColor = true;
        this.btnBuscarPorFecha.Click += new EventHandler(this.btnBuscarPorFecha_Click);

        // gbxAgendar
        this.gbxAgendar.Controls.Add(this.btnAgendar);
        this.gbxAgendar.Controls.Add(this.txtIDServicio);
        this.gbxAgendar.Controls.Add(this.txtIDVeterinario);
        this.gbxAgendar.Controls.Add(this.dtpHoraAgendar);
        this.gbxAgendar.Controls.Add(this.dtpFechaAgendar);
        this.gbxAgendar.Controls.Add(this.cmbMascota);
        this.gbxAgendar.Controls.Add(this.cmbPropietario);
        this.gbxAgendar.Controls.Add(this.lblIDServicio);
        this.gbxAgendar.Controls.Add(this.lblIDVeterinario);
        this.gbxAgendar.Controls.Add(this.lblHoraAgendar);
        this.gbxAgendar.Controls.Add(this.lblFechaAgendar);
        this.gbxAgendar.Controls.Add(this.lblMascota);
        this.gbxAgendar.Controls.Add(this.lblPropietario);
        this.gbxAgendar.Font = new Font("Segoe UI", 10F);
        this.gbxAgendar.Location = new Point(630, 12);
        this.gbxAgendar.Name = "gbxAgendar";
        this.gbxAgendar.Size = new Size(582, 200);
        this.gbxAgendar.TabIndex = 1;
        this.gbxAgendar.TabStop = false;
        this.gbxAgendar.Text = "Agendar Nueva Cita";

        this.lblPropietario.AutoSize = true;
        this.lblPropietario.Location = new Point(15, 30);
        this.lblPropietario.Name = "lblPropietario";
        this.lblPropietario.Size = new Size(80, 19);
        this.lblPropietario.TabIndex = 0;
        this.lblPropietario.Text = "Propietario:";

        this.cmbPropietario.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbPropietario.FormattingEnabled = true;
        this.cmbPropietario.Location = new Point(100, 27);
        this.cmbPropietario.Name = "cmbPropietario";
        this.cmbPropietario.Size = new Size(200, 25);
        this.cmbPropietario.TabIndex = 1;

        this.lblMascota.AutoSize = true;
        this.lblMascota.Location = new Point(320, 30);
        this.lblMascota.Name = "lblMascota";
        this.lblMascota.Size = new Size(65, 19);
        this.lblMascota.TabIndex = 2;
        this.lblMascota.Text = "Mascota:";

        this.cmbMascota.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbMascota.FormattingEnabled = true;
        this.cmbMascota.Location = new Point(390, 27);
        this.cmbMascota.Name = "cmbMascota";
        this.cmbMascota.Size = new Size(180, 25);
        this.cmbMascota.TabIndex = 3;

        this.lblFechaAgendar.AutoSize = true;
        this.lblFechaAgendar.Location = new Point(15, 70);
        this.lblFechaAgendar.Name = "lblFechaAgendar";
        this.lblFechaAgendar.Size = new Size(48, 19);
        this.lblFechaAgendar.TabIndex = 4;
        this.lblFechaAgendar.Text = "Fecha:";

        this.dtpFechaAgendar.Format = DateTimePickerFormat.Short;
        this.dtpFechaAgendar.Location = new Point(70, 67);
        this.dtpFechaAgendar.Name = "dtpFechaAgendar";
        this.dtpFechaAgendar.Size = new Size(150, 25);
        this.dtpFechaAgendar.TabIndex = 5;

        this.lblHoraAgendar.AutoSize = true;
        this.lblHoraAgendar.Location = new Point(240, 70);
        this.lblHoraAgendar.Name = "lblHoraAgendar";
        this.lblHoraAgendar.Size = new Size(42, 19);
        this.lblHoraAgendar.TabIndex = 6;
        this.lblHoraAgendar.Text = "Hora:";

        this.dtpHoraAgendar.Format = DateTimePickerFormat.Time;
        this.dtpHoraAgendar.Location = new Point(290, 67);
        this.dtpHoraAgendar.Name = "dtpHoraAgendar";
        this.dtpHoraAgendar.ShowUpDown = true;
        this.dtpHoraAgendar.Size = new Size(120, 25);
        this.dtpHoraAgendar.TabIndex = 7;

        this.lblIDVeterinario.AutoSize = true;
        this.lblIDVeterinario.Location = new Point(15, 110);
        this.lblIDVeterinario.Name = "lblIDVeterinario";
        this.lblIDVeterinario.Size = new Size(100, 19);
        this.lblIDVeterinario.TabIndex = 8;
        this.lblIDVeterinario.Text = "ID Veterinario:";

        this.txtIDVeterinario.Location = new Point(120, 107);
        this.txtIDVeterinario.Name = "txtIDVeterinario";
        this.txtIDVeterinario.Size = new Size(100, 25);
        this.txtIDVeterinario.TabIndex = 9;

        this.lblIDServicio.AutoSize = true;
        this.lblIDServicio.Location = new Point(240, 110);
        this.lblIDServicio.Name = "lblIDServicio";
        this.lblIDServicio.Size = new Size(85, 19);
        this.lblIDServicio.TabIndex = 10;
        this.lblIDServicio.Text = "ID Servicio:";

        this.txtIDServicio.Location = new Point(330, 107);
        this.txtIDServicio.Name = "txtIDServicio";
        this.txtIDServicio.Size = new Size(100, 25);
        this.txtIDServicio.TabIndex = 11;

        this.btnAgendar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnAgendar.Location = new Point(15, 150);
        this.btnAgendar.Name = "btnAgendar";
        this.btnAgendar.Size = new Size(200, 35);
        this.btnAgendar.TabIndex = 12;
        this.btnAgendar.Text = "&Agendar Cita";
        this.btnAgendar.UseVisualStyleBackColor = true;
        this.btnAgendar.Click += new EventHandler(this.btnAgendar_Click);

        // dgvCitas
        this.dgvCitas.AllowUserToAddRows = false;
        this.dgvCitas.AllowUserToDeleteRows = false;
        this.dgvCitas.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvCitas.Location = new Point(12, 230);
        this.dgvCitas.Name = "dgvCitas";
        this.dgvCitas.ReadOnly = true;
        this.dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvCitas.Size = new Size(1200, 350);
        this.dgvCitas.TabIndex = 2;

        // btnCancelar
        this.btnCancelar.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.btnCancelar.Font = new Font("Segoe UI", 10F);
        this.btnCancelar.Location = new Point(12, 590);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new Size(150, 35);
        this.btnCancelar.TabIndex = 3;
        this.btnCancelar.Text = "&Cancelar Cita";
        this.btnCancelar.UseVisualStyleBackColor = true;
        this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

        // btnExportarExcel
        this.btnExportarExcel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        this.btnExportarExcel.Font = new Font("Segoe UI", 10F);
        this.btnExportarExcel.Location = new Point(1050, 590);
        this.btnExportarExcel.Name = "btnExportarExcel";
        this.btnExportarExcel.Size = new Size(162, 35);
        this.btnExportarExcel.TabIndex = 4;
        this.btnExportarExcel.Text = "&Exportar a Excel";
        this.btnExportarExcel.UseVisualStyleBackColor = true;
        this.btnExportarExcel.Click += new EventHandler(this.btnExportarExcel_Click);

        // lblEstado
        this.lblEstado.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.lblEstado.AutoSize = true;
        this.lblEstado.Font = new Font("Segoe UI", 9F);
        this.lblEstado.Location = new Point(180, 600);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(0, 15);
        this.lblEstado.TabIndex = 5;

        // CitasForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1224, 637);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.btnExportarExcel);
        this.Controls.Add(this.btnCancelar);
        this.Controls.Add(this.dgvCitas);
        this.Controls.Add(this.gbxAgendar);
        this.Controls.Add(this.gbxBuscar);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(1240, 676);
        this.Name = "CitasForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Gestión de Citas - Veterinaria Genesis";
        this.Load += new EventHandler(this.CitasForm_Load);
        this.gbxBuscar.ResumeLayout(false);
        this.gbxBuscar.PerformLayout();
        this.gbxAgendar.ResumeLayout(false);
        this.gbxAgendar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

