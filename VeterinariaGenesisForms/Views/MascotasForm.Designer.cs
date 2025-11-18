#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class MascotasForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxFiltro = null!;
    private Label lblPropietario = null!;
    private ComboBox cmbPropietario = null!;
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
        this.gbxFiltro = new GroupBox();
        this.lblPropietario = new Label();
        this.cmbPropietario = new ComboBox();
        this.btnCargar = new Button();
        this.gbxDatos = new GroupBox();
        this.lblID = new Label();
        this.lblNombre = new Label();
        this.lblEspecie = new Label();
        this.lblRaza = new Label();
        this.lblEdad = new Label();
        this.lblSexo = new Label();
        this.txtID = new TextBox();
        this.txtNombre = new TextBox();
        this.txtEspecie = new TextBox();
        this.txtRaza = new TextBox();
        this.txtEdad = new TextBox();
        this.cmbSexo = new ComboBox();
        this.btnNuevo = new Button();
        this.btnActualizar = new Button();
        this.btnEliminar = new Button();
        this.btnLimpiar = new Button();
        this.dgvMascotas = new DataGridView();
        this.btnExportarExcel = new Button();
        this.lblEstado = new Label();
        this.gbxFiltro.SuspendLayout();
        this.gbxDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).BeginInit();
        this.SuspendLayout();

        // gbxFiltro
        this.gbxFiltro.Controls.Add(this.lblPropietario);
        this.gbxFiltro.Controls.Add(this.cmbPropietario);
        this.gbxFiltro.Controls.Add(this.btnCargar);
        this.gbxFiltro.Font = new Font("Segoe UI", 10F);
        this.gbxFiltro.Location = new Point(12, 12);
        this.gbxFiltro.Name = "gbxFiltro";
        this.gbxFiltro.Size = new Size(1200, 70);
        this.gbxFiltro.TabIndex = 0;
        this.gbxFiltro.TabStop = false;
        this.gbxFiltro.Text = "Filtro";

        this.lblPropietario.AutoSize = true;
        this.lblPropietario.Location = new Point(15, 30);
        this.lblPropietario.Name = "lblPropietario";
        this.lblPropietario.Size = new Size(80, 19);
        this.lblPropietario.TabIndex = 0;
        this.lblPropietario.Text = "Propietario:";

        this.cmbPropietario.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbPropietario.Font = new Font("Segoe UI", 10F);
        this.cmbPropietario.FormattingEnabled = true;
        this.cmbPropietario.Location = new Point(100, 27);
        this.cmbPropietario.Name = "cmbPropietario";
        this.cmbPropietario.Size = new Size(400, 25);
        this.cmbPropietario.TabIndex = 1;

        this.btnCargar.Font = new Font("Segoe UI", 10F);
        this.btnCargar.Location = new Point(520, 25);
        this.btnCargar.Name = "btnCargar";
        this.btnCargar.Size = new Size(150, 30);
        this.btnCargar.TabIndex = 2;
        this.btnCargar.Text = "&Cargar Mascotas";
        this.btnCargar.UseVisualStyleBackColor = true;
        this.btnCargar.Click += new EventHandler(this.btnCargar_Click);

        // gbxDatos
        this.gbxDatos.Controls.Add(this.btnLimpiar);
        this.gbxDatos.Controls.Add(this.btnEliminar);
        this.gbxDatos.Controls.Add(this.btnActualizar);
        this.gbxDatos.Controls.Add(this.btnNuevo);
        this.gbxDatos.Controls.Add(this.cmbSexo);
        this.gbxDatos.Controls.Add(this.txtEdad);
        this.gbxDatos.Controls.Add(this.txtRaza);
        this.gbxDatos.Controls.Add(this.txtEspecie);
        this.gbxDatos.Controls.Add(this.txtNombre);
        this.gbxDatos.Controls.Add(this.txtID);
        this.gbxDatos.Controls.Add(this.lblSexo);
        this.gbxDatos.Controls.Add(this.lblEdad);
        this.gbxDatos.Controls.Add(this.lblRaza);
        this.gbxDatos.Controls.Add(this.lblEspecie);
        this.gbxDatos.Controls.Add(this.lblNombre);
        this.gbxDatos.Controls.Add(this.lblID);
        this.gbxDatos.Font = new Font("Segoe UI", 10F);
        this.gbxDatos.Location = new Point(12, 95);
        this.gbxDatos.Name = "gbxDatos";
        this.gbxDatos.Size = new Size(600, 200);
        this.gbxDatos.TabIndex = 1;
        this.gbxDatos.TabStop = false;
        this.gbxDatos.Text = "Datos de la Mascota";

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

        this.lblEspecie.AutoSize = true;
        this.lblEspecie.Location = new Point(300, 65);
        this.lblEspecie.Name = "lblEspecie";
        this.lblEspecie.Size = new Size(60, 19);
        this.lblEspecie.TabIndex = 4;
        this.lblEspecie.Text = "Especie:";

        this.txtEspecie.Location = new Point(365, 62);
        this.txtEspecie.Name = "txtEspecie";
        this.txtEspecie.Size = new Size(200, 25);
        this.txtEspecie.TabIndex = 5;

        this.lblRaza.AutoSize = true;
        this.lblRaza.Location = new Point(15, 100);
        this.lblRaza.Name = "lblRaza";
        this.lblRaza.Size = new Size(45, 19);
        this.lblRaza.TabIndex = 6;
        this.lblRaza.Text = "Raza:";

        this.txtRaza.Location = new Point(65, 97);
        this.txtRaza.Name = "txtRaza";
        this.txtRaza.Size = new Size(200, 25);
        this.txtRaza.TabIndex = 7;

        this.lblEdad.AutoSize = true;
        this.lblEdad.Location = new Point(280, 100);
        this.lblEdad.Name = "lblEdad";
        this.lblEdad.Size = new Size(42, 19);
        this.lblEdad.TabIndex = 8;
        this.lblEdad.Text = "Edad:";

        this.txtEdad.Location = new Point(330, 97);
        this.txtEdad.Name = "txtEdad";
        this.txtEdad.Size = new Size(100, 25);
        this.txtEdad.TabIndex = 9;

        this.lblSexo.AutoSize = true;
        this.lblSexo.Location = new Point(450, 100);
        this.lblSexo.Name = "lblSexo";
        this.lblSexo.Size = new Size(42, 19);
        this.lblSexo.TabIndex = 10;
        this.lblSexo.Text = "Sexo:";

        this.cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbSexo.Font = new Font("Segoe UI", 10F);
        this.cmbSexo.FormattingEnabled = true;
        this.cmbSexo.Items.AddRange(new object[] { "Macho", "Hembra" });
        this.cmbSexo.Location = new Point(500, 97);
        this.cmbSexo.Name = "cmbSexo";
        this.cmbSexo.Size = new Size(80, 25);
        this.cmbSexo.TabIndex = 11;

        this.btnNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnNuevo.Location = new Point(15, 140);
        this.btnNuevo.Name = "btnNuevo";
        this.btnNuevo.Size = new Size(130, 30);
        this.btnNuevo.TabIndex = 12;
        this.btnNuevo.Text = "&Nuevo";
        this.btnNuevo.UseVisualStyleBackColor = true;
        this.btnNuevo.Click += new EventHandler(this.btnNuevo_Click);

        this.btnActualizar.Font = new Font("Segoe UI", 10F);
        this.btnActualizar.Location = new Point(155, 140);
        this.btnActualizar.Name = "btnActualizar";
        this.btnActualizar.Size = new Size(130, 30);
        this.btnActualizar.TabIndex = 13;
        this.btnActualizar.Text = "&Actualizar";
        this.btnActualizar.UseVisualStyleBackColor = true;
        this.btnActualizar.Click += new EventHandler(this.btnActualizar_Click);

        this.btnEliminar.Font = new Font("Segoe UI", 10F);
        this.btnEliminar.Location = new Point(295, 140);
        this.btnEliminar.Name = "btnEliminar";
        this.btnEliminar.Size = new Size(130, 30);
        this.btnEliminar.TabIndex = 14;
        this.btnEliminar.Text = "&Eliminar";
        this.btnEliminar.UseVisualStyleBackColor = true;
        this.btnEliminar.Click += new EventHandler(this.btnEliminar_Click);

        this.btnLimpiar.Font = new Font("Segoe UI", 10F);
        this.btnLimpiar.Location = new Point(435, 140);
        this.btnLimpiar.Name = "btnLimpiar";
        this.btnLimpiar.Size = new Size(130, 30);
        this.btnLimpiar.TabIndex = 15;
        this.btnLimpiar.Text = "&Limpiar";
        this.btnLimpiar.UseVisualStyleBackColor = true;
        this.btnLimpiar.Click += new EventHandler(this.btnLimpiar_Click);

        // dgvMascotas
        this.dgvMascotas.AllowUserToAddRows = false;
        this.dgvMascotas.AllowUserToDeleteRows = false;
        this.dgvMascotas.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvMascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvMascotas.Location = new Point(12, 310);
        this.dgvMascotas.Name = "dgvMascotas";
        this.dgvMascotas.ReadOnly = true;
        this.dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvMascotas.Size = new Size(1200, 300);
        this.dgvMascotas.TabIndex = 2;

        // btnExportarExcel
        this.btnExportarExcel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        this.btnExportarExcel.Font = new Font("Segoe UI", 10F);
        this.btnExportarExcel.Location = new Point(1050, 620);
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
        this.lblEstado.Location = new Point(12, 630);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(0, 15);
        this.lblEstado.TabIndex = 4;

        // MascotasForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1224, 667);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.btnExportarExcel);
        this.Controls.Add(this.dgvMascotas);
        this.Controls.Add(this.gbxDatos);
        this.Controls.Add(this.gbxFiltro);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(1240, 706);
        this.Name = "MascotasForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Gestión de Mascotas - Veterinaria Genesis";
        this.Load += new EventHandler(this.MascotasForm_Load);
        this.gbxFiltro.ResumeLayout(false);
        this.gbxFiltro.PerformLayout();
        this.gbxDatos.ResumeLayout(false);
        this.gbxDatos.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMascotas)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

