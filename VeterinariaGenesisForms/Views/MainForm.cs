using System.Collections.Generic;
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
    
    // Diccionario para rastrear formularios abiertos
    private readonly Dictionary<Type, Form> _formulariosAbiertos = new();

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
            
            // Servicios solo para Administrador
            mnuServicios.Enabled = esAdmin;
            mnuServicios.Visible = esAdmin;
            
            // Agendar Cita solo para Admin y Veterinario
            mnuAgendarCita.Enabled = esAdmin || esVeterinario;
            mnuAgendarCita.Visible = esAdmin || esVeterinario;
            
            // Los reportes solo para Admin y Veterinario
            mnuReportes.Enabled = esAdmin || esVeterinario;
            
            // El menú Usuario siempre está disponible
            mnuUsuario.Enabled = true;
            
            // Actualizar mensaje de bienvenida
            if (lblMensajeBienvenida != null)
            {
                lblMensajeBienvenida.Text = $"Bienvenido, {_usuario.NombreCompleto} ({_usuario.NombreRol})\r\n\r\n" +
                    "Sistema de Gestión Integral para Clínicas Veterinarias\r\n\r\n" +
                    "Utilice el menú superior para acceder a las diferentes funcionalidades:\r\n" +
                    "• Gestión: Administre propietarios, mascotas, citas y facturas\r\n" +
                    "• Servicios: Configure los servicios disponibles\r\n" +
                    "• Reportes: Visualice estadísticas y análisis\r\n\r\n" +
                    "Seleccione una opción del menú para comenzar.";
            }
        }
        else
        {
            // Si no hay usuario, habilitar todo (por si acaso)
            mnuGestion.Enabled = true;
            mnuReportes.Enabled = true;
            mnuUsuario.Enabled = true;
        }
        
        // Mostrar panel de bienvenida inicialmente
        if (panelBienvenida != null)
            panelBienvenida.Visible = true;
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        // Fondo degradado suave
        this.BackColor = Color.FromArgb(240, 248, 255); // Azul muy claro
        
        // Menú con color verde profesional
        menuStrip1.BackColor = Color.FromArgb(76, 175, 80); // Verde medio
        menuStrip1.ForeColor = Color.White;
        menuStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        
        // Status bar con color suave
        statusStrip1.BackColor = Color.FromArgb(200, 230, 201); // Verde claro
        statusStrip1.ForeColor = Color.FromArgb(27, 94, 32); // Verde oscuro para texto
        
        // Configurar panel de bienvenida si existe
        if (panelBienvenida != null)
        {
            panelBienvenida.BackColor = Color.White;
            panelBienvenida.BorderStyle = BorderStyle.None;
        }
    }
    
    /// <summary>
    /// Abre un formulario, cerrando el anterior del mismo tipo si existe
    /// </summary>
    private void AbrirFormulario<T>(Func<T> crearFormulario) where T : Form
    {
        // Cerrar formulario anterior del mismo tipo si existe
        if (_formulariosAbiertos.TryGetValue(typeof(T), out var formAnterior))
        {
            if (formAnterior != null && !formAnterior.IsDisposed)
            {
                formAnterior.Close();
                _formulariosAbiertos.Remove(typeof(T));
            }
        }
        
        // Crear y mostrar nuevo formulario
        var form = crearFormulario();
        form.MdiParent = this;
        form.WindowState = FormWindowState.Maximized;
        form.FormBorderStyle = FormBorderStyle.None;
        form.FormClosed += (s, e) => 
        {
            if (_formulariosAbiertos.ContainsKey(typeof(T)))
                _formulariosAbiertos.Remove(typeof(T));
            
            // Mostrar panel de bienvenida si no hay formularios abiertos
            if (_formulariosAbiertos.Count == 0 && panelBienvenida != null)
                panelBienvenida.Visible = true;
        };
        _formulariosAbiertos[typeof(T)] = form;
        form.Show();
        form.BringToFront();
        
        // Ocultar panel de bienvenida si existe
        if (panelBienvenida != null)
            panelBienvenida.Visible = false;
    }

    // Menú Propietarios
    private void mnuPropietarios_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() =>
        {
            var mascotaRepository = new MascotaRepository(_apiClient);
            return new PropietariosForm(_propietarioRepository, mascotaRepository);
        });
    }

    // Menú Mascotas
    private void mnuMascotas_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() => new MascotasForm(_mascotaRepository, _propietarioRepository));
    }

    // Menú Citas (Ver)
    private void mnuCitas_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() =>
        {
            var veterinarioRepository = new VeterinarioRepository(_apiClient);
            var servicioRepository = new ServicioRepository(_apiClient);
            return new CitasForm(_citaRepository, _propietarioRepository, _mascotaRepository, veterinarioRepository, servicioRepository);
        });
    }

    // Menú Agendar Cita
    private void mnuAgendarCita_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() =>
        {
            var veterinarioRepository = new VeterinarioRepository(_apiClient);
            var servicioRepository = new ServicioRepository(_apiClient);
            return new AgendarCitaForm(_citaRepository, _propietarioRepository, _mascotaRepository, veterinarioRepository, servicioRepository);
        });
    }

    // Menú Servicios
    private void mnuServicios_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() =>
        {
            var servicioRepository = new ServicioRepository(_apiClient);
            return new ServiciosForm(servicioRepository);
        });
    }

    // Menú Facturas
    private void mnuFacturas_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() => new FacturasForm(_facturaRepository, _citaRepository));
    }

    // Menú Pago Facturas
    private void mnuPagoFacturas_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() => new PagoFacturaForm(_facturaRepository));
    }

    // Menú Reportes
    private void mnuReportePropietarios_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() => new ReportePropietariosForm(_reporteRepository));
    }

    private void mnuReporteServiciosVendidos_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() => new ReporteServiciosVendidosForm(_reporteRepository));
    }

    private void mnuReporteCitasPorVeterinario_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() => new ReporteCitasPorVeterinarioForm(_reporteRepository));
    }

    private void mnuReporteIngresosPorPeriodo_Click(object? sender, EventArgs e)
    {
        AbrirFormulario(() => new ReporteIngresosPorPeriodoForm(_reporteRepository));
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

