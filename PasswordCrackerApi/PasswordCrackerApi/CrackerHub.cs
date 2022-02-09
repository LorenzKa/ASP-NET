﻿
using Microsoft.AspNetCore.SignalR;
using PasswordCrackerApi.Dtos;
namespace PasswordCrackerApi
{

    public class CrackerHub : Hub
    {

        public async void Bruteforce(CrackRequestDto crackRequest)
        {
            var worker = new Worker();
            
            var resultTask = worker.BruteforcePoolManager(crackRequest.HashCode, crackRequest.Length, crackRequest.Alphabet.ToCharArray());
            var result = await resultTask;
            await Clients.All.SendAsync(result);
        }

    }
}
