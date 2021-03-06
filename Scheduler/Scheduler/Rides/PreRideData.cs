﻿namespace Scheduler.Rides
{
    public class PreVehicleRideData
    {
        public int StepsToStart { get; }
        public int AvailiableAt { get;  }
        public int RideLenght { get;  }
        public int WaitTime { get; private set; }
        public int Id { get; set; }

        public PreVehicleRideData(int stepsToStart, int startAt, int rideLenght)
        {
            StepsToStart = stepsToStart;
            AvailiableAt = startAt;
            RideLenght = rideLenght;
        }

        public PreVehicleRideData UpdateWaitTime(int currentTime)
        {
            WaitTime = AvailiableAt - (currentTime + StepsToStart);
            if (WaitTime < 0) WaitTime = 0;
            return this;
        }

        public bool CanGetStartOnTimeBonus(int currentTime)
        {
            if (StepsToStart + currentTime > AvailiableAt)
                return false;

            return true;
        }
    }
}