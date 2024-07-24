namespace SpaceVC
{
    public class Spaceship
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int CrewCapacity { get; set; }
        public double MaxSpeed { get; set; }
        public string Status { get; set; }
        public DateTime LaunchDate { get; set; }
        public string MissionType { get; set; }

        public Spaceship(string name, string model, int crewCapacity, double maxSpeed, string status, DateTime launchDate, string missionTType)
        {
            Name = name;
            Model = model;
            CrewCapacity = crewCapacity;
            MaxSpeed = maxSpeed;
            Status = status;
            LaunchDate = launchDate;
            MissionType = missionTType;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Model: {Model}, CrewCapacity: {CrewCapacity}, MaxSpeed: {MaxSpeed}, Status: {Status}," +
                $" LaunchDate: {LaunchDate.ToShortDateString()}, MissionType: {MissionType}";
        }
    }
}