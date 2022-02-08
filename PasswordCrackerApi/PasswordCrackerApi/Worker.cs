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
            List<Task<string>> tasks = new List<Task<string>>();
            var progress = new Progress<string>();
            progress.ProgressChanged += (_, s) => Console.WriteLine("Progress: "+s);
            for (int i = 0; i < alphabet.Length; i++)
            {
                char[] password = (char.ToString(alphabet[i])+ new string(alphabet[0], length-1)).ToCharArray();
                //Console.WriteLine(password);
                tasks.Add(Task.Run(() => recursiveMethod(passwordHash.ToUpper(), password, alphabet, 1, 1, progress)));
            }
            Console.WriteLine("Started: " + tasks.Count);
            var resultList = await Task.WhenAll(tasks);
            var validResult = resultList.Where(x => x != null).FirstOrDefault();
            if (validResult != null)
            {
                return validResult;
            }
            return "Password not found!";

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
        public string recursiveMethod(string passwordHashToFind, char[] passwordArray, char[] alphabet, int passwordIndexToChange, int alphabetIndex, IProgress<string> progress)
        {
            //Console.WriteLine(alphabetIndex + "," + alphabet.Length + "," + passwordIndexToChange + "," + length+","+fixedPasswordIndex+","+fixedBruteforceIndex);
            int counter = 0;
            while (true)
            {
                //Console.WriteLine(new string(passwordArray));
                counter++;
                if (hashPassword(new string(passwordArray)) == passwordHashToFind) return "Password: " + new string(passwordArray);
                if (passwordArray.Skip(1).Contains(alphabet.Last()) && passwordArray.Skip(1).Distinct().Count() == 1) return null;
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
                            for (int i = 1; i < offset; i++)
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
                alphabetIndex++;
            }
        }
    }
}
