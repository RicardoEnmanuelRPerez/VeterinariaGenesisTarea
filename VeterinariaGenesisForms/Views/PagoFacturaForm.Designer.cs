#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class PagoFacturaForm
{
    private System.ComponentModel.IContainer? components = null;
    private GroupBox gbxBuscar = null!;
    private Label lblIDFactura = null!;
    private TextBox txtIDFactura = null!;
    private Button btnBuscar = null!;
    private GroupBox gbxDatos = null!;
    private Label lblFecha = null!;
    private Label lblTotal = null!;
    private Label lblEstadoFactura = null!;
    private TextBox txtFecha = null!;
    private TextBox txtTotal = null!;
    private TextBox txtEstado = null!;
    private DataGridView dgvDetalles = null!;
    private GroupBox gbxPago = null!;
    private Label lblMonto = null!;
    private Label lblMetodoPago = null!;
    private TextBox txtMonto = null!;
    private ComboBox cmbMetodoPago = null!;
    private Button btnPagar = null!;
    private Button btnVerComprobante = null!;
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
        this.gbxBuscar = new GroupBox();
        this.btnBuscar = new Button();
        this.txtIDFactura = new TextBox();
        this.lblIDFactura = new Label();
        this.gbxDatos = new GroupBox();
        this.dgvDetalles = new DataGridView();
        this.txtEstado = new TextBox();
        this.txtTotal = new TextBox();
        this.txtFecha = new TextBox();
        this.lblEstadoFactura = new Label();
        this.lblTotal = new Label();
        this.lblFecha = new Label();
        this.gbxPago = new GroupBox();
        this.btnVerComprobante = new Button();
        this.btnPagar = new Button();
        this.cmbMetodoPago = new ComboBox();
        this.txtMonto = new TextBox();
        this.lblMetodoPago = new Label();
        this.lblMonto = new Label();
        this.lblEstado = new Label();
        this.gbxBuscar.SuspendLayout();
        this.gbxDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
        this.gbxPago.SuspendLayout();
        this.SuspendLayout();

        // gbxBuscar
        this.gbxBuscar.Controls.Add(this.btnBuscar);
        this.gbxBuscar.Controls.Add(this.txtIDFactura);
        this.gbxBuscar.Controls.Add(this.lblIDFactura);
        this.gbxBuscar.Font = new Font("Segoe UI", 10F);
        this.gbxBuscar.Location = new Point(12, 12);
        this.gbxBuscar.Name = "gbxBuscar";
        this.gbxBuscar.Size = new Size(800, 70);
        this.gbxBuscar.TabIndex = 0;
        this.gbxBuscar.TabStop = false;
        this.gbxBuscar.Text = "Buscar Factura";

        this.lblIDFactura.AutoSize = true;
        this.lblIDFactura.Location = new Point(15, 30);
        this.lblIDFactura.Name = "lblIDFactura";
        this.lblIDFactura.Size = new Size(91, 23);
        this.lblIDFactura.TabIndex = 0;
        this.lblIDFactura.Text = "ID Factura:";

        this.txtIDFactura.Location = new Point(112, 27);
        this.txtIDFactura.Name = "txtIDFactura";
        this.txtIDFactura.Size = new Size(200, 30);
        this.txtIDFactura.TabIndex = 1;

        this.btnBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnBuscar.Location = new Point(330, 25);
        this.btnBuscar.Name = "btnBuscar";
        this.btnBuscar.Size = new Size(150, 35);
        this.btnBuscar.TabIndex = 2;
        this.btnBuscar.Text = "&Buscar";
        this.btnBuscar.UseVisualStyleBackColor = true;
        this.btnBuscar.Click += new EventHandler(this.btnBuscar_Click);

        // gbxDatos
        this.gbxDatos.Controls.Add(this.dgvDetalles);
        this.gbxDatos.Controls.Add(this.txtEstado);
        this.gbxDatos.Controls.Add(this.txtTotal);
        this.gbxDatos.Controls.Add(this.txtFecha);
        this.gbxDatos.Controls.Add(this.lblEstadoFactura);
        this.gbxDatos.Controls.Add(this.lblTotal);
        this.gbxDatos.Controls.Add(this.lblFecha);
        this.gbxDatos.Font = new Font("Segoe UI", 10F);
        this.gbxDatos.Location = new Point(12, 100);
        this.gbxDatos.Name = "gbxDatos";
        this.gbxDatos.Size = new Size(500, 400);
        this.gbxDatos.TabIndex = 1;
        this.gbxDatos.TabStop = false;
        this.gbxDatos.Text = "Datos de la Factura";

        this.lblFecha.AutoSize = true;
        this.lblFecha.Location = new Point(15, 30);
        this.lblFecha.Name = "lblFecha";
        this.lblFecha.Size = new Size(56, 23);
        this.lblFecha.TabIndex = 0;
        this.lblFecha.Text = "Fecha:";

        this.txtFecha.Location = new Point(80, 27);
        this.txtFecha.Name = "txtFecha";
        this.txtFecha.ReadOnly = true;
        this.txtFecha.Size = new Size(150, 30);
        this.txtFecha.TabIndex = 1;

        this.lblTotal.AutoSize = true;
        this.lblTotal.Location = new Point(250, 30);
        this.lblTotal.Name = "lblTotal";
        this.lblTotal.Size = new Size(50, 23);
        this.lblTotal.TabIndex = 2;
        this.lblTotal.Text = "Total:";

        this.txtTotal.Location = new Point(310, 27);
        this.txtTotal.Name = "txtTotal";
        this.txtTotal.ReadOnly = true;
        this.txtTotal.Size = new Size(150, 30);
        this.txtTotal.TabIndex = 3;

        this.lblEstadoFactura.AutoSize = true;
        this.lblEstadoFactura.Location = new Point(15, 70);
        this.lblEstadoFactura.Name = "lblEstadoFactura";
        this.lblEstadoFactura.Size = new Size(64, 23);
        this.lblEstadoFactura.TabIndex = 4;
        this.lblEstadoFactura.Text = "Estado:";

        this.txtEstado.Location = new Point(85, 67);
        this.txtEstado.Name = "txtEstado";
        this.txtEstado.ReadOnly = true;
        this.txtEstado.Size = new Size(150, 30);
        this.txtEstado.TabIndex = 5;

        this.dgvDetalles.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        this.dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvDetalles.Location = new Point(15, 110);
        this.dgvDetalles.Name = "dgvDetalles";
        this.dgvDetalles.ReadOnly = true;
        this.dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvDetalles.Size = new Size(470, 270);
        this.dgvDetalles.TabIndex = 6;

        // gbxPago
        this.gbxPago.Controls.Add(this.btnVerComprobante);
        this.gbxPago.Controls.Add(this.btnPagar);
        this.gbxPago.Controls.Add(this.cmbMetodoPago);
        this.gbxPago.Controls.Add(this.txtMonto);
        this.gbxPago.Controls.Add(this.lblMetodoPago);
        this.gbxPago.Controls.Add(this.lblMonto);
        this.gbxPago.Font = new Font("Segoe UI", 10F);
        this.gbxPago.Location = new Point(530, 100);
        this.gbxPago.Name = "gbxPago";
        this.gbxPago.Size = new Size(282, 250);
        this.gbxPago.TabIndex = 2;
        this.gbxPago.TabStop = false;
        this.gbxPago.Text = "Procesar Pago";

        this.lblMonto.AutoSize = true;
        this.lblMonto.Location = new Point(15, 30);
        this.lblMonto.Name = "lblMonto";
        this.lblMonto.Size = new Size(65, 23);
        this.lblMonto.TabIndex = 0;
        this.lblMonto.Text = "Monto:";

        this.txtMonto.Location = new Point(90, 27);
        this.txtMonto.Name = "txtMonto";
        this.txtMonto.Size = new Size(170, 30);
        this.txtMonto.TabIndex = 1;

        this.lblMetodoPago.AutoSize = true;
        this.lblMetodoPago.Location = new Point(15, 70);
        this.lblMetodoPago.Name = "lblMetodoPago";
        this.lblMetodoPago.Size = new Size(141, 23);
        this.lblMetodoPago.TabIndex = 2;
        this.lblMetodoPago.Text = "Método de Pago:";

        this.cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cmbMetodoPago.FormattingEnabled = true;
        this.cmbMetodoPago.Location = new Point(15, 100);
        this.cmbMetodoPago.Name = "cmbMetodoPago";
        this.cmbMetodoPago.Size = new Size(245, 31);
        this.cmbMetodoPago.TabIndex = 3;

        this.btnPagar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnPagar.Location = new Point(15, 150);
        this.btnPagar.Name = "btnPagar";
        this.btnPagar.Size = new Size(245, 40);
        this.btnPagar.TabIndex = 4;
        this.btnPagar.Text = "&Procesar Pago";
        this.btnPagar.UseVisualStyleBackColor = true;
        this.btnPagar.Click += new EventHandler(this.btnPagar_Click);
        this.btnPagar.Enabled = false;

        this.btnVerComprobante.Font = new Font("Segoe UI", 10F);
        this.btnVerComprobante.Location = new Point(15, 200);
        this.btnVerComprobante.Name = "btnVerComprobante";
        this.btnVerComprobante.Size = new Size(245, 40);
        this.btnVerComprobante.TabIndex = 5;
        this.btnVerComprobante.Text = "&Ver Comprobante PDF";
        this.btnVerComprobante.UseVisualStyleBackColor = true;
        this.btnVerComprobante.Click += new EventHandler(this.btnVerComprobante_Click);
        this.btnVerComprobante.Enabled = false;

        // lblEstado
        this.lblEstado.AutoSize = true;
        this.lblEstado.Font = new Font("Segoe UI", 9F);
        this.lblEstado.Location = new Point(12, 520);
        this.lblEstado.Name = "lblEstado";
        this.lblEstado.Size = new Size(0, 20);
        this.lblEstado.TabIndex = 3;

        // PagoFacturaForm
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(824, 550);
        this.Controls.Add(this.lblEstado);
        this.Controls.Add(this.gbxPago);
        this.Controls.Add(this.gbxDatos);
        this.Controls.Add(this.gbxBuscar);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(840, 589);
        this.Name = "PagoFacturaForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Pago de Facturas - Veterinaria Genesis";
        this.Load += new EventHandler(this.PagoFacturaForm_Load);
        this.gbxBuscar.ResumeLayout(false);
        this.gbxBuscar.PerformLayout();
        this.gbxDatos.ResumeLayout(false);
        this.gbxDatos.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
        this.gbxPago.ResumeLayout(false);
        this.gbxPago.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

