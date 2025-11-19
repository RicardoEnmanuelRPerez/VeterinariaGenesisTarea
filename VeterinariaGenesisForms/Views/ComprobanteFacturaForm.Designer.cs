#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class ComprobanteFacturaForm
{
    private System.ComponentModel.IContainer? components = null;
    private RichTextBox rtbComprobante = null!;
    private Button btnExportarPDF = null!;

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
        this.rtbComprobante = new RichTextBox();
        this.btnExportarPDF = new Button();
        this.SuspendLayout();

        // rtbComprobante
        this.rtbComprobante.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
        this.rtbComprobante.Font = new Font("Courier New", 10F);
        this.rtbComprobante.Location = new Point(12, 12);
        this.rtbComprobante.Name = "rtbComprobante";
        this.rtbComprobante.ReadOnly = true;
        this.rtbComprobante.Size = new Size(600, 500);
        this.rtbComprobante.TabIndex = 0;
        this.rtbComprobante.Text = "";

        // btnExportarPDF
        this.btnExportarPDF.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        this.btnExportarPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnExportarPDF.Location = new Point(400, 530);
        this.btnExportarPDF.Name = "btnExportarPDF";
        this.btnExportarPDF.Size = new Size(212, 40);
        this.btnExportarPDF.TabIndex = 1;
        this.btnExportarPDF.Text = "&Exportar a PDF";
        this.btnExportarPDF.UseVisualStyleBackColor = true;
        this.btnExportarPDF.Click += new EventHandler(this.btnExportarPDF_Click);

        // ComprobanteFacturaForm
        this.AutoScaleDimensions = new SizeF(8F, 20F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(624, 582);
        this.Controls.Add(this.btnExportarPDF);
        this.Controls.Add(this.rtbComprobante);
        this.Font = new Font("Segoe UI", 9F);
        this.MinimumSize = new Size(640, 621);
        this.Name = "ComprobanteFacturaForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Comprobante de Pago - Veterinaria Genesis";
        this.Load += new EventHandler(this.ComprobanteFacturaForm_Load);
        this.ResumeLayout(false);
    }
}

