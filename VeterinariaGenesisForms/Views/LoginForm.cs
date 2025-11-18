using VeterinariaGenesisForms.Controllers;
using VeterinariaGenesisForms.Models.Dto;
using Newtonsoft.Json;

namespace VeterinariaGenesisForms.Views;

public partial class LoginForm : Form
{
    private readonly ApiClient _apiClient;
    public string? Token { get; private set; }
    public UsuarioInfo? Usuario { get; private set; }

    public LoginForm()
    {
        InitializeComponent();
        _apiClient = new ApiClient();
        AplicarColoresVeterinaria();
    }

    private void AplicarColoresVeterinaria()
    {
        // Colores profesionales para veterinaria
        this.BackColor = Color.FromArgb(245, 250, 247); // Verde muy suave
        
        // Título con color verde
        lblTitulo.ForeColor = Color.FromArgb(27, 94, 32); // Verde oscuro
        
        // Botón de login con color verde
        btnLogin.BackColor = Color.FromArgb(76, 175, 80); // Verde
        btnLogin.ForeColor = Color.White;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(69, 160, 73); // Verde más oscuro al pasar el mouse
        
        // Botón cancelar con color gris
        btnCancelar.BackColor = Color.FromArgb(158, 158, 158); // Gris
        btnCancelar.ForeColor = Color.White;
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.FlatAppearance.BorderSize = 0;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            btnLogin.Enabled = false;
            lblMensaje.Text = "Iniciando sesión...";
            lblMensaje.ForeColor = Color.Blue;

            var loginRequest = new LoginRequest
            {
                NombreLogin = txtUsuario.Text.Trim(),
                Contrasena = txtContrasena.Text
            };

            var response = await _apiClient.PostAsync<LoginResponse>("Auth/login", loginRequest);

            if (response != null && !string.IsNullOrEmpty(response.Token))
            {
                Token = response.Token;
                Usuario = response.Usuario;
                _apiClient.SetBearerToken(Token);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                lblMensaje.Text = "Credenciales inválidas";
                lblMensaje.ForeColor = Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = $"Error: {ex.Message}";
            lblMensaje.ForeColor = Color.Red;
        }
        finally
        {
            btnLogin.Enabled = true;
        }
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}

