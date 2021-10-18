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
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            string query = @"select DepartmentID,DepartmentName from dbo.Department";
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
        public string Post(Department dep)
        {
            Console.WriteLine(dep.DepartmentName);
            string query = @"Insert into dbo.Department values('" + dep.DepartmentName + @"')";
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
        public string Put(Department dep)
        {
            Console.WriteLine(dep.DepartmentName);
            string query = @"Update dbo.Department set DepartmentName='" + dep.DepartmentName + @"' where DepartmentID=" + dep.DepartmentId.ToString();
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
            string query = @"delete from dbo.Department where DepartmentID=" + Id;
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
