namespace PasswordCracker
{
    class PasswordGen
    {
        private const string num = "0123456789";
        private const string min = "abcdefghijklmnopqrstuvwxyz";
        private const string max = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string spe = "!\"#$%&/()=?@${[]}\'*-+.-_,;";

        // Create a complex string to use for create a random password
        private static string ComplexityStringToUse(int complexity)
        {
            string toUse = num;                                     // 0 - Numbers
            if (complexity == 1) { toUse += min; }                  // 1 - Numbers and Little Letters
            else if (complexity == 2) { toUse += max + min; }       // 2 - Numbers and All Letters
            else if (complexity == 3) { toUse += max + min + spe; } // 3 - All Characters

            return toUse;
        }

        public static string PasswordGenerator(int length, int complexity)
        {
            Random r = new();
            string toUse = ComplexityStringToUse(complexity);
            string password = "";

            for (int i = 0; i < length; i++) { password += toUse[r.Next(toUse.Length)]; }

            return password;
        }

        public static double Complexity(int length, int complexity)
        {
            string toUse = ComplexityStringToUse(complexity);

            return Math.Pow(toUse.Length, length);
        }

        public static void ComplexityStatRange(int lengthmin = 1, int lengthmax = 9, int complexmin = 0, int complexmax = 3)
        {
            for (int c = complexmin; c <= complexmax; c++)
            {
                Console.WriteLine($"Complexity: {c}");
                for (int i = lengthmin; i <= lengthmax; i++)
                {
                    Console.WriteLine($"Length: {i,2} - {PasswordGen.Complexity(i, c)}");
                }
                Console.WriteLine();
            }
        }
    }
}
