#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
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
        ConfigurarDataGridViews();
        txtCantidad.Text = "1"; // Valor por defecto
        LimpiarDatosCita();
        
        // Suscribir evento una sola vez
        cmbCita.SelectedIndexChanged += CmbCita_SelectedIndexChanged;
        
        await CargarCitasAsync();
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBoxes con colores suaves
        gbxCrearFactura.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxDatosCita.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxAgregarItem.BackColor = Color.FromArgb(255, 255, 255); // Blanco
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
        
        btnCargarFacturas.BackColor = Color.FromArgb(255, 152, 0); // Naranja suave
        btnCargarFacturas.ForeColor = Color.White;
        btnCargarFacturas.FlatStyle = FlatStyle.Flat;
        btnCargarFacturas.FlatAppearance.BorderSize = 0;
        
        btnRecargarCitas.BackColor = Color.FromArgb(156, 39, 176); // Morado
        btnRecargarCitas.ForeColor = Color.White;
        btnRecargarCitas.FlatStyle = FlatStyle.Flat;
        btnRecargarCitas.FlatAppearance.BorderSize = 0;
        
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
            lblEstado.Text = "Cargando citas completadas sin factura...";
            lblEstado.ForeColor = Color.Blue;
            Application.DoEvents(); // Permitir que la UI se actualice
            
            // Usar el nuevo método que solo trae citas completadas sin factura
            var citasCompletadas = await _citaRepository.ListarCompletadasSinFacturaAsync();
            
            _citas = citasCompletadas;
            
            System.Diagnostics.Debug.WriteLine($"Citas completadas sin factura encontradas: {citasCompletadas.Count}");
            
            // Desconectar evento antes de modificar
            cmbCita.SelectedIndexChanged -= CmbCita_SelectedIndexChanged;
            
            if (citasCompletadas.Count == 0)
            {
                cmbCita.DataSource = null;
                cmbCita.Items.Clear();
                
                // Mostrar información útil
                var mensaje = "No hay citas completadas disponibles para generar factura.\n\n";
                mensaje += "Todas las citas completadas ya tienen factura asociada o no hay citas completadas.";
                
                lblEstado.Text = mensaje;
                lblEstado.ForeColor = Color.Orange;
                
                // Reconectar evento
                cmbCita.SelectedIndexChanged += CmbCita_SelectedIndexChanged;
                return;
            }
            
            // Crear lista de objetos anónimos para el ComboBox
            var itemsCombo = citasCompletadas.Select(c => new { 
                ID = c.ID_Cita, 
                Descripcion = $"{c.Mascota ?? "N/A"} - {c.Fecha:dd/MM/yyyy} {c.Hora:hh\\:mm} - {c.Propietario ?? "N/A"}" 
            }).ToList();
            
            // Configurar el ComboBox
            cmbCita.DataSource = null; // Limpiar primero
            cmbCita.Items.Clear();
            cmbCita.DataSource = itemsCombo;
            cmbCita.DisplayMember = "Descripcion";
            cmbCita.ValueMember = "ID";
            cmbCita.SelectedIndex = -1;
            
            // Reconectar evento DESPUÉS de configurar todo
            cmbCita.SelectedIndexChanged += CmbCita_SelectedIndexChanged;
            
            lblEstado.Text = $"✓ Cargadas {citasCompletadas.Count} cita(s) completada(s) sin factura";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            var mensajeError = $"Error al cargar citas: {ex.Message}";
            if (ex.InnerException != null)
            {
                mensajeError += $"\n\nDetalle: {ex.InnerException.Message}";
            }
            
            MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = $"Error: {ex.Message}";
            lblEstado.ForeColor = Color.Red;
            
            // Asegurar que el ComboBox esté limpio
            cmbCita.SelectedIndexChanged -= CmbCita_SelectedIndexChanged;
            cmbCita.DataSource = null;
            cmbCita.Items.Clear();
            cmbCita.SelectedIndexChanged += CmbCita_SelectedIndexChanged;
        }
    }

    private void CmbCita_SelectedIndexChanged(object? sender, EventArgs e)
    {
        // Verificar que hay una selección válida
        if (cmbCita.SelectedIndex < 0 || cmbCita.SelectedItem == null)
        {
            LimpiarDatosCita();
            return;
        }

        try
        {
            // Obtener el ID de la cita seleccionada
            int citaIdInt = -1;
            
            // Intentar obtener el valor usando SelectedValue (método preferido)
            if (cmbCita.SelectedValue != null)
            {
                if (int.TryParse(cmbCita.SelectedValue.ToString(), out citaIdInt))
                {
                    // Valor obtenido correctamente
                }
                else if (cmbCita.SelectedValue is int idDirecto)
                {
                    citaIdInt = idDirecto;
                }
            }
            
            // Si no funcionó SelectedValue, intentar con reflexión
            if (citaIdInt == -1 && cmbCita.SelectedItem != null)
            {
                var tipo = cmbCita.SelectedItem.GetType();
                var propId = tipo.GetProperty("ID");
                if (propId != null)
                {
                    var valor = propId.GetValue(cmbCita.SelectedItem);
                    if (valor != null && int.TryParse(valor.ToString(), out var id))
                    {
                        citaIdInt = id;
                    }
                }
            }
            
            // Si aún no tenemos el ID, salir
            if (citaIdInt == -1)
            {
                LimpiarDatosCita();
                lblEstado.Text = "No se pudo obtener el ID de la cita seleccionada";
                lblEstado.ForeColor = Color.Red;
                return;
            }
            
            // Buscar la cita en la lista
            var cita = _citas.FirstOrDefault(c => c.ID_Cita == citaIdInt);
            if (cita != null)
            {
                // Auto-rellenar datos del propietario y mascota
                txtPropietario.Text = cita.Propietario ?? "N/A";
                txtMascota.Text = cita.Mascota ?? "N/A";
                txtVeterinario.Text = cita.Veterinario ?? "N/A";
                txtServicio.Text = cita.Servicio ?? "N/A";
                txtFechaCita.Text = $"{cita.Fecha:dd/MM/yyyy} {cita.Hora:hh\\:mm}";
                
                lblEstado.Text = $"Cita seleccionada: {cita.Mascota ?? "N/A"} - ID: {cita.ID_Cita}";
                lblEstado.ForeColor = Color.Green;
            }
            else
            {
                LimpiarDatosCita();
                lblEstado.Text = $"No se encontraron los datos de la cita ID: {citaIdInt}";
                lblEstado.ForeColor = Color.Orange;
            }
        }
        catch (Exception ex)
        {
            LimpiarDatosCita();
            lblEstado.Text = $"Error al cargar datos: {ex.Message}";
            lblEstado.ForeColor = Color.Red;
            MessageBox.Show($"Error al cargar datos de la cita: {ex.Message}\n\nDetalles: {ex}", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnRecargarCitas_Click(object? sender, EventArgs e)
    {
        btnRecargarCitas.Enabled = false;
        try
        {
            await CargarCitasAsync();
        }
        finally
        {
            btnRecargarCitas.Enabled = true;
        }
    }

    private void LimpiarDatosCita()
    {
        txtPropietario.Clear();
        txtMascota.Clear();
        txtVeterinario.Clear();
        txtServicio.Clear();
        txtFechaCita.Clear();
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
            
            var prop = citaItem.GetType().GetProperty("ID");
            if (prop == null)
            {
                MessageBox.Show("Error al obtener el ID de la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var citaIdValue = prop.GetValue(citaItem);
            if (citaIdValue == null || !int.TryParse(citaIdValue.ToString(), out var idCita))
            {
                MessageBox.Show("Error al obtener el ID de la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            CalcularTotal();
            
            // Recargar historial de facturas
            btnCargarFacturas_Click(sender, e);
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



    private async Task CargarFacturaAsync(int idFactura)
    {
        try
        {
            _facturaSeleccionada = await _facturaRepository.BuscarPorIDAsync(idFactura);
            if (_facturaSeleccionada != null)
            {
                ActualizarVistaFactura();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void DgvFacturas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvFacturas.SelectedRows.Count > 0 && dgvFacturas.SelectedRows[0] != null)
        {
            var cell = dgvFacturas.SelectedRows[0].Cells["ID_Factura"];
            if (cell?.Value != null && int.TryParse(cell.Value.ToString(), out var id))
            {
                // Recargar la factura desde la base de datos para obtener el estado actualizado
                await CargarFacturaAsync(id);
            }
        }
        else
        {
            _facturaSeleccionada = null;
            ActualizarVistaFactura();
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
        dgvDetalles.DataSource = _facturaSeleccionada.Detalles ?? new List<FacturaDetalleDto>();

        // Calcular totales
        _subtotal = (_facturaSeleccionada.Detalles ?? new List<FacturaDetalleDto>()).Sum(d => d.Subtotal);
        _total = _facturaSeleccionada.Total;

        lblSubtotal.Text = $"Subtotal: ${_subtotal:F2}";
        lblTotal.Text = $"Total: ${_total:F2}";
        lblEstadoFactura.Text = $"Estado: {_facturaSeleccionada.EstadoPago}";
    }

    private void CalcularTotal()
    {
        if (_facturaSeleccionada != null)
        {
            _subtotal = (_facturaSeleccionada.Detalles ?? new List<FacturaDetalleDto>()).Sum(d => d.Subtotal);
            _total = _facturaSeleccionada.Total;
            lblSubtotal.Text = $"Subtotal: ${_subtotal:F2}";
            lblTotal.Text = $"Total: ${_total:F2}";
        }
    }

    private void txtCantidad_TextChanged(object? sender, EventArgs e)
    {
        // Calcular subtotal cuando cambia la cantidad (si hay precio unitario)
        // Esto se puede mejorar cuando tengamos acceso al precio del servicio
    }

    private async void btnCargarFacturas_Click(object? sender, EventArgs e)
    {
        await RecargarListaFacturasAsync();
    }

    private async Task RecargarListaFacturasAsync()
    {
        try
        {
            btnCargarFacturas.Enabled = false;
            lblEstado.Text = "Cargando facturas...";
            lblEstado.ForeColor = Color.Blue;
            Application.DoEvents(); // Permitir que la UI se actualice

            // Limpiar la lista anterior para forzar recarga
            _facturas.Clear();
            dgvFacturas.DataSource = null;

            // Recargar desde la base de datos
            _facturas = await _facturaRepository.ListarAsync();
            dgvFacturas.DataSource = _facturas;

            // Si había una factura seleccionada, recargarla también
            if (_facturaSeleccionada != null)
            {
                var idFactura = _facturaSeleccionada.ID_Factura;
                await CargarFacturaAsync(idFactura);
            }

            lblEstado.Text = $"Se cargaron {_facturas.Count} factura(s)";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al cargar facturas";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnCargarFacturas.Enabled = true;
        }
    }
}

