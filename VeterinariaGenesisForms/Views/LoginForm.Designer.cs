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
        this.lblTitulo = new Label();
        this.lblUsuario = new Label();
        this.lblContrasena = new Label();
        this.txtUsuario = new TextBox();
        this.txtContrasena = new TextBox();
        this.btnLogin = new Button();
        this.btnCancelar = new Button();
        this.lblMensaje = new Label();
        this.SuspendLayout();

        // lblTitulo
        this.lblTitulo.AutoSize = true;
        this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        this.lblTitulo.Location = new Point(100, 20);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new Size(280, 30);
        this.lblTitulo.TabIndex = 0;
        this.lblTitulo.Text = "Veterinaria Genesis - Login";

        // lblUsuario
        this.lblUsuario.AutoSize = true;
        this.lblUsuario.Font = new Font("Segoe UI", 10F);
        this.lblUsuario.Location = new Point(50, 80);
        this.lblUsuario.Name = "lblUsuario";
        this.lblUsuario.Size = new Size(120, 19);
        this.lblUsuario.TabIndex = 1;
        this.lblUsuario.Text = "Usuario:";

        // txtUsuario
        this.txtUsuario.Font = new Font("Segoe UI", 10F);
        this.txtUsuario.Location = new Point(50, 105);
        this.txtUsuario.Name = "txtUsuario";
        this.txtUsuario.Size = new Size(380, 25);
        this.txtUsuario.TabIndex = 2;

        // lblContrasena
        this.lblContrasena.AutoSize = true;
        this.lblContrasena.Font = new Font("Segoe UI", 10F);
        this.lblContrasena.Location = new Point(50, 150);
        this.lblContrasena.Name = "lblContrasena";
        this.lblContrasena.Size = new Size(120, 19);
        this.lblContrasena.TabIndex = 3;
        this.lblContrasena.Text = "Contraseña:";

        // txtContrasena
        this.txtContrasena.Font = new Font("Segoe UI", 10F);
        this.txtContrasena.Location = new Point(50, 175);
        this.txtContrasena.Name = "txtContrasena";
        this.txtContrasena.PasswordChar = '*';
        this.txtContrasena.Size = new Size(380, 25);
        this.txtContrasena.TabIndex = 4;

        // btnLogin
        this.btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.btnLogin.Location = new Point(50, 230);
        this.btnLogin.Name = "btnLogin";
        this.btnLogin.Size = new Size(180, 35);
        this.btnLogin.TabIndex = 5;
        this.btnLogin.Text = "&Iniciar Sesión";
        this.btnLogin.UseVisualStyleBackColor = true;
        this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

        // btnCancelar
        this.btnCancelar.Font = new Font("Segoe UI", 10F);
        this.btnCancelar.Location = new Point(250, 230);
        this.btnCancelar.Name = "btnCancelar";
        this.btnCancelar.Size = new Size(180, 35);
        this.btnCancelar.TabIndex = 6;
        this.btnCancelar.Text = "&Cancelar";
        this.btnCancelar.UseVisualStyleBackColor = true;
        this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

        // lblMensaje
        this.lblMensaje.AutoSize = true;
        this.lblMensaje.Font = new Font("Segoe UI", 9F);
        this.lblMensaje.Location = new Point(50, 290);
        this.lblMensaje.Name = "lblMensaje";
        this.lblMensaje.Size = new Size(0, 15);
        this.lblMensaje.TabIndex = 7;

        // LoginForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(480, 330);
        this.Controls.Add(this.lblMensaje);
        this.Controls.Add(this.btnCancelar);
        this.Controls.Add(this.btnLogin);
        this.Controls.Add(this.txtContrasena);
        this.Controls.Add(this.lblContrasena);
        this.Controls.Add(this.txtUsuario);
        this.Controls.Add(this.lblUsuario);
        this.Controls.Add(this.lblTitulo);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "LoginForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Login - Veterinaria Genesis";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}

