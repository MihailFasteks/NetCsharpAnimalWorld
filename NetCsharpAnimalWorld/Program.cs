// See https://aka.ms/new-console-template for more information
using NetCsharpAnimalWorld;

Continent cont1 = new Africa();
AnimalWorld aw=new AnimalWorld(cont1);
aw.EatHerbivore();
aw.EatCarnivore();

 cont1 = new NAmerica();
aw = new AnimalWorld(cont1);
aw.EatHerbivore();
aw.EatCarnivore();