#nullable enable
using ClosedXML.Excel;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class PropietariosForm : Form
{
    private readonly IPropietarioRepository _propietarioRepository;
    private readonly IMascotaRepository _mascotaRepository;
    private List<PropietarioDto> _propietarios = new();
    private List<MascotaDto> _mascotas = new();
    private PropietarioDto? _propietarioSeleccionado;
    private MascotaDto? _mascotaSeleccionada;

    public PropietariosForm(IPropietarioRepository propietarioRepository, IMascotaRepository mascotaRepository)
    {
        InitializeComponent();
        _propietarioRepository = propietarioRepository;
        _mascotaRepository = mascotaRepository;
    }

    private async void PropietariosForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        await CargarPropietariosAsync();
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBoxes con colores suaves
        gbxDatos.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxMascotas.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
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
        
        // Botones de mascotas
        btnMascotaNuevo.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnMascotaNuevo.ForeColor = Color.White;
        btnMascotaNuevo.FlatStyle = FlatStyle.Flat;
        btnMascotaNuevo.FlatAppearance.BorderSize = 0;
        
        btnMascotaActualizar.BackColor = Color.FromArgb(33, 150, 243); // Azul
        btnMascotaActualizar.ForeColor = Color.White;
        btnMascotaActualizar.FlatStyle = FlatStyle.Flat;
        btnMascotaActualizar.FlatAppearance.BorderSize = 0;
        
        btnMascotaEliminar.BackColor = Color.FromArgb(244, 67, 54); // Rojo suave
        btnMascotaEliminar.ForeColor = Color.White;
        btnMascotaEliminar.FlatStyle = FlatStyle.Flat;
        btnMascotaEliminar.FlatAppearance.BorderSize = 0;
        
        btnMascotaLimpiar.BackColor = Color.FromArgb(158, 158, 158); // Gris
        btnMascotaLimpiar.ForeColor = Color.White;
        btnMascotaLimpiar.FlatStyle = FlatStyle.Flat;
        btnMascotaLimpiar.FlatAppearance.BorderSize = 0;
        
        // DataGridView con colores alternados suaves
        dgvPropietarios.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvPropietarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvPropietarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
        dgvPropietarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvPropietarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvPropietarios.EnableHeadersVisualStyles = false;
        
        dgvMascotas.BackgroundColor = Color.FromArgb(250, 250, 250);
        dgvMascotas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
        dgvMascotas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
        dgvMascotas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvMascotas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        dgvMascotas.EnableHeadersVisualStyles = false;
    }

    private async Task CargarPropietariosAsync()
    {
        try
        {
            btnCargar.Enabled = false;
            lblEstado.Text = "Cargando propietarios...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            _propietarios = await _propietarioRepository.ListarActivosAsync();
            dgvPropietarios.DataSource = _propietarios;
            ConfigurarDataGridView();

            lblEstado.Text = $"Se encontraron {_propietarios.Count} propietarios activos";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar propietarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        dgvPropietarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvPropietarios.AllowUserToAddRows = false;
        dgvPropietarios.ReadOnly = true;
        dgvPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPropietarios.SelectionChanged += DgvPropietarios_SelectionChanged;
    }

    private void DgvPropietarios_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvPropietarios.SelectedRows.Count > 0 && dgvPropietarios.SelectedRows[0] != null)
        {
            var cell = dgvPropietarios.SelectedRows[0].Cells["ID_Propietario"];
            if (cell?.Value != null && cell.Value is int id)
            {
                _propietarioSeleccionado = _propietarios.FirstOrDefault(p => p.ID_Propietario == id);
                CargarDatosEnFormulario();
            }
        }
    }

    private void CargarDatosEnFormulario()
    {
        if (_propietarioSeleccionado == null)
        {
            LimpiarFormulario();
            LimpiarFormularioMascota();
            return;
        }

        txtID.Text = _propietarioSeleccionado.ID_Propietario.ToString();
        txtNombre.Text = _propietarioSeleccionado.Nombre;
        txtApellidos.Text = _propietarioSeleccionado.Apellidos;
        txtDireccion.Text = _propietarioSeleccionado.Direccion ?? "";
        txtTelefono.Text = _propietarioSeleccionado.Telefono ?? "";

        // Cargar mascotas del propietario
        CargarMascotasAsync(_propietarioSeleccionado.ID_Propietario);
    }

    private void LimpiarFormulario()
    {
        txtID.Clear();
        txtNombre.Clear();
        txtApellidos.Clear();
        txtDireccion.Clear();
        txtTelefono.Clear();
    }

    private async void btnNuevo_Click(object? sender, EventArgs e)
    {
        try
        {
            // Si no hay datos en el formulario, preparar modo nuevo
            if (string.IsNullOrWhiteSpace(txtNombre.Text) && string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                PrepararModoNuevo();
                return;
            }

            // Validar datos antes de crear
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("El nombre y apellidos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            var dto = new PropietarioCreateDto
            {
                Nombre = txtNombre.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
            };

            btnNuevo.Enabled = false;
            lblEstado.Text = "Creando propietario...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            await _propietarioRepository.CrearAsync(dto);
            MessageBox.Show($"Propietario '{dto.Nombre} {dto.Apellidos}' creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            PrepararModoNuevo();
            await CargarPropietariosAsync();
            
            // Después de crear, seleccionar el nuevo propietario y permitir agregar mascotas
            var nuevoPropietario = _propietarios.FirstOrDefault(p => 
                p.Nombre == dto.Nombre && p.Apellidos == dto.Apellidos);
            if (nuevoPropietario != null)
            {
                _propietarioSeleccionado = nuevoPropietario;
                CargarDatosEnFormulario();
                var resultado = MessageBox.Show(
                    $"¿Desea registrar mascotas para {dto.Nombre} {dto.Apellidos} ahora?",
                    "Registrar Mascotas",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    txtMascotaNombre.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al crear propietario";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnNuevo.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private async void btnActualizar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_propietarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un propietario para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("El nombre y apellidos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new PropietarioUpdateDto
            {
                ID_Propietario = _propietarioSeleccionado.ID_Propietario,
                Nombre = txtNombre.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim()
            };

            btnActualizar.Enabled = false;
            lblEstado.Text = "Actualizando propietario...";
            lblEstado.ForeColor = Color.Blue;

            await _propietarioRepository.ActualizarAsync(dto);
            MessageBox.Show("Propietario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await CargarPropietariosAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (_propietarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un propietario para desactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"¿Está seguro de desactivar al propietario {_propietarioSeleccionado.Nombre} {_propietarioSeleccionado.Apellidos}?",
                "Confirmar Desactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                btnEliminar.Enabled = false;
                lblEstado.Text = "Desactivando propietario...";
                lblEstado.ForeColor = Color.Blue;

                await _propietarioRepository.DesactivarAsync(_propietarioSeleccionado.ID_Propietario);
                MessageBox.Show("Propietario desactivado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                await CargarPropietariosAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al desactivar propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnEliminar.Enabled = true;
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        LimpiarFormulario();
        _propietarioSeleccionado = null;
        dgvPropietarios.ClearSelection();
        txtNombre.Focus();
    }

    private void PrepararModoNuevo()
    {
        LimpiarFormulario();
        _propietarioSeleccionado = null;
        dgvPropietarios.ClearSelection();
        txtNombre.Focus();
        lblEstado.Text = "Modo: Crear nuevo propietario. Complete los datos y haga clic en 'Nuevo' para guardar.";
        lblEstado.ForeColor = Color.Blue;
    }

    private async void btnCargar_Click(object? sender, EventArgs e)
    {
        await CargarPropietariosAsync();
    }

    private void btnExportarExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_propietarios.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"Propietarios_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Propietarios");

                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Apellidos";
                worksheet.Cell(1, 4).Value = "Dirección";
                worksheet.Cell(1, 5).Value = "Teléfono";
                worksheet.Cell(1, 6).Value = "Activo";

                var headerRange = worksheet.Range(1, 1, 1, 6);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightBlue;

                for (int i = 0; i < _propietarios.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _propietarios[i].ID_Propietario;
                    worksheet.Cell(row, 2).Value = _propietarios[i].Nombre;
                    worksheet.Cell(row, 3).Value = _propietarios[i].Apellidos;
                    worksheet.Cell(row, 4).Value = _propietarios[i].Direccion ?? "";
                    worksheet.Cell(row, 5).Value = _propietarios[i].Telefono ?? "";
                    worksheet.Cell(row, 6).Value = _propietarios[i].Activo ? "Sí" : "No";
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

    // ========== MÉTODOS PARA GESTIÓN DE MASCOTAS ==========

    private async Task CargarMascotasAsync(int idPropietario)
    {
        try
        {
            _mascotas = await _mascotaRepository.ListarPorPropietarioAsync(idPropietario);
            dgvMascotas.DataSource = _mascotas;
            ConfigurarDataGridViewMascotas();
            lblMascotasEstado.Text = $"Mascotas: {_mascotas.Count} registradas";
            lblMascotasEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar mascotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblMascotasEstado.Text = "Error al cargar mascotas";
            lblMascotasEstado.ForeColor = Color.Red;
        }
    }

    private void ConfigurarDataGridViewMascotas()
    {
        dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvMascotas.AllowUserToAddRows = false;
        dgvMascotas.ReadOnly = true;
        dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private void DgvMascotas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvMascotas.SelectedRows.Count > 0 && dgvMascotas.SelectedRows[0] != null)
        {
            var cell = dgvMascotas.SelectedRows[0].Cells["ID_Mascota"];
            if (cell?.Value != null && cell.Value is int id)
            {
                _mascotaSeleccionada = _mascotas.FirstOrDefault(m => m.ID_Mascota == id);
                CargarDatosMascotaEnFormulario();
            }
        }
    }

    private void CargarDatosMascotaEnFormulario()
    {
        if (_mascotaSeleccionada == null)
        {
            LimpiarFormularioMascota();
            return;
        }

        txtMascotaID.Text = _mascotaSeleccionada.ID_Mascota.ToString();
        txtMascotaNombre.Text = _mascotaSeleccionada.Nombre;
        txtMascotaEspecie.Text = _mascotaSeleccionada.Especie;
        txtMascotaRaza.Text = _mascotaSeleccionada.Raza ?? "";
        txtMascotaEdad.Text = _mascotaSeleccionada.Edad?.ToString() ?? "";
        cmbMascotaSexo.Text = _mascotaSeleccionada.Sexo;
    }

    private void LimpiarFormularioMascota()
    {
        txtMascotaID.Clear();
        txtMascotaNombre.Clear();
        txtMascotaEspecie.Clear();
        txtMascotaRaza.Clear();
        txtMascotaEdad.Clear();
        cmbMascotaSexo.SelectedIndex = -1;
        _mascotaSeleccionada = null;
        dgvMascotas.ClearSelection();
    }

    private async void btnMascotaNuevo_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_propietarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un propietario primero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMascotaNombre.Text) || string.IsNullOrWhiteSpace(txtMascotaEspecie.Text))
            {
                MessageBox.Show("El nombre y la especie son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMascotaNombre.Focus();
                return;
            }

            var dto = new MascotaCreateDto
            {
                Nombre = txtMascotaNombre.Text.Trim(),
                Especie = txtMascotaEspecie.Text.Trim(),
                Raza = string.IsNullOrWhiteSpace(txtMascotaRaza.Text) ? null : txtMascotaRaza.Text.Trim(),
                Edad = string.IsNullOrWhiteSpace(txtMascotaEdad.Text) ? null : int.TryParse(txtMascotaEdad.Text, out var edad) ? edad : null,
                Sexo = cmbMascotaSexo.Text ?? "",
                ID_Propietario = _propietarioSeleccionado.ID_Propietario
            };

            btnMascotaNuevo.Enabled = false;
            lblMascotasEstado.Text = "Creando mascota...";
            lblMascotasEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            await _mascotaRepository.CrearAsync(dto);
            MessageBox.Show($"Mascota '{dto.Nombre}' registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            LimpiarFormularioMascota();
            await CargarMascotasAsync(_propietarioSeleccionado.ID_Propietario);
            txtMascotaNombre.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblMascotasEstado.Text = "Error al crear mascota";
            lblMascotasEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnMascotaNuevo.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private async void btnMascotaActualizar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_mascotaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una mascota para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_propietarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un propietario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMascotaNombre.Text) || string.IsNullOrWhiteSpace(txtMascotaEspecie.Text))
            {
                MessageBox.Show("El nombre y la especie son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new MascotaUpdateDto
            {
                ID_Mascota = _mascotaSeleccionada.ID_Mascota,
                Nombre = txtMascotaNombre.Text.Trim(),
                Especie = txtMascotaEspecie.Text.Trim(),
                Raza = string.IsNullOrWhiteSpace(txtMascotaRaza.Text) ? null : txtMascotaRaza.Text.Trim(),
                Edad = string.IsNullOrWhiteSpace(txtMascotaEdad.Text) ? null : int.TryParse(txtMascotaEdad.Text, out var edad) ? edad : null,
                Sexo = cmbMascotaSexo.Text ?? "",
                ID_Propietario = _propietarioSeleccionado.ID_Propietario
            };

            btnMascotaActualizar.Enabled = false;
            lblMascotasEstado.Text = "Actualizando mascota...";
            lblMascotasEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            await _mascotaRepository.ActualizarAsync(dto);
            MessageBox.Show("Mascota actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            await CargarMascotasAsync(_propietarioSeleccionado.ID_Propietario);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblMascotasEstado.Text = "Error al actualizar mascota";
            lblMascotasEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnMascotaActualizar.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private void btnMascotaLimpiar_Click(object? sender, EventArgs e)
    {
        LimpiarFormularioMascota();
    }

    private async void btnMascotaEliminar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_mascotaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una mascota para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_propietarioSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un propietario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"¿Está seguro de eliminar la mascota '{_mascotaSeleccionada.Nombre}'?\n\n" +
                "ADVERTENCIA: Esta acción no se puede deshacer. Si la mascota tiene citas asociadas, no se podrá eliminar.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                btnMascotaEliminar.Enabled = false;
                lblMascotasEstado.Text = "Eliminando mascota...";
                lblMascotasEstado.ForeColor = Color.Blue;
                Cursor = Cursors.WaitCursor;

                await _mascotaRepository.EliminarAsync(_mascotaSeleccionada.ID_Mascota);
                MessageBox.Show("Mascota eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LimpiarFormularioMascota();
                await CargarMascotasAsync(_propietarioSeleccionado.ID_Propietario);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblMascotasEstado.Text = "Error al eliminar mascota";
            lblMascotasEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnMascotaEliminar.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}

