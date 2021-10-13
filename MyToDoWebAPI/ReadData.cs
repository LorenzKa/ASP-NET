using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI
{
    public class ReadData
    {
        public string[][] readAlbums()
        {
            const string FILEPATH = "./CSV/";
            string[][] data = File.ReadAllLines(FILEPATH + "album.csv").Select(l => l.Split(",")).ToArray();
            return data;
        }
    }
}
