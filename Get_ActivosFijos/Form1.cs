using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Get_ActivosFijos
{
    public partial class Form1 : Form
    {
        string Url = "https://localhost:7037/api/Datos/obtenerAsientos";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        public async Task<string>GetHttp()
        {
            WebRequest peticion = WebRequest.Create(Url);
            WebResponse respuesta = peticion.GetResponse();
            StreamReader sr = new StreamReader(respuesta.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string res = await GetHttp();
            List<PostViewModel> lis = JsonConvert.DeserializeObject<List<PostViewModel>>(res);
            dataGridView1.DataSource = lis;
        }
        private async Task<string> GetXmlFromApi(string apiUrl)
        {
            using (WebClient client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(apiUrl);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string apiUrl = "https://localhost:7037/api/Datos/generarXml"; 
                string xmlData = await GetXmlFromApi(apiUrl);
                textBox1.Text = xmlData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
