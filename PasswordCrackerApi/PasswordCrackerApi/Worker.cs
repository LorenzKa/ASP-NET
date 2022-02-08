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
            char[] password = new string(alphabet[0], length).ToCharArray();
            Task<string> task = Task.Run(() => recursiveMethod(passwordHash.ToUpper(), password, alphabet, 0, 1));
            return await task;

        }
        public string hashPassword(string password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                //Console.WriteLine("Password: "+password);
                var hash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string result = "";
                for (int i = 0; i < hash.Length; i++)
                {
                    result += hash[i].ToString("X2");
                }
                //Console.WriteLine("Hash: " + result);
                return result;
            }
        }
        public string recursiveMethod(string passwordHashToFind, char[] passwordArray, char[] alphabet, int passwordIndexToChange, int alphabetIndex)
        {
            //Console.WriteLine(alphabetIndex + "," + alphabet.Length + "," + passwordIndexToChange + "," + length+","+fixedPasswordIndex+","+fixedBruteforceIndex);
            while (true)
            {
                if (hashPassword(new string(passwordArray)) == passwordHashToFind) return "Password: " + new string(passwordArray);
                if (passwordArray.Contains(alphabet.Last()) && passwordArray.Distinct().Count() == 1) return "not found";
                if (alphabetIndex == alphabet.Length)
                {
                    //Console.WriteLine("Reached a z");
                    for (int offset = 1; offset < passwordArray.Length; offset++)
                    {
                        //Console.WriteLine(offset);
                        if (Array.IndexOf(alphabet, passwordArray[offset]) != alphabet.Length - 1)
                        {
                            //Console.WriteLine("Went into if");
                            //Console.WriteLine(passwordArray[offset]);
                            //Console.WriteLine("Alphabetindex: " + (Array.IndexOf(alphabet, passwordArray[offset])));
                            passwordArray[offset] = alphabet[Array.IndexOf(alphabet, passwordArray[offset]) + 1];
                            for (int i = 0; i < offset; i++)
                            {
                                passwordArray[i] = alphabet.First();
                            }
                            //Console.WriteLine("Manipulated PW:" + new string(passwordArray));
                            alphabetIndex = 0;
                            //Console.WriteLine("Going out of for");
                            break;
                        }
                    }
                    //Console.WriteLine(passwordArray);

                }
                passwordArray[passwordIndexToChange] = alphabet[alphabetIndex];
                Console.WriteLine(new string(passwordArray));
                alphabetIndex++;
            }
        }
    }
}
