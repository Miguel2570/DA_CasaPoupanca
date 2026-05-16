using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasaPoupanca
{
    public partial class FormModoCompra : Form
    {
        private int _compraId;
        public FormModoCompra(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
        }

        private void FormModoCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
