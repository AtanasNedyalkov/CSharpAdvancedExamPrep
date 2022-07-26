﻿namespace Drones
{
    public class Drone
    {

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available { get; set; } = true;

        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
        }
        public override string ToString()
        {
            return $"Drone: {this.Name}\r\n" +
                   $"Manufactured by: {this.Brand}\r\n" +
                   $"Range: {this.Range} kilometers";
        }
       
    }

}
