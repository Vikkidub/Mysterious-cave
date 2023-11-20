using System.ComponentModel.Design;
using Turnbased_RPG;

Console.WriteLine("Answer questions with 'yes' or 'no'. Exceptions are marked like 'this'");
Console.WriteLine("Health:"+Player.Health+" Potions:"+Player.Potions+" Attack:"+Player.Damage+" Torches:"+Player.Torches);
Console.WriteLine();

A1();
void A1()
{
   
    
    Console.WriteLine("You are an explorer in a distant land. You discover a mysterious cave. Do you enter?");

    var userInput = Console.ReadLine();

    if (userInput == "yes")
    {
        A2();
    }
    else 
    {
        A1O2();
    }
}

 void A1O2()
{
    Console.WriteLine("You decide to leave. On your journey a fierce storm starts brewing.");
    Console.WriteLine("Take 'shelter' in the cave?" + " or try to make it through the 'storm'?");
    var userInput = Console.ReadLine(); 

    if (userInput == "yes" || userInput == "shelter" || userInput == "cave") 
    {
        A2();
    }
    else if (userInput == "no" || userInput == "storm")
        {
            Console.WriteLine("Unfortunately the storm was too owerpowering and you never made it back home. THE END");
        }
        else
        {
            Console.WriteLine("This is not the time for that!");
            A1O2();
        }
    }


void A2()
{
    Console.Write("You enter the cave. It's terribly dark. Do you light a torch?");
    var userInput = Console.ReadLine();
    if (userInput == "yes")
    {
        Player.Torches--;
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
    Console.WriteLine("You attack the creature. It did: " + Player.Damage + " damage!");
    Console.WriteLine("The creature hits back. It did: " + Monster.Damage + " damage!");
    Monster.Health--;
    Player.Health--;
}

static void Defend()
{
    Console.WriteLine("You take a sip of your trusty canteen and evade an incoming blow!");
    Console.WriteLine("The monster is so suprised by the maneuver that it falls on its face");
    Monster.Health--;
    Player.Potions--;
}


Console.ReadLine();

