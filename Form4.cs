using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dyscord
{
    public partial class HintForm : System.Windows.Forms.Form
    {
        public String hint = "";
        public HintForm(System.Windows.Forms.Form owner)
        {
            InitializeComponent();
            this.Owner = owner;
            this.CenterToParent();


            this.sendButton.Click += new EventHandler(SendButton__Click);
        }

        private void SendButton__Click(object sender, EventArgs e)
        {
            this.hint = this.richTextBox1.Text;
            this.Close();
        }
    }
}
