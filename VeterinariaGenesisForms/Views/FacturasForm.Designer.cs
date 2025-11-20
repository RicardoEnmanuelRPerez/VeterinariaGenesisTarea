#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class FacturasForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxCrearFactura = null!;
    private Label lblBuscarPropietario = null!;
    private TextBox txtBuscarPropietario = null!;
    private DataGridView dgvCitas = null!;
    private Button btnCrearFactura = null!;
    private Button btnRecargarCitas = null!;
    private GroupBox gbxAgregarItem = null!;
    private Label lblIDFactura = null!;
    private Label lblIDServicioItem = null!;
    private Label lblCantidad = null!;
    private TextBox txtIDFactura = null!;
    private TextBox txtIDServicioItem = null!;
    private TextBox txtCantidad = null!;
    private Button btnAgregarItem = null!;
    private GroupBox gbxDatosCita = null!;
    private Label lblPropietario = null!;
    private Label lblMascota = null!;
    private Label lblVeterinario = null!;
    private Label lblServicio = null!;
    private Label lblFechaCita = null!;
    private TextBox txtPropietario = null!;
    private TextBox txtMascota = null!;
    private TextBox txtVeterinario = null!;
    private TextBox txtServicio = null!;
    private TextBox txtFechaCita = null!;
    private Label lblEstado = null!;
    private GroupBox gbxHistorial = null!;
    private DataGridView dgvFacturas = null!;
    private GroupBox gbxDetalles = null!;
    private DataGridView dgvDetalles = null!;
    private Label lblSubtotal = null!;
    private Label lblTotal = null!;
    private Label lblEstadoFactura = null!;
    private Button btnCargarFacturas = null!;

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
        gbxCrearFactura = new GroupBox();
        lblBuscarPropietario = new Label();
        txtBuscarPropietario = new TextBox();
        dgvCitas = new DataGridView();
        btnCrearFactura = new Button();
        btnRecargarCitas = new Button();
        gbxAgregarItem = new GroupBox();
        btnAgregarItem = new Button();
        txtCantidad = new TextBox();
        txtIDServicioItem = new TextBox();
        txtIDFactura = new TextBox();
        lblCantidad = new Label();
        lblIDServicioItem = new Label();
        lblIDFactura = new Label();
        gbxDatosCita = new GroupBox();
        txtFechaCita = new TextBox();
        txtServicio = new TextBox();
        txtVeterinario = new TextBox();
        txtMascota = new TextBox();
        txtPropietario = new TextBox();
        lblFechaCita = new Label();
        lblServicio = new Label();
        lblVeterinario = new Label();
        lblMascota = new Label();
        lblPropietario = new Label();
        lblEstado = new Label();
        gbxHistorial = new GroupBox();
        btnCargarFacturas = new Button();
        dgvFacturas = new DataGridView();
        gbxDetalles = new GroupBox();
        lblEstadoFactura = new Label();
        lblTotal = new Label();
        lblSubtotal = new Label();
        dgvDetalles = new DataGridView();
        gbxCrearFactura.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
        gbxAgregarItem.SuspendLayout();
        gbxDatosCita.SuspendLayout();
        gbxHistorial.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
        gbxDetalles.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
        SuspendLayout();
        // 
        // gbxCrearFactura
        // 
        gbxCrearFactura.Controls.Add(lblBuscarPropietario);
        gbxCrearFactura.Controls.Add(txtBuscarPropietario);
        gbxCrearFactura.Controls.Add(dgvCitas);
        gbxCrearFactura.Controls.Add(btnCrearFactura);
        gbxCrearFactura.Controls.Add(btnRecargarCitas);
        gbxCrearFactura.Font = new Font("Segoe UI", 10F);
        gbxCrearFactura.Location = new Point(14, 16);
        gbxCrearFactura.Margin = new Padding(3, 4, 3, 4);
        gbxCrearFactura.Name = "gbxCrearFactura";
        gbxCrearFactura.Padding = new Padding(3, 4, 3, 4);
        gbxCrearFactura.Size = new Size(1371, 300);
        gbxCrearFactura.TabIndex = 0;
        gbxCrearFactura.TabStop = false;
        gbxCrearFactura.Text = "Crear Factura desde Cita";
        // 
        // lblBuscarPropietario
        // 
        lblBuscarPropietario.AutoSize = true;
        lblBuscarPropietario.Location = new Point(17, 40);
        lblBuscarPropietario.Name = "lblBuscarPropietario";
        lblBuscarPropietario.Size = new Size(178, 23);
        lblBuscarPropietario.TabIndex = 0;
        lblBuscarPropietario.Text = "Buscar por Propietario:";
        // 
        // txtBuscarPropietario
        // 
        txtBuscarPropietario.Location = new Point(201, 36);
        txtBuscarPropietario.Margin = new Padding(3, 4, 3, 4);
        txtBuscarPropietario.Name = "txtBuscarPropietario";
        txtBuscarPropietario.Size = new Size(300, 30);
        txtBuscarPropietario.TabIndex = 1;
        txtBuscarPropietario.TextChanged += TxtBuscarPropietario_TextChanged;
        // 
        // dgvCitas
        // 
        dgvCitas.AllowUserToAddRows = false;
        dgvCitas.AllowUserToDeleteRows = false;
        dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCitas.Location = new Point(17, 80);
        dgvCitas.Margin = new Padding(3, 4, 3, 4);
        dgvCitas.MultiSelect = false;
        dgvCitas.Name = "dgvCitas";
        dgvCitas.ReadOnly = true;
        dgvCitas.RowHeadersWidth = 51;
        dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCitas.Size = new Size(1330, 190);
        dgvCitas.TabIndex = 2;
        dgvCitas.SelectionChanged += DgvCitas_SelectionChanged;
        // 
        // btnCrearFactura
        // 
        btnCrearFactura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCrearFactura.Location = new Point(520, 33);
        btnCrearFactura.Margin = new Padding(3, 4, 3, 4);
        btnCrearFactura.Name = "btnCrearFactura";
        btnCrearFactura.Size = new Size(229, 40);
        btnCrearFactura.TabIndex = 3;
        btnCrearFactura.Text = "&Crear Factura";
        btnCrearFactura.UseVisualStyleBackColor = true;
        btnCrearFactura.Click += btnCrearFactura_Click;
        // 
        // btnRecargarCitas
        // 
        btnRecargarCitas.Font = new Font("Segoe UI", 9F);
        btnRecargarCitas.Location = new Point(770, 33);
        btnRecargarCitas.Margin = new Padding(3, 4, 3, 4);
        btnRecargarCitas.Name = "btnRecargarCitas";
        btnRecargarCitas.Size = new Size(120, 40);
        btnRecargarCitas.TabIndex = 4;
        btnRecargarCitas.Text = "&Recargar Citas";
        btnRecargarCitas.UseVisualStyleBackColor = true;
        btnRecargarCitas.Click += btnRecargarCitas_Click;
        // 
        // gbxAgregarItem
        // 
        gbxAgregarItem.Controls.Add(btnAgregarItem);
        gbxAgregarItem.Controls.Add(txtCantidad);
        gbxAgregarItem.Controls.Add(txtIDServicioItem);
        gbxAgregarItem.Controls.Add(txtIDFactura);
        gbxAgregarItem.Controls.Add(lblCantidad);
        gbxAgregarItem.Controls.Add(lblIDServicioItem);
        gbxAgregarItem.Controls.Add(lblIDFactura);
        gbxAgregarItem.Font = new Font("Segoe UI", 10F);
        gbxAgregarItem.Location = new Point(14, 333);
        gbxAgregarItem.Margin = new Padding(3, 4, 3, 4);
        gbxAgregarItem.Name = "gbxAgregarItem";
        gbxAgregarItem.Padding = new Padding(3, 4, 3, 4);
        gbxAgregarItem.Size = new Size(686, 160);
        gbxAgregarItem.TabIndex = 1;
        gbxAgregarItem.TabStop = false;
        gbxAgregarItem.Text = "Agregar Item a Factura";
        // 
        // btnAgregarItem
        // 
        btnAgregarItem.Font = new Font("Segoe UI", 10F);
        btnAgregarItem.Location = new Point(17, 93);
        btnAgregarItem.Margin = new Padding(3, 4, 3, 4);
        btnAgregarItem.Name = "btnAgregarItem";
        btnAgregarItem.Size = new Size(229, 47);
        btnAgregarItem.TabIndex = 6;
        btnAgregarItem.Text = "&Agregar Item";
        btnAgregarItem.UseVisualStyleBackColor = true;
        btnAgregarItem.Click += btnAgregarItem_Click;
        // 
        // txtCantidad
        // 
        txtCantidad.Location = new Point(577, 36);
        txtCantidad.Margin = new Padding(3, 4, 3, 4);
        txtCantidad.Name = "txtCantidad";
        txtCantidad.Size = new Size(91, 30);
        txtCantidad.TabIndex = 5;
        // 
        // txtIDServicioItem
        // 
        txtIDServicioItem.Location = new Point(354, 36);
        txtIDServicioItem.Margin = new Padding(3, 4, 3, 4);
        txtIDServicioItem.Name = "txtIDServicioItem";
        txtIDServicioItem.Size = new Size(114, 30);
        txtIDServicioItem.TabIndex = 3;
        // 
        // txtIDFactura
        // 
        txtIDFactura.Location = new Point(114, 36);
        txtIDFactura.Margin = new Padding(3, 4, 3, 4);
        txtIDFactura.Name = "txtIDFactura";
        txtIDFactura.Size = new Size(114, 30);
        txtIDFactura.TabIndex = 1;
        // 
        // lblCantidad
        // 
        lblCantidad.AutoSize = true;
        lblCantidad.Location = new Point(491, 40);
        lblCantidad.Name = "lblCantidad";
        lblCantidad.Size = new Size(83, 23);
        lblCantidad.TabIndex = 4;
        lblCantidad.Text = "Cantidad:";
        // 
        // lblIDServicioItem
        // 
        lblIDServicioItem.AutoSize = true;
        lblIDServicioItem.Location = new Point(251, 40);
        lblIDServicioItem.Name = "lblIDServicioItem";
        lblIDServicioItem.Size = new Size(94, 23);
        lblIDServicioItem.TabIndex = 2;
        lblIDServicioItem.Text = "ID Servicio:";
        // 
        // lblIDFactura
        // 
        lblIDFactura.AutoSize = true;
        lblIDFactura.Location = new Point(17, 40);
        lblIDFactura.Name = "lblIDFactura";
        lblIDFactura.Size = new Size(91, 23);
        lblIDFactura.TabIndex = 0;
        lblIDFactura.Text = "ID Factura:";
        // 
        // gbxDatosCita
        // 
        gbxDatosCita.Controls.Add(txtFechaCita);
        gbxDatosCita.Controls.Add(txtServicio);
        gbxDatosCita.Controls.Add(txtVeterinario);
        gbxDatosCita.Controls.Add(txtMascota);
        gbxDatosCita.Controls.Add(txtPropietario);
        gbxDatosCita.Controls.Add(lblFechaCita);
        gbxDatosCita.Controls.Add(lblServicio);
        gbxDatosCita.Controls.Add(lblVeterinario);
        gbxDatosCita.Controls.Add(lblMascota);
        gbxDatosCita.Controls.Add(lblPropietario);
        gbxDatosCita.Font = new Font("Segoe UI", 10F);
        gbxDatosCita.Location = new Point(720, 333);
        gbxDatosCita.Margin = new Padding(3, 4, 3, 4);
        gbxDatosCita.Name = "gbxDatosCita";
        gbxDatosCita.Padding = new Padding(3, 4, 3, 4);
        gbxDatosCita.Size = new Size(665, 200);
        gbxDatosCita.TabIndex = 2;
        gbxDatosCita.TabStop = false;
        gbxDatosCita.Text = "Datos de la Cita Seleccionada";
        // 
        // txtFechaCita
        // 
        txtFechaCita.Location = new Point(450, 107);
        txtFechaCita.Margin = new Padding(3, 4, 3, 4);
        txtFechaCita.Name = "txtFechaCita";
        txtFechaCita.ReadOnly = true;
        txtFechaCita.Size = new Size(190, 30);
        txtFechaCita.TabIndex = 9;
        // 
        // txtServicio
        // 
        txtServicio.Location = new Point(120, 107);
        txtServicio.Margin = new Padding(3, 4, 3, 4);
        txtServicio.Name = "txtServicio";
        txtServicio.ReadOnly = true;
        txtServicio.Size = new Size(250, 30);
        txtServicio.TabIndex = 7;
        // 
        // txtVeterinario
        // 
        txtVeterinario.Location = new Point(490, 67);
        txtVeterinario.Margin = new Padding(3, 4, 3, 4);
        txtVeterinario.Name = "txtVeterinario";
        txtVeterinario.ReadOnly = true;
        txtVeterinario.Size = new Size(150, 30);
        txtVeterinario.TabIndex = 5;
        // 
        // txtMascota
        // 
        txtMascota.Location = new Point(120, 67);
        txtMascota.Margin = new Padding(3, 4, 3, 4);
        txtMascota.Name = "txtMascota";
        txtMascota.ReadOnly = true;
        txtMascota.Size = new Size(250, 30);
        txtMascota.TabIndex = 3;
        // 
        // txtPropietario
        // 
        txtPropietario.Location = new Point(120, 27);
        txtPropietario.Margin = new Padding(3, 4, 3, 4);
        txtPropietario.Name = "txtPropietario";
        txtPropietario.ReadOnly = true;
        txtPropietario.Size = new Size(520, 30);
        txtPropietario.TabIndex = 1;
        // 
        // lblFechaCita
        // 
        lblFechaCita.AutoSize = true;
        lblFechaCita.Location = new Point(390, 110);
        lblFechaCita.Name = "lblFechaCita";
        lblFechaCita.Size = new Size(58, 23);
        lblFechaCita.TabIndex = 8;
        lblFechaCita.Text = "Fecha:";
        // 
        // lblServicio
        // 
        lblServicio.AutoSize = true;
        lblServicio.Location = new Point(17, 110);
        lblServicio.Name = "lblServicio";
        lblServicio.Size = new Size(72, 23);
        lblServicio.TabIndex = 6;
        lblServicio.Text = "Servicio:";
        // 
        // lblVeterinario
        // 
        lblVeterinario.AutoSize = true;
        lblVeterinario.Location = new Point(390, 70);
        lblVeterinario.Name = "lblVeterinario";
        lblVeterinario.Size = new Size(97, 23);
        lblVeterinario.TabIndex = 4;
        lblVeterinario.Text = "Veterinario:";
        // 
        // lblMascota
        // 
        lblMascota.AutoSize = true;
        lblMascota.Location = new Point(17, 70);
        lblMascota.Name = "lblMascota";
        lblMascota.Size = new Size(78, 23);
        lblMascota.TabIndex = 2;
        lblMascota.Text = "Mascota:";
        // 
        // lblPropietario
        // 
        lblPropietario.AutoSize = true;
        lblPropietario.Location = new Point(17, 30);
        lblPropietario.Name = "lblPropietario";
        lblPropietario.Size = new Size(98, 23);
        lblPropietario.TabIndex = 0;
        lblPropietario.Text = "Propietario:";
        // 
        // lblEstado
        // 
        lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblEstado.AutoSize = true;
        lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEstado.Location = new Point(14, 810);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(200, 20);
        lblEstado.TabIndex = 3;
        lblEstado.Text = "Estado: Cargando...";
        // 
        // gbxHistorial
        // 
        gbxHistorial.Controls.Add(btnCargarFacturas);
        gbxHistorial.Controls.Add(dgvFacturas);
        gbxHistorial.Font = new Font("Segoe UI", 10F);
        gbxHistorial.Location = new Point(14, 520);
        gbxHistorial.Margin = new Padding(3, 4, 3, 4);
        gbxHistorial.Name = "gbxHistorial";
        gbxHistorial.Padding = new Padding(3, 4, 3, 4);
        gbxHistorial.Size = new Size(686, 467);
        gbxHistorial.TabIndex = 4;
        gbxHistorial.TabStop = false;
        gbxHistorial.Text = "Historial de Facturas";
        // 
        // btnCargarFacturas
        // 
        btnCargarFacturas.Font = new Font("Segoe UI", 10F);
        btnCargarFacturas.Location = new Point(17, 33);
        btnCargarFacturas.Margin = new Padding(3, 4, 3, 4);
        btnCargarFacturas.Name = "btnCargarFacturas";
        btnCargarFacturas.Size = new Size(171, 33);
        btnCargarFacturas.TabIndex = 1;
        btnCargarFacturas.Text = "&Cargar Historial";
        btnCargarFacturas.UseVisualStyleBackColor = true;
        btnCargarFacturas.Click += btnCargarFacturas_Click;
        // 
        // dgvFacturas
        // 
        dgvFacturas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvFacturas.Location = new Point(17, 73);
        dgvFacturas.Margin = new Padding(3, 4, 3, 4);
        dgvFacturas.Name = "dgvFacturas";
        dgvFacturas.ReadOnly = true;
        dgvFacturas.RowHeadersWidth = 51;
        dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvFacturas.Size = new Size(651, 373);
        dgvFacturas.TabIndex = 0;
        // 
        // gbxDetalles
        // 
        gbxDetalles.Controls.Add(lblEstadoFactura);
        gbxDetalles.Controls.Add(lblTotal);
        gbxDetalles.Controls.Add(lblSubtotal);
        gbxDetalles.Controls.Add(dgvDetalles);
        gbxDetalles.Font = new Font("Segoe UI", 10F);
        gbxDetalles.Location = new Point(720, 520);
        gbxDetalles.Margin = new Padding(3, 4, 3, 4);
        gbxDetalles.Name = "gbxDetalles";
        gbxDetalles.Padding = new Padding(3, 4, 3, 4);
        gbxDetalles.Size = new Size(665, 467);
        gbxDetalles.TabIndex = 5;
        gbxDetalles.TabStop = false;
        gbxDetalles.Text = "Detalles de Factura";
        // 
        // lblEstadoFactura
        // 
        lblEstadoFactura.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        lblEstadoFactura.AutoSize = true;
        lblEstadoFactura.Font = new Font("Segoe UI", 10F);
        lblEstadoFactura.Location = new Point(400, 413);
        lblEstadoFactura.Name = "lblEstadoFactura";
        lblEstadoFactura.Size = new Size(0, 23);
        lblEstadoFactura.TabIndex = 3;
        // 
        // lblTotal
        // 
        lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotal.ForeColor = Color.Blue;
        lblTotal.Location = new Point(17, 413);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(123, 28);
        lblTotal.TabIndex = 2;
        lblTotal.Text = "Total: $0.00";
        // 
        // lblSubtotal
        // 
        lblSubtotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblSubtotal.AutoSize = true;
        lblSubtotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblSubtotal.Location = new Point(17, 380);
        lblSubtotal.Name = "lblSubtotal";
        lblSubtotal.Size = new Size(134, 23);
        lblSubtotal.TabIndex = 1;
        lblSubtotal.Text = "Subtotal: $0.00";
        // 
        // dgvDetalles
        // 
        dgvDetalles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDetalles.Location = new Point(17, 73);
        dgvDetalles.Margin = new Padding(3, 4, 3, 4);
        dgvDetalles.Name = "dgvDetalles";
        dgvDetalles.ReadOnly = true;
        dgvDetalles.RowHeadersWidth = 51;
        dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDetalles.Size = new Size(631, 293);
        dgvDetalles.TabIndex = 0;
        // 
        // FacturasForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1399, 827);
        Controls.Add(gbxDetalles);
        Controls.Add(gbxHistorial);
        Controls.Add(lblEstado);
        Controls.Add(gbxDatosCita);
        Controls.Add(gbxAgregarItem);
        Controls.Add(gbxCrearFactura);
        Font = new Font("Segoe UI", 9F);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(1415, 410);
        Name = "FacturasForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestión de Facturas - Veterinaria Genesis";
        Load += FacturasForm_Load;
        gbxCrearFactura.ResumeLayout(false);
        gbxCrearFactura.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
        gbxAgregarItem.ResumeLayout(false);
        gbxAgregarItem.PerformLayout();
        gbxDatosCita.ResumeLayout(false);
        gbxDatosCita.PerformLayout();
        gbxHistorial.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
        gbxDetalles.ResumeLayout(false);
        gbxDetalles.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

