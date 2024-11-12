using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace NetCsharpAnimalWorld
{
     abstract class Herbivore
    {
        public int weight {  get; set; }
        public bool life {  get; set; }
        public Herbivore()
        {
            weight = 100;
            life = true;
        }

        public void EatGrass()
        {
            weight += 10;
            Print();
            Console.Write(" eat grass");
            Console.WriteLine();

        }
        public abstract void Print();
    }
     class Wildebeest : Herbivore
    {
        public override void Print()
        {
            Console.Write("Wildebeest");
        }
    }
    class Bison : Herbivore
    {
        public override void Print()
        {
            Console.Write("Bison");
        }
    }
    abstract class Carnivore
    {
        public int power {  get; set; }
        public bool life {  set; get; }
        public Carnivore()
        {
            power = 100;
            life = true;
        }

        public void EatHerbivore(Herbivore herb)
        {
            if (herb.weight > 0 && herb.life==true)
            {
                if (life == true && power>0)
                {
                    if (power >= herb.weight)
                    {
                        power += 10;
                        herb.life = false;


                    }
                    else
                    {
                        power -= 10;
                       
                    }
                    Print();
                    Console.Write(" eat ");
                    herb.Print();
                    Console.WriteLine();

                    if (power == 0)
                    {
                        life = false;
                        Console.WriteLine("Carnivore is dead!");
                    }
                }
                else
                {
                    
                    Console.WriteLine("Error! Carnivore is dead");
                    Console.WriteLine();
                }
                
            }
            else
            {
                herb.life = false;
                Console.WriteLine("Error! Herbirove is dead");
                Console.WriteLine();
            }
           
        }
        public abstract void Print();
    }

    class Lion : Carnivore
    {
        public override void Print()
        {
            Console.Write("Lion");
            
        }
    }
    class Wolf : Carnivore
    {
        public override void Print()
        {
            Console.Write("Wolf");
           
        }
    }


    abstract class Continent
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
    class Africa : Continent
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
    class NAmerica : Continent
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
     class AnimalWorld
    {
        Herbivore herb {  get; set; }
        Carnivore carn {  get; set; }

      public AnimalWorld(Continent cont)
        {
            herb = cont.CreateHerbivore();
            carn = cont.CreateCarnivore();
        }
       public void EatHerbivore()
        {
            herb.EatGrass();
        }
      public  void EatCarnivore()
        {
            carn.EatHerbivore(herb);
        }
    }


}
