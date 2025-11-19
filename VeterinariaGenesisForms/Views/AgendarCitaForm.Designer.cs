#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class AgendarCitaForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxDatos = null!;
    private Label lblPropietario = null!;
    private Label lblMascota = null!;
    private Label lblFecha = null!;
    private Label lblHora = null!;
    private Label lblVeterinario = null!;
    private Label lblServicios = null!;
    private ComboBox cmbPropietario = null!;
    private ComboBox cmbMascota = null!;
    private ComboBox cmbVeterinario = null!;
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
        this.lblMascota = new Label();
        this.lblFecha = new Label();
        this.lblHora = new Label();
        this.lblVeterinario = new Label();
        this.lblServicios = new Label();
        this.cmbPropietario = new ComboBox();
        this.cmbMascota = new ComboBox();
        this.cmbVeterinario = new ComboBox();
        this.clbServicios = new CheckedListBox();
        this.dtpFecha = new DateTimePicker();
        this.dtpHora = new DateTimePicker();
        this.btnAgendar = new Button();
        this.btnLimpiar = new Button();
        this.lblEstado = new Label();
        this.gbxDatos.SuspendLayout();
        this.SuspendLayout();

        // gbxDatos
        this.gbxDatos.Controls.Add(this.btnLimpiar);
        this.gbxDatos.Controls.Add(this.btnAgendar);
        this.gbxDatos.Controls.Add(this.clbServicios);
        this.gbxDatos.Controls.Add(this.cmbVeterinario);
        this.gbxDatos.Controls.Add(this.dtpHora);
        this.gbxDatos.Controls.Add(this.dtpFecha);
        this.gbxDatos.Controls.Add(this.cmbMascota);
        this.gbxDatos.Controls.Add(this.cmbPropietario);
        this.gbxDatos.Controls.Add(this.lblServicios);
        this.gbxDatos.Controls.Add(this.lblVeterinario);
        this.gbxDatos.Controls.Add(this.lblHora);
        this.gbxDatos.Controls.Add(this.lblFecha);
        this.gbxDatos.Controls.Add(this.lblMascota);
        this.gbxDatos.Controls.Add(this.lblPropietario);
        this.gbxDatos.Font = new Font("Segoe UI", 10F);
        this.gbxDatos.Location = new Point(12, 12);
        this.gbxDatos.Name = "gbxDatos";
        this.gbxDatos.Size = new Size(600, 400);
        this.gbxDatos.TabIndex = 0;
        this.gbxDatos.TabStop = false;
        this.gbxDatos.Text = "Datos de la Cita";

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
        this.cmbPropietario.Size = new Size(470, 25);
        this.cmbPropietario.TabIndex = 1;

        this.lblMascota.AutoSize = true;
        this.lblMascota.Location = new Point(15, 70);
        this.lblMascota.Name = "lblMascota";
        this.lblMascota.Size = new Size(65, 19);
        this.lblMascota.TabIndex = 2;
        this.lblMascota.Text = "Mascota:";

        this.cmbMascota.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbMascota.FormattingEnabled = true;
        this.cmbMascota.Location = new Point(100, 67);
        this.cmbMascota.Name = "cmbMascota";
        this.cmbMascota.Size = new Size(470, 25);
        this.cmbMascota.TabIndex = 3;

        this.lblFecha.AutoSize = true;
        this.lblFecha.Location = new Point(15, 110);
        this.lblFecha.Name = "lblFecha";
        this.lblFecha.Size = new Size(48, 19);
        this.lblFecha.TabIndex = 4;
        this.lblFecha.Text = "Fecha:";

        this.dtpFecha.Format = DateTimePickerFormat.Short;
        this.dtpFecha.Location = new Point(70, 107);
        this.dtpFecha.Name = "dtpFecha";
        this.dtpFecha.Size = new Size(150, 25);
        this.dtpFecha.TabIndex = 5;

        this.lblHora.AutoSize = true;
        this.lblHora.Location = new Point(240, 110);
        this.lblHora.Name = "lblHora";
        this.lblHora.Size = new Size(42, 19);
        this.lblHora.TabIndex = 6;
        this.lblHora.Text = "Hora:";

        this.dtpHora.Format = DateTimePickerFormat.Time;
        this.dtpHora.Location = new Point(290, 107);
        this.dtpHora.Name = "dtpHora";
        this.dtpHora.ShowUpDown = true;
        this.dtpHora.Size = new Size(120, 25);
        this.dtpHora.TabIndex = 7;

        this.lblVeterinario.AutoSize = true;
        this.lblVeterinario.Location = new Point(15, 150);
        this.lblVeterinario.Name = "lblVeterinario";
        this.lblVeterinario.Size = new Size(78, 19);
        this.lblVeterinario.TabIndex = 8;
        this.lblVeterinario.Text = "Veterinario:";

        this.cmbVeterinario.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbVeterinario.FormattingEnabled = true;
        this.cmbVeterinario.Location = new Point(100, 147);
        this.cmbVeterinario.Name = "cmbVeterinario";
        this.cmbVeterinario.Size = new Size(470, 25);
        this.cmbVeterinario.TabIndex = 9;

        this.lblServicios.AutoSize = true;
        this.lblServicios.Location = new Point(15, 190);
        this.lblServicios.Name = "lblServicios";
        this.lblServicios.Size = new Size(68, 19);
        this.lblServicios.TabIndex = 10;
        this.lblServicios.Text = "Servicios:";

        this.clbServicios.CheckOnClick = true;
        this.clbServicios.FormattingEnabled = true;
        this.clbServicios.Location = new Point(100, 187);
        this.clbServicios.Name = "clbServicios";
        this.clbServicios.Size = new Size(470, 150);
        this.clbServicios.TabIndex = 11;

        this.btnAgendar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnAgendar.Location = new Point(100, 350);
        this.btnAgendar.Name = "btnAgendar";
        this.btnAgendar.Size = new Size(200, 35);
        this.btnAgendar.TabIndex = 12;
        this.btnAgendar.Text = "&Agendar Cita(s)";
        this.btnAgendar.UseVisualStyleBackColor = true;
        this.btnAgendar.Click += new EventHandler(this.btnAgendar_Click);

        this.btnLimpiar.Font = new Font("Segoe UI", 10F);
        this.btnLimpiar.Location = new Point(320, 350);
        this.btnLimpiar.Name = "btnLimpiar";
        this.btnLimpiar.Size = new Size(150, 35);
        this.btnLimpiar.TabIndex = 13;
        this.btnLimpiar.Text = "&Limpiar";
        this.btnLimpiar.UseVisualStyleBackColor = true;
        this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);

        // lblEstado
        this.lblEstado.AutoSize = true;
        this.lblEstado.Font = new Font("Segoe UI", 9F);
        this.lblEstado.Location = new Point(15, 420);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(0, 15);
        this.lblEstado.TabIndex = 1;

        // AgendarCitaForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(624, 450);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.gbxDatos);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(640, 489);
        this.Name = "AgendarCitaForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Agendar Nueva Cita - Veterinaria Genesis";
        this.Load += new EventHandler(this.AgendarCitaForm_Load);
        this.gbxDatos.ResumeLayout(false);
        this.gbxDatos.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

