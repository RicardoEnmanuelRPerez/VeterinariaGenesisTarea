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
        lblBusqueda = new Label();
        txtBusqueda = new TextBox();
        btnBuscar = new Button();
        btnLimpiar = new Button();
        dgvMascotas = new DataGridView();
        gbxDatosMascota = new GroupBox();
        lblNombreMascota = new Label();
        lblEspecie = new Label();
        lblRaza = new Label();
        lblFechaNacimiento = new Label();
        lblPropietario = new Label();
        lblTelefono = new Label();
        lblDireccion = new Label();
        txtNombreMascota = new TextBox();
        txtEspecie = new TextBox();
        txtRaza = new TextBox();
        txtFechaNacimiento = new TextBox();
        txtPropietario = new TextBox();
        txtTelefono = new TextBox();
        txtDireccion = new TextBox();
        gbxHistorial = new GroupBox();
        dgvHistorial = new DataGridView();
        btnExportarExcel = new Button();
        lblEstado = new Label();
        lblMensajeSinResultados = new Label();
        errorProvider1 = new ErrorProvider(components);
        gbxBusqueda.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(dgvMascotas)).BeginInit();
        gbxDatosMascota.SuspendLayout();
        gbxHistorial.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(dgvHistorial)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(errorProvider1)).BeginInit();
        SuspendLayout();
        
        // gbxBusqueda
        gbxBusqueda.Controls.Add(btnLimpiar);
        gbxBusqueda.Controls.Add(btnBuscar);
        gbxBusqueda.Controls.Add(txtBusqueda);
        gbxBusqueda.Controls.Add(lblBusqueda);
        gbxBusqueda.Font = new Font("Segoe UI", 10F);
        gbxBusqueda.Location = new Point(12, 12);
        gbxBusqueda.Name = "gbxBusqueda";
        gbxBusqueda.Size = new Size(1200, 80);
        gbxBusqueda.TabIndex = 0;
        gbxBusqueda.TabStop = false;
        gbxBusqueda.Text = "Buscar Mascota";
        
        // lblBusqueda
        lblBusqueda.AutoSize = true;
        lblBusqueda.Location = new Point(15, 35);
        lblBusqueda.Name = "lblBusqueda";
        lblBusqueda.Size = new Size(280, 19);
        lblBusqueda.TabIndex = 0;
        lblBusqueda.Text = "Nombre de Mascota o Propietario:";
        
        // txtBusqueda
        txtBusqueda.Location = new Point(300, 32);
        txtBusqueda.Name = "txtBusqueda";
        txtBusqueda.Size = new Size(400, 25);
        txtBusqueda.TabIndex = 1;
        txtBusqueda.KeyDown += txtBusqueda_KeyDown;
        
        // btnBuscar
        btnBuscar.Location = new Point(720, 30);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(120, 30);
        btnBuscar.TabIndex = 2;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += btnBuscar_Click;
        
        // btnLimpiar
        btnLimpiar.Location = new Point(850, 30);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(120, 30);
        btnLimpiar.TabIndex = 3;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        
        // dgvMascotas
        dgvMascotas.Location = new Point(12, 100);
        dgvMascotas.Name = "dgvMascotas";
        dgvMascotas.Size = new Size(600, 200);
        dgvMascotas.TabIndex = 1;
        
        // gbxDatosMascota
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
        gbxDatosMascota.Location = new Point(630, 100);
        gbxDatosMascota.Name = "gbxDatosMascota";
        gbxDatosMascota.Size = new Size(582, 200);
        gbxDatosMascota.TabIndex = 2;
        gbxDatosMascota.TabStop = false;
        gbxDatosMascota.Text = "Datos de la Mascota Seleccionada";
        
        // Labels y TextBoxes de datos de mascota
        lblNombreMascota.AutoSize = true;
        lblNombreMascota.Location = new Point(15, 30);
        lblNombreMascota.Name = "lblNombreMascota";
        lblNombreMascota.Size = new Size(65, 19);
        lblNombreMascota.TabIndex = 0;
        lblNombreMascota.Text = "Nombre:";
        
        txtNombreMascota.Location = new Point(90, 27);
        txtNombreMascota.Name = "txtNombreMascota";
        txtNombreMascota.ReadOnly = true;
        txtNombreMascota.Size = new Size(200, 25);
        txtNombreMascota.TabIndex = 1;
        
        lblEspecie.AutoSize = true;
        lblEspecie.Location = new Point(300, 30);
        lblEspecie.Name = "lblEspecie";
        lblEspecie.Size = new Size(60, 19);
        lblEspecie.TabIndex = 2;
        lblEspecie.Text = "Especie:";
        
        txtEspecie.Location = new Point(370, 27);
        txtEspecie.Name = "txtEspecie";
        txtEspecie.ReadOnly = true;
        txtEspecie.Size = new Size(150, 25);
        txtEspecie.TabIndex = 3;
        
        lblRaza.AutoSize = true;
        lblRaza.Location = new Point(15, 65);
        lblRaza.Name = "lblRaza";
        lblRaza.Size = new Size(45, 19);
        lblRaza.TabIndex = 4;
        lblRaza.Text = "Raza:";
        
        txtRaza.Location = new Point(70, 62);
        txtRaza.Name = "txtRaza";
        txtRaza.ReadOnly = true;
        txtRaza.Size = new Size(200, 25);
        txtRaza.TabIndex = 5;
        
        lblFechaNacimiento.AutoSize = true;
        lblFechaNacimiento.Location = new Point(300, 65);
        lblFechaNacimiento.Name = "lblFechaNacimiento";
        lblFechaNacimiento.Size = new Size(130, 19);
        lblFechaNacimiento.TabIndex = 6;
        lblFechaNacimiento.Text = "Fecha Nacimiento:";
        
        txtFechaNacimiento.Location = new Point(440, 62);
        txtFechaNacimiento.Name = "txtFechaNacimiento";
        txtFechaNacimiento.ReadOnly = true;
        txtFechaNacimiento.Size = new Size(120, 25);
        txtFechaNacimiento.TabIndex = 7;
        
        lblPropietario.AutoSize = true;
        lblPropietario.Location = new Point(15, 100);
        lblPropietario.Name = "lblPropietario";
        lblPropietario.Size = new Size(80, 19);
        lblPropietario.TabIndex = 8;
        lblPropietario.Text = "Propietario:";
        
        txtPropietario.Location = new Point(100, 97);
        txtPropietario.Name = "txtPropietario";
        txtPropietario.ReadOnly = true;
        txtPropietario.Size = new Size(300, 25);
        txtPropietario.TabIndex = 9;
        
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(15, 135);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(65, 19);
        lblTelefono.TabIndex = 10;
        lblTelefono.Text = "Teléfono:";
        
        txtTelefono.Location = new Point(90, 132);
        txtTelefono.Name = "txtTelefono";
        txtTelefono.ReadOnly = true;
        txtTelefono.Size = new Size(200, 25);
        txtTelefono.TabIndex = 11;
        
        lblDireccion.AutoSize = true;
        lblDireccion.Location = new Point(300, 135);
        lblDireccion.Name = "lblDireccion";
        lblDireccion.Size = new Size(70, 19);
        lblDireccion.TabIndex = 12;
        lblDireccion.Text = "Dirección:";
        
        txtDireccion.Location = new Point(380, 132);
        txtDireccion.Name = "txtDireccion";
        txtDireccion.ReadOnly = true;
        txtDireccion.Size = new Size(180, 25);
        txtDireccion.TabIndex = 13;
        
        // gbxHistorial
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
        
        // dgvHistorial
        dgvHistorial.Location = new Point(15, 30);
        dgvHistorial.Name = "dgvHistorial";
        dgvHistorial.Size = new Size(1170, 330);
        dgvHistorial.TabIndex = 0;
        
        // btnExportarExcel
        btnExportarExcel.Location = new Point(1050, 370);
        btnExportarExcel.Name = "btnExportarExcel";
        btnExportarExcel.Size = new Size(135, 30);
        btnExportarExcel.TabIndex = 1;
        btnExportarExcel.Text = "Exportar Excel";
        btnExportarExcel.UseVisualStyleBackColor = true;
        btnExportarExcel.Click += btnExportarExcel_Click;
        
        // lblMensajeSinResultados
        lblMensajeSinResultados.AutoSize = true;
        lblMensajeSinResultados.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblMensajeSinResultados.Location = new Point(15, 375);
        lblMensajeSinResultados.Name = "lblMensajeSinResultados";
        lblMensajeSinResultados.Size = new Size(0, 21);
        lblMensajeSinResultados.TabIndex = 2;
        
        // lblEstado
        lblEstado.AutoSize = true;
        lblEstado.Font = new Font("Segoe UI", 10F);
        lblEstado.Location = new Point(12, 720);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(40, 19);
        lblEstado.TabIndex = 4;
        lblEstado.Text = "Listo";
        
        // HistorialClinicoForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1224, 750);
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
        ((System.ComponentModel.ISupportInitialize)(dgvMascotas)).EndInit();
        gbxDatosMascota.ResumeLayout(false);
        gbxDatosMascota.PerformLayout();
        gbxHistorial.ResumeLayout(false);
        gbxHistorial.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(dgvHistorial)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(errorProvider1)).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

