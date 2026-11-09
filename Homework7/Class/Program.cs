using Class.MenuImplementation;
using MenuLib;

namespace Class;

class Program {
    static void Main(string[] args) {
        MainMenu root =  new MainMenu();
        MenuRunner.Run(root);
    }
}