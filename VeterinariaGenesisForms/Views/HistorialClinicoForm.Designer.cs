#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class HistorialClinicoForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxBusqueda = null!;
    private TextBox txtBusqueda = null!;
    private Button btnBuscar = null!;
    private Button btnLimpiar = null!;
    private Label lblBusqueda = null!;
    private DataGridView dgvMascotas = null!;
    private GroupBox gbxDatosMascota = null!;
    private Label lblNombreMascota = null!;
    private Label lblEspecie = null!;
    private Label lblRaza = null!;
    private Label lblFechaNacimiento = null!;
    private Label lblPropietario = null!;
    private Label lblTelefono = null!;
    private Label lblDireccion = null!;
    private TextBox txtNombreMascota = null!;
    private TextBox txtEspecie = null!;
    private TextBox txtRaza = null!;
    private TextBox txtFechaNacimiento = null!;
    private TextBox txtPropietario = null!;
    private TextBox txtTelefono = null!;
    private TextBox txtDireccion = null!;
    private GroupBox gbxHistorial = null!;
    private DataGridView dgvHistorial = null!;
    private Button btnExportarExcel = null!;
    private Label lblEstado = null!;
    private Label lblMensajeSinResultados = null!;
    private ErrorProvider errorProvider1 = null!;

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
        components = new System.ComponentModel.Container();
        gbxBusqueda = new GroupBox();
        btnLimpiar = new Button();
        btnBuscar = new Button();
        txtBusqueda = new TextBox();
        lblBusqueda = new Label();
        dgvMascotas = new DataGridView();
        gbxDatosMascota = new GroupBox();
        txtDireccion = new TextBox();
        txtTelefono = new TextBox();
        txtPropietario = new TextBox();
        txtFechaNacimiento = new TextBox();
        txtRaza = new TextBox();
        txtEspecie = new TextBox();
        txtNombreMascota = new TextBox();
        lblDireccion = new Label();
        lblTelefono = new Label();
        lblPropietario = new Label();
        lblFechaNacimiento = new Label();
        lblRaza = new Label();
        lblEspecie = new Label();
        lblNombreMascota = new Label();
        gbxHistorial = new GroupBox();
        lblMensajeSinResultados = new Label();
        btnExportarExcel = new Button();
        dgvHistorial = new DataGridView();
        lblEstado = new Label();
        errorProvider1 = new ErrorProvider(components);
        gbxBusqueda.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMascotas).BeginInit();
        gbxDatosMascota.SuspendLayout();
        gbxHistorial.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();
        // 
        // gbxBusqueda
        // 
        gbxBusqueda.Controls.Add(btnLimpiar);
        gbxBusqueda.Controls.Add(btnBuscar);
        gbxBusqueda.Controls.Add(txtBusqueda);
        gbxBusqueda.Controls.Add(lblBusqueda);
        gbxBusqueda.Font = new Font("Segoe UI", 10F);
        gbxBusqueda.Location = new Point(12, 12);
        gbxBusqueda.Name = "gbxBusqueda";
        gbxBusqueda.Size = new Size(1537, 80);
        gbxBusqueda.TabIndex = 0;
        gbxBusqueda.TabStop = false;
        gbxBusqueda.Text = "Buscar Mascota";
        // 
        // btnLimpiar
        // 
        btnLimpiar.Location = new Point(850, 30);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(120, 30);
        btnLimpiar.TabIndex = 3;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // btnBuscar
        // 
        btnBuscar.Location = new Point(720, 30);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(120, 30);
        btnBuscar.TabIndex = 2;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += btnBuscar_Click;
        // 
        // txtBusqueda
        // 
        txtBusqueda.Location = new Point(300, 32);
        txtBusqueda.Name = "txtBusqueda";
        txtBusqueda.Size = new Size(400, 30);
        txtBusqueda.TabIndex = 1;
        txtBusqueda.KeyDown += txtBusqueda_KeyDown;
        // 
        // lblBusqueda
        // 
        lblBusqueda.AutoSize = true;
        lblBusqueda.Location = new Point(15, 35);
        lblBusqueda.Name = "lblBusqueda";
        lblBusqueda.Size = new Size(274, 23);
        lblBusqueda.TabIndex = 0;
        lblBusqueda.Text = "Nombre de Mascota o Propietario:";
        // 
        // dgvMascotas
        // 
        dgvMascotas.ColumnHeadersHeight = 29;
        dgvMascotas.Location = new Point(12, 100);
        dgvMascotas.Name = "dgvMascotas";
        dgvMascotas.RowHeadersWidth = 51;
        dgvMascotas.Size = new Size(813, 200);
        dgvMascotas.TabIndex = 1;
        // 
        // gbxDatosMascota
        // 
        gbxDatosMascota.Controls.Add(txtDireccion);
        gbxDatosMascota.Controls.Add(txtTelefono);
        gbxDatosMascota.Controls.Add(txtPropietario);
        gbxDatosMascota.Controls.Add(txtFechaNacimiento);
        gbxDatosMascota.Controls.Add(txtRaza);
        gbxDatosMascota.Controls.Add(txtEspecie);
        gbxDatosMascota.Controls.Add(txtNombreMascota);
        gbxDatosMascota.Controls.Add(lblDireccion);
        gbxDatosMascota.Controls.Add(lblTelefono);
        gbxDatosMascota.Controls.Add(lblPropietario);
        gbxDatosMascota.Controls.Add(lblFechaNacimiento);
        gbxDatosMascota.Controls.Add(lblRaza);
        gbxDatosMascota.Controls.Add(lblEspecie);
        gbxDatosMascota.Controls.Add(lblNombreMascota);
        gbxDatosMascota.Font = new Font("Segoe UI", 10F);
        gbxDatosMascota.Location = new Point(862, 104);
        gbxDatosMascota.Name = "gbxDatosMascota";
        gbxDatosMascota.Size = new Size(650, 200);
        gbxDatosMascota.TabIndex = 2;
        gbxDatosMascota.TabStop = false;
        gbxDatosMascota.Text = "Datos de la Mascota Seleccionada";
        // 
        // txtDireccion
        // 
        txtDireccion.Location = new Point(380, 132);
        txtDireccion.Name = "txtDireccion";
        txtDireccion.ReadOnly = true;
        txtDireccion.Size = new Size(180, 30);
        txtDireccion.TabIndex = 13;
        // 
        // txtTelefono
        // 
        txtTelefono.Location = new Point(90, 132);
        txtTelefono.Name = "txtTelefono";
        txtTelefono.ReadOnly = true;
        txtTelefono.Size = new Size(200, 30);
        txtTelefono.TabIndex = 11;
        // 
        // txtPropietario
        // 
        txtPropietario.Location = new Point(130, 100);
        txtPropietario.Name = "txtPropietario";
        txtPropietario.ReadOnly = true;
        txtPropietario.Size = new Size(300, 30);
        txtPropietario.TabIndex = 9;
        // 
        // txtFechaNacimiento
        // 
        txtFechaNacimiento.Location = new Point(470, 59);
        txtFechaNacimiento.Name = "txtFechaNacimiento";
        txtFechaNacimiento.ReadOnly = true;
        txtFechaNacimiento.Size = new Size(120, 30);
        txtFechaNacimiento.TabIndex = 7;
        // 
        // txtRaza
        // 
        txtRaza.Location = new Point(94, 61);
        txtRaza.Name = "txtRaza";
        txtRaza.ReadOnly = true;
        txtRaza.Size = new Size(200, 30);
        txtRaza.TabIndex = 5;
        // 
        // txtEspecie
        // 
        txtEspecie.Location = new Point(440, 23);
        txtEspecie.Name = "txtEspecie";
        txtEspecie.ReadOnly = true;
        txtEspecie.Size = new Size(150, 30);
        txtEspecie.TabIndex = 3;
        // 
        // txtNombreMascota
        // 
        txtNombreMascota.Location = new Point(90, 27);
        txtNombreMascota.Name = "txtNombreMascota";
        txtNombreMascota.ReadOnly = true;
        txtNombreMascota.Size = new Size(200, 30);
        txtNombreMascota.TabIndex = 1;
        // 
        // lblDireccion
        // 
        lblDireccion.AutoSize = true;
        lblDireccion.Location = new Point(300, 135);
        lblDireccion.Name = "lblDireccion";
        lblDireccion.Size = new Size(85, 23);
        lblDireccion.TabIndex = 12;
        lblDireccion.Text = "Dirección:";
        // 
        // lblTelefono
        // 
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(15, 135);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(78, 23);
        lblTelefono.TabIndex = 10;
        lblTelefono.Text = "Teléfono:";
        // 
        // lblPropietario
        // 
        lblPropietario.AutoSize = true;
        lblPropietario.Location = new Point(15, 100);
        lblPropietario.Name = "lblPropietario";
        lblPropietario.Size = new Size(98, 23);
        lblPropietario.TabIndex = 8;
        lblPropietario.Text = "Propietario:";
        // 
        // lblFechaNacimiento
        // 
        lblFechaNacimiento.AutoSize = true;
        lblFechaNacimiento.Location = new Point(300, 65);
        lblFechaNacimiento.Name = "lblFechaNacimiento";
        lblFechaNacimiento.Size = new Size(151, 23);
        lblFechaNacimiento.TabIndex = 6;
        lblFechaNacimiento.Text = "Fecha Nacimiento:";
        // 
        // lblRaza
        // 
        lblRaza.AutoSize = true;
        lblRaza.Location = new Point(15, 65);
        lblRaza.Name = "lblRaza";
        lblRaza.Size = new Size(50, 23);
        lblRaza.TabIndex = 4;
        lblRaza.Text = "Raza:";
        // 
        // lblEspecie
        // 
        lblEspecie.AutoSize = true;
        lblEspecie.Location = new Point(346, 30);
        lblEspecie.Name = "lblEspecie";
        lblEspecie.Size = new Size(70, 23);
        lblEspecie.TabIndex = 2;
        lblEspecie.Text = "Especie:";
        // 
        // lblNombreMascota
        // 
        lblNombreMascota.AutoSize = true;
        lblNombreMascota.Location = new Point(15, 30);
        lblNombreMascota.Name = "lblNombreMascota";
        lblNombreMascota.Size = new Size(77, 23);
        lblNombreMascota.TabIndex = 0;
        lblNombreMascota.Text = "Nombre:";
        // 
        // gbxHistorial
        // 
        gbxHistorial.Controls.Add(lblMensajeSinResultados);
        gbxHistorial.Controls.Add(btnExportarExcel);
        gbxHistorial.Controls.Add(dgvHistorial);
        gbxHistorial.Font = new Font("Segoe UI", 10F);
        gbxHistorial.Location = new Point(12, 310);
        gbxHistorial.Name = "gbxHistorial";
        gbxHistorial.Size = new Size(1200, 400);
        gbxHistorial.TabIndex = 3;
        gbxHistorial.TabStop = false;
        gbxHistorial.Text = "Historial Clínico";
        // 
        // lblMensajeSinResultados
        // 
        lblMensajeSinResultados.AutoSize = true;
        lblMensajeSinResultados.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblMensajeSinResultados.Location = new Point(15, 375);
        lblMensajeSinResultados.Name = "lblMensajeSinResultados";
        lblMensajeSinResultados.Size = new Size(0, 28);
        lblMensajeSinResultados.TabIndex = 2;
        // 
        // btnExportarExcel
        // 
        btnExportarExcel.Location = new Point(1050, 370);
        btnExportarExcel.Name = "btnExportarExcel";
        btnExportarExcel.Size = new Size(135, 30);
        btnExportarExcel.TabIndex = 1;
        btnExportarExcel.Text = "Exportar Excel";
        btnExportarExcel.UseVisualStyleBackColor = true;
        btnExportarExcel.Click += btnExportarExcel_Click;
        // 
        // dgvHistorial
        // 
        dgvHistorial.ColumnHeadersHeight = 29;
        dgvHistorial.Location = new Point(15, 30);
        dgvHistorial.Name = "dgvHistorial";
        dgvHistorial.RowHeadersWidth = 51;
        dgvHistorial.Size = new Size(1170, 330);
        dgvHistorial.TabIndex = 0;
        // 
        // lblEstado
        // 
        lblEstado.AutoSize = true;
        lblEstado.Font = new Font("Segoe UI", 10F);
        lblEstado.Location = new Point(12, 720);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(45, 23);
        lblEstado.TabIndex = 4;
        lblEstado.Text = "Listo";
        // 
        // errorProvider1
        // 
        errorProvider1.ContainerControl = this;
        // 
        // HistorialClinicoForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1615, 750);
        Controls.Add(lblEstado);
        Controls.Add(gbxHistorial);
        Controls.Add(gbxDatosMascota);
        Controls.Add(dgvMascotas);
        Controls.Add(gbxBusqueda);
        FormBorderStyle = FormBorderStyle.None;
        Name = "HistorialClinicoForm";
        Text = "Historial Clínico de Mascotas";
        Load += HistorialClinicoForm_Load;
        gbxBusqueda.ResumeLayout(false);
        gbxBusqueda.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMascotas).EndInit();
        gbxDatosMascota.ResumeLayout(false);
        gbxDatosMascota.PerformLayout();
        gbxHistorial.ResumeLayout(false);
        gbxHistorial.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

