#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class AgendarCitaForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxDatos = null!;
    private Label lblPropietario = null!;
    private Label lblBuscarPropietario = null!;
    private TextBox txtBuscarPropietario = null!;
    private DataGridView dgvPropietarios = null!;
    private Label lblMascota = null!;
    private Label lblBuscarMascota = null!;
    private TextBox txtBuscarMascota = null!;
    private DataGridView dgvMascotas = null!;
    private Label lblFecha = null!;
    private Label lblHora = null!;
    private Label lblVeterinario = null!;
    private Label lblBuscarVeterinario = null!;
    private TextBox txtBuscarVeterinario = null!;
    private DataGridView dgvVeterinarios = null!;
    private Label lblServicios = null!;
    private CheckedListBox clbServicios = null!;
    private DateTimePicker dtpFecha = null!;
    private DateTimePicker dtpHora = null!;
    private Button btnAgendar = null!;
    private Button btnLimpiar = null!;
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
        this.gbxDatos = new GroupBox();
        this.lblPropietario = new Label();
        this.lblBuscarPropietario = new Label();
        this.txtBuscarPropietario = new TextBox();
        this.dgvPropietarios = new DataGridView();
        this.lblMascota = new Label();
        this.lblBuscarMascota = new Label();
        this.txtBuscarMascota = new TextBox();
        this.dgvMascotas = new DataGridView();
        this.lblFecha = new Label();
        this.lblHora = new Label();
        this.lblVeterinario = new Label();
        this.lblBuscarVeterinario = new Label();
        this.txtBuscarVeterinario = new TextBox();
        this.dgvVeterinarios = new DataGridView();
        this.lblServicios = new Label();
        this.clbServicios = new CheckedListBox();
        this.dtpFecha = new DateTimePicker();
        this.dtpHora = new DateTimePicker();
        this.btnAgendar = new Button();
        this.btnLimpiar = new Button();
        this.lblEstado = new Label();
        this.gbxDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvVeterinarios)).BeginInit();
        this.SuspendLayout();

        // gbxDatos
        this.gbxDatos.Controls.Add(this.btnLimpiar);
        this.gbxDatos.Controls.Add(this.btnAgendar);
        this.gbxDatos.Controls.Add(this.clbServicios);
        this.gbxDatos.Controls.Add(this.dgvVeterinarios);
        this.gbxDatos.Controls.Add(this.txtBuscarVeterinario);
        this.gbxDatos.Controls.Add(this.lblBuscarVeterinario);
        this.gbxDatos.Controls.Add(this.dtpHora);
        this.gbxDatos.Controls.Add(this.dtpFecha);
        this.gbxDatos.Controls.Add(this.dgvMascotas);
        this.gbxDatos.Controls.Add(this.txtBuscarMascota);
        this.gbxDatos.Controls.Add(this.lblBuscarMascota);
        this.gbxDatos.Controls.Add(this.dgvPropietarios);
        this.gbxDatos.Controls.Add(this.txtBuscarPropietario);
        this.gbxDatos.Controls.Add(this.lblBuscarPropietario);
        this.gbxDatos.Controls.Add(this.lblServicios);
        this.gbxDatos.Controls.Add(this.lblVeterinario);
        this.gbxDatos.Controls.Add(this.lblHora);
        this.gbxDatos.Controls.Add(this.lblFecha);
        this.gbxDatos.Controls.Add(this.lblMascota);
        this.gbxDatos.Controls.Add(this.lblPropietario);
        this.gbxDatos.Font = new Font("Segoe UI", 10F);
        this.gbxDatos.Location = new Point(12, 12);
        this.gbxDatos.Name = "gbxDatos";
        this.gbxDatos.Size = new Size(600, 750);
        this.gbxDatos.TabIndex = 0;
        this.gbxDatos.TabStop = false;
        this.gbxDatos.Text = "Datos de la Cita";

        this.lblPropietario.AutoSize = true;
        this.lblPropietario.Location = new Point(15, 30);
        this.lblPropietario.Name = "lblPropietario";
        this.lblPropietario.Size = new Size(80, 23);
        this.lblPropietario.TabIndex = 0;
        this.lblPropietario.Text = "Propietario:";

        this.lblBuscarPropietario.AutoSize = true;
        this.lblBuscarPropietario.Location = new Point(100, 30);
        this.lblBuscarPropietario.Name = "lblBuscarPropietario";
        this.lblBuscarPropietario.Size = new Size(178, 23);
        this.lblBuscarPropietario.TabIndex = 1;
        this.lblBuscarPropietario.Text = "Buscar por Nombre:";

        this.txtBuscarPropietario.Location = new Point(285, 27);
        this.txtBuscarPropietario.Name = "txtBuscarPropietario";
        this.txtBuscarPropietario.Size = new Size(285, 30);
        this.txtBuscarPropietario.TabIndex = 2;
        this.txtBuscarPropietario.TextChanged += new EventHandler(this.TxtBuscarPropietario_TextChanged);

        this.dgvPropietarios.AllowUserToAddRows = false;
        this.dgvPropietarios.AllowUserToDeleteRows = false;
        this.dgvPropietarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvPropietarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvPropietarios.Location = new Point(15, 65);
        this.dgvPropietarios.MultiSelect = false;
        this.dgvPropietarios.Name = "dgvPropietarios";
        this.dgvPropietarios.ReadOnly = true;
        this.dgvPropietarios.RowHeadersWidth = 51;
        this.dgvPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvPropietarios.Size = new Size(555, 120);
        this.dgvPropietarios.TabIndex = 3;
        this.dgvPropietarios.SelectionChanged += new EventHandler(this.DgvPropietarios_SelectionChanged);

        this.lblMascota.AutoSize = true;
        this.lblMascota.Location = new Point(15, 200);
        this.lblMascota.Name = "lblMascota";
        this.lblMascota.Size = new Size(78, 23);
        this.lblMascota.TabIndex = 4;
        this.lblMascota.Text = "Mascota:";

        this.lblBuscarMascota.AutoSize = true;
        this.lblBuscarMascota.Location = new Point(100, 200);
        this.lblBuscarMascota.Name = "lblBuscarMascota";
        this.lblBuscarMascota.Size = new Size(178, 23);
        this.lblBuscarMascota.TabIndex = 5;
        this.lblBuscarMascota.Text = "Buscar por Nombre:";

        this.txtBuscarMascota.Location = new Point(285, 197);
        this.txtBuscarMascota.Name = "txtBuscarMascota";
        this.txtBuscarMascota.Size = new Size(285, 30);
        this.txtBuscarMascota.TabIndex = 6;
        this.txtBuscarMascota.TextChanged += new EventHandler(this.TxtBuscarMascota_TextChanged);

        this.dgvMascotas.AllowUserToAddRows = false;
        this.dgvMascotas.AllowUserToDeleteRows = false;
        this.dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvMascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvMascotas.Location = new Point(15, 235);
        this.dgvMascotas.MultiSelect = false;
        this.dgvMascotas.Name = "dgvMascotas";
        this.dgvMascotas.ReadOnly = true;
        this.dgvMascotas.RowHeadersWidth = 51;
        this.dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvMascotas.Size = new Size(555, 120);
        this.dgvMascotas.TabIndex = 7;
        this.dgvMascotas.SelectionChanged += new EventHandler(this.DgvMascotas_SelectionChanged);

        this.lblFecha.AutoSize = true;
        this.lblFecha.Location = new Point(15, 370);
        this.lblFecha.Name = "lblFecha";
        this.lblFecha.Size = new Size(58, 23);
        this.lblFecha.TabIndex = 8;
        this.lblFecha.Text = "Fecha:";

        this.dtpFecha.Format = DateTimePickerFormat.Short;
        this.dtpFecha.Location = new Point(80, 367);
        this.dtpFecha.Name = "dtpFecha";
        this.dtpFecha.Size = new Size(150, 30);
        this.dtpFecha.TabIndex = 9;

        this.lblHora.AutoSize = true;
        this.lblHora.Location = new Point(250, 370);
        this.lblHora.Name = "lblHora";
        this.lblHora.Size = new Size(50, 23);
        this.lblHora.TabIndex = 10;
        this.lblHora.Text = "Hora:";

        this.dtpHora.Format = DateTimePickerFormat.Time;
        this.dtpHora.Location = new Point(310, 367);
        this.dtpHora.Name = "dtpHora";
        this.dtpHora.ShowUpDown = true;
        this.dtpHora.Size = new Size(140, 30);
        this.dtpHora.TabIndex = 11;

        this.lblVeterinario.AutoSize = true;
        this.lblVeterinario.Location = new Point(15, 410);
        this.lblVeterinario.Name = "lblVeterinario";
        this.lblVeterinario.Size = new Size(97, 23);
        this.lblVeterinario.TabIndex = 12;
        this.lblVeterinario.Text = "Veterinario:";

        this.lblBuscarVeterinario.AutoSize = true;
        this.lblBuscarVeterinario.Location = new Point(120, 410);
        this.lblBuscarVeterinario.Name = "lblBuscarVeterinario";
        this.lblBuscarVeterinario.Size = new Size(178, 23);
        this.lblBuscarVeterinario.TabIndex = 13;
        this.lblBuscarVeterinario.Text = "Buscar por Nombre:";

        this.txtBuscarVeterinario.Location = new Point(305, 407);
        this.txtBuscarVeterinario.Name = "txtBuscarVeterinario";
        this.txtBuscarVeterinario.Size = new Size(265, 30);
        this.txtBuscarVeterinario.TabIndex = 14;
        this.txtBuscarVeterinario.TextChanged += new EventHandler(this.TxtBuscarVeterinario_TextChanged);

        this.dgvVeterinarios.AllowUserToAddRows = false;
        this.dgvVeterinarios.AllowUserToDeleteRows = false;
        this.dgvVeterinarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvVeterinarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvVeterinarios.Location = new Point(15, 445);
        this.dgvVeterinarios.MultiSelect = false;
        this.dgvVeterinarios.Name = "dgvVeterinarios";
        this.dgvVeterinarios.ReadOnly = true;
        this.dgvVeterinarios.RowHeadersWidth = 51;
        this.dgvVeterinarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvVeterinarios.Size = new Size(555, 120);
        this.dgvVeterinarios.TabIndex = 15;
        this.dgvVeterinarios.SelectionChanged += new EventHandler(this.DgvVeterinarios_SelectionChanged);

        this.lblServicios.AutoSize = true;
        this.lblServicios.Location = new Point(15, 580);
        this.lblServicios.Name = "lblServicios";
        this.lblServicios.Size = new Size(82, 23);
        this.lblServicios.TabIndex = 16;
        this.lblServicios.Text = "Servicios:";

        this.clbServicios.CheckOnClick = true;
        this.clbServicios.FormattingEnabled = true;
        this.clbServicios.Location = new Point(105, 577);
        this.clbServicios.Name = "clbServicios";
        this.clbServicios.Size = new Size(465, 100);
        this.clbServicios.TabIndex = 17;

        this.btnAgendar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnAgendar.Location = new Point(100, 690);
        this.btnAgendar.Name = "btnAgendar";
        this.btnAgendar.Size = new Size(200, 35);
        this.btnAgendar.TabIndex = 18;
        this.btnAgendar.Text = "&Agendar Cita(s)";
        this.btnAgendar.UseVisualStyleBackColor = true;
        this.btnAgendar.Click += new EventHandler(this.btnAgendar_Click);

        this.btnLimpiar.Font = new Font("Segoe UI", 10F);
        this.btnLimpiar.Location = new Point(320, 690);
        this.btnLimpiar.Name = "btnLimpiar";
        this.btnLimpiar.Size = new Size(150, 35);
        this.btnLimpiar.TabIndex = 19;
        this.btnLimpiar.Text = "&Limpiar";
        this.btnLimpiar.UseVisualStyleBackColor = true;
        this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);

        // lblEstado
        this.lblEstado.AutoSize = true;
        this.lblEstado.Font = new Font("Segoe UI", 9F);
        this.lblEstado.Location = new Point(15, 780);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(0, 15);
        this.lblEstado.TabIndex = 1;

        // AgendarCitaForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(624, 800);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.gbxDatos);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(640, 839);
        this.Name = "AgendarCitaForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Agendar Nueva Cita - Veterinaria Genesis";
        this.Load += new EventHandler(this.AgendarCitaForm_Load);
        this.gbxDatos.ResumeLayout(false);
        this.gbxDatos.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvVeterinarios)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

