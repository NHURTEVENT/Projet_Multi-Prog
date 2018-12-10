using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MachineDBEntry
    {
        [Key]
        public int MachineId { get; set; }

        public String MachineType { get; set; }
        public int MaxCapacity { get; set; }
        public int MinCapacity { get; set; }
        public int RunningTime { get; set; }
        public int UnloadingTime { get; set; }
        public int LoadingTime { get; set; }

        public MachineDBEntry(string machineType, int maxCapacity, int minCapacity, int runningTime, int unloadingTime, int loadingTime)
        {
            MachineType = machineType;
            MaxCapacity = maxCapacity;
            MinCapacity = minCapacity;
            RunningTime = runningTime;
            UnloadingTime = unloadingTime;
            LoadingTime = loadingTime;
        }

        public MachineDBEntry() { }
    }
}
