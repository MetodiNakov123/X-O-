using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_O {
    public partial class Form3 : Form {
        public Form3() {
            InitializeComponent();
        }

        private void btnSingleplayer_Click(object sender, EventArgs e) {

            DialogResult = DialogResult.OK;
        }

        private void btnMultiplayer_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Abort;
        }
    }
}
