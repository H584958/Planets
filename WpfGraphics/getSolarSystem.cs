using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceSim;

namespace WpfSolarSystem
{
    class getSolarSystem
    {
        private List<SpaceObject> list = new List<SpaceObject>();
        private List<SpaceObject> RealList = new List<SpaceObject>();

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

        public List<SpaceObject> getRealSolar()
        {
            Star Sun = new Star("Sun", 0, 0, 696342, 0, "Crimson");
            Planet Mercury = new Planet("Mercury", 57909274, 87.97, 2439.5, 59, "Aquamarine");
            Planet Venus = new Planet("Venus", 108209475, 224.70, 6052, 243, "DarkGoldenrod");
            Planet Earth = new Planet("Earth", 149600, 365.26, 6371, 1, "SteelBlue");
            Planet Mars = new Planet("Mars", 227940, 686.98, 3402.5, 1.025, "Brown");
            Planet Jupiter = new Planet("Jupiter", 778330, 4332.71, 69911, 0.4125, "Salmon");
            Planet Saturn = new Planet("Saturn", 1429400, 10759.5, 60268, 0.417, "BurlyWood");
            Planet Uranus = new Planet("Uranus", 2870990, 30685, 25559, 0.67, "DeepSkyBlue");
            Planet Neptun = new Planet("Neptun", 4504300, 60190, 24764, 0.708, "DodgerBlue");
            Moon TheMoon = new Moon("The Moon", 0.384, 27.322, 1737.1, 27, "GRAY");
            Moon Phobos = new Moon("Phobos", 0.000009, 0.3189, 11.25, 0.3, "GRAY");
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
            RealList.Add(Sun);
            RealList.Add(Mercury);
            RealList.Add(Venus);
            RealList.Add(Earth);
            RealList.Add(Mars);
            RealList.Add(Jupiter);
            RealList.Add(Saturn);
            RealList.Add(Uranus);
            RealList.Add(Neptun);
            RealList.Add(TheMoon);
            RealList.Add(Phobos);
            return RealList;
        }

    }
}