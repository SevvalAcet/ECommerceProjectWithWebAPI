using Entities.Dtos.UserDtos;
using System.Net.Http.Json;

namespace WebAPIWithWindowsForm
{
    public partial class Form1 : Form
    {

        #region Defines 
        string url = "http://localhost:37453/api/";
        private int selectedID = 0;
        #endregion Defines

        #region Form1
        public Form1()
        {
            InitializeComponent();
        }
        #endregion Form1

        private async void Form1_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            await DataGridViewFill();
            CmbGenderFill();
        }

        #region Crud
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserAddDto userAddDto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text),
                    Email = txtEmail.Text,
                    Gender = txtGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };

                HttpResponseMessage response = await httpClient.PostAsJsonAsync(url + "Users/Add", userAddDto);
                if (response.IsSuccessStatusCode)
                {
                    await DataGridViewFill();
                    MessageBox.Show("Ekleme iþlemi baþarýlý!");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Ekleme iþlemi baþarýsýz!");
                }
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                UserUpdateDto userUpdateDto = new UserUpdateDto()
                {
                    Id = selectedID,
                    FirstName = txtFirstName.Text,
                    Address = txtAddress.Text,
                    DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text),
                    Email = txtEmail.Text,
                    Gender = txtGender.Text == "Erkek" ? true : false,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text
                };

                HttpResponseMessage response = await httpClient.PutAsJsonAsync(url + "Users/Update", userUpdateDto);
                if (response.IsSuccessStatusCode)
                {
                    await DataGridViewFill();
                    MessageBox.Show("Düzenleme iþlemi baþarýlý!");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Düzenleme iþlemi baþarýsýz!");
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            using (HttpClient httpClient = new HttpClient())
            {

                HttpResponseMessage response = await httpClient.DeleteAsync(url + "Users/Delete" + selectedID);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Silme iþlemi baþarýlý!");
                    await DataGridViewFill();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Silme iþlemi baþarýsýz!");
                }
            }
        }

        private async void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            selectedID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            using (HttpClient httpClient = new HttpClient())
            {
                var user = await httpClient.GetFromJsonAsync<UserDto>(url + "Users/GetById/" + selectedID);

                txtAddress.Text = user.Address;
                txtGender.SelectedValue = user.Gender == true ? 1 : 2;
                txtUserName.Text = user.UserName;
                txtLastName.Text = user.LastName;
                txtFirstName.Text = user.FirstName;
                txtEmail.Text = user.Email;
                txtPassword.Text = String.Empty;
                dtpDateOfBirth.Value = user.DateOfBirth;
            }
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }

        #endregion

        #region Methods

        private void CmbGenderFill()
        {
            List<Gender> genders = new List<Gender>();
            genders.Add(new Gender() { Id = 1, GenderName = "Erkek" });
            genders.Add(new Gender() { Id = 2, GenderName = "Kadýn" });
            txtGender.DataSource = genders;
            txtGender.DisplayMember = "GenderName";
            txtGender.ValueMember = "Id";
        }

        class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }

        private async Task DataGridViewFill()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var users = await httpClient.GetFromJsonAsync<List<UserDetailDto>>(url + "Users/GetList");
                dataGridView1.DataSource = users;
            }
        }
        void ClearForm()
        {
            txtAddress.Text = String.Empty;
            txtGender.SelectedValue = 0;
            txtPassword.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            dtpDateOfBirth.Value = DateTime.Now;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        #endregion Methods

    }
}