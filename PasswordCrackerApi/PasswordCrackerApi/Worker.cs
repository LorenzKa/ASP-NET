using HtmlAgilityPack;
using PasswordCrackerApi.Dtos;
using System.Security.Cryptography;
using System.Text;

namespace PasswordCrackerApi
{
    public class Worker
    {


        public async Task<string> BruteforcePoolManager(string passwordHash, int length, char[] alphabet, Progress<ProgressModel> progress, CancellationToken cancellationToken)
        {
            List<Task<string>> tasks = new List<Task<string>>();
            long tries = (long)(Math.Pow(alphabet.Length, length) / alphabet.Length);
            //Console.WriteLine(tries);
            Parallel.ForEach(string.Concat(alphabet), async i =>
            {
                char[] password = (char.ToString(i) + new string(i, length - 1)).ToCharArray();
                //Console.WriteLine(password);
                tasks.Add(BruteforceUnit(passwordHash, password, alphabet, 1, 1, progress, tries, cancellationToken));
            });
            Console.WriteLine("Started: " + tasks.Count);
            var resultList = await Task.WhenAll(tasks);
            var validResult = resultList.Where(x => x != null).FirstOrDefault();
            if (validResult != null) return validResult;
            return "Password not found!";

        }
        public async Task<string> BruteforceUnit(string passwordHashToFind, char[] passwordArray, char[] alphabet, int passwordIndexToChange, int alphabetIndex, IProgress<ProgressModel> progress, long totalTries, CancellationToken cancellationToken)
        {
            //Console.WriteLine(alphabetIndex + "," + alphabet.Length + "," + passwordIndexToChange + "," + length+","+fixedPasswordIndex+","+fixedBruteforceIndex);
            long counter = 1;
            int lastReportedAt = 0;
            while (true)
            {
                if (cancellationToken.IsCancellationRequested) return null;
                counter++;
                if (ReportProgress(counter, totalTries, passwordArray[0], lastReportedAt, progress) == true) lastReportedAt = (int)((double)counter / (double)totalTries) * 100;
                if (HashPassword(new string(passwordArray)) == passwordHashToFind)
                {
                    Console.WriteLine($"Task: {passwordArray[0]} found Password");
                    Console.WriteLine("Password is "+new string(passwordArray));
                    progress.Report(new ProgressModel { Id = passwordArray[0], ProgressInPercent = -100 });
                    return "Password: " + new string(passwordArray);
                }
                Console.WriteLine(new String(passwordArray));
                if (passwordArray.Skip(1).Contains(alphabet.Last()) && passwordArray.Skip(1).Distinct().Count() == 1)
                {
                    progress.Report(new ProgressModel
                    {
                        Id = passwordArray[0],
                        ProgressInPercent = 100
                    });
                    Console.Write($"Task: {passwordArray[0]} completed");
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
        public async Task<string> WebCrawlerBruteforce(string passwordHash, string url, Progress<ProgressModel> progress)
        {
            var html = url;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc =await  Task.Run(() =>  web.Load(html));
            var nodes = htmlDoc.DocumentNode.SelectNodes("/html/body/div[3]/div[3]/div[5]/div[1]/ul/li/a").Select(x => x.InnerText).ToList();
            Console.WriteLine("From Webcrawler: " + nodes.Count());
            var totalTries = nodes.Count;
            int lastReportedAt = 0;
            for (int counter = 0; counter < totalTries; counter++)
            {
                if (HashPassword(nodes[counter]) == passwordHash) return "Password: " + nodes[counter];
                if (ReportProgress(counter, totalTries, '1', lastReportedAt, progress) == true) lastReportedAt = (counter / totalTries) * 100;
            }
            return "Password not found";

        }
        public bool ReportProgress(long counter, long totalTries, char id, int lastReportedAt, IProgress<ProgressModel> progress)
        {
            //Console.WriteLine("Hello from ReportProgress");
            double percent = (counter / totalTries) * 100;
            if (lastReportedAt == (int)percent) return false;
            Console.WriteLine("Reported: " + id + " at " + (int)percent);
            progress.Report(new ProgressModel
            {
                Id = id,
                ProgressInPercent = (int)percent
            });
            return true;
        }
        public string HashPassword(string password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                //Console.WriteLine("Password: "+password);
                var hash = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string result = "";
                for (int i = 0; i < hash.Length; i++) result += hash[i].ToString("X2");
                //Console.WriteLine("Hash: " + result);
                return result;
            }
        }
    }
}
