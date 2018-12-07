using Shared;
using System;

namespace Model
{

    public abstract class Machine : IMachine
    {
        private int maxCapacity;
        private int minCapacity;
        private int runningTime;
        private int unloadingTime;
        private int loadingTime;

        public int GetMaxCapacity()
        {
            return this.maxCapacity;
        }
        public void SetMaxCapacity(ref object maxCapacity)
        {
            throw new System.Exception("Not implemented");
        }
        public int GetMinCapacity()
        {
            return this.minCapacity;
        }
        public void SetMinCapacity(ref object minCapacity)
        {
            throw new System.Exception("Not implemented");
        }
        public int GetRunningTime()
        {
            return this.runningTime;
        }
        public void SetRunningTime(ref int runningTime)
        {
            this.runningTime = runningTime;
        }
        public int GetUnloadingTime()
        {
            return this.unloadingTime;
        }
        public void SetUnloadingTime(ref int unloadingTime)
        {
            this.unloadingTime = unloadingTime;
        }
        public int GetLoadingTime()
        {
            return this.loadingTime;
        }
        public void SetLoadingTime(ref int loadingTime)
        {
            this.loadingTime = loadingTime;
        }
        public void GetAttribute()
        {
            throw new System.Exception("Not implemented");
        }
        public void SetAttribute(ref object attribute)
        {
            throw new System.Exception("Not implemented");
        }

        private IKitchen kitchen;

    }
}