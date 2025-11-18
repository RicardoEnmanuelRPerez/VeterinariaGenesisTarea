#nullable enable
using ClosedXML.Excel;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class MascotasForm : Form
{
    private readonly IMascotaRepository _mascotaRepository;
    private readonly IPropietarioRepository _propietarioRepository;
    private List<MascotaDto> _mascotas = new();
    private List<PropietarioDto> _propietarios = new();
    private MascotaDto? _mascotaSeleccionada;

    public MascotasForm(IMascotaRepository mascotaRepository, IPropietarioRepository propietarioRepository)
    {
        InitializeComponent();
        _mascotaRepository = mascotaRepository;
        _propietarioRepository = propietarioRepository;
    }

    private async void MascotasForm_Load(object? sender, EventArgs e)
    {
        AplicarColoresVeterinaria();
        await CargarPropietariosAsync();
        cmbPropietario.SelectedIndexChanged += CmbPropietario_SelectedIndexChanged;
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // GroupBoxes con colores suaves
        gbxFiltro.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        gbxDatos.BackColor = Color.FromArgb(255, 255, 255); // Blanco
        
        // Botones con colores temáticos
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
            _propietarios = await _propietarioRepository.ListarActivosAsync();
            cmbPropietario.DataSource = _propietarios.Select(p => new { 
                ID = p.ID_Propietario, 
                NombreCompleto = $"{p.Nombre} {p.Apellidos}" 
            }).ToList();
            cmbPropietario.DisplayMember = "NombreCompleto";
            cmbPropietario.ValueMember = "ID";
            cmbPropietario.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar propietarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void CmbPropietario_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cmbPropietario.SelectedItem != null)
        {
            var propItem = cmbPropietario.SelectedItem;
            var propId = propItem.GetType().GetProperty("ID")?.GetValue(propItem);
            if (propId != null && propId is int propIdInt)
            {
                await CargarMascotasAsync(propIdInt);
            }
        }
    }

    private async Task CargarMascotasAsync(int idPropietario)
    {
        try
        {
            btnCargar.Enabled = false;
            lblEstado.Text = "Cargando mascotas...";
            lblEstado.ForeColor = Color.Blue;
            Cursor = Cursors.WaitCursor;

            _mascotas = await _mascotaRepository.ListarPorPropietarioAsync(idPropietario);
            dgvMascotas.DataSource = _mascotas;
            ConfigurarDataGridView();

            lblEstado.Text = $"Se encontraron {_mascotas.Count} mascotas";
            lblEstado.ForeColor = Color.Green;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar mascotas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        dgvMascotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dgvMascotas.AllowUserToAddRows = false;
        dgvMascotas.ReadOnly = true;
        dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMascotas.SelectionChanged += DgvMascotas_SelectionChanged;
    }

    private void DgvMascotas_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvMascotas.SelectedRows.Count > 0 && dgvMascotas.SelectedRows[0] != null)
        {
            var cell = dgvMascotas.SelectedRows[0].Cells["ID_Mascota"];
            if (cell?.Value != null && cell.Value is int id)
            {
                _mascotaSeleccionada = _mascotas.FirstOrDefault(m => m.ID_Mascota == id);
                CargarDatosEnFormulario();
            }
        }
    }

    private void CargarDatosEnFormulario()
    {
        if (_mascotaSeleccionada == null)
        {
            LimpiarFormulario();
            return;
        }

        txtID.Text = _mascotaSeleccionada.ID_Mascota.ToString();
        txtNombre.Text = _mascotaSeleccionada.Nombre;
        txtEspecie.Text = _mascotaSeleccionada.Especie;
        txtRaza.Text = _mascotaSeleccionada.Raza ?? "";
        txtEdad.Text = _mascotaSeleccionada.Edad?.ToString() ?? "";
        cmbSexo.Text = _mascotaSeleccionada.Sexo;
        for (int i = 0; i < cmbPropietario.Items.Count; i++)
        {
            var item = cmbPropietario.Items[i];
            var itemId = item?.GetType().GetProperty("ID")?.GetValue(item);
            if (itemId != null && itemId is int itemIdInt && itemIdInt == _mascotaSeleccionada.ID_Propietario)
            {
                cmbPropietario.SelectedIndex = i;
                break;
            }
        }
    }

    private void LimpiarFormulario()
    {
        txtID.Clear();
        txtNombre.Clear();
        txtEspecie.Clear();
        txtRaza.Clear();
        txtEdad.Clear();
        cmbSexo.SelectedIndex = -1;
    }

    private async void btnNuevo_Click(object? sender, EventArgs e)
    {
        try
        {
            if (cmbPropietario.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un propietario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEspecie.Text))
            {
                MessageBox.Show("El nombre y la especie son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var propItemNuevo = cmbPropietario.SelectedItem;
            if (propItemNuevo == null)
            {
                MessageBox.Show("Debe seleccionar un propietario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var propIdNuevo = propItemNuevo.GetType().GetProperty("ID")?.GetValue(propItemNuevo);
            if (propIdNuevo == null || !(propIdNuevo is int propIdIntNuevo))
            {
                MessageBox.Show("Error al obtener el ID del propietario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var idPropietario = propIdIntNuevo;

            var dto = new MascotaCreateDto
            {
                Nombre = txtNombre.Text.Trim(),
                Especie = txtEspecie.Text.Trim(),
                Raza = string.IsNullOrWhiteSpace(txtRaza.Text) ? null : txtRaza.Text.Trim(),
                Edad = string.IsNullOrWhiteSpace(txtEdad.Text) ? null : int.TryParse(txtEdad.Text, out var edad) ? edad : null,
                Sexo = cmbSexo.Text,
                ID_Propietario = idPropietario
            };

            btnNuevo.Enabled = false;
            lblEstado.Text = "Creando mascota...";
            lblEstado.ForeColor = Color.Blue;

            await _mascotaRepository.CrearAsync(dto);
            MessageBox.Show("Mascota creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
            if (cmbPropietario.SelectedItem != null)
            {
                var propItem3 = cmbPropietario.SelectedItem;
                var propId3 = propItem3.GetType().GetProperty("ID")?.GetValue(propItem3);
                if (propId3 != null && propId3 is int propIdInt3)
                {
                    await CargarMascotasAsync(propIdInt3);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (_mascotaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una mascota para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEspecie.Text))
            {
                MessageBox.Show("El nombre y la especie son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var propItemActualizar = cmbPropietario.SelectedItem;
            if (propItemActualizar == null)
            {
                MessageBox.Show("Debe seleccionar un propietario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var propIdActualizar = propItemActualizar.GetType().GetProperty("ID")?.GetValue(propItemActualizar);
            if (propIdActualizar == null || !(propIdActualizar is int propIdIntActualizar))
            {
                MessageBox.Show("Error al obtener el ID del propietario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var idPropietario = propIdIntActualizar;

            var dto = new MascotaUpdateDto
            {
                ID_Mascota = _mascotaSeleccionada.ID_Mascota,
                Nombre = txtNombre.Text.Trim(),
                Especie = txtEspecie.Text.Trim(),
                Raza = string.IsNullOrWhiteSpace(txtRaza.Text) ? null : txtRaza.Text.Trim(),
                Edad = string.IsNullOrWhiteSpace(txtEdad.Text) ? null : int.TryParse(txtEdad.Text, out var edad) ? edad : null,
                Sexo = cmbSexo.Text,
                ID_Propietario = idPropietario
            };

            btnActualizar.Enabled = false;
            lblEstado.Text = "Actualizando mascota...";
            lblEstado.ForeColor = Color.Blue;

            await _mascotaRepository.ActualizarAsync(dto);
            MessageBox.Show("Mascota actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (cmbPropietario.SelectedItem != null)
            {
                var propItem4 = cmbPropietario.SelectedItem;
                var propId4 = propItem4.GetType().GetProperty("ID")?.GetValue(propItem4);
                if (propId4 != null && propId4 is int propIdInt4)
                {
                    await CargarMascotasAsync(propIdInt4);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al actualizar mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnActualizar.Enabled = true;
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        LimpiarFormulario();
        _mascotaSeleccionada = null;
        dgvMascotas.ClearSelection();
    }

    private async void btnEliminar_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_mascotaSeleccionada == null)
            {
                MessageBox.Show("Seleccione una mascota para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                btnEliminar.Enabled = false;
                lblEstado.Text = "Eliminando mascota...";
                lblEstado.ForeColor = Color.Blue;
                Cursor = Cursors.WaitCursor;

                await _mascotaRepository.EliminarAsync(_mascotaSeleccionada.ID_Mascota);
                MessageBox.Show("Mascota eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LimpiarFormulario();
                if (cmbPropietario.SelectedItem != null)
                {
                    var propItem = cmbPropietario.SelectedItem;
                    var propId = propItem.GetType().GetProperty("ID")?.GetValue(propItem);
                    if (propId != null && propId is int propIdInt)
                    {
                        await CargarMascotasAsync(propIdInt);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblEstado.Text = "Error al eliminar mascota";
            lblEstado.ForeColor = Color.Red;
        }
        finally
        {
            btnEliminar.Enabled = true;
            Cursor = Cursors.Default;
        }
    }

    private async void btnCargar_Click(object? sender, EventArgs e)
    {
        if (cmbPropietario.SelectedItem != null)
        {
            var propItem = cmbPropietario.SelectedItem;
            var propId = propItem.GetType().GetProperty("ID")?.GetValue(propItem);
            if (propId != null && propId is int propIdInt)
            {
                await CargarMascotasAsync(propIdInt);
            }
            else
            {
                MessageBox.Show("Error al obtener el ID del propietario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Seleccione un propietario primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnExportarExcel_Click(object? sender, EventArgs e)
    {
        try
        {
            if (_mascotas.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"Mascotas_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Mascotas");

                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nombre";
                worksheet.Cell(1, 3).Value = "Especie";
                worksheet.Cell(1, 4).Value = "Raza";
                worksheet.Cell(1, 5).Value = "Edad";
                worksheet.Cell(1, 6).Value = "Sexo";
                worksheet.Cell(1, 7).Value = "Propietario";

                var headerRange = worksheet.Range(1, 1, 1, 7);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGreen;

                for (int i = 0; i < _mascotas.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = _mascotas[i].ID_Mascota;
                    worksheet.Cell(row, 2).Value = _mascotas[i].Nombre;
                    worksheet.Cell(row, 3).Value = _mascotas[i].Especie;
                    worksheet.Cell(row, 4).Value = _mascotas[i].Raza ?? "";
                    worksheet.Cell(row, 5).Value = _mascotas[i].Edad?.ToString() ?? "";
                    worksheet.Cell(row, 6).Value = _mascotas[i].Sexo;
                    worksheet.Cell(row, 7).Value = _mascotas[i].NombrePropietario ?? "";
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

