using ClanPenguin.Models;

namespace ClanPenguin.ViewModels
{
    public class Main
    {
        public ClanPenguinContext Context { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public bool Sidebar { get; set; }
        public bool Navbar { get; set; }
    }
}
