using Entities.Dtos.UserDtos;
using System.Net.Http.Json;

namespace WebAPIWithWindowsForm
{
    public partial class Form1 : Form
    {
        string url = "http://localhost:37453/api/Users/GetList";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(new Uri(url));
                dataGridView1.DataSource = users;
            }
        }
    }
}