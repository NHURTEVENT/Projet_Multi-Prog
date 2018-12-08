using Shared;
using System;

namespace Model
{

    public abstract class Machine : IMachine
    {
        public int MaxCapacity { get; set; }
        public int MinCapacity { get; set; }
        public int RunningTime { get; set; }
        public int UnloadingTime { get; set; }
        public int LoadingTime { get; set; }
        public IKitchen Kitchen { get; set; }


    }
}