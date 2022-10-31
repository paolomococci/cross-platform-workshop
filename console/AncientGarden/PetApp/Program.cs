using PetLibrary.Shared;

Pet ginger = new() { Name="Ginger" };
Pet gus = new() { Name = "Gus" };

Pet iron = Pet.Procreate(
  ginger,
  gus
);
