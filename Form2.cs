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
    public delegate void UpdateConversationDelegate(string text);
    public partial class DysordForm : System.Windows.Forms.Form
    {
        string targetUser = "";
        public string targetIp = "";
        public int targetPort;
        string myIp = "";
        int myPort;
        Thread thread;
        Socket listener;

        public DysordForm()
        {
            InitializeComponent();

           
            SettingsForm settingsForm = new SettingsForm(this, myPort);
            settingsForm.ShowDialog();
            this.myPort = settingsForm.myPort;

            this.Show();

            ThreadStart threadStart = new ThreadStart(Listen);
            thread = new Thread(threadStart);
            thread.Start();

            IPHostEntry iPHost = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress iPAddress in iPHost.AddressList)
            {
                if(iPAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    this.myIp = iPAddress.ToString();
                    break;

                }
            }

            this.loginButton.Click += new EventHandler(LoginButton__Click);
            //this.usersButton.Click += new EventHandler(UsersButton__Click);
            this.sendButton.Click += new EventHandler(SendButton__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);
            this.webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser2__DocumentCompleted);
            this.FormClosing += new FormClosingEventHandler(Form__FormClosing);
        }

        private void LoginButton__Click(object sender, EventArgs e)
        {
            if(userTextBox.TextLength > 0)
            {
                webBrowser1.Navigate("http://people.rit.edu/dxsigm/php/login.php?login=" + userTextBox + "&ip=" + myIp + ":" + myPort);
                webBrowser1.Visible = false;
                userTextBox.Enabled = false;
                loginButton.Enabled = false;
            }
        }

        private void UsersButton__Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://people.rit.edu/dxsigm/php/login.php?logins");
            //webBrowser1.Visible = true;
            convRichTextBox.SendToBack();
        }

        private void SendButton__Click(object sender, EventArgs e)
        {
            if(this.targetIp.Length > 0)
            {
                IPAddress iPAddress = IPAddress.Parse(this.targetIp);
                IPEndPoint remoteEndPoint = new IPEndPoint(iPAddress, this.targetPort);

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(remoteEndPoint);
                Stream netStream = new NetworkStream(server);
                StreamWriter writer = new StreamWriter(netStream);

                string msg = userTextBox.Text + ":" + msgRichTextBox;
                writer.Write(msg.ToCharArray(), 0, msg.Length);

                writer.Close();
                netStream.Close();
                server.Close();

                this.convRichTextBox.Text += "> " + this.targetUser + ":" + msgRichTextBox.Text + "\n";

                msgRichTextBox.Clear();
            }

        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            listener.Close();
            thread.Abort();

            Application.Exit();
        }

        private void Form__FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Close();
            thread.Abort();
        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser2.Navigate("http://people.rit.edu/dxsigm/php/login.php?logins");

        }

        private void WebBrowser2__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection htmlElementCollection = webBrowser2.Document.GetElementsByTagName("button");
            Random rand = new Random();
            int randUser = rand.Next(htmlElementCollection.Count-1);

            //make a catch if no one is in the chat room

            string title;
            string[] ipPort;

            HtmlElement htmlElement = htmlElementCollection[randUser];
            
            //
            title = htmlElement.GetAttribute("title");
            ipPort = title.Split(':');
            this.targetIp = ipPort[0];
            this.targetPort = Int32.Parse(ipPort[1]);
            //
            this.targetUser = htmlElement.GetAttribute("name");
            this.groupBox1.Text = "You've been matched!! ";
 

        }

        private void Listen()
        {
            UpdateConversationDelegate updateConversationDelegate = new UpdateConversationDelegate(UpdateConversation);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, this.myPort);

            this.listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(serverEndPoint);
            listener.Listen(300);

            while(true)
            {
                Socket client = listener.Accept();
                Stream netStream = new NetworkStream(client);
                StreamReader reader = new StreamReader(netStream);
                string result = reader.ReadToEnd();
                Invoke(updateConversationDelegate, result);
                reader.Close();
                netStream.Close();
                client.Close();

            }

        }

        private void UpdateConversation(string text)
        {
            this.convRichTextBox.Text += text + '\n';
            //this.toolStripProgressBar1.Value += 1;
        }


        private void questions20button__Click(object sender, EventArgs e)
        {
            PhraseForm phraseForm = new PhraseForm(this);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
