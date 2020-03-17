using System;


namespace ConsoleApplication7
{
    public class InvalidException : Exception
    {
        public void Invalidname()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INVALID NAME" + "\n" + "The name Should Start with Uppercase " + "\n" + "Its not contaion two spaces" + "\n" + "Continue of same char and no special char");
            Console.ForegroundColor = ConsoleColor.White;
            
        }
        public void InvalidId()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INVALID ID" + "\n" + "The Id Should Start with ACE**** " + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Invalidemail()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INVALID EMAIL" + "\n" + "The email Should Start with lowercase " + "\n" + "Its not contaion  spaces" + "\n" + "Ex:firstname.lastname@aspiresys.com");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Invalidcontact()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INVALID CONTACT" + "\n" + "The contact Should contain 10 digits " + "\n" + "it's starts with 6 to 9" + "\n" + "Ex:9047***567");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void InvalidDOB()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INVALID Dateofbirth" + "\n" + "FORMAT is 12/29/1999  or  1999/07/18 ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Invalidjoiningdate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("INVALID join date" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
