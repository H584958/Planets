using System;

namespace SpaceSim
{
    public class SpaceObject
    {

        public String name;
        public double orbitalRadius;
        public double orbitalPeriod;
        public double objectRadius;
        public double rotationPeriod;
        public bool isPlanet;
        public string color;
        public double posX;
        public double posY;

        public SpaceObject Parent;
        public List<SpaceObject> Children = new List<SpaceObject>();

        public SpaceObject(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationPeriod, string color)
        {
            this.name = name;
            this.orbitalRadius = orbitalRadius;
            this.orbitalPeriod = orbitalPeriod;
            this.objectRadius = objectRadius;
            this.rotationPeriod = rotationPeriod;
            this.color = color;
            posX = 0;
            posY = 0;
        }

        public virtual void Draw()
        {
            Console.WriteLine(name);

            if (Parent != null)
            {
                Console.Write("Orbital Radius: " + orbitalRadius + "*10^6 km ");
                Console.WriteLine("around the " + Parent.name);
                Console.WriteLine("Orbital Period: " + orbitalPeriod + " days");
                Console.WriteLine("Rotation Period: " + rotationPeriod + " days");
            }

            Console.WriteLine("Object Radius: " + orbitalRadius + " km");
        }


        public void setParent(SpaceObject parent)
        {
            this.Parent = parent;
        }

        public void setChild(SpaceObject child)
        {
            this.Children.Add(child);
        }


        public void getPosition(double time)
        {
            double x;
            double y;

            if (orbitalRadius != 0)
            {
                double rad = 2 * Math.PI * (time / orbitalPeriod);

                x = orbitalRadius * Math.Cos(rad);
                y = orbitalRadius * Math.Sin(rad);

                if (Parent != null)
                {
                    
                    Parent.getPosition(time);
                    x += Parent.posX;
                    y += Parent.posY;
                }
            }
            else
            {
                x = 0;
                y = 0;
            }
            this.posX = x;
            this.posY = y;
        }
    }

    public class Star : SpaceObject
    {
        public Star(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationPeriod, string color) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationPeriod, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Star  : ");
            base.Draw();
        }
    }

    public class Planet : SpaceObject
    {
        public Planet(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationPeriod, string color) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationPeriod, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class Moon : Planet
    {
        public Moon(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationPeriod, string color) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationPeriod, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Moon  : ");
            base.Draw();
        }
    }

    public class Asteroids : SpaceObject
    {
        public Asteroids(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationPeriod, string color) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationPeriod, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Astroids: ");
            base.Draw();
        }
    }

    public class AstroidBelt : SpaceObject
    {
        public AstroidBelt(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationPeriod, string color) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationPeriod, color)
        {
        }

        public override void Draw()
        {
            Console.Write("AstroidBelt: ");
            base.Draw();
        }
    }

    public class Dwarfplanet : Planet
    {
        public Dwarfplanet(string name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationPeriod, string color) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationPeriod, color)
        {
        }

        public override void Draw()
        {
            Console.Write("Dwarfplanet: ");
            base.Draw();
        }
    }
}
