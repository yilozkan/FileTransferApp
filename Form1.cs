using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace FileTransferApp
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void sendBtn_Click(object sender, EventArgs e)
        {
            string selectedFilePath = textBox1.Text;
            


            if (!File.Exists(selectedFilePath))
            {
                MessageBox.Show("Select a valid file");
                return;
            }


            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 5000);
                NetworkStream ns = client.GetStream();
                BinaryWriter writer = new BinaryWriter(ns);
                
                
                using (client)
                using (ns)
                using (writer)
                {
                    FileInfo file = new FileInfo(selectedFilePath);
                    
                    writer.Write(file.Name);
                    writer.Write(file.Length);
                    
                    FileStream fs=new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read);
                    using (fs)
                    {
                        byte[] buffer = new byte[1024];
                        int byteRead;

                        while ((byteRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ns.Write(buffer, 0, byteRead);
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
         }

        private void fileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            using (openFileDialog)
            {
                openFileDialog.Filter = "All Files|*.*";
                openFileDialog.Title = "Select a file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    textBox1.Text = openFileDialog.FileName;
                }

            }
        }
    }
}