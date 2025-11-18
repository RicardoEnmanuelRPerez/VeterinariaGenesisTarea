using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using VeterinariaGenesisForms.Repository;
using VeterinariaGenesisForms.Repository.Interfaces;

namespace VeterinariaGenesisForms.Views;

public partial class MainForm : Form
{
    private readonly ApiClient _apiClient;
    private readonly IReporteRepository _reporteRepository;
    private readonly IPropietarioRepository _propietarioRepository;
    private readonly IMascotaRepository _mascotaRepository;
    private readonly ICitaRepository _citaRepository;
    private readonly IFacturaRepository _facturaRepository;
    private UsuarioInfo? _usuario;

    public MainForm(ApiClient apiClient, UsuarioInfo? usuario)
    {
        InitializeComponent();
        _apiClient = apiClient;
        _usuario = usuario;
        _reporteRepository = new ReporteRepository(_apiClient);
        _propietarioRepository = new PropietarioRepository(_apiClient);
        _mascotaRepository = new MascotaRepository(_apiClient);
        _citaRepository = new CitaRepository(_apiClient);
        _facturaRepository = new FacturaRepository(_apiClient);
        
        if (_usuario != null)
        {
            lblUsuario.Text = $"Usuario: {_usuario.NombreCompleto} ({_usuario.NombreRol})";
        }
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        // Aplicar colores temáticos de veterinaria
        AplicarColoresVeterinaria();
        
        // Configurar menú según el rol del usuario
        if (_usuario != null)
        {
            bool esAdmin = _usuario.NombreRol == "Administrador";
            bool esVeterinario = _usuario.NombreRol == "Veterinario" || esAdmin;
            bool esRecepcionista = _usuario.NombreRol == "Recepcionista";

            // El menú Gestión está disponible para todos los roles
            mnuGestion.Enabled = true;
            
            // Los reportes solo para Admin y Veterinario
            mnuReportes.Enabled = esAdmin || esVeterinario;
            
            // El menú Usuario siempre está disponible
            mnuUsuario.Enabled = true;
        }
        else
        {
            // Si no hay usuario, habilitar todo (por si acaso)
            mnuGestion.Enabled = true;
            mnuReportes.Enabled = true;
            mnuUsuario.Enabled = true;
        }
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        // Verde suave (naturaleza, salud)
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // Menú con color verde suave
        menuStrip1.BackColor = Color.FromArgb(76, 175, 80); // Verde medio
        menuStrip1.ForeColor = Color.White;
        
        // Status bar con color suave
        statusStrip1.BackColor = Color.FromArgb(200, 230, 201); // Verde claro
        statusStrip1.ForeColor = Color.FromArgb(27, 94, 32); // Verde oscuro para texto
    }

    // Menú Propietarios
    private void mnuPropietarios_Click(object? sender, EventArgs e)
    {
        var mascotaRepository = new MascotaRepository(_apiClient);
        var form = new PropietariosForm(_propietarioRepository, mascotaRepository);
        form.MdiParent = this;
        form.Show();
    }

    // Menú Mascotas
    private void mnuMascotas_Click(object? sender, EventArgs e)
    {
        var form = new MascotasForm(_mascotaRepository, _propietarioRepository);
        form.MdiParent = this;
        form.Show();
    }

    // Menú Citas
    private void mnuCitas_Click(object? sender, EventArgs e)
    {
        var form = new CitasForm(_citaRepository, _propietarioRepository, _mascotaRepository);
        form.MdiParent = this;
        form.Show();
    }

    // Menú Facturas
    private void mnuFacturas_Click(object? sender, EventArgs e)
    {
        var form = new FacturasForm(_facturaRepository, _citaRepository);
        form.MdiParent = this;
        form.Show();
    }

    // Menú Reportes
    private void mnuReportePropietarios_Click(object? sender, EventArgs e)
    {
        var form = new ReportePropietariosForm(_reporteRepository);
        form.MdiParent = this;
        form.Show();
    }

    private void mnuReporteServiciosVendidos_Click(object? sender, EventArgs e)
    {
        var form = new ReporteServiciosVendidosForm(_reporteRepository);
        form.MdiParent = this;
        form.Show();
    }

    private void mnuReporteCitasPorVeterinario_Click(object? sender, EventArgs e)
    {
        var form = new ReporteCitasPorVeterinarioForm(_reporteRepository);
        form.MdiParent = this;
        form.Show();
    }

    private void mnuReporteIngresosPorPeriodo_Click(object? sender, EventArgs e)
    {
        var form = new ReporteIngresosPorPeriodoForm(_reporteRepository);
        form.MdiParent = this;
        form.Show();
    }

    private void mnuSalir_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    private void mnuCerrarSesion_Click(object? sender, EventArgs e)
    {
        _apiClient.ClearToken();
        var loginForm = new LoginForm();
        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            _usuario = loginForm.Usuario;
            _apiClient.SetBearerToken(loginForm.Token ?? "");
            lblUsuario.Text = $"Usuario: {_usuario?.NombreCompleto} ({_usuario?.NombreRol})";
        }
        else
        {
            Application.Exit();
        }
    }
}

