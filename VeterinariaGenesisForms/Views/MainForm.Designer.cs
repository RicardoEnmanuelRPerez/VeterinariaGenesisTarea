#nullable enable
namespace VeterinariaGenesisForms.Views;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;
    private MenuStrip menuStrip1 = null!;
    private ToolStripMenuItem mnuReportes = null!;
    private ToolStripMenuItem mnuReportePropietarios = null!;
    private ToolStripMenuItem mnuUsuario = null!;
    private ToolStripMenuItem mnuCerrarSesion = null!;
    private ToolStripMenuItem mnuSalir = null!;
    private StatusStrip statusStrip1 = null!;
    private ToolStripStatusLabel lblUsuario = null!;

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
        menuStrip1 = new MenuStrip();
        mnuReportes = new ToolStripMenuItem();
        mnuReportePropietarios = new ToolStripMenuItem();
        mnuUsuario = new ToolStripMenuItem();
        mnuCerrarSesion = new ToolStripMenuItem();
        mnuSalir = new ToolStripMenuItem();
        statusStrip1 = new StatusStrip();
        lblUsuario = new ToolStripStatusLabel();
        menuStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(20, 20);
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuReportes, mnuUsuario });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Padding = new Padding(7, 3, 0, 3);
        menuStrip1.Size = new Size(1417, 30);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // mnuReportes
        // 
        mnuReportes.DropDownItems.AddRange(new ToolStripItem[] { mnuReportePropietarios });
        mnuReportes.Name = "mnuReportes";
        mnuReportes.Size = new Size(82, 24);
        mnuReportes.Text = "&Reportes";
        // 
        // mnuReportePropietarios
        // 
        mnuReportePropietarios.Name = "mnuReportePropietarios";
        mnuReportePropietarios.Size = new Size(250, 26);
        mnuReportePropietarios.Text = "Reporte de &Propietarios";
        mnuReportePropietarios.Click += mnuReportePropietarios_Click;
        // 
        // mnuUsuario
        // 
        mnuUsuario.DropDownItems.AddRange(new ToolStripItem[] { mnuCerrarSesion, mnuSalir });
        mnuUsuario.Name = "mnuUsuario";
        mnuUsuario.Size = new Size(73, 24);
        mnuUsuario.Text = "&Usuario";
        // 
        // mnuCerrarSesion
        // 
        mnuCerrarSesion.Name = "mnuCerrarSesion";
        mnuCerrarSesion.Size = new Size(224, 26);
        mnuCerrarSesion.Text = "&Cerrar Sesión";
        mnuCerrarSesion.Click += mnuCerrarSesion_Click;
        // 
        // mnuSalir
        // 
        mnuSalir.Name = "mnuSalir";
        mnuSalir.Size = new Size(224, 26);
        mnuSalir.Text = "&Salir";
        mnuSalir.Click += mnuSalir_Click;
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new Size(20, 20);
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblUsuario });
        statusStrip1.Location = new Point(0, 765);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Padding = new Padding(1, 0, 16, 0);
        statusStrip1.Size = new Size(1417, 22);
        statusStrip1.TabIndex = 1;
        statusStrip1.Text = "statusStrip1";
        // 
        // lblUsuario
        // 
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(0, 16);
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1417, 787);
        Controls.Add(statusStrip1);
        Controls.Add(menuStrip1);
        IsMdiContainer = true;
        MainMenuStrip = menuStrip1;
        Margin = new Padding(3, 4, 3, 4);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Veterinaria Genesis - Sistema de Gestión";
        WindowState = FormWindowState.Maximized;
        Load += MainForm_Load;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}

