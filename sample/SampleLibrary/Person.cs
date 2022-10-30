using System;
using System.Collections.Generic;

using static System.Console;

namespace Sample.Shared
{
    public partial class Person : object
    {

        public const string Species = "Homo Sapiens";
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        public string Name;
        public DateTime DateOfBirth;
        public Wonders FavoriteWonder;
        public Wonders BucketList;
        public List<Person> Children = new List<Person>();
    }
}
