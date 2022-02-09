using PasswordCrackerApi.Dtos;
using System.Security.Cryptography;
using System.Text;

namespace PasswordCrackerApi
{
    public class Worker
    {

        public async Task<string> BruteforcePoolManager(string passwordHash, int length, char[] alphabet)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            
            List<Task<string>> tasks = new List<Task<string>>();
            var progress = new Progress<string>();
            progress.ProgressChanged += (_, s) =>
            {
                Console.WriteLine("Progress: " + s);
                if (s.Contains("found Password")) cancellationTokenSource.Cancel();
            };
            var tries = (int)Math.Pow(alphabet.Length, length) / alphabet.Length;
            
            for (int i = 0; i < alphabet.Length; i++)
            {
                char[] password = (char.ToString(alphabet[i]) + new string(alphabet[0], length - 1)).ToCharArray();
                //Console.WriteLine(password);
                tasks.Add(Task.Run(() => BruteforceUnit(passwordHash.ToUpper(), password, alphabet, 1, 1, progress, tries, cancellationTokenSource.Token)));
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
        public string BruteforceUnit(string passwordHashToFind, char[] passwordArray, char[] alphabet, int passwordIndexToChange, int alphabetIndex, IProgress<string> progress, int tries, CancellationToken cancellationToken)
        {
            //Console.WriteLine(alphabetIndex + "," + alphabet.Length + "," + passwordIndexToChange + "," + length+","+fixedPasswordIndex+","+fixedBruteforceIndex);
            int counter = 0;
            int reportedAt = 0;
            while (true)
            {
                if (cancellationToken.IsCancellationRequested) return null;
                //Console.WriteLine(new string(passwordArray));
                counter++;
                if ((tries / counter) % 10.0 == 0.0 && (tries / counter) < 100 && reportedAt != (tries / counter))
                {
                    reportedAt = tries / counter;
                    //Console.WriteLine(tries + "," + counter);
                    //Console.WriteLine($"Task: {passwordArray[0]} {tries}");
                    progress.Report($"Task: {passwordArray[0]} is {100 - (tries / counter)}% complete");
                }
                if (HashPassword(new string(passwordArray)) == passwordHashToFind)
                {
                    progress.Report($"Task: {passwordArray[0]} found Password");
                    return "Password: " + new string(passwordArray);
                }
                if (passwordArray.Skip(1).Contains(alphabet.Last()) && passwordArray.Skip(1).Distinct().Count() == 1)
                {
                    progress.Report($"Task: {passwordArray[0]} completed");
                    return null;
                }
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
        public string HashPassword(string password)
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
    }
}
