#nullable enable
using System.Diagnostics;
using VeterinariaGenesisForms.Models.Dto;

namespace VeterinariaGenesisForms.Views;

public partial class ComprobanteFacturaForm : Form
{
    private readonly FacturaDto _factura;

    public ComprobanteFacturaForm(FacturaDto factura)
    {
        InitializeComponent();
        _factura = factura;
    }

    private void ComprobanteFacturaForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        MostrarComprobante();
    }

    private void AplicarColoresVeterinaria()
    {
        this.BackColor = Color.FromArgb(245, 250, 247);
        btnExportarPDF.BackColor = Color.FromArgb(76, 175, 80);
        btnExportarPDF.ForeColor = Color.White;
        btnExportarPDF.FlatStyle = FlatStyle.Flat;
        btnExportarPDF.FlatAppearance.BorderSize = 0;
    }

    private void MostrarComprobante()
    {
        rtbComprobante.Clear();
        rtbComprobante.Font = new Font("Courier New", 10F);
        rtbComprobante.AppendText("═══════════════════════════════════════════════════════\n");
        rtbComprobante.AppendText("          VETERINARIA GENESIS\n");
        rtbComprobante.AppendText("═══════════════════════════════════════════════════════\n\n");
        rtbComprobante.AppendText($"COMPROBANTE DE PAGO\n");
        rtbComprobante.AppendText($"───────────────────────────────────────────────────────\n\n");
        rtbComprobante.AppendText($"Factura N°: {_factura.ID_Factura:D6}\n");
        rtbComprobante.AppendText($"Fecha: {_factura.Fecha:dd/MM/yyyy}\n");
        rtbComprobante.AppendText($"Estado: {_factura.EstadoPago}\n\n");
        rtbComprobante.AppendText($"───────────────────────────────────────────────────────\n");
        rtbComprobante.AppendText($"DETALLES:\n");
        rtbComprobante.AppendText($"───────────────────────────────────────────────────────\n");
        
        decimal subtotal = 0;
        if (_factura.Detalles != null)
        {
            foreach (var detalle in _factura.Detalles)
            {
                rtbComprobante.AppendText($"Servicio ID: {detalle.ID_Servicio}\n");
                rtbComprobante.AppendText($"Cantidad: {detalle.Cantidad} x ${detalle.PrecioUnitario:F2}\n");
                rtbComprobante.AppendText($"Subtotal: ${detalle.Subtotal:F2}\n\n");
                subtotal += detalle.Subtotal;
            }
        }
        
        rtbComprobante.AppendText($"───────────────────────────────────────────────────────\n");
        rtbComprobante.AppendText($"TOTAL: ${_factura.Total:F2}\n");
        rtbComprobante.AppendText($"═══════════════════════════════════════════════════════\n");
        rtbComprobante.AppendText($"\nGracias por su preferencia\n");
        rtbComprobante.AppendText($"Veterinaria Genesis\n");
    }

    private void btnExportarPDF_Click(object? sender, EventArgs e)
    {
        try
        {
            using var saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                FileName = $"Comprobante_Factura_{_factura.ID_Factura:D6}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                ExportarAPDF(saveDialog.FileName);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al exportar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ExportarAPDF(string rutaArchivo)
    {
        try
        {
            // Método simple: guardar como texto formateado
            // Para PDF real, instalar: Install-Package iTextSharp o Install-Package QuestPDF
            // Por ahora, guardamos como texto formateado que puede abrirse en cualquier editor
            
            var contenido = rtbComprobante.Text;
            var archivoTxt = rutaArchivo.Replace(".pdf", ".txt");
            System.IO.File.WriteAllText(archivoTxt, contenido, System.Text.Encoding.UTF8);
            
            // Intentar abrir el archivo
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = archivoTxt,
                    UseShellExecute = true
                };
                Process.Start(processInfo);
            }
            catch
            {
                // Si no se puede abrir, solo mostrar el mensaje
            }
            
            MessageBox.Show($"Comprobante guardado como texto.\n\nPara generar PDF real, instala el paquete NuGet 'iTextSharp' o 'QuestPDF'.\n\nArchivo: {archivoTxt}", 
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

