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
        public static void Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:3000");
            RestRequest request = new RestRequest("/employees/"+id, Method.DELETE);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);

        }
        public static void Add(Employee employee)
        {
            RestClient client = new RestClient("http://localhost:3000");
            RestRequest request = new RestRequest("/employees", Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(employee), ParameterType.RequestBody);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        public static void Update(Employee employee,int id)
        {
            RestClient client = new RestClient("http://localhost:3000");
            RestRequest request = new RestRequest("/employees/"+id, Method.PUT);
            request.AddParameter("application/json", JsonConvert.SerializeObject(employee), ParameterType.RequestBody);
            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
        static void Main(string[] args)
        {
            Delete(5);
            var list = getEmployee();
            foreach (var item in list)
            {
                Console.WriteLine(item.name+" "+item.salary);
            }
        }
    }
}
