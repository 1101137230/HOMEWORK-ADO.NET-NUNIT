using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HOMEWORK_ADO.NET_NUNIT
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            searchButton_Click(null, null);
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    //cmd.CommandText = "select * from Student where Name like @name";

                    cmd.CommandText = "SELECT Student_ID, Student_Class, Student_Name,Student_Gender, FORMAT(Student_Birthday,'yyyy/MM/dd') AS Student_Birthday FROM Student where Student_Name like @name;";

                    cmd.Parameters.Add(new SqlParameter("@name", "%" + searchBox.Text + "%"));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dr.Close();
                        resultGridView.DataSource = dt;
                        resultGridView.DataBind();

                        //add age column and calculate age
                        /***      dt.Columns.Add("Age", typeof(System.Int32));
                               Calculate cal = new Calculate();
                               foreach (DataRow data in dt.Rows)
                               {
                                   int age = cal.getAge(Convert.ToDateTime(data["Birthday"]));
                                   data["Age"] = age;
                               }***/


                    }
                }
            }
        }
        protected void insertButton_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO [dbo].[Student]([Student_Class],[Student_Name],[Student_Gender],[Student_Birthday])
                            VALUES (@Student_Class,@Student_Name,@Student_Gender,@Student_Birthday);SELECT CAST(scope_identity() AS int);";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@Student_Class", insertClassTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Student_Name", insertNameTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Student_Gender", insertGenderTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Student_Birthday", insertBirthdayTextBox.Text));

                    insertIDTextBox.Text = cmd.ExecuteScalar().ToString();
                }
                searchButton_Click(null, null);
            }
        }
        protected void updateButton_Click(object sender, EventArgs e)
        {
            string sql = @"update [dbo].[Student] set [Student_Class]=@Student_Class,[Student_Name] = @Student_Name,[Student_Gender]=@Student_Gender ,[Student_Birthday]=@Student_Birthday
                             where [Student_ID] = @Student_ID";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@Student_ID", updateIDTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Student_Class", updateClassTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Student_Name", updateNameTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Student_Gender", updateGenderTextBox.Text));
                    cmd.Parameters.Add(new SqlParameter("@Student_Birthday", updateBirthdayTextBox.Text));

                    cmd.ExecuteNonQuery();
                }
                searchButton_Click(null, null);
            }
        }
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string sql = @"DELETE FROM [dbo].[Student]
                           WHERE Student_ID = @Student_ID";
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SqlParameter("@Student_ID", deleteIDTextBox.Text));

                    cmd.ExecuteNonQuery();
                }
                searchButton_Click(null, null);
            }
        }
    }
}