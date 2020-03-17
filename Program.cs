using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ConsoleApplication7
{

    class Employee
    {
        public String name;
        public String Empid;
        public String Contactnum;
        public String emailid;
        public DateTime dateofbirth;
        public DateTime joiningDate;
        public String detailsid;
        public String updateid;
        public int age = 0;
        List<string[]> list = new List<string[]>();
        private DataTable dataTable = new DataTable();
        Int32 count;




        public void getname()
        {
            try
            {
                Console.WriteLine("Enter Name ");
                name = Console.ReadLine();
                String condition1 = @"^(?!.*([A-Za-z])\1{2})(^[A-Z][a-z]*[\s][A-Za-z][a-z]*)$";
                String condition2 = @"^(?!.*([A-Za-z])\1{2})(^[A-Z][a-z]*)$";

                Regex regex1 = new Regex(condition1);
                Regex regex2 = new Regex(condition2);

                if (regex1.IsMatch(name))
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Name Entered");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else if (regex2.IsMatch(name))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Name Entered");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    throw new InvalidException();
                }
            }

            catch (InvalidException exception)
            {
                exception.Invalidname();
                getname();
            }


        }





        public void getid()
        {

            try
            {
                Console.WriteLine("Enter Employee Id EX:ACE****");
                Empid = Console.ReadLine();
                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Equals((list[i][1]), Empid))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Employee ID Already Exists\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        getid();
                        return;

                    }

                }

                String Condition = @"(?!.*([0])\1{3})(^[A][C][E][0-9]{4})$";
                Regex regex = new Regex(Condition);

                if (regex.IsMatch(Empid))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Employee ID Entered\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    throw new InvalidException();
                }
            }
            catch (InvalidException exception)
            {
                exception.InvalidId();
                getid();
            }
        }






        public void getemail()
        {
            try
            {
                Console.WriteLine("Enter EmployeeEmail ");
                emailid = Console.ReadLine();

                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Equals((list[i][3]), emailid))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Employee Email ID Already Exists");
                        Console.ForegroundColor = ConsoleColor.White;
                        getemail();
                        return;

                    }
                }
                String Condition = @"(?!.*([a-z])\1{2})(^[a-z]+.[a-z]+(@aspiresys.com))";
                Regex regex = new Regex(Condition);

                if (regex.IsMatch(emailid))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Email Entered");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    throw new InvalidException();
            }
            catch (InvalidException exception)
            {
                exception.Invalidemail();
                getemail();
            }
        }





        public void getcontactnum()
        {
            try
            {
                Console.WriteLine("Enter Employee Contact EX:9047******");
                Contactnum = Console.ReadLine();

                for (int i = 0; i < list.Count; i++)
                {
                    if (String.Equals((list[i][2]), Contactnum))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Employee Contact Number Already Exists");
                        Console.ForegroundColor = ConsoleColor.White;
                        getcontactnum();
                        return;

                    }
                }
                String Condition = @"(^[6-9][0-9]{9}$)";
                Regex regex = new Regex(Condition);

                if (regex.IsMatch(Contactnum))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Contact number Entered");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    throw new InvalidException();

            }
            catch (InvalidException exception)
            {
                exception.Invalidcontact();
                getcontactnum();
            }
        }





        public void getdateofbirth()
        {
            try
            {
                Console.WriteLine("Enter date of birth " + "\n" + " FORMAT is MM/DD/YYYY or  YYYY/DD/MM \n ");


                dateofbirth = Convert.ToDateTime(Console.ReadLine());

                age = DateTime.Now.Year - dateofbirth.Year;
                if (DateTime.Now.Month < dateofbirth.Month || (DateTime.Now.Month == dateofbirth.Month && DateTime.Now.Day < dateofbirth.Day))
                    age--;

                if (age >= 20 && age <= 60)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Date Of Birth Entered");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    throw new InvalidException();

            }
            catch (InvalidException e)
            {
                e.InvalidDOB();
                getdateofbirth();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID FORMAT  MM/DD/YYYY or  YYYY/DD/MM \n");
                Console.ForegroundColor = ConsoleColor.White;
                getdateofbirth();
            }
        }





        public void getdateofjoin()
        {
            try
            {
                Console.WriteLine("Enter joining date " + "\n" + " FORMAT is MM/DD/YYYY or  YYYY/DD/MM ");
                joiningDate = Convert.ToDateTime(Console.ReadLine());

                if (joiningDate.Year - dateofbirth.Year >= 20)
                {
                    Console.WriteLine("Joining Date Entered");
                }
                else
                    throw new InvalidException();
            }
            catch (InvalidException e)
            {
                e.Invalidjoiningdate();
                getdateofjoin();

            }
            catch (FormatException)
            {
                Console.WriteLine("INVALID FORMAT  MM/DD/YYYY or  YYYY/DD/MM ");
                getdateofbirth();
            }

        }



        SqlConnection sqlConnection = new SqlConnection("Data Source = ASPIRE1043; Initial Catalog =library; Integrated Security = True; ");

        public void databaseConnection()
        {
            sqlConnection.Open();
            String query2 = "select count(*) from employeemanagement";
            SqlCommand command2 = new SqlCommand(query2, sqlConnection);
            count = (Int32)command2.ExecuteScalar();
            sqlConnection.Close();
        }



        public void Store()
        {
            //list.Add(new string[] { name, Empid, Contactnum, emailid, Convert.ToString(dateofbirth), Convert.ToString(joiningDate) });

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("The data Entered Sucessfully" + "\n");
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.WriteLine("Name: " + name + "\n");
            //Console.WriteLine("Employeeid: " + Empid + "\n");
            //Console.WriteLine("Email: " + emailid + "\n");
            //Console.WriteLine("Contactnum: " + Contactnum + "\n");
            //Console.WriteLine("Dateofbirth: " + dateofbirth + "\n");
            //Console.WriteLine("Joining date: " + joiningDate + "\n");
            //Console.WriteLine("************************************************");
            //Console.WriteLine("                                                ");
            //Console.WriteLine("************************************************");



            sqlConnection.Open();

            string query = "insert into employeemanagement(name,empid,emailid,contactnum,dob,doj) values (@pa1,@pa2,@pa3,@pa4,@pa5,@pa6)";
            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.Parameters.Add("@pa1", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@pa2", SqlDbType.VarChar).Value = Empid;
            command.Parameters.Add("@pa3", SqlDbType.VarChar).Value = emailid;
            command.Parameters.Add("@pa4", SqlDbType.VarChar).Value = Contactnum;
            command.Parameters.Add("@pa5", SqlDbType.Date).Value = dateofbirth;
            command.Parameters.Add("@pa6", SqlDbType.Date).Value = joiningDate;
            command.ExecuteNonQuery();
              sqlConnection.Close();



        }





        public void getdetails()
        {

            Console.WriteLine("THE TOTAL RECORD IS: " + count);


            if (count > 0)
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from employeemanagement", sqlConnection);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine("Name:" + data.GetValue(0).ToString());
                    Console.WriteLine("EmployeeID:" + data.GetValue(1).ToString());
                    Console.WriteLine("EmailID:" + data.GetValue(2).ToString());
                    Console.WriteLine("ContactNO:" + data.GetValue(3).ToString());
                    Console.WriteLine("DOB:" + data.GetValue(4).ToString());
                    Console.WriteLine("DOJ:" + data.GetValue(5).ToString());
                    Console.WriteLine("******************************");



                }
                sqlConnection.Close();

            }
            else
                Console.WriteLine("NO RECORD FOUND");





            //if (list.Count > 0)
            //{
            //    Console.WriteLine("The Total Emplpoyee records is " + list.Count);
            //    for (int index = 0; index < list.Count; index++)
            //    {


            //        Console.WriteLine("Emplpoyee name:{0} \n Emplpoyee ID: {1} \n Emplpoyee Contactnum:{2} \n Emplpoyee Email:{3} \n  Emplpoyee Dateofbirth:{4} \n Emplpoyee joiningDate:{5}", list[index][0], list[index][1], list[index][2], list[index][3], list[index][4], list[index][5]);
            //        Console.WriteLine("************************************************");
            //        Console.WriteLine("                                                ");
            //        Console.WriteLine("************************************************");
            //    }
            //}
            //else
            //    Console.WriteLine("NO RECORD FOUND");

        }


        public void idvalidation()
        {
            if (count > 0)
            {
                sqlConnection.Open();
                Console.WriteLine("Enter Employee ID which you to Delete ");
                detailsid = Console.ReadLine();
                SqlCommand command = new SqlCommand("SELECT empid FROM employeemanagement", sqlConnection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (detailsid.Equals(reader[0]))
                        {
                            reader.Close();
                            sqlConnection.Close();
                            removedetails();
                            return;
                        }
                    }
                    Console.WriteLine("Employee ID Does not Exixts....");
                }
                sqlConnection.Close();
            }
            else
                Console.WriteLine("NO RECORD TO DELETE");


        }


        public void removedetails()
        {


            sqlConnection.Open();
            string query = "delete from employeemanagement where empid=@id";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = detailsid;
            command.ExecuteNonQuery();
            sqlConnection.Close();
            Console.WriteLine("Details Deleted Sucessfully....");




            //for (int index = 0; index < list.Count; index++)
            //{
            //    if (String.Equals(list[index][1], removedetailsid))
            //    {
            //        list.RemoveAt(index);
            //        Console.WriteLine("Details Deleted");
            //        break;

            //    }
            //    else if(index == list.Count - 1)
            //        Console.WriteLine("NO MATCH FOUND");
            //}

        }







        public void update()
        {
            if (count > 0)
            {
               sqlConnection.Open();
                Console.WriteLine("Enter Employee ID which you to update ");
                detailsid = Console.ReadLine();
                
                       
                        
                            
                            Console.WriteLine("Which data you want to update \n 1.Name 2.EmpID 3.Email 4.Contact Number 5.Date Of Birth 6.Date of Join\n");
                            String choices = Console.ReadLine();


                            switch (choices)
                            {
                                case "1":
                                    getname();
                                    sqlConnection.Close();
                                    sqlConnection.Open();
                                    string queryname = "update  employeemanagement set name=@name where empid=@id";
                                    SqlCommand updatename = new SqlCommand(queryname, sqlConnection);
                                    updatename.Parameters.Add("@id", SqlDbType.VarChar).Value = detailsid;
                                    updatename.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                                    updatename.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Console.WriteLine("Details updated  Sucessfully....");
                                    break;

                                case "2":
                                    getid();
                                    sqlConnection.Close();
                                    sqlConnection.Open();
                                    string queryid = "update  employeemanagement set empid=@updateid where empid=@id";
                                    SqlCommand updateid = new SqlCommand(queryid, sqlConnection);
                                    updateid.Parameters.Add("@id", SqlDbType.VarChar).Value = detailsid;
                                    updateid.Parameters.Add("@updateid", SqlDbType.VarChar).Value = Empid;
                                    updateid.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Console.WriteLine("Details updated  Sucessfully...."); break;


                                case "3":
                                    getemail();
                                    sqlConnection.Close();
                                    sqlConnection.Open();
                                    string querymail = "update  employeemanagement set emailid=@mail where empid=@id";
                                    SqlCommand updatemail = new SqlCommand(querymail, sqlConnection);
                                    updatemail.Parameters.Add("@id", SqlDbType.VarChar).Value = detailsid;
                                    updatemail.Parameters.Add("@mail", SqlDbType.VarChar).Value = emailid;
                                    updatemail.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Console.WriteLine("Details updated Sucessfully...."); break;


                                case "4":
                                    getcontactnum();

                                    sqlConnection.Open();
                                    string querynum = "update  employeemanagement set contactnum=@num where empid=@id";
                                    SqlCommand updatenum = new SqlCommand(querynum, sqlConnection);
                                    updatenum.Parameters.Add("@id", SqlDbType.VarChar).Value = detailsid;
                                    updatenum.Parameters.Add("@num", SqlDbType.VarChar).Value = Contactnum;
                                    updatenum.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Console.WriteLine("Details updated  Sucessfully...."); break;


                                case "5":
                                    getdateofbirth();
                                    sqlConnection.Open();
                                    string querydob = "update  employeemanagement set dob=@dob where empid=@id";
                                    SqlCommand updatedob = new SqlCommand(querydob, sqlConnection);
                                    updatedob.Parameters.Add("@id", SqlDbType.VarChar).Value = detailsid;
                                    updatedob.Parameters.Add("@dob", SqlDbType.VarChar).Value = dateofbirth;
                                    updatedob.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Console.WriteLine("Details updated  Sucessfully...."); break;



                                case "6":
                                    getdateofjoin();
                                    sqlConnection.Open();
                                    string querydoj = "update  employeemanagement set doj=@doj where empid=@id";
                                    SqlCommand updatedoj = new SqlCommand(querydoj, sqlConnection);
                                    updatedoj.Parameters.Add("@id", SqlDbType.VarChar).Value = detailsid;
                                    updatedoj.Parameters.Add("@doj", SqlDbType.VarChar).Value = joiningDate;
                                    updatedoj.ExecuteNonQuery();
                                    sqlConnection.Close();
                                    Console.WriteLine("Details updated Sucessfully...."); break;



                                default:
                                    Console.WriteLine("Invalid Choice");
                                    update(); break;
      }                         
                 
               
            }
            else
                Console.WriteLine("NO RECORD TO update");


                        //int index;

            //Console.WriteLine("Enter Employee ID to Update\n");
            //updateid = Console.ReadLine();
            //for (index = 0; index < list.Count; index++)
            //{
            //    if (String.Equals(list[index][1], updateid))
            //    {


            //        Console.WriteLine("Which data you want to update \n 1.Name 2.EmpID 3.Email 4.Contact Number 5.Date Of Birth 6.Date of Join\n");
            //        String choices = Console.ReadLine();


            //        switch (choices)
            //        {
            //            case "1":
            //                getname();
            //                list[index][0] = name; break;
            //            case "2":
            //                getid();
            //                list[index][1] = Empid; break;
            //            case "3":
            //                getemail();
            //                list[index][2] = emailid; break;
            //            case "4":
            //                getcontactnum();
            //                list[index][3] = Contactnum; break;
            //            case "5":
            //                getdateofbirth();
            //                list[index][4] = Convert.ToString(dateofbirth); break;
            //            case "6":
            //                getdateofjoin();
            //                list[index][5] = Convert.ToString(joiningDate); break;
            //            default:
            //                Console.WriteLine("Invalid Choice");
            //                update(); break;



            //        }
            //        break;

            //    }
            //    else if(index== list.Count-1)
            //    {
            //        Console.WriteLine("No Record Found");
            //    }


            //}

        }
    }
}
   

    

