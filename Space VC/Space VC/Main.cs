using SpaceVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_VC
{
    class Program
    {
        static Custom2DArray<Spaceship> map = new Custom2DArray<Spaceship>(5, 5);

        static void Main(string[] args)
        {
            CustomArray<Spaceship> fleet = new CustomArray<Spaceship>();

            fleet.Add(new Spaceship("Explore", "X-1", 5, 15000, "active", new DateTime(2023, 5, 1), "research"));
            fleet.Add(new Spaceship("Transporter", "T-200", 20, 12000, "inactive", new DateTime(2022, 8, 15), "transport"));
            fleet.Add(new Spaceship("Defender", "D-300", 10, 18000, "maintenance", new DateTime(2021, 3, 10), "military"));

            while (true)
            {
                Console.WriteLine("\nSpaceVC Fleet Management");
                Console.WriteLine("1. Add new spaceship");
                Console.WriteLine("2. Delete spaceship");
                Console.WriteLine("3. Update spaceship");
                Console.WriteLine("4. View all spaceships");
                Console.WriteLine("5. Place a spaceship on the map");
                Console.WriteLine("6. Remove spaceship from the map");
                Console.WriteLine("7. View map");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddSpaceship(fleet);
                        break;
                    case "2":
                        DeleteSpaceship(fleet);
                        break;
                    case "3":
                        UpdateSpaceship(fleet);
                        break;
                    case "4":
                        fleet.OutputContents();
                        break;
                    case "5":
                        PlaceSpaceshipOnMap(fleet);
                        break;
                    case "6":
                        RemoveSpaceshipFromMap();
                        break;
                    case "7":
                        map.OutputContents();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Option not valid. Try again.");
                        break;
                }
            }
        }

        static void AddSpaceship(CustomArray<Spaceship> fleet)
        {
            Console.Write("Please enter the name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter the ship's model: ");
            string model = Console.ReadLine();
            Console.Write("Please enter the crew capacity: ");
            int crewCapacity = int.Parse(Console.ReadLine());
            Console.Write("Please enter the max speed: ");
            double maxSpeed = double.Parse(Console.ReadLine());
            Console.Write("Please enter the ship's status (Active, Inactive, Maintenance): ");
            string status = Console.ReadLine();
            Console.Write("Please enter the launch date (yyyy-mm-dd): ");
            DateTime launchDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Please enter the mission type (Research, Transport, Military, Communications): ");
            string missionType = Console.ReadLine();

            Spaceship newShip = new Spaceship(name, model, crewCapacity, maxSpeed, status, launchDate, missionType);
            fleet.Add(newShip);
            Console.WriteLine("Added successfully!");
        }

        static void DeleteSpaceship(CustomArray<Spaceship> fleet)
        {
            Console.Write("Please enter the index of the spaceship you wish to delete: ");
            int index = int.Parse(Console.ReadLine());

            try
            {
                fleet.RemoveAt(index);
                Console.WriteLine("Deleted successfully!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index does not exist, please enter a valid index.");
            }
        }

        static void UpdateSpaceship(CustomArray<Spaceship> fleet)
        {
            Console.Write("Please enter the index of the spaceship you want to update: ");
            int index = int.Parse(Console.ReadLine());

            try
            {
                Spaceship ship = fleet.Get(index);

                Console.Write("Please enter the new name for the spaceship (Leave blank to keep current name): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    ship.Name = name;
                }

                Console.Write("Please enter the new model name (Leave blank to keep current model): ");
                string model = Console.ReadLine();
                if (!string.IsNullOrEmpty(model))
                {
                    ship.Model = model;
                }

                Console.Write("Please enter the new crew capacity (Leave blank to keep current capacity): ");
                string crewCap = Console.ReadLine();
                if (!string.IsNullOrEmpty(crewCap))
                {
                    ship.CrewCapacity = int.Parse(crewCap);
                }

                Console.Write("Please enter the new max speed (Leave blank to keep current speed): ");
                string maxSpeedStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(maxSpeedStr))
                {
                    ship.MaxSpeed = double.Parse(maxSpeedStr);
                }

                Console.Write("Please enter the new status of the ship (Leave blank to keep current status): ");
                string stat = Console.ReadLine();
                if (!string.IsNullOrEmpty(stat))
                {
                    ship.Status = stat;
                }

                Console.Write("Please enter the new launch date (Leave blank to keep current date, format yyyy-mm-dd): ");
                string date = Console.ReadLine();
                if (!string.IsNullOrEmpty(date))
                {
                    ship.LaunchDate = DateTime.Parse(date);
                }

                Console.Write("Please enter the new mission type (Leave blank to keep current type): ");
                string type = Console.ReadLine();
                if (!string.IsNullOrEmpty(type))
                {
                    ship.MissionType = type;
                }

                Console.WriteLine("Updated successfully!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index does not exist, please enter a valid index.");
            }
        }

        static void PlaceSpaceshipOnMap(CustomArray<Spaceship> fleet)
        {
            Console.Write("Please enter the index of the spaceship to place it on the map: ");
            int index = int.Parse(Console.ReadLine());
            try
            {
                Spaceship ship = fleet.Get(index);

                Console.Write("Please enter row (0-4): ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Please enter column (0-4): ");
                int column = int.Parse(Console.ReadLine());

                map.Add(row, column, ship);
                Console.WriteLine("Successfully placed on the map.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Coordinates are out of range, please enter valid coordinates.");
            }
        }

        static void RemoveSpaceshipFromMap()
        {
            Console.Write("Please enter the row you wish to delete (0-4): ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Please enter the column you wish to delete (0-4): ");
            int column = int.Parse(Console.ReadLine());

            try
            {
                map.Remove(row, column);
                Console.WriteLine("Successfully removed spaceship.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Coordinates are out of range, please enter valid coordinates.");
            }
        }
    }
}
