using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace _24521120_NT106_Lab4
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
            this.Load += (s, e) => CenterContent();
            this.Resize += (s, e) => CenterContent();
        }

        private void CenterContent()
        {
            int spacing = 20;
            int totalWidth = textURL.Width + spacing + btnGet.Width;
            int left = (this.ClientSize.Width - totalWidth) / 2;
            textURL.Left = left;
            btnGet.Left = left + textURL.Width + spacing;

            richtextHTML.Left = (this.ClientSize.Width - richtextHTML.Width) / 2;
            textHTML.Left = (this.ClientSize.Width - textHTML.Width) / 2;

            int firstTop = textURL.Top;
            int lastBottom = richtextHTML.Bottom;
            int blockHeight = lastBottom - firstTop;
            int newFirstTop = Math.Max(10, (this.ClientSize.Height - blockHeight) / 2);
            int dy = newFirstTop - firstTop;

            textURL.Top += dy;
            btnGet.Top += dy;
            textHTML.Top += dy;
            richtextHTML.Top += dy;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                string correctURL = null;
                if (textURL.Text.Length == 0)
                {
                    MessageBox.Show("URL is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!textURL.Text.Contains("https://") && !textURL.Text.Contains("http://"))
                {
                    correctURL = "https://" + textURL.Text;
                }
                else
                {
                    correctURL = textURL.Text;
                }

                // Create a request for the URL.
                WebRequest request = WebRequest.Create(correctURL);
                // Get the response.
                WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Close the response.
                response.Close();

                richtextHTML.Text = responseFromServer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
