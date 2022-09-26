using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClass9_19
{
    internal static class Constants
    {
        private const string readName = "Stats.txt";
        private const string writeName = "GameLog.txt";
        private const string folderName = "temp";

        internal static string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        internal static string readPath = Path.Combine(directoryPath, readName);
        internal static string writePath = Path.Combine(directoryPath, writeName);
    }
}
