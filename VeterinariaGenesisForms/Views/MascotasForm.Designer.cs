#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class MascotasForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxFiltro = null!;
    private Label lblBuscarPropietario = null!;
    private TextBox txtBuscarPropietario = null!;
    private DataGridView dgvPropietarios = null!;
    private Button btnCargar = null!;
    private GroupBox gbxDatos = null!;
    private Label lblID = null!;
    private Label lblNombre = null!;
    private Label lblEspecie = null!;
    private Label lblRaza = null!;
    private Label lblEdad = null!;
    private Label lblSexo = null!;
    private TextBox txtID = null!;
    private TextBox txtNombre = null!;
    private TextBox txtEspecie = null!;
    private TextBox txtRaza = null!;
    private TextBox txtEdad = null!;
    private ComboBox cmbSexo = null!;
    private Button btnNuevo = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnLimpiar = null!;
    private DataGridView dgvMascotas = null!;
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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        gbxFiltro = new GroupBox();
        lblBuscarPropietario = new Label();
        txtBuscarPropietario = new TextBox();
        dgvPropietarios = new DataGridView();
        btnCargar = new Button();
        gbxDatos = new GroupBox();
        btnLimpiar = new Button();
        btnEliminar = new Button();
        btnActualizar = new Button();
        btnNuevo = new Button();
        cmbSexo = new ComboBox();
        txtEdad = new TextBox();
        txtRaza = new TextBox();
        txtEspecie = new TextBox();
        txtNombre = new TextBox();
        txtID = new TextBox();
        lblSexo = new Label();
        lblEdad = new Label();
        lblRaza = new Label();
        lblEspecie = new Label();
        lblNombre = new Label();
        lblID = new Label();
        dgvMascotas = new DataGridView();
        btnExportarExcel = new Button();
        lblEstado = new Label();
        gbxFiltro.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPropietarios).BeginInit();
        gbxDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMascotas).BeginInit();
        SuspendLayout();
        // 
        // gbxFiltro
        // 
        gbxFiltro.Controls.Add(lblBuscarPropietario);
        gbxFiltro.Controls.Add(txtBuscarPropietario);
        gbxFiltro.Controls.Add(dgvPropietarios);
        gbxFiltro.Controls.Add(btnCargar);
        gbxFiltro.Font = new Font("Segoe UI", 10F);
        gbxFiltro.Location = new Point(14, 16);
        gbxFiltro.Margin = new Padding(3, 4, 3, 4);
        gbxFiltro.Name = "gbxFiltro";
        gbxFiltro.Padding = new Padding(3, 4, 3, 4);
        gbxFiltro.Size = new Size(1371, 281);
        gbxFiltro.TabIndex = 0;
        gbxFiltro.TabStop = false;
        gbxFiltro.Text = "Seleccionar Propietario";
        // 
        // lblBuscarPropietario
        // 
        lblBuscarPropietario.AutoSize = true;
        lblBuscarPropietario.Location = new Point(17, 40);
        lblBuscarPropietario.Name = "lblBuscarPropietario";
        lblBuscarPropietario.Size = new Size(163, 23);
        lblBuscarPropietario.TabIndex = 0;
        lblBuscarPropietario.Text = "Buscar por Nombre:";
        // 
        // txtBuscarPropietario
        // 
        txtBuscarPropietario.Location = new Point(229, 36);
        txtBuscarPropietario.Margin = new Padding(3, 4, 3, 4);
        txtBuscarPropietario.Name = "txtBuscarPropietario";
        txtBuscarPropietario.Size = new Size(457, 30);
        txtBuscarPropietario.TabIndex = 1;
        txtBuscarPropietario.TextChanged += TxtBuscarPropietario_TextChanged;
        // 
        // dgvPropietarios
        // 
        dgvPropietarios.AllowUserToAddRows = false;
        dgvPropietarios.AllowUserToDeleteRows = false;
        dgvPropietarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvPropietarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPropietarios.Location = new Point(17, 93);
        dgvPropietarios.Margin = new Padding(3, 4, 3, 4);
        dgvPropietarios.MultiSelect = false;
        dgvPropietarios.Name = "dgvPropietarios";
        dgvPropietarios.ReadOnly = true;
        dgvPropietarios.RowHeadersWidth = 51;
        dgvPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPropietarios.Size = new Size(1337, 164);
        dgvPropietarios.TabIndex = 2;
        dgvPropietarios.SelectionChanged += DgvPropietarios_SelectionChanged;
        // 
        // btnCargar
        // 
        btnCargar.Font = new Font("Segoe UI", 10F);
        btnCargar.Location = new Point(709, 33);
        btnCargar.Margin = new Padding(3, 4, 3, 4);
        btnCargar.Name = "btnCargar";
        btnCargar.Size = new Size(171, 40);
        btnCargar.TabIndex = 3;
        btnCargar.Text = "&Cargar Mascotas";
        btnCargar.UseVisualStyleBackColor = true;
        btnCargar.Click += btnCargar_Click;
        // 
        // gbxDatos
        // 
        gbxDatos.Controls.Add(btnLimpiar);
        gbxDatos.Controls.Add(btnEliminar);
        gbxDatos.Controls.Add(btnActualizar);
        gbxDatos.Controls.Add(btnNuevo);
        gbxDatos.Controls.Add(cmbSexo);
        gbxDatos.Controls.Add(txtEdad);
        gbxDatos.Controls.Add(txtRaza);
        gbxDatos.Controls.Add(txtEspecie);
        gbxDatos.Controls.Add(txtNombre);
        gbxDatos.Controls.Add(txtID);
        gbxDatos.Controls.Add(lblSexo);
        gbxDatos.Controls.Add(lblEdad);
        gbxDatos.Controls.Add(lblRaza);
        gbxDatos.Controls.Add(lblEspecie);
        gbxDatos.Controls.Add(lblNombre);
        gbxDatos.Controls.Add(lblID);
        gbxDatos.Font = new Font("Segoe UI", 10F);
        gbxDatos.Location = new Point(31, 305);
        gbxDatos.Margin = new Padding(3, 4, 3, 4);
        gbxDatos.Name = "gbxDatos";
        gbxDatos.Padding = new Padding(3, 4, 3, 4);
        gbxDatos.Size = new Size(686, 267);
        gbxDatos.TabIndex = 1;
        gbxDatos.TabStop = false;
        gbxDatos.Text = "Datos de la Mascota";
        // 
        // btnLimpiar
        // 
        btnLimpiar.Font = new Font("Segoe UI", 10F);
        btnLimpiar.Location = new Point(497, 187);
        btnLimpiar.Margin = new Padding(3, 4, 3, 4);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(149, 40);
        btnLimpiar.TabIndex = 15;
        btnLimpiar.Text = "&Limpiar";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.Font = new Font("Segoe UI", 10F);
        btnEliminar.Location = new Point(337, 187);
        btnEliminar.Margin = new Padding(3, 4, 3, 4);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(149, 40);
        btnEliminar.TabIndex = 14;
        btnEliminar.Text = "&Eliminar";
        btnEliminar.UseVisualStyleBackColor = true;
        btnEliminar.Click += btnEliminar_Click;
        // 
        // btnActualizar
        // 
        btnActualizar.Font = new Font("Segoe UI", 10F);
        btnActualizar.Location = new Point(177, 187);
        btnActualizar.Margin = new Padding(3, 4, 3, 4);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new Size(149, 40);
        btnActualizar.TabIndex = 13;
        btnActualizar.Text = "&Actualizar";
        btnActualizar.UseVisualStyleBackColor = true;
        btnActualizar.Click += btnActualizar_Click;
        // 
        // btnNuevo
        // 
        btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnNuevo.Location = new Point(17, 187);
        btnNuevo.Margin = new Padding(3, 4, 3, 4);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(149, 40);
        btnNuevo.TabIndex = 12;
        btnNuevo.Text = "&Nuevo";
        btnNuevo.UseVisualStyleBackColor = true;
        btnNuevo.Click += btnNuevo_Click;
        // 
        // cmbSexo
        // 
        cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSexo.Font = new Font("Segoe UI", 10F);
        cmbSexo.FormattingEnabled = true;
        cmbSexo.Items.AddRange(new object[] { "Macho", "Hembra" });
        cmbSexo.Location = new Point(571, 129);
        cmbSexo.Margin = new Padding(3, 4, 3, 4);
        cmbSexo.Name = "cmbSexo";
        cmbSexo.Size = new Size(91, 31);
        cmbSexo.TabIndex = 11;
        // 
        // txtEdad
        // 
        txtEdad.Location = new Point(377, 129);
        txtEdad.Margin = new Padding(3, 4, 3, 4);
        txtEdad.Name = "txtEdad";
        txtEdad.Size = new Size(114, 30);
        txtEdad.TabIndex = 9;
        // 
        // txtRaza
        // 
        txtRaza.Location = new Point(74, 129);
        txtRaza.Margin = new Padding(3, 4, 3, 4);
        txtRaza.Name = "txtRaza";
        txtRaza.Size = new Size(228, 30);
        txtRaza.TabIndex = 7;
        // 
        // txtEspecie
        // 
        txtEspecie.Location = new Point(417, 83);
        txtEspecie.Margin = new Padding(3, 4, 3, 4);
        txtEspecie.Name = "txtEspecie";
        txtEspecie.Size = new Size(228, 30);
        txtEspecie.TabIndex = 5;
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
        // lblSexo
        // 
        lblSexo.AutoSize = true;
        lblSexo.Location = new Point(514, 133);
        lblSexo.Name = "lblSexo";
        lblSexo.Size = new Size(50, 23);
        lblSexo.TabIndex = 10;
        lblSexo.Text = "Sexo:";
        // 
        // lblEdad
        // 
        lblEdad.AutoSize = true;
        lblEdad.Location = new Point(320, 133);
        lblEdad.Name = "lblEdad";
        lblEdad.Size = new Size(52, 23);
        lblEdad.TabIndex = 8;
        lblEdad.Text = "Edad:";
        // 
        // lblRaza
        // 
        lblRaza.AutoSize = true;
        lblRaza.Location = new Point(17, 133);
        lblRaza.Name = "lblRaza";
        lblRaza.Size = new Size(50, 23);
        lblRaza.TabIndex = 6;
        lblRaza.Text = "Raza:";
        // 
        // lblEspecie
        // 
        lblEspecie.AutoSize = true;
        lblEspecie.Location = new Point(343, 87);
        lblEspecie.Name = "lblEspecie";
        lblEspecie.Size = new Size(70, 23);
        lblEspecie.TabIndex = 4;
        lblEspecie.Text = "Especie:";
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
        // dgvMascotas
        // 
        dgvMascotas.AllowUserToAddRows = false;
        dgvMascotas.AllowUserToDeleteRows = false;
        dgvMascotas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvMascotas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvMascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvMascotas.DefaultCellStyle = dataGridViewCellStyle2;
        dgvMascotas.Location = new Point(20, 591);
        dgvMascotas.Margin = new Padding(3, 4, 3, 4);
        dgvMascotas.Name = "dgvMascotas";
        dgvMascotas.ReadOnly = true;
        dgvMascotas.RowHeadersWidth = 51;
        dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMascotas.Size = new Size(1371, 400);
        dgvMascotas.TabIndex = 2;
        // 
        // btnExportarExcel
        // 
        btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnExportarExcel.Font = new Font("Segoe UI", 10F);
        btnExportarExcel.Location = new Point(1200, 827);
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
        lblEstado.Location = new Point(14, 840);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(0, 20);
        lblEstado.TabIndex = 4;
        // 
        // MascotasForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1399, 889);
        Controls.Add(lblEstado);
        Controls.Add(btnExportarExcel);
        Controls.Add(dgvMascotas);
        Controls.Add(gbxDatos);
        Controls.Add(gbxFiltro);
        Font = new Font("Segoe UI", 9F);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(1415, 926);
        Name = "MascotasForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestión de Mascotas - Veterinaria Genesis";
        Load += MascotasForm_Load;
        gbxFiltro.ResumeLayout(false);
        gbxFiltro.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvPropietarios).EndInit();
        gbxDatos.ResumeLayout(false);
        gbxDatos.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMascotas).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

