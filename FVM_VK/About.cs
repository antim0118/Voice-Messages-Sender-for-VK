using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;


public partial class About : Form
{
    public About()
    {
        InitializeComponent();
        TopMost = true;
        PosY = Height * -1;
        pos = Height * -1;
    }

    #region Методы доступа к атрибутам сборки
    public string AssemblyTitle
    {
        get
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }
    }

    public string AssemblyVersion
    {
        get
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }

    public string AssemblyDescription
    {
        get
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }
    }

    public string AssemblyProduct
    {
        get
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyProductAttribute)attributes[0]).Product;
        }
    }

    public string AssemblyCopyright
    {
        get
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
    }

    public string AssemblyCompany
    {
        get
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }
    #endregion

    private void About_Load(object sender, EventArgs e)
    {
        label_soft.Text = $"{AssemblyTitle} {AssemblyVersion}";
    }

    #region Анимация при запуске
    float pos = 0f;
    private void timer_about_Tick(object sender, EventArgs e)
    {
        if (PosY < 0)
        {
            if (pos > -1f)
                pos = 0f;
            else
                pos -= pos / 15f;
            PosY = pos;
        }
        Invoke((MethodInvoker)delegate ()
        {
            Refresh();
        });
    }
    private float PosY
    {
        get
        {
            return Location.Y;
        }
        set
        {
            if (InvokeRequired)
                Invoke(new Action<string>(
                    (s) =>
                Location = new Point(Location.X, (int)value)
                ), "");
            else
                Location = new Point(Location.X, (int)value);
        }
    }
    #endregion
    #region выход по истечении времени
    private int wait = 0;
    private void timer_close_Tick(object sender, EventArgs e)
    {
        wait++;
        if (wait >= 40 * 10)
        {
            close();
        }
    }
    #endregion

    private void linkLabel_antim_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start("https://github.com/antimYT");
    }

    #region button_close
    private void close()
    {
        Invoke((MethodInvoker)delegate ()
        {
            this.Close();
            this.Dispose();
        });

    }
    
    private void button_close_Click(object sender, EventArgs e)
    {
        close();
    }
    #endregion
    

    

    private void About_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawRectangle(new Pen(Color.FromArgb(39, 111, 169)), 0f, 0f, Width - 1, Height - 1);

        e.Graphics.DrawLine(new Pen(Color.FromArgb(39, 111, 169), 3), 1f, Height - 3, Width - (Width / (40f * 10f) * wait - 1f), Height - 3);
    }
}