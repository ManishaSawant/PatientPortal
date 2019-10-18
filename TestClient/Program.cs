using EFDemo.Domain.DataAccess;
using System;
using System.Linq;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context=new EFDemo.Domain.DataAccess.EFDemoContext())
            {                var patients = context.Patients.ToList();
                foreach (var patient in patients)
                {
                    Console.WriteLine(patient.FirstName + "" + patient.LastName);
                }
                Console.ReadKey();
            }
        }
    }
}
