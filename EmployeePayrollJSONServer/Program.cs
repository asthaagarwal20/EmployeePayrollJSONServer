using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollJSONServer
{
     class Program
    {
        public  static List<Employee> getEmployee()
        {
            RestClient client = new RestClient("http://localhost:3000");
            RestRequest request = new RestRequest("/employees",Method.GET);
            var response =  client.Execute(request);
            return JsonConvert.DeserializeObject<List<Employee>>(response.Content);
        }
        static void Main(string[] args)
        {
            var list = getEmployee();
            foreach (var item in list)
            {
                Console.WriteLine(item.name);
            }
        }
    }
}
