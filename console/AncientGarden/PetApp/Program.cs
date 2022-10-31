using PetLibrary.Shared;

Pet ginger = new() { Name="Ginger" };
Pet gus = new() { Name = "Gus" };

Pet iron = Pet.Procreate(
  ginger,
  gus
);

Console.WriteLine($"{ginger.Name} and {gus.Name} they had a puppy identified with {iron.Id}");
