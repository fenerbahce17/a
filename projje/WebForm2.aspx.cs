using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;
using System.Collections.Generic;
using System.Web.Services.Description;

namespace WebApplication1
{
    public class User
    {
        
        public string Username { get; set; }
        
        public string Password { get; set; }
    }
    public partial class WebForm2 : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            // Sayfa yüklendiğinde yapılacak işlemler
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string connectionString = "Data Source=LAPTOP-NP5SSJAJ\\SQLEXPRESS;Initial Catalog=ornek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


          

            using (SqlConnection connection = new SqlConnection(connectionString))
            {



                try
                {
                    connection.Open();
                    Console.WriteLine("SQL Server Database is connected successfully");

                    // Giriş işlemleri için burada ek işlemleri gerçekleştirebilirsiniz.

                    string query = "SELECT COUNT(*) FROM Table_1 WHERE isim = @isim AND sifre = @sifre";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isim", username.Text);
                        command.Parameters.AddWithValue("@sifre", password.Text);

                        int userCount = (int)command.ExecuteScalar();

                        if (userCount > 0)
                        {

                            // Kullanıcı doğrulandı, giriş başarılı

                            lblMessage.Text = "giriş başarılı";
                            Response.Redirect("Premium.html", false);
                        }
                        else
                        {
                            // Kullanıcı doğrulanamadı, giriş başarısız

                            lblMessage.Text = "giriş başarısız";

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    lblMessage.Text = ex.Message;

                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-NP5SSJAJ\\SQLEXPRESS;Initial Catalog=ornek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            UserManager userManager = new UserManager();
            User newUser = new User
            {
                Username = username.Text,
             
                Password = password.Text
            };

            userManager.AddUser(newUser);


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("SQL Server Database is connected successfully");

                    // Kayıt işlemleri için burada ek işlemleri gerçekleştirebilirsiniz.
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public class UserManager
        {
            private string connectionString = "Data Source=LAPTOP-NP5SSJAJ\\SQLEXPRESS;Initial Catalog=ornek;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            public void AddUser(User user)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Table_1 (isim,  sifre) VALUES (@isim,  @sifre)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isim", user.Username);
                       
                        command.Parameters.AddWithValue("@sifre", user.Password);
                        command.ExecuteNonQuery();
                    }
                }
            }

           
        }

        protected void username_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
