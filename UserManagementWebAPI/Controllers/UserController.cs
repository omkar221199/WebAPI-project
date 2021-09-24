using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManagementWebAPI.Models;

namespace UserManagementWebAPI.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string query = @"select userid, username from dbo.Users";


            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserManagementDB"].ConnectionString);
            var cmd = new SqlCommand(query, con);
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dt);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string Post(User user)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @" INSERT INTO dbo.Users values ('" + user.UserName + @"')
                                ";


                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserManagementDB"].ConnectionString);
                var cmd = new SqlCommand(query, con);
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }

                return "Added successfully";
            }
            catch (Exception ex)
            {
                return "Failed to add.";
            }
        }

        public string Put(User user)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @" update dbo.Users set username = '" + user.UserName + @"'
                                    where userid = " + user.UserID + @"
                                ";


                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["UserManagementDB"].ConnectionString);
                var cmd = new SqlCommand(query, con);
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dt);
                }

                return "Updated successfully";
            }
            catch (Exception ex)
            {
                return "Failed to update.";
            }
        }
    }
}
