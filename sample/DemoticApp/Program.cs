using Sample.Shared;

using static System.Console;


Person thomas = new();

thomas.Name = "Thomas Jones";
thomas.DateOfBirth = new DateTime(1972, 10, 25);

WriteLine(
    format: "{0} was born on {1:dddd, d MMMM yyyy}",
    arg0: thomas.Name,
    arg1: thomas.DateOfBirth
);
