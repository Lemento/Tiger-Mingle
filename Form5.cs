using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Dyscord
{
    public partial class PhraseForm : Form
    {
        public String answer = "";
        public PhraseForm(Form owner)
        {
            InitializeComponent();
            this.Owner = owner;
            this.CenterToParent();
            this.targetIp = Owner.targetIp;
            this.targetPort = Owner.targetPort;


            this.sendButton.Click += new EventHandler(SendButton__Click);
        }

        private void SendButton__Click(object sender, EventArgs e)
        {
            this.answer = this.richTextBox1.Text;

            IPAddress iPAddress = IPAddress.Parse(targetIp);
            IPEndPoint remoteEndPoint = new IPEndPoint(iPAddress, targetPort);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Connect(remoteEndPoint);
            Stream netStream = new NetworkStream(server);
            StreamWriter writer = new StreamWriter(netStream);

            HangmanForm hangman = new HangmanForm(this);

            writer.Write(hangman);

            writer.Close();
            netStream.Close();
            server.Close();
            
            this.Close();
        }
    }
}
