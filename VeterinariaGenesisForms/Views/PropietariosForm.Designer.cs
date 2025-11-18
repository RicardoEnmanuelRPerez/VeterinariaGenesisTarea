#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class PropietariosForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxDatos = null!;
    private Label lblID = null!;
    private Label lblNombre = null!;
    private Label lblApellidos = null!;
    private Label lblDireccion = null!;
    private Label lblTelefono = null!;
    private TextBox txtID = null!;
    private TextBox txtNombre = null!;
    private TextBox txtApellidos = null!;
    private TextBox txtDireccion = null!;
    private TextBox txtTelefono = null!;
    private Button btnNuevo = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnLimpiar = null!;
    private DataGridView dgvPropietarios = null!;
    private Button btnCargar = null!;
    private Button btnExportarExcel = null!;
    private Label lblEstado = null!;
    private Panel pnlBotones = null!;
    private GroupBox gbxMascotas = null!;
    private Label lblMascotaID = null!;
    private Label lblMascotaNombre = null!;
    private Label lblMascotaEspecie = null!;
    private Label lblMascotaRaza = null!;
    private Label lblMascotaEdad = null!;
    private Label lblMascotaSexo = null!;
    private TextBox txtMascotaID = null!;
    private TextBox txtMascotaNombre = null!;
    private TextBox txtMascotaEspecie = null!;
    private TextBox txtMascotaRaza = null!;
    private TextBox txtMascotaEdad = null!;
    private ComboBox cmbMascotaSexo = null!;
    private Button btnMascotaNuevo = null!;
    private Button btnMascotaActualizar = null!;
    private Button btnMascotaEliminar = null!;
    private Button btnMascotaLimpiar = null!;
    private DataGridView dgvMascotas = null!;
    private Label lblMascotasEstado = null!;
    private Panel pnlMascotasBotones = null!;

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
        this.lblID = new Label();
        this.lblNombre = new Label();
        this.lblApellidos = new Label();
        this.lblDireccion = new Label();
        this.lblTelefono = new Label();
        this.txtID = new TextBox();
        this.txtNombre = new TextBox();
        this.txtApellidos = new TextBox();
        this.txtDireccion = new TextBox();
        this.txtTelefono = new TextBox();
        this.pnlBotones = new Panel();
        this.btnNuevo = new Button();
        this.btnActualizar = new Button();
        this.btnEliminar = new Button();
        this.btnLimpiar = new Button();
        this.dgvPropietarios = new DataGridView();
        this.btnCargar = new Button();
        this.btnExportarExcel = new Button();
        this.lblEstado = new Label();
        this.gbxMascotas = new GroupBox();
        this.lblMascotaID = new Label();
        this.lblMascotaNombre = new Label();
        this.lblMascotaEspecie = new Label();
        this.lblMascotaRaza = new Label();
        this.lblMascotaEdad = new Label();
        this.lblMascotaSexo = new Label();
        this.txtMascotaID = new TextBox();
        this.txtMascotaNombre = new TextBox();
        this.txtMascotaEspecie = new TextBox();
        this.txtMascotaRaza = new TextBox();
        this.txtMascotaEdad = new TextBox();
        this.cmbMascotaSexo = new ComboBox();
        this.pnlMascotasBotones = new Panel();
        this.btnMascotaNuevo = new Button();
        this.btnMascotaActualizar = new Button();
        this.btnMascotaEliminar = new Button();
        this.btnMascotaLimpiar = new Button();
        this.dgvMascotas = new DataGridView();
        this.lblMascotasEstado = new Label();
        this.gbxDatos.SuspendLayout();
        this.pnlBotones.SuspendLayout();
        this.gbxMascotas.SuspendLayout();
        this.pnlMascotasBotones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
        this.SuspendLayout();

        // gbxDatos
        this.gbxDatos.Controls.Add(this.pnlBotones);
        this.gbxDatos.Controls.Add(this.txtTelefono);
        this.gbxDatos.Controls.Add(this.txtDireccion);
        this.gbxDatos.Controls.Add(this.txtApellidos);
        this.gbxDatos.Controls.Add(this.txtNombre);
        this.gbxDatos.Controls.Add(this.txtID);
        this.gbxDatos.Controls.Add(this.lblTelefono);
        this.gbxDatos.Controls.Add(this.lblDireccion);
        this.gbxDatos.Controls.Add(this.lblApellidos);
        this.gbxDatos.Controls.Add(this.lblNombre);
        this.gbxDatos.Controls.Add(this.lblID);
        this.gbxDatos.Font = new Font("Segoe UI", 10F);
        this.gbxDatos.Location = new Point(12, 12);
        this.gbxDatos.Name = "gbxDatos";
        this.gbxDatos.Size = new Size(600, 250);
        this.gbxDatos.TabIndex = 0;
        this.gbxDatos.TabStop = false;
        this.gbxDatos.Text = "Datos del Propietario";

        this.lblID.AutoSize = true;
        this.lblID.Location = new Point(15, 30);
        this.lblID.Name = "lblID";
        this.lblID.Size = new Size(25, 19);
        this.lblID.TabIndex = 0;
        this.lblID.Text = "ID:";

        this.txtID.Enabled = false;
        this.txtID.Location = new Point(50, 27);
        this.txtID.Name = "txtID";
        this.txtID.Size = new Size(100, 25);
        this.txtID.TabIndex = 1;

        this.lblNombre.AutoSize = true;
        this.lblNombre.Location = new Point(15, 65);
        this.lblNombre.Name = "lblNombre";
        this.lblNombre.Size = new Size(62, 19);
        this.lblNombre.TabIndex = 2;
        this.lblNombre.Text = "Nombre:";

        this.txtNombre.Location = new Point(85, 62);
        this.txtNombre.Name = "txtNombre";
        this.txtNombre.Size = new Size(200, 25);
        this.txtNombre.TabIndex = 3;

        this.lblApellidos.AutoSize = true;
        this.lblApellidos.Location = new Point(300, 65);
        this.lblApellidos.Name = "lblApellidos";
        this.lblApellidos.Size = new Size(70, 19);
        this.lblApellidos.TabIndex = 4;
        this.lblApellidos.Text = "Apellidos:";

        this.txtApellidos.Location = new Point(375, 62);
        this.txtApellidos.Name = "txtApellidos";
        this.txtApellidos.Size = new Size(200, 25);
        this.txtApellidos.TabIndex = 5;

        this.lblDireccion.AutoSize = true;
        this.lblDireccion.Location = new Point(15, 100);
        this.lblDireccion.Name = "lblDireccion";
        this.lblDireccion.Size = new Size(70, 19);
        this.lblDireccion.TabIndex = 6;
        this.lblDireccion.Text = "Dirección:";

        this.txtDireccion.Location = new Point(90, 97);
        this.txtDireccion.Name = "txtDireccion";
        this.txtDireccion.Size = new Size(485, 25);
        this.txtDireccion.TabIndex = 7;

        this.lblTelefono.AutoSize = true;
        this.lblTelefono.Location = new Point(15, 135);
        this.lblTelefono.Name = "lblTelefono";
        this.lblTelefono.Size = new Size(65, 19);
        this.lblTelefono.TabIndex = 8;
        this.lblTelefono.Text = "Teléfono:";

        this.txtTelefono.Location = new Point(85, 132);
        this.txtTelefono.Name = "txtTelefono";
        this.txtTelefono.Size = new Size(200, 25);
        this.txtTelefono.TabIndex = 9;

        // pnlBotones
        this.pnlBotones.Controls.Add(this.btnNuevo);
        this.pnlBotones.Controls.Add(this.btnActualizar);
        this.pnlBotones.Controls.Add(this.btnEliminar);
        this.pnlBotones.Controls.Add(this.btnLimpiar);
        this.pnlBotones.Location = new Point(15, 170);
        this.pnlBotones.Name = "pnlBotones";
        this.pnlBotones.Size = new Size(560, 70);
        this.pnlBotones.TabIndex = 10;

        this.btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnNuevo.Location = new Point(0, 5);
        this.btnNuevo.Name = "btnNuevo";
        this.btnNuevo.Size = new Size(130, 30);
        this.btnNuevo.TabIndex = 0;
        this.btnNuevo.Text = "&Nuevo / Guardar";
        this.btnNuevo.UseVisualStyleBackColor = true;
        this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);

        this.btnActualizar.Font = new Font("Segoe UI", 10F);
        this.btnActualizar.Location = new Point(140, 5);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new Size(130, 30);
        this.btnActualizar.TabIndex = 1;
        this.btnActualizar.Text = "&Actualizar";
        this.btnActualizar.UseVisualStyleBackColor = true;
        this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);

        this.btnEliminar.Font = new Font("Segoe UI", 10F);
        this.btnEliminar.Location = new Point(280, 5);
        this.btnEliminar.Name = "btnEliminar";
        this.btnEliminar.Size = new Size(130, 30);
        this.btnEliminar.TabIndex = 2;
        this.btnEliminar.Text = "&Desactivar";
        this.btnEliminar.UseVisualStyleBackColor = true;
        this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);

        this.btnLimpiar.Font = new Font("Segoe UI", 10F);
        this.btnLimpiar.Location = new Point(420, 5);
        this.btnLimpiar.Name = "btnLimpiar";
        this.btnLimpiar.Size = new Size(130, 30);
        this.btnLimpiar.TabIndex = 3;
        this.btnLimpiar.Text = "&Limpiar";
        this.btnLimpiar.UseVisualStyleBackColor = true;
        this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);

        // dgvPropietarios
        this.dgvPropietarios.AllowUserToAddRows = false;
        this.dgvPropietarios.AllowUserToDeleteRows = false;
        this.dgvPropietarios.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left)));
        this.dgvPropietarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvPropietarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvPropietarios.Location = new Point(12, 280);
        this.dgvPropietarios.Name = "dgvPropietarios";
        this.dgvPropietarios.ReadOnly = true;
        this.dgvPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvPropietarios.Size = new Size(600, 300);
        this.dgvPropietarios.TabIndex = 1;

        // btnCargar
        this.btnCargar.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
        this.btnCargar.Font = new Font("Segoe UI", 10F);
        this.btnCargar.Location = new Point(1050, 12);
        this.btnCargar.Name = "btnCargar";
        this.btnCargar.Size = new Size(162, 35);
        this.btnCargar.TabIndex = 2;
        this.btnCargar.Text = "&Recargar";
        this.btnCargar.UseVisualStyleBackColor = true;
        this.btnCargar.Click += new EventHandler(this.btnCargar_Click);

        // btnExportarExcel
        this.btnExportarExcel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        this.btnExportarExcel.Font = new Font("Segoe UI", 10F);
        this.btnExportarExcel.Location = new Point(1050, 590);
        this.btnExportarExcel.Name = "btnExportarExcel";
        this.btnExportarExcel.Size = new Size(162, 35);
        this.btnExportarExcel.TabIndex = 3;
        this.btnExportarExcel.Text = "&Exportar a Excel";
        this.btnExportarExcel.UseVisualStyleBackColor = true;
        this.btnExportarExcel.Click += new EventHandler(this.btnExportarExcel_Click);

        // lblEstado
        this.lblEstado.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.lblEstado.AutoSize = true;
        this.lblEstado.Font = new Font("Segoe UI", 9F);
        this.lblEstado.Location = new Point(12, 600);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(0, 15);
        this.lblEstado.TabIndex = 4;

        // gbxMascotas
        this.gbxMascotas.Controls.Add(this.pnlMascotasBotones);
        this.gbxMascotas.Controls.Add(this.dgvMascotas);
        this.gbxMascotas.Controls.Add(this.cmbMascotaSexo);
        this.gbxMascotas.Controls.Add(this.txtMascotaEdad);
        this.gbxMascotas.Controls.Add(this.txtMascotaRaza);
        this.gbxMascotas.Controls.Add(this.txtMascotaEspecie);
        this.gbxMascotas.Controls.Add(this.txtMascotaNombre);
        this.gbxMascotas.Controls.Add(this.txtMascotaID);
        this.gbxMascotas.Controls.Add(this.lblMascotaSexo);
        this.gbxMascotas.Controls.Add(this.lblMascotaEdad);
        this.gbxMascotas.Controls.Add(this.lblMascotaRaza);
        this.gbxMascotas.Controls.Add(this.lblMascotaEspecie);
        this.gbxMascotas.Controls.Add(this.lblMascotaNombre);
        this.gbxMascotas.Controls.Add(this.lblMascotaID);
        this.gbxMascotas.Controls.Add(this.lblMascotasEstado);
        this.gbxMascotas.Font = new Font("Segoe UI", 10F);
        this.gbxMascotas.Location = new Point(620, 12);
        this.gbxMascotas.Name = "gbxMascotas";
        this.gbxMascotas.Size = new Size(592, 568);
        this.gbxMascotas.TabIndex = 5;
        this.gbxMascotas.TabStop = false;
        this.gbxMascotas.Text = "Mascotas del Propietario";

        this.lblMascotaID.AutoSize = true;
        this.lblMascotaID.Location = new Point(15, 30);
        this.lblMascotaID.Name = "lblMascotaID";
        this.lblMascotaID.Size = new Size(25, 19);
        this.lblMascotaID.TabIndex = 0;
        this.lblMascotaID.Text = "ID:";

        this.txtMascotaID.Enabled = false;
        this.txtMascotaID.Location = new Point(50, 27);
        this.txtMascotaID.Name = "txtMascotaID";
        this.txtMascotaID.Size = new Size(100, 25);
        this.txtMascotaID.TabIndex = 1;

        this.lblMascotaNombre.AutoSize = true;
        this.lblMascotaNombre.Location = new Point(15, 65);
        this.lblMascotaNombre.Name = "lblMascotaNombre";
        this.lblMascotaNombre.Size = new Size(62, 19);
        this.lblMascotaNombre.TabIndex = 2;
        this.lblMascotaNombre.Text = "Nombre:";

        this.txtMascotaNombre.Location = new Point(85, 62);
        this.txtMascotaNombre.Name = "txtMascotaNombre";
        this.txtMascotaNombre.Size = new Size(200, 25);
        this.txtMascotaNombre.TabIndex = 3;

        this.lblMascotaEspecie.AutoSize = true;
        this.lblMascotaEspecie.Location = new Point(15, 100);
        this.lblMascotaEspecie.Name = "lblMascotaEspecie";
        this.lblMascotaEspecie.Size = new Size(60, 19);
        this.lblMascotaEspecie.TabIndex = 4;
        this.lblMascotaEspecie.Text = "Especie:";

        this.txtMascotaEspecie.Location = new Point(80, 97);
        this.txtMascotaEspecie.Name = "txtMascotaEspecie";
        this.txtMascotaEspecie.Size = new Size(200, 25);
        this.txtMascotaEspecie.TabIndex = 5;

        this.lblMascotaRaza.AutoSize = true;
        this.lblMascotaRaza.Location = new Point(300, 100);
        this.lblMascotaRaza.Name = "lblMascotaRaza";
        this.lblMascotaRaza.Size = new Size(42, 19);
        this.lblMascotaRaza.TabIndex = 6;
        this.lblMascotaRaza.Text = "Raza:";

        this.txtMascotaRaza.Location = new Point(350, 97);
        this.txtMascotaRaza.Name = "txtMascotaRaza";
        this.txtMascotaRaza.Size = new Size(200, 25);
        this.txtMascotaRaza.TabIndex = 7;

        this.lblMascotaEdad.AutoSize = true;
        this.lblMascotaEdad.Location = new Point(15, 135);
        this.lblMascotaEdad.Name = "lblMascotaEdad";
        this.lblMascotaEdad.Size = new Size(42, 19);
        this.lblMascotaEdad.TabIndex = 8;
        this.lblMascotaEdad.Text = "Edad:";

        this.txtMascotaEdad.Location = new Point(65, 132);
        this.txtMascotaEdad.Name = "txtMascotaEdad";
        this.txtMascotaEdad.Size = new Size(100, 25);
        this.txtMascotaEdad.TabIndex = 9;

        this.lblMascotaSexo.AutoSize = true;
        this.lblMascotaSexo.Location = new Point(180, 135);
        this.lblMascotaSexo.Name = "lblMascotaSexo";
        this.lblMascotaSexo.Size = new Size(42, 19);
        this.lblMascotaSexo.TabIndex = 10;
        this.lblMascotaSexo.Text = "Sexo:";

        this.cmbMascotaSexo.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbMascotaSexo.FormattingEnabled = true;
        this.cmbMascotaSexo.Items.AddRange(new object[] { "Macho", "Hembra" });
        this.cmbMascotaSexo.Location = new Point(230, 132);
        this.cmbMascotaSexo.Name = "cmbMascotaSexo";
        this.cmbMascotaSexo.Size = new Size(150, 25);
        this.cmbMascotaSexo.TabIndex = 11;

        this.pnlMascotasBotones.Controls.Add(this.btnMascotaNuevo);
        this.pnlMascotasBotones.Controls.Add(this.btnMascotaActualizar);
        this.pnlMascotasBotones.Controls.Add(this.btnMascotaEliminar);
        this.pnlMascotasBotones.Controls.Add(this.btnMascotaLimpiar);
        this.pnlMascotasBotones.Location = new Point(15, 170);
        this.pnlMascotasBotones.Name = "pnlMascotasBotones";
        this.pnlMascotasBotones.Size = new Size(560, 40);
        this.pnlMascotasBotones.TabIndex = 12;

        this.btnMascotaNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnMascotaNuevo.Location = new Point(0, 5);
        this.btnMascotaNuevo.Name = "btnMascotaNuevo";
        this.btnMascotaNuevo.Size = new Size(135, 30);
        this.btnMascotaNuevo.TabIndex = 0;
        this.btnMascotaNuevo.Text = "&Agregar";
        this.btnMascotaNuevo.UseVisualStyleBackColor = true;
        this.btnMascotaNuevo.Click += new EventHandler(this.btnMascotaNuevo_Click);

        this.btnMascotaActualizar.Font = new Font("Segoe UI", 10F);
        this.btnMascotaActualizar.Location = new Point(140, 5);
        this.btnMascotaActualizar.Name = "btnMascotaActualizar";
        this.btnMascotaActualizar.Size = new Size(135, 30);
        this.btnMascotaActualizar.TabIndex = 1;
        this.btnMascotaActualizar.Text = "&Actualizar";
        this.btnMascotaActualizar.UseVisualStyleBackColor = true;
        this.btnMascotaActualizar.Click += new EventHandler(this.btnMascotaActualizar_Click);

        this.btnMascotaEliminar.Font = new Font("Segoe UI", 10F);
        this.btnMascotaEliminar.Location = new Point(280, 5);
        this.btnMascotaEliminar.Name = "btnMascotaEliminar";
        this.btnMascotaEliminar.Size = new Size(135, 30);
        this.btnMascotaEliminar.TabIndex = 2;
        this.btnMascotaEliminar.Text = "&Eliminar";
        this.btnMascotaEliminar.UseVisualStyleBackColor = true;
        this.btnMascotaEliminar.Click += new EventHandler(this.btnMascotaEliminar_Click);

        this.btnMascotaLimpiar.Font = new Font("Segoe UI", 10F);
        this.btnMascotaLimpiar.Location = new Point(420, 5);
        this.btnMascotaLimpiar.Name = "btnMascotaLimpiar";
        this.btnMascotaLimpiar.Size = new Size(135, 30);
        this.btnMascotaLimpiar.TabIndex = 3;
        this.btnMascotaLimpiar.Text = "&Limpiar";
        this.btnMascotaLimpiar.UseVisualStyleBackColor = true;
        this.btnMascotaLimpiar.Click += new EventHandler(this.btnMascotaLimpiar_Click);

        this.dgvMascotas.AllowUserToAddRows = false;
        this.dgvMascotas.AllowUserToDeleteRows = false;
        this.dgvMascotas.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvMascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvMascotas.Location = new Point(15, 220);
        this.dgvMascotas.Name = "dgvMascotas";
        this.dgvMascotas.ReadOnly = true;
        this.dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvMascotas.Size = new Size(560, 310);
        this.dgvMascotas.TabIndex = 13;
        this.dgvMascotas.SelectionChanged += new EventHandler(this.DgvMascotas_SelectionChanged);

        this.lblMascotasEstado.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.lblMascotasEstado.AutoSize = true;
        this.lblMascotasEstado.Font = new Font("Segoe UI", 9F);
        this.lblMascotasEstado.Location = new Point(15, 540);
        this.lblMascotasEstado.Name = "lblMascotasEstado";
        this.lblMascotasEstado.Size = new Size(0, 15);
        this.lblMascotasEstado.TabIndex = 14;

        // PropietariosForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1224, 637);
        this.Controls.Add(this.gbxMascotas);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.btnExportarExcel);
        this.Controls.Add(this.btnCargar);
        this.Controls.Add(this.dgvPropietarios);
        this.Controls.Add(this.gbxDatos);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(1240, 676);
        this.Name = "PropietariosForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Gestión de Propietarios - Veterinaria Genesis";
        this.Load += new EventHandler(this.PropietariosForm_Load);
        this.gbxDatos.ResumeLayout(false);
        this.gbxDatos.PerformLayout();
        this.pnlBotones.ResumeLayout(false);
        this.gbxMascotas.ResumeLayout(false);
        this.gbxMascotas.PerformLayout();
        this.pnlMascotasBotones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvPropietarios)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

