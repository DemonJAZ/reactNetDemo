using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using reactNetDemo.Model;

namespace reactNetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            string query = @"SELECT [EmployeeID],[EmployeeName],[Department],[DateOfJoining],[PhotoFileName] FROM [EmployeeDB].[dbo].[Employee]";
            DataTable table = new DataTable();
            string conn = _configuration.GetConnectionString("EmployeeAppCon");
            using (SqlConnection myCon = new SqlConnection(conn))
            {
                myCon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                {
                    SqlDataReader myReader = sqlCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();

                }

            }
            return JsonConvert.SerializeObject(table);
        }

        [HttpPost]
        public string Post(Employee emp)
        {
            string query = @"Insert into dbo.Employee values('" + emp.EmployeeName + @"','" + emp.Department + "','" + emp.DateOfJoining + "','" + emp.PhotoFileName + "')";
            string conn = _configuration.GetConnectionString("EmployeeAppCon");
            using (SqlConnection myCon = new SqlConnection(conn))
            {
                myCon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                {
                    sqlCommand.ExecuteReader();
                    myCon.Close();

                }

            }
            return "Added successfully";
        }

        [HttpPut]
        public string Put(Employee emp)
        {
            string query = @"Update dbo.Employee set 
                            Department='" + emp.Department + @"',
                            EmployeeName='" + emp.EmployeeName + @"',
                            DateOfJoining='" + emp.DateOfJoining + @"',
                            PhotoFileName='" + emp.PhotoFileName + @"',
                            where EmployeeID=" + emp.EmployeeID;
            string conn = _configuration.GetConnectionString("EmployeeAppCon");
            using (SqlConnection myCon = new SqlConnection(conn))
            {
                myCon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                {
                    sqlCommand.ExecuteReader();
                    myCon.Close();

                }

            }
            return "updated successfully";
        }

        [HttpDelete("{Id}")]

        public string Delete(int Id)
        {
            string query = @"delete from dbo.Employee where EmployeeID=" + Id;
            string conn = _configuration.GetConnectionString("EmployeeAppCon");
            using (SqlConnection myCon = new SqlConnection(conn))
            {
                myCon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                {
                    sqlCommand.ExecuteReader();
                    myCon.Close();

                }

            }
            return "deleted successfully";
        }
    }
}
