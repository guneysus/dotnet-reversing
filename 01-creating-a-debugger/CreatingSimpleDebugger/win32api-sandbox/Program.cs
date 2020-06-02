using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win32api_sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
}

public class FormApp
{
    public FormApp()
    {
    }
    public void Run()
    {
        var frm = new MyForm();
        frm.Load += Frm_Load;
        frm.ShowInTaskbar = false;

        //NativeMethods.FreeConsole();

        ApplicationContext context = new ApplicationContext(frm);
        System.Windows.Forms.Application.Run(context);
    }

    private static void Frm_Load(object sender, EventArgs e)
    {
        //MessageBox.Show("lorem ipsum");
    }
}


public class MyForm : System.Windows.Forms.Form
{
    IContainer components;

    public MyForm()
    {
        components = new System.ComponentModel.Container();
        components.Add(new Button()
        {
            Text = "Click",
            Left = 0,
            Top = 0,
            Visible = true
        });

        this.Text = "This is the Title of the Form....";
        this.BackColor = System.Drawing.Color.FromArgb(0x56, 0x7c, 0x73);
    }
}