#nullable enable
using ClosedXML.Excel;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class ServiciosForm : Form
{
    private readonly IServicioRepository _servicioRepository;
    private List<ServicioDto> _servicios = new();
    private ServicioDto? _servicioSeleccionado;

    public ServiciosForm(IServicioRepository servicioRepository)
    {
        InitializeComponent();
        _servicioRepository = servicioRepository;
    }

    private async void ServiciosForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        await CargarServiciosAsync();
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBoxes con colores suaves
        gbxDatos.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
        // Botones principales con colores temáticos
        btnNuevo.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnNuevo.ForeColor = Color.White;
        btnNuevo.FlatStyle = FlatStyle.Flat;
        btnNuevo.FlatAppearance.BorderSize = 0;
        
        btnActualizar.BackColor = Color.FromArgb(33, 150, 243); // Azul
        btnActualizar.ForeColor = Color.White;
        btnActualizar.FlatStyle = FlatStyle.Flat;
        btnActualizar.FlatAppearance.BorderSize = 0;
        
        btnEliminar.BackColor = Color.FromArgb(244, 67, 54); // Rojo suave
        btnEliminar.ForeColor = Color.White;
        btnEliminar.FlatStyle = FlatStyle.Flat;
        btnEliminar.FlatAppearance.BorderSize = 0;
        
        btnLimpiar.BackColor = Color.FromArgb(158, 158, 158); // Gris
        btnLimpiar.ForeColor = Color.White;
        btnLimpiar.FlatStyle = FlatStyle.Flat;
        btnLimpiar.FlatAppearance.BorderSize = 0;
        
        btnCargar.BackColor = Color.FromArgb(255, 152, 0); // Naranja suave
        btnCargar.ForeColor = Color.White;
        btnCargar.FlatStyle = FlatStyle.Flat;
        btnCargar.FlatAppearance.BorderSize = 0;
        
        btnExportarExcel.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnExportarExcel.ForeColor = Color.White;
        btnExportarExcel.FlatStyle = FlatStyle.Flat;
        btnExportarExcel.FlatAppearance.BorderSize = 0;
        
        // DataGridView con colores alternados suaves
        dgvServicios.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvServicios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvServicios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
        dgvServicios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvServicios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvServicios.EnableHeadersVisualStyles = false;
    }

    private async Task CargarServiciosAsync()
    {
        try
        {
            btnCargar.Enabled = false;
            lblEstado.Text = "Cargando servicios...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            _servicios = await _servicioRepository.ListarAsync();
            dgvServicios.DataSource = _servicios;
            ConfigurarDataGridView();

            lblEstado.Text = $"Se cargaron {_servicios.Count} servicios";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar servicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al cargar datos";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnCargar.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private void ConfigurarDataGridView()
    {
        dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvServicios.AllowUserToAddRows = false;
        dgvServicios.ReadOnly = true;
        dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvServicios.SelectionChanged += DgvServicios_SelectionChanged;
    }

    private void DgvServicios_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvServicios.SelectedRows.Count > 0 && dgvServicios.SelectedRows[0] != null)
        {
            var cell = dgvServicios.SelectedRows[0].Cells["ID_Servicio"];
            if (cell?.Value != null && cell.Value is int id)
            {
                _servicioSeleccionado = _servicios.FirstOrDefault(s => s.ID_Servicio == id);
                if (_servicioSeleccionado != null)
                {
                    CargarDatosEnFormulario(_servicioSeleccionado);
                }
            }
        }
    }

    private void CargarDatosEnFormulario(ServicioDto servicio)
    {
        txtID.Text = servicio.ID_Servicio.ToString();
        txtNombre.Text = servicio.Nombre;
        txtDescripcion.Text = servicio.Descripcion ?? "";
        txtCosto.Text = servicio.Costo.ToString("F2");
    }

    private void LimpiarFormulario()
    {
        txtID.Clear();
        txtNombre.Clear();
        txtDescripcion.Clear();
        txtCosto.Clear();
        _servicioSeleccionado = null;
        dgvServicios.ClearSelection();
    }

    private async void btnNuevo_Click(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del servicio es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (!decimal.TryParse(txtCosto.Text, out var costo) || costo < 0)
            {
                MessageBox.Show("Debe ingresar un costo válido (mayor o igual a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return;
            }

            var dto = new ServicioCreateDto
            {
                Nombre = txtNombre.Text.Trim(),
                Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
                Costo = costo
            };

            btnNuevo.Enabled = false;
            lblEstado.Text = "Creando servicio...";
            lblEstado.ForeColor = Color.Blue;

            await _servicioRepository.CrearAsync(dto);
            MessageBox.Show("Servicio creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            LimpiarFormulario();
            await CargarServiciosAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnNuevo.Enabled = true;
        }
    }

    private async void btnActualizar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_servicioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un servicio para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del servicio es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (!decimal.TryParse(txtCosto.Text, out var costo) || costo < 0)
            {
                MessageBox.Show("Debe ingresar un costo válido (mayor o igual a 0).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCosto.Focus();
                return;
            }

            var dto = new ServicioUpdateDto
            {
                ID_Servicio = _servicioSeleccionado.ID_Servicio,
                Nombre = txtNombre.Text.Trim(),
                Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
                Costo = costo
            };

            btnActualizar.Enabled = false;
            lblEstado.Text = "Actualizando servicio...";
            lblEstado.ForeColor = Color.Blue;

            await _servicioRepository.ActualizarAsync(dto);
            MessageBox.Show("Servicio actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            await CargarServiciosAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnActualizar.Enabled = true;
        }
    }

    private async void btnEliminar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_servicioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un servicio para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"¿Está seguro de eliminar el servicio '{_servicioSeleccionado.Nombre}'?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                btnEliminar.Enabled = false;
                lblEstado.Text = "Eliminando servicio...";
                lblEstado.ForeColor = Color.Blue;

                await _servicioRepository.EliminarAsync(_servicioSeleccionado.ID_Servicio);
                MessageBox.Show("Servicio eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LimpiarFormulario();
                await CargarServiciosAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnEliminar.Enabled = true;
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        LimpiarFormulario();
        lblEstado.Text = "Formulario limpiado";
        lblEstado.ForeColor = Color.Gray;
    }

    private async void btnCargar_Click(object? sender, EventArgs e)
    {
        await CargarServiciosAsync();
    }

    private void btnExportarExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_servicios.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"Servicios_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Servicios");

                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Descripción";
                worksheet.Cell(1, 4).Value = "Costo";

                var headerRange = worksheet.Range(1, 1, 1, 4);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightYellow;

                for (int i = 0; i < _servicios.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _servicios[i].ID_Servicio;
                    worksheet.Cell(row, 2).Value = _servicios[i].Nombre;
                    worksheet.Cell(row, 3).Value = _servicios[i].Descripcion ?? "";
                    worksheet.Cell(row, 4).Value = _servicios[i].Costo;
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(saveDialog.FileName);
                MessageBox.Show($"Datos exportados exitosamente a:\n{saveDialog.FileName}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

