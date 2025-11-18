#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class FacturasForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxCrearFactura = null!;
    private Label lblCita = null!;
    private ComboBox cmbCita = null!;
    private Button btnCrearFactura = null!;
    private GroupBox gbxAgregarItem = null!;
    private Label lblIDFactura = null!;
    private Label lblIDServicioItem = null!;
    private Label lblCantidad = null!;
    private TextBox txtIDFactura = null!;
    private TextBox txtIDServicioItem = null!;
    private TextBox txtCantidad = null!;
    private Button btnAgregarItem = null!;
    private GroupBox gbxPagar = null!;
    private Label lblIDFacturaPago = null!;
    private Label lblMonto = null!;
    private Label lblMetodoPago = null!;
    private TextBox txtIDFacturaPago = null!;
    private TextBox txtMonto = null!;
    private ComboBox cmbMetodoPago = null!;
    private Button btnPagar = null!;
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
        lblCita = new Label();
        cmbCita = new ComboBox();
        btnCrearFactura = new Button();
        gbxAgregarItem = new GroupBox();
        btnAgregarItem = new Button();
        txtCantidad = new TextBox();
        txtIDServicioItem = new TextBox();
        txtIDFactura = new TextBox();
        lblCantidad = new Label();
        lblIDServicioItem = new Label();
        lblIDFactura = new Label();
        gbxPagar = new GroupBox();
        btnPagar = new Button();
        cmbMetodoPago = new ComboBox();
        txtMonto = new TextBox();
        txtIDFacturaPago = new TextBox();
        lblMetodoPago = new Label();
        lblMonto = new Label();
        lblIDFacturaPago = new Label();
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
        gbxAgregarItem.SuspendLayout();
        gbxPagar.SuspendLayout();
        gbxHistorial.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
        gbxDetalles.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
        SuspendLayout();
        // 
        // gbxCrearFactura
        // 
        gbxCrearFactura.Controls.Add(lblCita);
        gbxCrearFactura.Controls.Add(cmbCita);
        gbxCrearFactura.Controls.Add(btnCrearFactura);
        gbxCrearFactura.Font = new Font("Segoe UI", 10F);
        gbxCrearFactura.Location = new Point(14, 16);
        gbxCrearFactura.Margin = new Padding(3, 4, 3, 4);
        gbxCrearFactura.Name = "gbxCrearFactura";
        gbxCrearFactura.Padding = new Padding(3, 4, 3, 4);
        gbxCrearFactura.Size = new Size(1371, 107);
        gbxCrearFactura.TabIndex = 0;
        gbxCrearFactura.TabStop = false;
        gbxCrearFactura.Text = "Crear Factura desde Cita";
        // 
        // lblCita
        // 
        lblCita.AutoSize = true;
        lblCita.Location = new Point(17, 40);
        lblCita.Name = "lblCita";
        lblCita.Size = new Size(44, 23);
        lblCita.TabIndex = 0;
        lblCita.Text = "Cita:";
        // 
        // cmbCita
        // 
        cmbCita.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCita.FormattingEnabled = true;
        cmbCita.Location = new Point(69, 36);
        cmbCita.Margin = new Padding(3, 4, 3, 4);
        cmbCita.Name = "cmbCita";
        cmbCita.Size = new Size(571, 31);
        cmbCita.TabIndex = 1;
        // 
        // btnCrearFactura
        // 
        btnCrearFactura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCrearFactura.Location = new Point(663, 33);
        btnCrearFactura.Margin = new Padding(3, 4, 3, 4);
        btnCrearFactura.Name = "btnCrearFactura";
        btnCrearFactura.Size = new Size(229, 40);
        btnCrearFactura.TabIndex = 2;
        btnCrearFactura.Text = "&Crear Factura";
        btnCrearFactura.UseVisualStyleBackColor = true;
        btnCrearFactura.Click += btnCrearFactura_Click;
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
        gbxAgregarItem.Location = new Point(14, 147);
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
        // gbxPagar
        // 
        gbxPagar.Controls.Add(btnPagar);
        gbxPagar.Controls.Add(cmbMetodoPago);
        gbxPagar.Controls.Add(txtMonto);
        gbxPagar.Controls.Add(txtIDFacturaPago);
        gbxPagar.Controls.Add(lblMetodoPago);
        gbxPagar.Controls.Add(lblMonto);
        gbxPagar.Controls.Add(lblIDFacturaPago);
        gbxPagar.Font = new Font("Segoe UI", 10F);
        gbxPagar.Location = new Point(720, 147);
        gbxPagar.Margin = new Padding(3, 4, 3, 4);
        gbxPagar.Name = "gbxPagar";
        gbxPagar.Padding = new Padding(3, 4, 3, 4);
        gbxPagar.Size = new Size(665, 160);
        gbxPagar.TabIndex = 2;
        gbxPagar.TabStop = false;
        gbxPagar.Text = "Pagar Factura";
        // 
        // btnPagar
        // 
        btnPagar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnPagar.Location = new Point(400, 87);
        btnPagar.Margin = new Padding(3, 4, 3, 4);
        btnPagar.Name = "btnPagar";
        btnPagar.Size = new Size(229, 40);
        btnPagar.TabIndex = 6;
        btnPagar.Text = "&Procesar Pago";
        btnPagar.UseVisualStyleBackColor = true;
        btnPagar.Click += btnPagar_Click;
        // 
        // cmbMetodoPago
        // 
        cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMetodoPago.FormattingEnabled = true;
        cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta", "Transferencia" });
        cmbMetodoPago.Location = new Point(164, 90);
        cmbMetodoPago.Margin = new Padding(3, 4, 3, 4);
        cmbMetodoPago.Name = "cmbMetodoPago";
        cmbMetodoPago.Size = new Size(228, 31);
        cmbMetodoPago.TabIndex = 5;
        // 
        // txtMonto
        // 
        txtMonto.Location = new Point(320, 36);
        txtMonto.Margin = new Padding(3, 4, 3, 4);
        txtMonto.Name = "txtMonto";
        txtMonto.Size = new Size(137, 30);
        txtMonto.TabIndex = 3;
        // 
        // txtIDFacturaPago
        // 
        txtIDFacturaPago.Location = new Point(114, 36);
        txtIDFacturaPago.Margin = new Padding(3, 4, 3, 4);
        txtIDFacturaPago.Name = "txtIDFacturaPago";
        txtIDFacturaPago.Size = new Size(114, 30);
        txtIDFacturaPago.TabIndex = 1;
        // 
        // lblMetodoPago
        // 
        lblMetodoPago.AutoSize = true;
        lblMetodoPago.Location = new Point(17, 93);
        lblMetodoPago.Name = "lblMetodoPago";
        lblMetodoPago.Size = new Size(141, 23);
        lblMetodoPago.TabIndex = 4;
        lblMetodoPago.Text = "Método de Pago:";
        // 
        // lblMonto
        // 
        lblMonto.AutoSize = true;
        lblMonto.Location = new Point(251, 40);
        lblMonto.Name = "lblMonto";
        lblMonto.Size = new Size(65, 23);
        lblMonto.TabIndex = 2;
        lblMonto.Text = "Monto:";
        // 
        // lblIDFacturaPago
        // 
        lblIDFacturaPago.AutoSize = true;
        lblIDFacturaPago.Location = new Point(17, 40);
        lblIDFacturaPago.Name = "lblIDFacturaPago";
        lblIDFacturaPago.Size = new Size(91, 23);
        lblIDFacturaPago.TabIndex = 0;
        lblIDFacturaPago.Text = "ID Factura:";
        // 
        // lblEstado
        // 
        lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblEstado.AutoSize = true;
        lblEstado.Font = new Font("Segoe UI", 9F);
        lblEstado.Location = new Point(14, 333);
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(0, 20);
        lblEstado.TabIndex = 3;
        // 
        // gbxHistorial
        // 
        gbxHistorial.Controls.Add(btnCargarFacturas);
        gbxHistorial.Controls.Add(dgvFacturas);
        gbxHistorial.Font = new Font("Segoe UI", 10F);
        gbxHistorial.Location = new Point(14, 333);
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
        gbxDetalles.Location = new Point(720, 333);
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
        Controls.Add(gbxPagar);
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
        gbxAgregarItem.ResumeLayout(false);
        gbxAgregarItem.PerformLayout();
        gbxPagar.ResumeLayout(false);
        gbxPagar.PerformLayout();
        gbxHistorial.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
        gbxDetalles.ResumeLayout(false);
        gbxDetalles.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}

