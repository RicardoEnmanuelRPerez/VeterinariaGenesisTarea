#nullable enable
using ClosedXML.Excel;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class FacturasForm : Form
{
    private readonly IFacturaRepository _facturaRepository;
    private readonly ICitaRepository _citaRepository;
    private List<CitaDto> _citas = new();
    private List<FacturaDto> _facturas = new();
    private FacturaDto? _facturaSeleccionada;
    private decimal _subtotal = 0;
    private decimal _total = 0;

    public FacturasForm(IFacturaRepository facturaRepository, ICitaRepository citaRepository)
    {
        InitializeComponent();
        _facturaRepository = facturaRepository;
        _citaRepository = citaRepository;
    }

    private async void FacturasForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        await CargarCitasAsync();
        ConfigurarComboBoxes();
        ConfigurarDataGridViews();
        txtCantidad.Text = "1"; // Valor por defecto
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBoxes con colores suaves
        gbxCrearFactura.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxAgregarItem.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxPagar.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxHistorial.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxDetalles.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
        // Botones con colores temáticos
        btnCrearFactura.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnCrearFactura.ForeColor = Color.White;
        btnCrearFactura.FlatStyle = FlatStyle.Flat;
        btnCrearFactura.FlatAppearance.BorderSize = 0;
        
        btnAgregarItem.BackColor = Color.FromArgb(33, 150, 243); // Azul
        btnAgregarItem.ForeColor = Color.White;
        btnAgregarItem.FlatStyle = FlatStyle.Flat;
        btnAgregarItem.FlatAppearance.BorderSize = 0;
        
        btnPagar.BackColor = Color.FromArgb(156, 39, 176); // Morado suave
        btnPagar.ForeColor = Color.White;
        btnPagar.FlatStyle = FlatStyle.Flat;
        btnPagar.FlatAppearance.BorderSize = 0;
        
        btnCargarFacturas.BackColor = Color.FromArgb(255, 152, 0); // Naranja suave
        btnCargarFacturas.ForeColor = Color.White;
        btnCargarFacturas.FlatStyle = FlatStyle.Flat;
        btnCargarFacturas.FlatAppearance.BorderSize = 0;
        
        // DataGridViews con colores alternados suaves
        dgvFacturas.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvFacturas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvFacturas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(156, 39, 176);
        dgvFacturas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvFacturas.EnableHeadersVisualStyles = false;
        
        dgvDetalles.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvDetalles.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvDetalles.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
        dgvDetalles.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvDetalles.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvDetalles.EnableHeadersVisualStyles = false;
        
        // Labels de totales con colores destacados
        lblTotal.ForeColor = Color.FromArgb(27, 94, 32); // Verde oscuro
        lblSubtotal.ForeColor = Color.FromArgb(33, 150, 243); // Azul
    }

    private void ConfigurarComboBoxes()
    {
        cmbMetodoPago.Items.Clear();
        cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta de Crédito", "Tarjeta de Débito", "Transferencia Bancaria", "Cheque" });
    }

    private void ConfigurarDataGridViews()
    {
        dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvFacturas.AllowUserToAddRows = false;
        dgvFacturas.ReadOnly = true;
        dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvFacturas.SelectionChanged += DgvFacturas_SelectionChanged;

        dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvDetalles.AllowUserToAddRows = false;
        dgvDetalles.ReadOnly = true;
        dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private async Task CargarCitasAsync()
    {
        try
        {
            _citas = await _citaRepository.ListarPorFechaAsync(DateTime.Today);
            cmbCita.DataSource = _citas.Where(c => c.Estado == "Completada").Select(c => new { 
                ID = c.ID_Cita, 
                Descripcion = $"{c.Mascota} - {c.Fecha:dd/MM/yyyy} {c.Hora:hh\\:mm}" 
            }).ToList();
            cmbCita.DisplayMember = "Descripcion";
            cmbCita.ValueMember = "ID";
            cmbCita.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar citas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnCrearFactura_Click(object? sender, EventArgs e)
    {
        try
        {
            if (cmbCita.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar una cita completada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var citaItem = cmbCita.SelectedItem;
            if (citaItem == null)
            {
                MessageBox.Show("Debe seleccionar una cita completada.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var citaId = citaItem.GetType().GetProperty("ID")?.GetValue(citaItem);
            if (citaId == null || !(citaId is int citaIdInt))
            {
                MessageBox.Show("Error al obtener el ID de la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var idCita = citaIdInt;

            var dto = new FacturaCreateDto { ID_Cita = idCita };

            btnCrearFactura.Enabled = false;
            lblEstado.Text = "Creando factura...";
            lblEstado.ForeColor = Color.Blue;

            var idFactura = await _facturaRepository.CrearDesdeCitaAsync(dto);
            MessageBox.Show($"Factura creada exitosamente. ID: {idFactura}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Cargar la factura recién creada
            await CargarFacturaAsync(idFactura);
            await CargarCitasAsync();
            
            // Preparar para agregar items
            txtIDFactura.Text = idFactura.ToString();
            txtIDFacturaPago.Text = idFactura.ToString();
            CalcularTotal();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnCrearFactura.Enabled = true;
        }
    }

    private async void btnAgregarItem_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtIDFactura.Text) || !int.TryParse(txtIDFactura.Text, out var idFactura))
            {
                MessageBox.Show("Debe ingresar un ID de factura válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIDServicioItem.Text) || !int.TryParse(txtIDServicioItem.Text, out var idServicio))
            {
                MessageBox.Show("Debe ingresar un ID de servicio válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out var cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new FacturaItemDto
            {
                ID_Factura = idFactura,
                ID_Servicio = idServicio,
                Cantidad = cantidad
            };

            btnAgregarItem.Enabled = false;
            lblEstado.Text = "Agregando item...";
            lblEstado.ForeColor = Color.Blue;

            await _facturaRepository.AgregarItemAsync(dto);
            MessageBox.Show("Item agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Recargar la factura para actualizar totales
            await CargarFacturaAsync(idFactura);
            CalcularTotal();
            
            // Limpiar campos de item
            txtIDServicioItem.Clear();
            txtCantidad.Text = "1";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al agregar item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnAgregarItem.Enabled = true;
        }
    }

    private async void btnPagar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtIDFacturaPago.Text) || !int.TryParse(txtIDFacturaPago.Text, out var idFactura))
            {
                MessageBox.Show("Debe ingresar un ID de factura válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            var dto = new FacturaPagoDto
            {
                ID_Factura = idFactura,
                MontoPagado = monto,
                MetodoPago = cmbMetodoPago.Text
            };

            btnPagar.Enabled = false;
            lblEstado.Text = "Procesando pago...";
            lblEstado.ForeColor = Color.Blue;

            await _facturaRepository.PagarAsync(dto);
            MessageBox.Show($"Pago de ${monto:F2} procesado exitosamente mediante {dto.MetodoPago}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Recargar la factura para actualizar estado
            await CargarFacturaAsync(idFactura);
            LimpiarFormularioPago();
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

    private void LimpiarFormularioPago()
    {
        txtMonto.Clear();
        cmbMetodoPago.SelectedIndex = -1;
        // No limpiar txtIDFacturaPago para mantener la factura seleccionada
    }

    private async Task CargarFacturaAsync(int idFactura)
    {
        try
        {
            // Por ahora, solo actualizamos la factura seleccionada si ya la tenemos
            // En el futuro, podríamos agregar un endpoint para obtener factura por ID
            if (_facturaSeleccionada != null && _facturaSeleccionada.ID_Factura == idFactura)
            {
                // Recargar detalles si es posible
                ActualizarVistaFactura();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DgvFacturas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvFacturas.SelectedRows.Count > 0 && dgvFacturas.SelectedRows[0] != null)
        {
            var cell = dgvFacturas.SelectedRows[0].Cells["ID_Factura"];
            if (cell?.Value != null && cell.Value is int id)
            {
                _facturaSeleccionada = _facturas.FirstOrDefault(f => f.ID_Factura == id);
                ActualizarVistaFactura();
            }
        }
    }

    private void ActualizarVistaFactura()
    {
        if (_facturaSeleccionada == null)
        {
            dgvDetalles.DataSource = null;
            lblSubtotal.Text = "Subtotal: $0.00";
            lblTotal.Text = "Total: $0.00";
            lblEstadoFactura.Text = "";
            return;
        }

        // Mostrar detalles
        dgvDetalles.DataSource = _facturaSeleccionada.Detalles;

        // Calcular totales
        _subtotal = _facturaSeleccionada.Detalles.Sum(d => d.Subtotal);
        _total = _facturaSeleccionada.Total;

        lblSubtotal.Text = $"Subtotal: ${_subtotal:F2}";
        lblTotal.Text = $"Total: ${_total:F2}";
        lblEstadoFactura.Text = $"Estado: {_facturaSeleccionada.EstadoPago}";

        // Actualizar campos de pago
        txtIDFacturaPago.Text = _facturaSeleccionada.ID_Factura.ToString();
        txtMonto.Text = _total.ToString("F2");
        
        // Si ya está pagada, deshabilitar pago
        btnPagar.Enabled = _facturaSeleccionada.EstadoPago != "Pagada";
    }

    private void CalcularTotal()
    {
        if (_facturaSeleccionada != null)
        {
            _subtotal = _facturaSeleccionada.Detalles.Sum(d => d.Subtotal);
            _total = _facturaSeleccionada.Total;
            lblSubtotal.Text = $"Subtotal: ${_subtotal:F2}";
            lblTotal.Text = $"Total: ${_total:F2}";
            txtMonto.Text = _total.ToString("F2");
        }
    }

    private void txtCantidad_TextChanged(object? sender, EventArgs e)
    {
        // Calcular subtotal cuando cambia la cantidad (si hay precio unitario)
        // Esto se puede mejorar cuando tengamos acceso al precio del servicio
    }

    private async void btnCargarFacturas_Click(object? sender, EventArgs e)
    {
        // Por ahora, este método se puede usar para recargar facturas
        // En el futuro, cuando tengamos un endpoint para listar facturas, lo implementaremos aquí
        MessageBox.Show("Funcionalidad de historial de facturas próximamente disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

