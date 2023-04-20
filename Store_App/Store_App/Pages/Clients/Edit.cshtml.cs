using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Store_App.Pages.Clients
{
    public class EditModel : PageModel
    {
		public ClientInfo clientInfo = new ClientInfo();
		public string errorMessage = "";
		public string successMessage = "";
		public void OnGet()
        {
			string id = Request.Query["id"];

			try
			{
				string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=mystore;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string sql = "SELECT * FROM clients WHERE id=@id";
					using (SqlCommand command = new SqlCommand(sql, connection))//to exicute the sql query
					{
						command.Parameters.AddWithValue("@id", id);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								clientInfo.id = "" + reader.GetInt32(0);
								clientInfo.name = reader.GetString(1);
								clientInfo.email = reader.GetString(2);
								clientInfo.phone = reader.GetString(3);
								clientInfo.address = reader.GetString(4);
							}
						}
					}

				}

			}
			catch (Exception ex)
			{
				errorMessage = ex.Message;
			}
		}
		public void OnPost()
		{
			clientInfo.id = Request.Form["id"];
			clientInfo.name = Request.Form["name"];
			clientInfo.email = Request.Form["email"];
			clientInfo.address = Request.Form["address"];
			clientInfo.phone = Request.Form["phone"];

			if (clientInfo.name.Length == 0 || clientInfo.email.Length == 0 || clientInfo.address.Length == 0 || clientInfo.phone.Length == 0)
			{
				errorMessage = "All Fields are required";
				return;
			}

			//svae new client into database
			try
			{
				string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=mystore;Integrated Security=True";
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string sql = "UPDATE clients " +
								"SET name=@name,email=@email,phone=@phone,address=@address " +
								"WHERE id=@id";

					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@name", clientInfo.name);
						command.Parameters.AddWithValue("@email", clientInfo.email);
						command.Parameters.AddWithValue("@phone", clientInfo.phone);
						command.Parameters.AddWithValue("@address", clientInfo.address);
						command.Parameters.AddWithValue("@id", clientInfo.id);

						command.ExecuteNonQuery();
					}
				}

			}
			catch (Exception ex)
			{
				errorMessage = ex.Message;
				return;
			}
			clientInfo.name = "";
			clientInfo.email = "";
			clientInfo.address = "";
			clientInfo.phone = "";
			successMessage = "New Client Added Successfully";

			Response.Redirect("/Clients");




		}
	}
}
