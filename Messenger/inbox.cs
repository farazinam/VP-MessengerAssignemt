using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace Messenger
{
    public partial class inbox : Form
    {
        public inbox()
        {
            
            InitializeComponent();
        }
        public class Response
        {
            public string message_id { get; set; }
            public int message_count { get; set; }
            public double price { get; set; }
        }
        public class RootObject
        {
            public Response Response { get; set; }
            public string ErrorMessage { get; set; }
            public int Status { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Phone = textBox1.Text;
            string messages = richTextBox1.Text;
            string API_KEY = "k7tawggw9i5wdb5";
            string SECRET_KEY = "qkfjups6vfnub8d";
            string API_URL = "https://www.thetexting.com/rest/sms/json/message/send?api_key=" + API_KEY + "&api_secret=" + SECRET_KEY + "&to=" + Phone + "&text=" + messages;

            try
            {

                using (WebClient client = new WebClient())
                {

                    string s = client.DownloadString(API_URL);

                    var responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(s);
                    int n = responseObject.Status;
                    if (n == 3)
                    {
                        MessageBox.Show("Message Not Send Successfully", "My Demo App");

                    }
                    else
                    {
                        MessageBox.Show("Message Send Successfully", "My Demo App");
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Message Not Send Successfully", "My Demo App");
                ex.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 LoginPage = new Form1();

            LoginPage.Show();
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

