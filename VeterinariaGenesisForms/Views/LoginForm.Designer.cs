namespace VeterinariaGenesisForms.Views;

partial class LoginForm
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo;
    private Label lblUsuario;
    private Label lblContrasena;
    private TextBox txtUsuario;
    private TextBox txtContrasena;
    private Button btnLogin;
    private Button btnCancelar;
    private Label lblMensaje;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblUsuario = new Label();
        lblContrasena = new Label();
        txtUsuario = new TextBox();
        txtContrasena = new TextBox();
        btnLogin = new Button();
        btnCancelar = new Button();
        lblMensaje = new Label();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.Location = new Point(114, 27);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(359, 37);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Veterinaria Genesis - Login";
        // 
        // lblUsuario
        // 
        lblUsuario.AutoSize = true;
        lblUsuario.Font = new Font("Segoe UI", 10F);
        lblUsuario.Location = new Point(57, 107);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(72, 23);
        lblUsuario.TabIndex = 1;
        lblUsuario.Text = "Usuario:";
        // 
        // lblContrasena
        // 
        lblContrasena.AutoSize = true;
        lblContrasena.Font = new Font("Segoe UI", 10F);
        lblContrasena.Location = new Point(57, 200);
        lblContrasena.Name = "lblContrasena";
        lblContrasena.Size = new Size(101, 23);
        lblContrasena.TabIndex = 3;
        lblContrasena.Text = "Contraseña:";
        // 
        // txtUsuario
        // 
        txtUsuario.Font = new Font("Segoe UI", 10F);
        txtUsuario.Location = new Point(57, 140);
        txtUsuario.Margin = new Padding(3, 4, 3, 4);
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(434, 30);
        txtUsuario.TabIndex = 2;
        // 
        // txtContrasena
        // 
        txtContrasena.Font = new Font("Segoe UI", 10F);
        txtContrasena.Location = new Point(57, 233);
        txtContrasena.Margin = new Padding(3, 4, 3, 4);
        txtContrasena.Name = "txtContrasena";
        txtContrasena.PasswordChar = '*';
        txtContrasena.Size = new Size(434, 30);
        txtContrasena.TabIndex = 4;
        txtContrasena.TextChanged += txtContrasena_TextChanged;
        // 
        // btnLogin
        // 
        btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLogin.Location = new Point(57, 307);
        btnLogin.Margin = new Padding(3, 4, 3, 4);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(206, 47);
        btnLogin.TabIndex = 5;
        btnLogin.Text = "&Iniciar Sesión";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // btnCancelar
        // 
        btnCancelar.Font = new Font("Segoe UI", 10F);
        btnCancelar.Location = new Point(286, 307);
        btnCancelar.Margin = new Padding(3, 4, 3, 4);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(206, 47);
        btnCancelar.TabIndex = 6;
        btnCancelar.Text = "&Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        btnCancelar.Click += btnCancelar_Click;
        // 
        // lblMensaje
        // 
        lblMensaje.AutoSize = true;
        lblMensaje.Font = new Font("Segoe UI", 9F);
        lblMensaje.Location = new Point(57, 387);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(0, 20);
        lblMensaje.TabIndex = 7;
        // 
        // LoginForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(549, 440);
        Controls.Add(lblMensaje);
        Controls.Add(btnCancelar);
        Controls.Add(btnLogin);
        Controls.Add(txtContrasena);
        Controls.Add(lblContrasena);
        Controls.Add(txtUsuario);
        Controls.Add(lblUsuario);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Login - Veterinaria Genesis";
        ResumeLayout(false);
        PerformLayout();
    }
}

