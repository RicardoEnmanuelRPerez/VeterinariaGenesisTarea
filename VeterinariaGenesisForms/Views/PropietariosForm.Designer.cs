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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        gbxDatos = new GroupBox();
        pnlBotones = new Panel();
        btnNuevo = new Button();
        btnActualizar = new Button();
        btnEliminar = new Button();
        btnLimpiar = new Button();
        txtTelefono = new TextBox();
        txtDireccion = new TextBox();
        txtApellidos = new TextBox();
        txtNombre = new TextBox();
        txtID = new TextBox();
        lblTelefono = new Label();
        lblDireccion = new Label();
        lblApellidos = new Label();
        lblNombre = new Label();
        lblID = new Label();
        dgvPropietarios = new DataGridView();
        btnCargar = new Button();
        btnExportarExcel = new Button();
        lblEstado = new Label();
        gbxMascotas = new GroupBox();
        pnlMascotasBotones = new Panel();
        btnMascotaNuevo = new Button();
        btnMascotaActualizar = new Button();
        btnMascotaEliminar = new Button();
        btnMascotaLimpiar = new Button();
        dgvMascotas = new DataGridView();
        cmbMascotaSexo = new ComboBox();
        txtMascotaEdad = new TextBox();
        txtMascotaRaza = new TextBox();
        txtMascotaEspecie = new TextBox();
        txtMascotaNombre = new TextBox();
        txtMascotaID = new TextBox();
        lblMascotaSexo = new Label();
        lblMascotaEdad = new Label();
        lblMascotaRaza = new Label();
        lblMascotaEspecie = new Label();
        lblMascotaNombre = new Label();
        lblMascotaID = new Label();
        lblMascotasEstado = new Label();
        gbxDatos.SuspendLayout();
        pnlBotones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPropietarios).BeginInit();
        gbxMascotas.SuspendLayout();
        pnlMascotasBotones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMascotas).BeginInit();
        SuspendLayout();
        // 
        // gbxDatos
        // 
        gbxDatos.Controls.Add(pnlBotones);
        gbxDatos.Controls.Add(txtTelefono);
        gbxDatos.Controls.Add(txtDireccion);
        gbxDatos.Controls.Add(txtApellidos);
        gbxDatos.Controls.Add(txtNombre);
        gbxDatos.Controls.Add(txtID);
        gbxDatos.Controls.Add(lblTelefono);
        gbxDatos.Controls.Add(lblDireccion);
        gbxDatos.Controls.Add(lblApellidos);
        gbxDatos.Controls.Add(lblNombre);
        gbxDatos.Controls.Add(lblID);
        gbxDatos.Font = new Font("Segoe UI", 10F);
        gbxDatos.Location = new Point(60, 65);
        gbxDatos.Margin = new Padding(3, 4, 3, 4);
        gbxDatos.Name = "gbxDatos";
        gbxDatos.Padding = new Padding(3, 4, 3, 4);
        gbxDatos.Size = new Size(686, 333);
        gbxDatos.TabIndex = 0;
        gbxDatos.TabStop = false;
        gbxDatos.Text = "Datos del Propietario";
        // 
        // pnlBotones
        // 
        pnlBotones.Controls.Add(btnNuevo);
        pnlBotones.Controls.Add(btnActualizar);
        pnlBotones.Controls.Add(btnEliminar);
        pnlBotones.Controls.Add(btnLimpiar);
        pnlBotones.Location = new Point(17, 227);
        pnlBotones.Margin = new Padding(3, 4, 3, 4);
        pnlBotones.Name = "pnlBotones";
        pnlBotones.Size = new Size(640, 93);
        pnlBotones.TabIndex = 10;
        // 
        // btnNuevo
        // 
        btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnNuevo.Location = new Point(0, 7);
        btnNuevo.Margin = new Padding(3, 4, 3, 4);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(149, 40);
        btnNuevo.TabIndex = 0;
        btnNuevo.Text = "&Nuevo / Guardar";
        btnNuevo.UseVisualStyleBackColor = true;
        btnNuevo.Click += btnNuevo_Click;
        // 
        // btnActualizar
        // 
        btnActualizar.Font = new Font("Segoe UI", 10F);
        btnActualizar.Location = new Point(160, 7);
        btnActualizar.Margin = new Padding(3, 4, 3, 4);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new Size(149, 40);
        btnActualizar.TabIndex = 1;
        btnActualizar.Text = "&Actualizar";
        btnActualizar.UseVisualStyleBackColor = true;
        btnActualizar.Click += btnActualizar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.Font = new Font("Segoe UI", 10F);
        btnEliminar.Location = new Point(320, 7);
        btnEliminar.Margin = new Padding(3, 4, 3, 4);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(149, 40);
        btnEliminar.TabIndex = 2;
        btnEliminar.Text = "&Desactivar";
        btnEliminar.UseVisualStyleBackColor = true;
        btnEliminar.Click += btnEliminar_Click;
        // 
        // btnLimpiar
        // 
        btnLimpiar.Font = new Font("Segoe UI", 10F);
        btnLimpiar.Location = new Point(480, 7);
        btnLimpiar.Margin = new Padding(3, 4, 3, 4);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(149, 40);
        btnLimpiar.TabIndex = 3;
        btnLimpiar.Text = "&Limpiar";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // txtTelefono
        // 
        txtTelefono.Location = new Point(97, 176);
        txtTelefono.Margin = new Padding(3, 4, 3, 4);
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(228, 30);
        txtTelefono.TabIndex = 9;
        // 
        // txtDireccion
        // 
        txtDireccion.Location = new Point(103, 129);
        txtDireccion.Margin = new Padding(3, 4, 3, 4);
        txtDireccion.Name = "txtDireccion";
        txtDireccion.Size = new Size(554, 30);
        txtDireccion.TabIndex = 7;
        // 
        // txtApellidos
        // 
        txtApellidos.Location = new Point(429, 83);
        txtApellidos.Margin = new Padding(3, 4, 3, 4);
        txtApellidos.Name = "txtApellidos";
        txtApellidos.Size = new Size(228, 30);
        txtApellidos.TabIndex = 5;
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(97, 83);
        txtNombre.Margin = new Padding(3, 4, 3, 4);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(228, 30);
        txtNombre.TabIndex = 3;
        // 
        // txtID
        // 
        txtID.Enabled = false;
        txtID.Location = new Point(57, 36);
        txtID.Margin = new Padding(3, 4, 3, 4);
        txtID.Name = "txtID";
        txtID.Size = new Size(114, 30);
        txtID.TabIndex = 1;
        // 
        // lblTelefono
        // 
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(17, 180);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(78, 23);
        lblTelefono.TabIndex = 8;
        lblTelefono.Text = "Teléfono:";
        // 
        // lblDireccion
        // 
        lblDireccion.AutoSize = true;
        lblDireccion.Location = new Point(17, 133);
        lblDireccion.Name = "lblDireccion";
        lblDireccion.Size = new Size(85, 23);
        lblDireccion.TabIndex = 6;
        lblDireccion.Text = "Dirección:";
        // 
        // lblApellidos
        // 
        lblApellidos.AutoSize = true;
        lblApellidos.Location = new Point(343, 87);
        lblApellidos.Name = "lblApellidos";
        lblApellidos.Size = new Size(83, 23);
        lblApellidos.TabIndex = 4;
        lblApellidos.Text = "Apellidos:";
        // 
        // lblNombre
        // 
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(17, 87);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(77, 23);
        lblNombre.TabIndex = 2;
        lblNombre.Text = "Nombre:";
        // 
        // lblID
        // 
        lblID.AutoSize = true;
        lblID.Location = new Point(17, 40);
        lblID.Name = "lblID";
        lblID.Size = new Size(31, 23);
        lblID.TabIndex = 0;
        lblID.Text = "ID:";
        // 
        // dgvPropietarios
        // 
        dgvPropietarios.AllowUserToAddRows = false;
        dgvPropietarios.AllowUserToDeleteRows = false;
        dgvPropietarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        dgvPropietarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvPropietarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvPropietarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvPropietarios.DefaultCellStyle = dataGridViewCellStyle2;
        dgvPropietarios.Location = new Point(60, 392);
        dgvPropietarios.Margin = new Padding(3, 4, 3, 4);
        dgvPropietarios.Name = "dgvPropietarios";
        dgvPropietarios.ReadOnly = true;
        dgvPropietarios.RowHeadersWidth = 51;
        dgvPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPropietarios.Size = new Size(686, 332);
        dgvPropietarios.TabIndex = 1;
        // 
        // btnCargar
        // 
        btnCargar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCargar.Font = new Font("Segoe UI", 10F);
        btnCargar.Location = new Point(1465, 65);
        btnCargar.Margin = new Padding(3, 4, 3, 4);
        btnCargar.Name = "btnCargar";
        btnCargar.Size = new Size(185, 47);
        btnCargar.TabIndex = 2;
        btnCargar.Text = "&Recargar";
        btnCargar.UseVisualStyleBackColor = true;
        btnCargar.Click += btnCargar_Click;
        // 
        // btnExportarExcel
        // 
        btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnExportarExcel.Font = new Font("Segoe UI", 10F);
        btnExportarExcel.Location = new Point(1455, 661);
        btnExportarExcel.Margin = new Padding(3, 4, 3, 4);
        btnExportarExcel.Name = "btnExportarExcel";
        btnExportarExcel.Size = new Size(185, 47);
        btnExportarExcel.TabIndex = 3;
        btnExportarExcel.Text = "&Exportar a Excel";
        btnExportarExcel.UseVisualStyleBackColor = true;
        btnExportarExcel.Click += btnExportarExcel_Click;
        // 
        // lblEstado
        // 
        lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblEstado.AutoSize = true;
        lblEstado.Font = new Font("Segoe UI", 9F);
        lblEstado.Location = new Point(14, 800);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(0, 20);
        lblEstado.TabIndex = 4;
        // 
        // gbxMascotas
        // 
        gbxMascotas.Controls.Add(pnlMascotasBotones);
        gbxMascotas.Controls.Add(dgvMascotas);
        gbxMascotas.Controls.Add(cmbMascotaSexo);
        gbxMascotas.Controls.Add(txtMascotaEdad);
        gbxMascotas.Controls.Add(txtMascotaRaza);
        gbxMascotas.Controls.Add(txtMascotaEspecie);
        gbxMascotas.Controls.Add(txtMascotaNombre);
        gbxMascotas.Controls.Add(txtMascotaID);
        gbxMascotas.Controls.Add(lblMascotaSexo);
        gbxMascotas.Controls.Add(lblMascotaEdad);
        gbxMascotas.Controls.Add(lblMascotaRaza);
        gbxMascotas.Controls.Add(lblMascotaEspecie);
        gbxMascotas.Controls.Add(lblMascotaNombre);
        gbxMascotas.Controls.Add(lblMascotaID);
        gbxMascotas.Controls.Add(lblMascotasEstado);
        gbxMascotas.Font = new Font("Segoe UI", 10F);
        gbxMascotas.Location = new Point(772, 44);
        gbxMascotas.Margin = new Padding(3, 4, 3, 4);
        gbxMascotas.Name = "gbxMascotas";
        gbxMascotas.Padding = new Padding(3, 4, 3, 4);
        gbxMascotas.Size = new Size(677, 757);
        gbxMascotas.TabIndex = 5;
        gbxMascotas.TabStop = false;
        gbxMascotas.Text = "Mascotas del Propietario";
        // 
        // pnlMascotasBotones
        // 
        pnlMascotasBotones.Controls.Add(btnMascotaNuevo);
        pnlMascotasBotones.Controls.Add(btnMascotaActualizar);
        pnlMascotasBotones.Controls.Add(btnMascotaEliminar);
        pnlMascotasBotones.Controls.Add(btnMascotaLimpiar);
        pnlMascotasBotones.Location = new Point(17, 227);
        pnlMascotasBotones.Margin = new Padding(3, 4, 3, 4);
        pnlMascotasBotones.Name = "pnlMascotasBotones";
        pnlMascotasBotones.Size = new Size(640, 53);
        pnlMascotasBotones.TabIndex = 12;
        // 
        // btnMascotaNuevo
        // 
        btnMascotaNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnMascotaNuevo.Location = new Point(0, 7);
        btnMascotaNuevo.Margin = new Padding(3, 4, 3, 4);
        btnMascotaNuevo.Name = "btnMascotaNuevo";
        btnMascotaNuevo.Size = new Size(154, 40);
        btnMascotaNuevo.TabIndex = 0;
        btnMascotaNuevo.Text = "&Agregar";
        btnMascotaNuevo.UseVisualStyleBackColor = true;
        btnMascotaNuevo.Click += btnMascotaNuevo_Click;
        // 
        // btnMascotaActualizar
        // 
        btnMascotaActualizar.Font = new Font("Segoe UI", 10F);
        btnMascotaActualizar.Location = new Point(160, 7);
        btnMascotaActualizar.Margin = new Padding(3, 4, 3, 4);
        btnMascotaActualizar.Name = "btnMascotaActualizar";
        btnMascotaActualizar.Size = new Size(154, 40);
        btnMascotaActualizar.TabIndex = 1;
        btnMascotaActualizar.Text = "&Actualizar";
        btnMascotaActualizar.UseVisualStyleBackColor = true;
        btnMascotaActualizar.Click += btnMascotaActualizar_Click;
        // 
        // btnMascotaEliminar
        // 
        btnMascotaEliminar.Font = new Font("Segoe UI", 10F);
        btnMascotaEliminar.Location = new Point(320, 7);
        btnMascotaEliminar.Margin = new Padding(3, 4, 3, 4);
        btnMascotaEliminar.Name = "btnMascotaEliminar";
        btnMascotaEliminar.Size = new Size(154, 40);
        btnMascotaEliminar.TabIndex = 2;
        btnMascotaEliminar.Text = "&Eliminar";
        btnMascotaEliminar.UseVisualStyleBackColor = true;
        btnMascotaEliminar.Click += btnMascotaEliminar_Click;
        // 
        // btnMascotaLimpiar
        // 
        btnMascotaLimpiar.Font = new Font("Segoe UI", 10F);
        btnMascotaLimpiar.Location = new Point(480, 7);
        btnMascotaLimpiar.Margin = new Padding(3, 4, 3, 4);
        btnMascotaLimpiar.Name = "btnMascotaLimpiar";
        btnMascotaLimpiar.Size = new Size(154, 40);
        btnMascotaLimpiar.TabIndex = 3;
        btnMascotaLimpiar.Text = "&Limpiar";
        btnMascotaLimpiar.UseVisualStyleBackColor = true;
        btnMascotaLimpiar.Click += btnMascotaLimpiar_Click;
        // 
        // dgvMascotas
        // 
        dgvMascotas.AllowUserToAddRows = false;
        dgvMascotas.AllowUserToDeleteRows = false;
        dgvMascotas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvMascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvMascotas.Location = new Point(17, 303);
        dgvMascotas.Margin = new Padding(3, 4, 3, 4);
        dgvMascotas.Name = "dgvMascotas";
        dgvMascotas.ReadOnly = true;
        dgvMascotas.RowHeadersWidth = 51;
        dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMascotas.Size = new Size(640, 413);
        dgvMascotas.TabIndex = 13;
        dgvMascotas.SelectionChanged += DgvMascotas_SelectionChanged;
        // 
        // cmbMascotaSexo
        // 
        cmbMascotaSexo.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMascotaSexo.FormattingEnabled = true;
        cmbMascotaSexo.Items.AddRange(new object[] { "Macho", "Hembra" });
        cmbMascotaSexo.Location = new Point(263, 176);
        cmbMascotaSexo.Margin = new Padding(3, 4, 3, 4);
        cmbMascotaSexo.Name = "cmbMascotaSexo";
        cmbMascotaSexo.Size = new Size(171, 31);
        cmbMascotaSexo.TabIndex = 11;
        // 
        // txtMascotaEdad
        // 
        txtMascotaEdad.Location = new Point(74, 176);
        txtMascotaEdad.Margin = new Padding(3, 4, 3, 4);
        txtMascotaEdad.Name = "txtMascotaEdad";
        txtMascotaEdad.Size = new Size(114, 30);
        txtMascotaEdad.TabIndex = 9;
        // 
        // txtMascotaRaza
        // 
        txtMascotaRaza.Location = new Point(400, 129);
        txtMascotaRaza.Margin = new Padding(3, 4, 3, 4);
        txtMascotaRaza.Name = "txtMascotaRaza";
        txtMascotaRaza.Size = new Size(228, 30);
        txtMascotaRaza.TabIndex = 7;
        // 
        // txtMascotaEspecie
        // 
        txtMascotaEspecie.Location = new Point(91, 129);
        txtMascotaEspecie.Margin = new Padding(3, 4, 3, 4);
        txtMascotaEspecie.Name = "txtMascotaEspecie";
        txtMascotaEspecie.Size = new Size(228, 30);
        txtMascotaEspecie.TabIndex = 5;
        // 
        // txtMascotaNombre
        // 
        txtMascotaNombre.Location = new Point(97, 83);
        txtMascotaNombre.Margin = new Padding(3, 4, 3, 4);
        txtMascotaNombre.Name = "txtMascotaNombre";
        txtMascotaNombre.Size = new Size(228, 30);
        txtMascotaNombre.TabIndex = 3;
        // 
        // txtMascotaID
        // 
        txtMascotaID.Enabled = false;
        txtMascotaID.Location = new Point(57, 36);
        txtMascotaID.Margin = new Padding(3, 4, 3, 4);
        txtMascotaID.Name = "txtMascotaID";
        txtMascotaID.Size = new Size(114, 30);
        txtMascotaID.TabIndex = 1;
        // 
        // lblMascotaSexo
        // 
        lblMascotaSexo.AutoSize = true;
        lblMascotaSexo.Location = new Point(206, 180);
        lblMascotaSexo.Name = "lblMascotaSexo";
        lblMascotaSexo.Size = new Size(50, 23);
        lblMascotaSexo.TabIndex = 10;
        lblMascotaSexo.Text = "Sexo:";
        // 
        // lblMascotaEdad
        // 
        lblMascotaEdad.AutoSize = true;
        lblMascotaEdad.Location = new Point(17, 180);
        lblMascotaEdad.Name = "lblMascotaEdad";
        lblMascotaEdad.Size = new Size(52, 23);
        lblMascotaEdad.TabIndex = 8;
        lblMascotaEdad.Text = "Edad:";
        // 
        // lblMascotaRaza
        // 
        lblMascotaRaza.AutoSize = true;
        lblMascotaRaza.Location = new Point(343, 133);
        lblMascotaRaza.Name = "lblMascotaRaza";
        lblMascotaRaza.Size = new Size(50, 23);
        lblMascotaRaza.TabIndex = 6;
        lblMascotaRaza.Text = "Raza:";
        // 
        // lblMascotaEspecie
        // 
        lblMascotaEspecie.AutoSize = true;
        lblMascotaEspecie.Location = new Point(17, 133);
        lblMascotaEspecie.Name = "lblMascotaEspecie";
        lblMascotaEspecie.Size = new Size(70, 23);
        lblMascotaEspecie.TabIndex = 4;
        lblMascotaEspecie.Text = "Especie:";
        // 
        // lblMascotaNombre
        // 
        lblMascotaNombre.AutoSize = true;
        lblMascotaNombre.Location = new Point(17, 87);
        lblMascotaNombre.Name = "lblMascotaNombre";
        lblMascotaNombre.Size = new Size(77, 23);
        lblMascotaNombre.TabIndex = 2;
        lblMascotaNombre.Text = "Nombre:";
        // 
        // lblMascotaID
        // 
        lblMascotaID.AutoSize = true;
        lblMascotaID.Location = new Point(17, 40);
        lblMascotaID.Name = "lblMascotaID";
        lblMascotaID.Size = new Size(31, 23);
        lblMascotaID.TabIndex = 0;
        lblMascotaID.Text = "ID:";
        // 
        // lblMascotasEstado
        // 
        lblMascotasEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblMascotasEstado.AutoSize = true;
        lblMascotasEstado.Font = new Font("Segoe UI", 9F);
        lblMascotasEstado.Location = new Point(17, 720);
        lblMascotasEstado.Name = "lblMascotasEstado";
        lblMascotasEstado.Size = new Size(0, 20);
        lblMascotasEstado.TabIndex = 14;
        // 
        // PropietariosForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1664, 849);
        Controls.Add(gbxMascotas);
        Controls.Add(lblEstado);
        Controls.Add(btnExportarExcel);
        Controls.Add(btnCargar);
        Controls.Add(dgvPropietarios);
        Controls.Add(gbxDatos);
        Font = new Font("Segoe UI", 9F);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(1415, 886);
        Name = "PropietariosForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestión de Propietarios - Veterinaria Genesis";
        Load += PropietariosForm_Load;
        gbxDatos.ResumeLayout(false);
        gbxDatos.PerformLayout();
        pnlBotones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvPropietarios).EndInit();
        gbxMascotas.ResumeLayout(false);
        gbxMascotas.PerformLayout();
        pnlMascotasBotones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvMascotas).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

