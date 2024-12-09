using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmkoliks.comV1
{
    public partial class salonListesi : UserControl // Burada Inheritance (kalıtım) örneği var. salomListesi sınıfı UserControl sınıfından miras almış.
    {
        public salonListesi()
        {
            InitializeComponent();
        }
        private void gel(object sender, MouseEventArgs e)
        {
            
            this.BackColor = Color.Lavender;
                
        }

        private void ayril(object sender, EventArgs e)
        {
            
            this.BackColor = Color.WhiteSmoke;
        }
    }
}
