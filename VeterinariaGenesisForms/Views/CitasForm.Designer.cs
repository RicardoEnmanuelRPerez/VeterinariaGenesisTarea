#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class CitasForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxBuscar = null!;
    private Label lblFechaBuscar = null!;
    private DateTimePicker dtpFechaBuscar = null!;
    private Button btnBuscarPorFecha = null!;
    private GroupBox gbxEditar = null!;
    private Label lblPropietario = null!;
    private Label lblMascota = null!;
    private Label lblFechaEditar = null!;
    private Label lblHoraEditar = null!;
    private Label lblVeterinario = null!;
    private Label lblServicios = null!;
    private Label lblEstado = null!;
    private ComboBox cmbPropietario = null!;
    private ComboBox cmbMascota = null!;
    private ComboBox cmbVeterinario = null!;
    private CheckedListBox clbServicios = null!;
    private DateTimePicker dtpFechaEditar = null!;
    private DateTimePicker dtpHoraEditar = null!;
    private ComboBox cmbEstado = null!;
    private Button btnEditar = null!;
    private Button btnActualizar = null!;
    private Button btnLimpiar = null!;
    private DataGridView dgvCitas = null!;
    private Button btnCancelar = null!;
    private Button btnExportarExcel = null!;
    private Label lblEstadoMensaje = null!;

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
        this.gbxEditar = new GroupBox();
        this.lblPropietario = new Label();
        this.lblMascota = new Label();
        this.lblFechaEditar = new Label();
        this.lblHoraEditar = new Label();
        this.lblVeterinario = new Label();
        this.lblServicios = new Label();
        this.lblEstado = new Label();
        this.cmbPropietario = new ComboBox();
        this.cmbMascota = new ComboBox();
        this.cmbVeterinario = new ComboBox();
        this.clbServicios = new CheckedListBox();
        this.dtpFechaEditar = new DateTimePicker();
        this.dtpHoraEditar = new DateTimePicker();
        this.cmbEstado = new ComboBox();
        this.btnEditar = new Button();
        this.btnActualizar = new Button();
        this.btnLimpiar = new Button();
        this.dgvCitas = new DataGridView();
        this.btnCancelar = new Button();
        this.btnExportarExcel = new Button();
        this.lblEstadoMensaje = new Label();
        this.gbxBuscar.SuspendLayout();
        this.gbxEditar.SuspendLayout();
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

        // gbxEditar
        this.gbxEditar.Controls.Add(this.btnLimpiar);
        this.gbxEditar.Controls.Add(this.btnActualizar);
        this.gbxEditar.Controls.Add(this.btnEditar);
        this.gbxEditar.Controls.Add(this.cmbEstado);
        this.gbxEditar.Controls.Add(this.clbServicios);
        this.gbxEditar.Controls.Add(this.cmbVeterinario);
        this.gbxEditar.Controls.Add(this.dtpHoraEditar);
        this.gbxEditar.Controls.Add(this.dtpFechaEditar);
        this.gbxEditar.Controls.Add(this.cmbMascota);
        this.gbxEditar.Controls.Add(this.cmbPropietario);
        this.gbxEditar.Controls.Add(this.lblEstado);
        this.gbxEditar.Controls.Add(this.lblServicios);
        this.gbxEditar.Controls.Add(this.lblVeterinario);
        this.gbxEditar.Controls.Add(this.lblHoraEditar);
        this.gbxEditar.Controls.Add(this.lblFechaEditar);
        this.gbxEditar.Controls.Add(this.lblMascota);
        this.gbxEditar.Controls.Add(this.lblPropietario);
        this.gbxEditar.Font = new Font("Segoe UI", 10F);
        this.gbxEditar.Location = new Point(630, 12);
        this.gbxEditar.Name = "gbxEditar";
        this.gbxEditar.Size = new Size(582, 350);
        this.gbxEditar.TabIndex = 1;
        this.gbxEditar.TabStop = false;
        this.gbxEditar.Text = "Editar Cita";

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
        this.cmbPropietario.Enabled = false;
        this.cmbPropietario.SelectedIndexChanged += new EventHandler(this.CmbPropietario_SelectedIndexChanged);

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
        this.cmbMascota.Enabled = false;

        this.lblFechaEditar.AutoSize = true;
        this.lblFechaEditar.Location = new Point(15, 70);
        this.lblFechaEditar.Name = "lblFechaEditar";
        this.lblFechaEditar.Size = new Size(48, 19);
        this.lblFechaEditar.TabIndex = 4;
        this.lblFechaEditar.Text = "Fecha:";

        this.dtpFechaEditar.Format = DateTimePickerFormat.Short;
        this.dtpFechaEditar.Location = new Point(70, 67);
        this.dtpFechaEditar.Name = "dtpFechaEditar";
        this.dtpFechaEditar.Size = new Size(150, 25);
        this.dtpFechaEditar.TabIndex = 5;
        this.dtpFechaEditar.Enabled = false;

        this.lblHoraEditar.AutoSize = true;
        this.lblHoraEditar.Location = new Point(240, 70);
        this.lblHoraEditar.Name = "lblHoraEditar";
        this.lblHoraEditar.Size = new Size(42, 19);
        this.lblHoraEditar.TabIndex = 6;
        this.lblHoraEditar.Text = "Hora:";

        this.dtpHoraEditar.Format = DateTimePickerFormat.Time;
        this.dtpHoraEditar.Location = new Point(290, 67);
        this.dtpHoraEditar.Name = "dtpHoraEditar";
        this.dtpHoraEditar.ShowUpDown = true;
        this.dtpHoraEditar.Size = new Size(120, 25);
        this.dtpHoraEditar.TabIndex = 7;
        this.dtpHoraEditar.Enabled = false;

        this.lblVeterinario.AutoSize = true;
        this.lblVeterinario.Location = new Point(15, 110);
        this.lblVeterinario.Name = "lblVeterinario";
        this.lblVeterinario.Size = new Size(78, 19);
        this.lblVeterinario.TabIndex = 8;
        this.lblVeterinario.Text = "Veterinario:";

        this.cmbVeterinario.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbVeterinario.FormattingEnabled = true;
        this.cmbVeterinario.Location = new Point(100, 107);
        this.cmbVeterinario.Name = "cmbVeterinario";
        this.cmbVeterinario.Size = new Size(470, 25);
        this.cmbVeterinario.TabIndex = 9;
        this.cmbVeterinario.Enabled = false;

        this.lblServicios.AutoSize = true;
        this.lblServicios.Location = new Point(15, 150);
        this.lblServicios.Name = "lblServicios";
        this.lblServicios.Size = new Size(68, 19);
        this.lblServicios.TabIndex = 10;
        this.lblServicios.Text = "Servicios:";

        this.clbServicios.CheckOnClick = true;
        this.clbServicios.FormattingEnabled = true;
        this.clbServicios.Location = new Point(100, 147);
        this.clbServicios.Name = "clbServicios";
        this.clbServicios.Size = new Size(470, 100);
        this.clbServicios.TabIndex = 11;
        this.clbServicios.Enabled = false;

        this.lblEstado.AutoSize = true;
        this.lblEstado.Location = new Point(15, 260);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(50, 19);
        this.lblEstado.TabIndex = 12;
        this.lblEstado.Text = "Estado:";

        this.cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbEstado.FormattingEnabled = true;
        this.cmbEstado.Items.AddRange(new object[] { "Programada", "Completada", "Cancelada" });
        this.cmbEstado.Location = new Point(100, 257);
        this.cmbEstado.Name = "cmbEstado";
        this.cmbEstado.Size = new Size(200, 25);
        this.cmbEstado.TabIndex = 13;
        this.cmbEstado.Enabled = false;

        this.btnEditar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnEditar.Location = new Point(15, 295);
        this.btnEditar.Name = "btnEditar";
        this.btnEditar.Size = new Size(150, 35);
        this.btnEditar.TabIndex = 14;
        this.btnEditar.Text = "&Editar";
        this.btnEditar.UseVisualStyleBackColor = true;
        this.btnEditar.Click += new EventHandler(this.btnEditar_Click);

        this.btnActualizar.Font = new Font("Segoe UI", 10F);
        this.btnActualizar.Location = new Point(180, 295);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new Size(150, 35);
        this.btnActualizar.TabIndex = 15;
        this.btnActualizar.Text = "&Actualizar";
        this.btnActualizar.UseVisualStyleBackColor = true;
        this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);
        this.btnActualizar.Enabled = false;

        this.btnLimpiar.Font = new Font("Segoe UI", 10F);
        this.btnLimpiar.Location = new Point(345, 295);
        this.btnLimpiar.Name = "btnLimpiar";
        this.btnLimpiar.Size = new Size(150, 35);
        this.btnLimpiar.TabIndex = 16;
        this.btnLimpiar.Text = "&Limpiar";
        this.btnLimpiar.UseVisualStyleBackColor = true;
        this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);
        this.btnLimpiar.Enabled = false;

        // dgvCitas
        this.dgvCitas.AllowUserToAddRows = false;
        this.dgvCitas.AllowUserToDeleteRows = false;
        this.dgvCitas.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvCitas.Location = new Point(12, 380);
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

        // lblEstadoMensaje
        this.lblEstadoMensaje.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.lblEstadoMensaje.AutoSize = true;
        this.lblEstadoMensaje.Font = new Font("Segoe UI", 9F);
        this.lblEstadoMensaje.Location = new Point(180, 600);
        this.lblEstadoMensaje.Name = "lblEstadoMensaje";
        this.lblEstadoMensaje.Size = new Size(0, 15);
        this.lblEstadoMensaje.TabIndex = 5;

        // CitasForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1224, 787);
        this.Controls.Add(this.lblEstadoMensaje);
        this.Controls.Add(this.btnExportarExcel);
        this.Controls.Add(this.btnCancelar);
        this.Controls.Add(this.dgvCitas);
        this.Controls.Add(this.gbxEditar);
        this.Controls.Add(this.gbxBuscar);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(1240, 676);
        this.Name = "CitasForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Gestión de Citas - Veterinaria Genesis";
        this.Load += new EventHandler(this.CitasForm_Load);
        this.gbxBuscar.ResumeLayout(false);
        this.gbxBuscar.PerformLayout();
        this.gbxEditar.ResumeLayout(false);
        this.gbxEditar.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

