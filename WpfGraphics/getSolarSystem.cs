using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSim;

namespace WpfSolarSystem
{
    class SolarSystem
    {
        private List<SpaceObject> list = new List<SpaceObject>();

        public List<SpaceObject> getSolar()
        {
            Star Sun = new Star("Sun", 0, 0, 60000, 0, "OrangeRed");
            Planet Mercury = new Planet("Mercury", 80, 88, 6000, 59, "Aquamarine");
            Planet Venus = new Planet("Venus", 120, 224, 10000, 243, "DarkGoldenrod");
            Planet Earth = new Planet("Earth", 150, 365, 11000, 1, "SteelBlue");
            Planet Mars = new Planet("Mars", 180, 687, 9800, 1.025, "Brown");
            Planet Jupiter = new Planet("Jupiter", 240, 20000, 32000, 0.4125, "Salmon");
            Planet Saturn = new Planet("Saturn", 300, 18000, 30004, 0.417, "BurlyWood");
            Planet Uranus = new Planet("Uranus", 360, 30685, 18000, 0.67, "DeepSkyBlue");
            Planet Neptun = new Planet("Neptun", 400, 60190, 17000, 0.71, "DodgerBlue");

            Moon TheMoon = new Moon("The Moon", 16, 27.322, 3800, 27, "White");
            Moon Phobos = new Moon("Phobos", 10, 0.3189, 3500, 0.3, "GRAY");
            Mercury.setParent(Sun);
            Venus.setParent(Sun);
            Earth.setParent(Sun);
            Mars.setParent(Sun);
            Jupiter.setParent(Sun);
            Saturn.setParent(Sun);
            Uranus.setParent(Sun);
            Neptun.setParent(Sun);
            TheMoon.setParent(Earth);
            Phobos.setParent(Mars);
            Earth.setChild(TheMoon);
            Mars.setChild(Phobos);
            list.Add(Sun);
            list.Add(Mercury);
            list.Add(Venus);
            list.Add(Earth);
            list.Add(Mars);
            list.Add(Jupiter);
            list.Add(Saturn);
            list.Add(Uranus);
            list.Add(Neptun);
            list.Add(TheMoon);
            list.Add(Phobos);
            return list;
        }
      

    }
}