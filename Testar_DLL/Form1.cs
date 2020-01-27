using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicos;


namespace Testar_DLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                classServico _objservico = new classServico();
                _objservico.GravarMovimento(_objservico.Credencial, _objservico.horalocal);
                MessageBox.Show("Menssagem inserido");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
