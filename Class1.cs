using System;


namespace ConsoleApplication7
{
    class Employeemanagent
    {
        string choice;
        Employee Employee = new Employee();
        
                   
        public void start()
        {
            while (true)
            {
                Employee.databaseConnection();
                Console.WriteLine("Enter your choice\n");
                Console.WriteLine("1. Add\n");
                Console.WriteLine("2. Display\n");
                Console.WriteLine("3. Remove details \n");
                Console.WriteLine("4. Update\n");
                Console.WriteLine("5. Exit");
               

                choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        Employee.getid();
                        Employee.getname();
                        Employee.getemail();
                        Employee.getcontactnum();
                        Employee.getdateofbirth();
                        Employee.getdateofjoin();
                        Employee.Store(); break;

                    case "2":
                        Employee.getdetails(); break;

                    case "3":
                        Employee.idvalidation();
                         break;

                    case "4":
                        Employee.update();
                         break;

                    case "5":
                        System.Environment.Exit(0); break;


                    default:
                        Console.WriteLine("Enter correct choice"); break;
                }
            }

        }
static void Main(string[] args)
        {
            Employeemanagent employeemanagement = new Employeemanagent();
            employeemanagement.start(); 
          

            Console.ReadLine();
        }
    }
}
