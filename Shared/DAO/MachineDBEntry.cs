using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    /// <summary>
    /// All the informations of a given machine in the restaurant
    /// </summary>
    public class MachineDBEntry
    {
        //Primary key, only serves to identify the record
        [Key]
        public int MachineId { get; set; }
        //Type of machine (dishwaser or washing-machine)
        public MachineType MachineType { get; set; }
        //Maximum number of item that can fit in
        public int MaxCapacity { get; set; }
        //Minimum number of item to launch it
        public int MinCapacity { get; set; }
        //Self-explainatory
        public int RunningTime { get; set; }
        //Self-explainatory
        public int UnloadingTime { get; set; }
        //Self-explainatory
        public int LoadingTime { get; set; }

        public MachineDBEntry(MachineType machineType, int maxCapacity, int minCapacity, int runningTime, int unloadingTime, int loadingTime)
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
