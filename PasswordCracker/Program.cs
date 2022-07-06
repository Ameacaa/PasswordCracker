namespace PasswordCracker
{    
    class Program
    {
        private readonly static string password = PasswordGen.PasswordGenerator(5, 1);









        static void Main()
        {

            Console.WriteLine(password);



        }
    }
}
