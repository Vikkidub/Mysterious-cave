using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using Turnbased_RPG;

int health = 3;
int damage = 1;
int potions = 2;

var enemy = new Monster {};

A1();
 void A1()
{
    Console.WriteLine("Answer questions with 'yes' or 'no'. Exceptions are marked like 'this'");
    Console.WriteLine("You are an explorer in a distant land. You discover a mysterious cave. Do you enter?");
    
    var userInput = Console.ReadLine();

    if (userInput == "yes")
    {
        A2();
    }
     else {
        {
            Console.WriteLine("You have a bad feeling about the cave and decide to leave. You still can't help but wonder what adventures could have been had. THE END");
        }
    }
}

    void A2()
    {
        Console.Write("You enter the cave. It's terribly dark. Do you light a torch?");
        var userInput = Console.ReadLine();
        if (userInput == "yes")
        {
            A3O1();
        }
        else
        {
            Console.WriteLine("You decide to save your torch for the time being. You can still see in a short vicinity and barely make out a path to follow");
        }
    }

void A3O1()
{
    Console.WriteLine("You light a torch and can now see clearly, but the light has drawn the attention of some creature coming your way. Will you 'fight' or attempt to 'hide'");
    var userInput = Console.ReadLine();
    if (userInput == "yes" || userInput == "fight")
    {
        Console.WriteLine("You prepare to fight. Press a button when ready");
        Console.ReadKey();
        FirstEncounter();
    }
}
static void FirstEncounter()
{
    Console.WriteLine("Monster health: " + Monster.Health);
    Console.WriteLine("'Attack'" + "'defend'");
    var userInput = Console.ReadLine();
    if (userInput == "attack")
    {
       Attack();
    }
    else if (userInput == "defend")
    {
        Defend();
    }
    else
    {
        Console.WriteLine("This is not the time for that!");
        FirstEncounter();
    }
}

static void Attack()
{
    int playerDamage = 1; 
    Console.WriteLine("You attack the creature. It did: " + Player.Damage + " damage!");
    Console.WriteLine("The creature hits back. It did: " + Monster.Damage + " damage!");
    Monster.Health--;
    Player.Health--;
}

static void Defend()
{
    Console.WriteLine("You evaded an incoming blow");
}







Console.ReadLine();

