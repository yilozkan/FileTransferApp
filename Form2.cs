using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransferApp
{
    public partial class Form2 : Form
    {
        TcpListener listener;
        bool isListening = false;

        public Form2()
        {
            InitializeComponent();
      
        }

        private void fileBtn2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog(); 
            using (dialog)
            {
                dialog.Description = "Select a folder";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    textBox1.Text = dialog.SelectedPath;
                }

            }
        }

        private void listenBtn_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("Select a valid folder!");
                return;
            }

            Thread thread = new Thread(StartListening);
            thread.IsBackground = true;
            thread.Start();
            isListening = true;
            MessageBox.Show("Listening...");
        }

        private void StartListening()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, 5000);
                listener.Start();

                while (isListening)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    NetworkStream ns = client.GetStream();
                    BinaryReader binaryReader = new BinaryReader(ns);


                    using (ns)
                    using (binaryReader)
                    {
                        string fileName = binaryReader.ReadString();
                        long fileLength = binaryReader.ReadInt64();

                        string destPath = Path.Combine(textBox1.InvokeRequired ?
                    (string)textBox1.Invoke(new Func<string>(() => textBox1.Text)) :
                    textBox1.Text, fileName);

                        FileStream fs = new FileStream(destPath, FileMode.Create, FileAccess.Write);

                    using (fs)
                        {
                            byte[] buffer = new byte[4096];
                            int bytesRead;
                            long totalRead = 0;

                            while (totalRead < fileLength &&
                                   (bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fs.Write(buffer, 0, bytesRead);
                                totalRead += bytesRead;
                            }
                        }


                        MessageBox.Show("File received: " + fileName);
                    }
                    client.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
