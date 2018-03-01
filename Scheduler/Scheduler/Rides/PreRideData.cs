namespace Scheduler.Rides
{
    public class PreVehicleRideData
    {
        public int StepsToStart { get; }
        public int AvailiableAt { get;  }
        public int RideLenght { get;  }
        public int Id { get; set; }

        public PreVehicleRideData(int stepsToStart, int startAt, int rideLenght)
        {
            StepsToStart = stepsToStart;
            AvailiableAt = startAt;
            RideLenght = rideLenght;
        }
    }
}