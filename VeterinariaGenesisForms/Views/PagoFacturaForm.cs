#nullable enable
using System.Collections.Generic;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class PagoFacturaForm : Form
{
    private readonly IFacturaRepository _facturaRepository;
    private FacturaDto? _facturaSeleccionada;

    public PagoFacturaForm(IFacturaRepository facturaRepository)
    {
        InitializeComponent();
        _facturaRepository = facturaRepository;
    }

    private void PagoFacturaForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        ConfigurarComboBox();
        txtIDFactura.TextChanged += TxtIDFactura_TextChanged;
    }

    private void AplicarColoresVeterinaria()
    {
        this.BackColor = Color.FromArgb(245, 250, 247);
        gbxDatos.BackColor = Color.FromArgb(255, 255, 255);
        gbxPago.BackColor = Color.FromArgb(255, 255, 255);
        
        btnBuscar.BackColor = Color.FromArgb(255, 152, 0);
        btnBuscar.ForeColor = Color.White;
        btnBuscar.FlatStyle = FlatStyle.Flat;
        btnBuscar.FlatAppearance.BorderSize = 0;
        
        btnPagar.BackColor = Color.FromArgb(156, 39, 176);
        btnPagar.ForeColor = Color.White;
        btnPagar.FlatStyle = FlatStyle.Flat;
        btnPagar.FlatAppearance.BorderSize = 0;
        
        btnVerComprobante.BackColor = Color.FromArgb(76, 175, 80);
        btnVerComprobante.ForeColor = Color.White;
        btnVerComprobante.FlatStyle = FlatStyle.Flat;
        btnVerComprobante.FlatAppearance.BorderSize = 0;
    }

    private void ConfigurarComboBox()
    {
        cmbMetodoPago.Items.Clear();
        cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta de Crédito", "Tarjeta de Débito", "Transferencia Bancaria", "Cheque" });
    }

    private async void TxtIDFactura_TextChanged(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIDFactura.Text) || !int.TryParse(txtIDFactura.Text, out var id))
        {
            LimpiarDatos();
            return;
        }

        await CargarFacturaAsync(id);
    }

    private async void btnBuscar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIDFactura.Text) || !int.TryParse(txtIDFactura.Text, out var id))
        {
            MessageBox.Show("Debe ingresar un ID de factura válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        await CargarFacturaAsync(id);
    }

    private async Task CargarFacturaAsync(int id)
    {
        try
        {
            btnBuscar.Enabled = false;
            lblEstado.Text = "Cargando factura...";
            lblEstado.ForeColor = Color.Blue;

            _facturaSeleccionada = await _facturaRepository.BuscarPorIDAsync(id);
            
            if (_facturaSeleccionada == null)
            {
                MessageBox.Show("Factura no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarDatos();
                return;
            }

            // Mostrar datos de la factura
            txtFecha.Text = _facturaSeleccionada.Fecha.ToString("dd/MM/yyyy");
            txtTotal.Text = _facturaSeleccionada.Total.ToString("F2");
            txtEstado.Text = _facturaSeleccionada.EstadoPago;
            txtMonto.Text = _facturaSeleccionada.Total.ToString("F2");

            // Configurar DataGridView de detalles
            dgvDetalles.DataSource = _facturaSeleccionada.Detalles ?? new List<FacturaDetalleDto>();

            // Habilitar/deshabilitar pago según estado (comparación case-insensitive)
            bool puedePagar = string.Equals(_facturaSeleccionada.EstadoPago?.Trim(), "Pendiente", StringComparison.OrdinalIgnoreCase);
            btnPagar.Enabled = puedePagar;
            cmbMetodoPago.Enabled = puedePagar;
            txtMonto.Enabled = puedePagar;
            btnVerComprobante.Enabled = string.Equals(_facturaSeleccionada.EstadoPago?.Trim(), "Pagada", StringComparison.OrdinalIgnoreCase);

            lblEstado.Text = "Factura cargada exitosamente";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al cargar factura";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnBuscar.Enabled = true;
        }
    }

    private async void btnPagar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_facturaSeleccionada == null)
            {
                MessageBox.Show("Debe cargar una factura primero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out var monto) || monto <= 0)
            {
                MessageBox.Show("Debe ingresar un monto válido mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMetodoPago.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Normalizar el método de pago para que coincida con los valores de la base de datos
            string metodoPagoNormalizado = NormalizarMetodoPago(cmbMetodoPago.Text);

            var dto = new FacturaPagoDto
            {
                ID_Factura = _facturaSeleccionada.ID_Factura,
                MontoPagado = monto,
                MetodoPago = metodoPagoNormalizado
            };

            btnPagar.Enabled = false;
            lblEstado.Text = "Procesando pago...";
            lblEstado.ForeColor = Color.Blue;

            await _facturaRepository.PagarAsync(dto);
            MessageBox.Show($"Pago de ${monto:F2} procesado exitosamente mediante {dto.MetodoPago}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Esperar un momento para asegurar que la transacción se complete
            await Task.Delay(100);
            
            // Recargar la factura para actualizar estado (forzar recarga desde BD)
            var idFactura = _facturaSeleccionada.ID_Factura;
            _facturaSeleccionada = null; // Limpiar caché
            await CargarFacturaAsync(idFactura);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al procesar pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnPagar.Enabled = true;
        }
    }

    private void btnVerComprobante_Click(object? sender, EventArgs e)
    {
        if (_facturaSeleccionada == null || !string.Equals(_facturaSeleccionada.EstadoPago?.Trim(), "Pagada", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Solo se pueden ver comprobantes de facturas pagadas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Abrir formulario de comprobante PDF
        var comprobanteForm = new ComprobanteFacturaForm(_facturaSeleccionada);
        comprobanteForm.ShowDialog();
    }

    private void LimpiarDatos()
    {
        _facturaSeleccionada = null;
        txtFecha.Clear();
        txtTotal.Clear();
        txtEstado.Clear();
        txtMonto.Clear();
        cmbMetodoPago.SelectedIndex = -1;
        dgvDetalles.DataSource = null;
        btnPagar.Enabled = false;
        btnVerComprobante.Enabled = false;
    }

    /// <summary>
    /// Normaliza el método de pago del formulario a los valores aceptados por la base de datos.
    /// La BD acepta: 'Efectivo', 'Tarjeta', 'Transferencia'
    /// </summary>
    private string NormalizarMetodoPago(string metodoPago)
    {
        if (string.IsNullOrWhiteSpace(metodoPago))
            return "Efectivo"; // Valor por defecto

        // Normalizar a minúsculas para comparación case-insensitive
        var metodo = metodoPago.Trim().ToLowerInvariant();

        // Mapear los valores del formulario a los valores de la BD
        if (metodo.Contains("efectivo"))
            return "Efectivo";
        
        if (metodo.Contains("tarjeta") || metodo.Contains("crédito") || metodo.Contains("credito") || metodo.Contains("débito") || metodo.Contains("debito"))
            return "Tarjeta";
        
        if (metodo.Contains("transferencia") || metodo.Contains("bancaria"))
            return "Transferencia";
        
        if (metodo.Contains("cheque"))
            return "Efectivo"; // Mapear Cheque a Efectivo como alternativa

        // Si no coincide con ninguno, retornar el valor original (puede causar error, pero mejor que fallar silenciosamente)
        return metodoPago.Trim();
    }
}

