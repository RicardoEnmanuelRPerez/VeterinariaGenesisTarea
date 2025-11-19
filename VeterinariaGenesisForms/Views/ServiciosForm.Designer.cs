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
        this.gbxDatos = new GroupBox();
        this.lblID = new Label();
        this.lblNombre = new Label();
        this.lblDescripcion = new Label();
        this.lblCosto = new Label();
        this.txtID = new TextBox();
        this.txtNombre = new TextBox();
        this.txtDescripcion = new TextBox();
        this.txtCosto = new TextBox();
        this.btnNuevo = new Button();
        this.btnActualizar = new Button();
        this.btnEliminar = new Button();
        this.btnLimpiar = new Button();
        this.dgvServicios = new DataGridView();
        this.btnCargar = new Button();
        this.btnExportarExcel = new Button();
        this.lblEstado = new Label();
        this.gbxDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
        this.SuspendLayout();

        // gbxDatos
        this.gbxDatos.Controls.Add(this.btnLimpiar);
        this.gbxDatos.Controls.Add(this.btnEliminar);
        this.gbxDatos.Controls.Add(this.btnActualizar);
        this.gbxDatos.Controls.Add(this.btnNuevo);
        this.gbxDatos.Controls.Add(this.txtCosto);
        this.gbxDatos.Controls.Add(this.txtDescripcion);
        this.gbxDatos.Controls.Add(this.txtNombre);
        this.gbxDatos.Controls.Add(this.txtID);
        this.gbxDatos.Controls.Add(this.lblCosto);
        this.gbxDatos.Controls.Add(this.lblDescripcion);
        this.gbxDatos.Controls.Add(this.lblNombre);
        this.gbxDatos.Controls.Add(this.lblID);
        this.gbxDatos.Font = new Font("Segoe UI", 10F);
        this.gbxDatos.Location = new Point(12, 12);
        this.gbxDatos.Name = "gbxDatos";
        this.gbxDatos.Size = new Size(600, 200);
        this.gbxDatos.TabIndex = 0;
        this.gbxDatos.TabStop = false;
        this.gbxDatos.Text = "Datos del Servicio";

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
        this.lblNombre.Location = new Point(170, 30);
        this.lblNombre.Name = "lblNombre";
        this.lblNombre.Size = new Size(62, 19);
        this.lblNombre.TabIndex = 2;
        this.lblNombre.Text = "Nombre:";

        this.txtNombre.Location = new Point(240, 27);
        this.txtNombre.Name = "txtNombre";
        this.txtNombre.Size = new Size(340, 25);
        this.txtNombre.TabIndex = 3;

        this.lblDescripcion.AutoSize = true;
        this.lblDescripcion.Location = new Point(15, 65);
        this.lblDescripcion.Name = "lblDescripcion";
        this.lblDescripcion.Size = new Size(81, 19);
        this.lblDescripcion.TabIndex = 4;
        this.lblDescripcion.Text = "Descripción:";

        this.txtDescripcion.Location = new Point(100, 62);
        this.txtDescripcion.Multiline = true;
        this.txtDescripcion.Name = "txtDescripcion";
        this.txtDescripcion.Size = new Size(480, 60);
        this.txtDescripcion.TabIndex = 5;

        this.lblCosto.AutoSize = true;
        this.lblCosto.Location = new Point(15, 135);
        this.lblCosto.Name = "lblCosto";
        this.lblCosto.Size = new Size(48, 19);
        this.lblCosto.TabIndex = 6;
        this.lblCosto.Text = "Costo:";

        this.txtCosto.Location = new Point(70, 132);
        this.txtCosto.Name = "txtCosto";
        this.txtCosto.Size = new Size(150, 25);
        this.txtCosto.TabIndex = 7;

        this.btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnNuevo.Location = new Point(240, 130);
        this.btnNuevo.Name = "btnNuevo";
        this.btnNuevo.Size = new Size(100, 30);
        this.btnNuevo.TabIndex = 8;
        this.btnNuevo.Text = "&Nuevo";
        this.btnNuevo.UseVisualStyleBackColor = true;
        this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);

        this.btnActualizar.Font = new Font("Segoe UI", 10F);
        this.btnActualizar.Location = new Point(350, 130);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new Size(100, 30);
        this.btnActualizar.TabIndex = 9;
        this.btnActualizar.Text = "&Actualizar";
        this.btnActualizar.UseVisualStyleBackColor = true;
        this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);

        this.btnEliminar.Font = new Font("Segoe UI", 10F);
        this.btnEliminar.Location = new Point(460, 130);
        this.btnEliminar.Name = "btnEliminar";
        this.btnEliminar.Size = new Size(100, 30);
        this.btnEliminar.TabIndex = 10;
        this.btnEliminar.Text = "&Eliminar";
        this.btnEliminar.UseVisualStyleBackColor = true;
        this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);

        this.btnLimpiar.Font = new Font("Segoe UI", 10F);
        this.btnLimpiar.Location = new Point(15, 165);
        this.btnLimpiar.Name = "btnLimpiar";
        this.btnLimpiar.Size = new Size(100, 30);
        this.btnLimpiar.TabIndex = 11;
        this.btnLimpiar.Text = "&Limpiar";
        this.btnLimpiar.UseVisualStyleBackColor = true;
        this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);

        // dgvServicios
        this.dgvServicios.AllowUserToAddRows = false;
        this.dgvServicios.AllowUserToDeleteRows = false;
        this.dgvServicios.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvServicios.Location = new Point(630, 12);
        this.dgvServicios.Name = "dgvServicios";
        this.dgvServicios.ReadOnly = true;
        this.dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvServicios.Size = new Size(582, 400);
        this.dgvServicios.TabIndex = 1;

        // btnCargar
        this.btnCargar.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
        this.btnCargar.Font = new Font("Segoe UI", 10F);
        this.btnCargar.Location = new Point(12, 420);
        this.btnCargar.Name = "btnCargar";
        this.btnCargar.Size = new Size(150, 35);
        this.btnCargar.TabIndex = 2;
        this.btnCargar.Text = "&Cargar Servicios";
        this.btnCargar.UseVisualStyleBackColor = true;
        this.btnCargar.Click += new EventHandler(this.btnCargar_Click);

        // btnExportarExcel
        this.btnExportarExcel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        this.btnExportarExcel.Font = new Font("Segoe UI", 10F);
        this.btnExportarExcel.Location = new Point(1050, 420);
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
        this.lblEstado.Location = new Point(180, 430);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(0, 15);
        this.lblEstado.TabIndex = 4;

        // ServiciosForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1224, 467);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.btnExportarExcel);
        this.Controls.Add(this.btnCargar);
        this.Controls.Add(this.dgvServicios);
        this.Controls.Add(this.gbxDatos);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(1240, 506);
        this.Name = "ServiciosForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Gestión de Servicios - Veterinaria Genesis";
        this.Load += new EventHandler(this.ServiciosForm_Load);
        this.gbxDatos.ResumeLayout(false);
        this.gbxDatos.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

