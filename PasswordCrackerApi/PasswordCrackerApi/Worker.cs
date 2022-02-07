using PasswordCrackerApi.Dtos;
using System.Security.Cryptography;
using System.Text;

namespace PasswordCrackerApi
{
    public class Worker
    {

        public async Task<string> BruteforcePool(CrackRequestDto crackRequest)
        {
            var task1 = BruteforceUnit(crackRequest.HashCode, crackRequest.Length, crackRequest.Alphabet.ToCharArray());
            return await task1;
        }
        public async Task<string> BruteforceUnit(string passwordHash, int length, char[] alphabet)
        {
            char[] password = new string(alphabet[0], 4).ToCharArray();
            Task<string> task = Task.Run(() => recursiveMethod(passwordHash, password, length, alphabet, 1, 1));
            return await task;

        }
        public string recursiveMethod(string passwordHashToFind, char[] passwordArray, int length, char[] alphabet, int passwordIndexToChange, int alphabetIndex)
        {
            Console.WriteLine(alphabetIndex + "," + alphabet.Length + "," + passwordIndexToChange + "," + length);
            if (alphabetIndex == alphabet.Length - 1 && passwordIndexToChange == 0) { Console.WriteLine("stopped"); return "not found"; };
            if (passwordIndexToChange != 0)
            {
                passwordArray[passwordIndexToChange] = alphabet[alphabetIndex];
                passwordIndexToChange++;
            }
            if (passwordIndexToChange == 0)
            {
                alphabetIndex++;
                passwordArray[0] = alphabet[alphabetIndex];
                passwordIndexToChange++;
            }
            
            if (passwordIndexToChange == length)
            {
                passwordIndexToChange = 0;
            }
            Console.WriteLine(new string(passwordArray));
            if (hashPassword(new string(passwordArray)) == passwordHashToFind) return new string(passwordArray);
            Console.WriteLine(DateTime.Now.ToString());
            recursiveMethod(passwordHashToFind, passwordArray, length, alphabet, passwordIndexToChange, alphabetIndex);
            return "not found";
        }
        public string hashPassword(string password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                return System.Text.Encoding.Default.GetString(mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
