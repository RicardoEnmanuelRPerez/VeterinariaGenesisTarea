#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class ServiciosForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxDatos = null!;
    private Label lblID = null!;
    private Label lblNombre = null!;
    private Label lblDescripcion = null!;
    private Label lblCosto = null!;
    private TextBox txtID = null!;
    private TextBox txtNombre = null!;
    private TextBox txtDescripcion = null!;
    private TextBox txtCosto = null!;
    private Button btnNuevo = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnLimpiar = null!;
    private DataGridView dgvServicios = null!;
    private Button btnCargar = null!;
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
        gbxDatos = new GroupBox();
        btnLimpiar = new Button();
        btnEliminar = new Button();
        btnActualizar = new Button();
        btnNuevo = new Button();
        txtCosto = new TextBox();
        txtDescripcion = new TextBox();
        txtNombre = new TextBox();
        txtID = new TextBox();
        lblCosto = new Label();
        lblDescripcion = new Label();
        lblNombre = new Label();
        lblID = new Label();
        dgvServicios = new DataGridView();
        btnCargar = new Button();
        btnExportarExcel = new Button();
        lblEstado = new Label();
        gbxDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvServicios).BeginInit();
        SuspendLayout();
        // 
        // gbxDatos
        // 
        gbxDatos.Controls.Add(btnLimpiar);
        gbxDatos.Controls.Add(btnEliminar);
        gbxDatos.Controls.Add(btnActualizar);
        gbxDatos.Controls.Add(btnNuevo);
        gbxDatos.Controls.Add(txtCosto);
        gbxDatos.Controls.Add(txtDescripcion);
        gbxDatos.Controls.Add(txtNombre);
        gbxDatos.Controls.Add(txtID);
        gbxDatos.Controls.Add(lblCosto);
        gbxDatos.Controls.Add(lblDescripcion);
        gbxDatos.Controls.Add(lblNombre);
        gbxDatos.Controls.Add(lblID);
        gbxDatos.Font = new Font("Segoe UI", 10F);
        gbxDatos.Location = new Point(14, 16);
        gbxDatos.Margin = new Padding(3, 4, 3, 4);
        gbxDatos.Name = "gbxDatos";
        gbxDatos.Padding = new Padding(3, 4, 3, 4);
        gbxDatos.Size = new Size(686, 267);
        gbxDatos.TabIndex = 0;
        gbxDatos.TabStop = false;
        gbxDatos.Text = "Datos del Servicio";
        // 
        // btnLimpiar
        // 
        btnLimpiar.Font = new Font("Segoe UI", 10F);
        btnLimpiar.Location = new Point(17, 220);
        btnLimpiar.Margin = new Padding(3, 4, 3, 4);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(114, 40);
        btnLimpiar.TabIndex = 11;
        btnLimpiar.Text = "&Limpiar";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.Font = new Font("Segoe UI", 10F);
        btnEliminar.Location = new Point(526, 173);
        btnEliminar.Margin = new Padding(3, 4, 3, 4);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(114, 40);
        btnEliminar.TabIndex = 10;
        btnEliminar.Text = "&Eliminar";
        btnEliminar.UseVisualStyleBackColor = true;
        btnEliminar.Click += btnEliminar_Click;
        // 
        // btnActualizar
        // 
        btnActualizar.Font = new Font("Segoe UI", 10F);
        btnActualizar.Location = new Point(400, 173);
        btnActualizar.Margin = new Padding(3, 4, 3, 4);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new Size(114, 40);
        btnActualizar.TabIndex = 9;
        btnActualizar.Text = "&Actualizar";
        btnActualizar.UseVisualStyleBackColor = true;
        btnActualizar.Click += btnActualizar_Click;
        // 
        // btnNuevo
        // 
        btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnNuevo.Location = new Point(274, 173);
        btnNuevo.Margin = new Padding(3, 4, 3, 4);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(114, 40);
        btnNuevo.TabIndex = 8;
        btnNuevo.Text = "&Nuevo";
        btnNuevo.UseVisualStyleBackColor = true;
        btnNuevo.Click += btnNuevo_Click;
        // 
        // txtCosto
        // 
        txtCosto.Location = new Point(80, 176);
        txtCosto.Margin = new Padding(3, 4, 3, 4);
        txtCosto.Name = "txtCosto";
        txtCosto.Size = new Size(171, 30);
        txtCosto.TabIndex = 7;
        // 
        // txtDescripcion
        // 
        txtDescripcion.Location = new Point(114, 83);
        txtDescripcion.Margin = new Padding(3, 4, 3, 4);
        txtDescripcion.Multiline = true;
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.Size = new Size(548, 79);
        txtDescripcion.TabIndex = 5;
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(274, 36);
        txtNombre.Margin = new Padding(3, 4, 3, 4);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(388, 30);
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
        // lblCosto
        // 
        lblCosto.AutoSize = true;
        lblCosto.Location = new Point(17, 180);
        lblCosto.Name = "lblCosto";
        lblCosto.Size = new Size(58, 23);
        lblCosto.TabIndex = 6;
        lblCosto.Text = "Costo:";
        // 
        // lblDescripcion
        // 
        lblDescripcion.AutoSize = true;
        lblDescripcion.Location = new Point(17, 87);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(102, 23);
        lblDescripcion.TabIndex = 4;
        lblDescripcion.Text = "Descripción:";
        // 
        // lblNombre
        // 
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(194, 40);
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
        // dgvServicios
        // 
        dgvServicios.AllowUserToAddRows = false;
        dgvServicios.AllowUserToDeleteRows = false;
        dgvServicios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Control;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvServicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvServicios.DefaultCellStyle = dataGridViewCellStyle2;
        dgvServicios.Location = new Point(720, 31);
        dgvServicios.Margin = new Padding(3, 4, 3, 4);
        dgvServicios.Name = "dgvServicios";
        dgvServicios.ReadOnly = true;
        dgvServicios.RowHeadersWidth = 51;
        dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvServicios.Size = new Size(665, 575);
        dgvServicios.TabIndex = 1;
        // 
        // btnCargar
        // 
        btnCargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnCargar.Font = new Font("Segoe UI", 10F);
        btnCargar.Location = new Point(14, 601);
        btnCargar.Margin = new Padding(3, 4, 3, 4);
        btnCargar.Name = "btnCargar";
        btnCargar.Size = new Size(171, 47);
        btnCargar.TabIndex = 2;
        btnCargar.Text = "&Cargar Servicios";
        btnCargar.UseVisualStyleBackColor = true;
        btnCargar.Click += btnCargar_Click;
        // 
        // btnExportarExcel
        // 
        btnExportarExcel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnExportarExcel.Font = new Font("Segoe UI", 10F);
        btnExportarExcel.Location = new Point(1202, 614);
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
        lblEstado.Location = new Point(206, 614);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(0, 20);
        lblEstado.TabIndex = 4;
        // 
        // ServiciosForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1399, 664);
        Controls.Add(lblEstado);
        Controls.Add(btnExportarExcel);
        Controls.Add(btnCargar);
        Controls.Add(dgvServicios);
        Controls.Add(gbxDatos);
        Font = new Font("Segoe UI", 9F);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(1415, 659);
        Name = "ServiciosForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestión de Servicios - Veterinaria Genesis";
        Load += ServiciosForm_Load;
        gbxDatos.ResumeLayout(false);
        gbxDatos.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvServicios).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

