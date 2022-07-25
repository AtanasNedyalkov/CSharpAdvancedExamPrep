using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }
        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) ||
                string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (this.Drones.Count>=this.Capacity)
            {
                return "Airfield is full.";
            }
            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
            
        }
        public bool RemoveDrone(string nameToDelete)
        {
            this.Drones.RemoveAll(drone => drone.Name == nameToDelete);
            return Count > 0;
        }
        public int RemoveDroneByBrand(string brandToDelete)
        {
            this.Drones.RemoveAll(drone => drone.Brand == brandToDelete);
            return Count;
        }
        public Drone FlyDrone(string name)
        {
            Drone drone = this.Drones.FirstOrDefault(drone => drone.Name == name);

            if (drone == null)
            {
                return null;
            }

            drone.Available = false;
            return drone;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> matchingDrones =
                this.Drones.Where(d => d.Range >= range).ToList();
            foreach (var d in matchingDrones)
            {
                d.Available = false;
            }
            return matchingDrones;
        }

        public string Report()
        {
            var dronesAvailable = this.Drones.Where(d => d.Available == true);
            return $"Drones available at {this.Name}:\r\n" +
                     string.Join("\r\n", this.Drones);
        }




    }
}
