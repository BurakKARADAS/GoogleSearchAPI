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
using Newtonsoft.Json;

namespace GoogleSearchAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string aranacak = "karadasburak.com";
            string cx = "012206473211536691174:p3wdsjftbeo";
            string apikey = "AIzaSyBAPNMCX7Ywi85WMCW1WGLNvIucpbnCe_8";
            string link = "https://www.googleapis.com/customsearch/v1?key=" + apikey + "&cx=" + cx + "&q=" + aranacak + "&start=1";
            var request = WebRequest.Create(link);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            string rs = reader.ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(rs);

            if (json.items != null)
            {
                foreach (var item in json.items)
                {
                    dgv.Rows.Add(item.link, item.title, item.snippet);
                }
            }
        }
    }
}
