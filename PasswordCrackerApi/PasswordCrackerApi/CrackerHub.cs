
using Microsoft.AspNetCore.SignalR;
using PasswordCrackerApi.Dtos;
namespace PasswordCrackerApi
{

    public class CrackerHub : Hub
    {

        public async void Bruteforce(CrackRequestDto crackRequest)
        {
            var worker = new Worker();
            var progress = new Progress<ProgressModel>();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var resultTask = worker.BruteforcePoolManager(crackRequest.HashCode, crackRequest.Length, crackRequest.Alphabet.ToCharArray(), progress, cancellationTokenSource.Token);
            var progressMap = new Dictionary<string, int>();
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            progress.ProgressChanged += (_, s) =>
            {
                if (s.ProgressInPercent == -100)
                {
                    cancellationTokenSource.Cancel();
                }
                if (progressMap.ContainsKey(s.Id.ToString()))
                {
                    progressMap[s.Id.ToString()] = s.ProgressInPercent;
                }
                else
                {
                    progressMap.Add(s.Id.ToString(), s.ProgressInPercent);
                }
                Clients.Caller.SendAsync("progress",progressMap.Values.ToList().Sum() / crackRequest.Alphabet.Length);
                Console.WriteLine(progressMap.Values.ToList().Sum() / crackRequest.Alphabet.Length);
            };
            var result = await resultTask;
            await Clients.Caller.SendAsync("result", result);
            watch.Stop();
            Console.WriteLine($"Execution Time Parallel: {watch.ElapsedMilliseconds} ms");

        }

    }
}
