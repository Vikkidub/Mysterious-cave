using Turnbased_RPG;

Console.WriteLine("Answer questions with 'yes' or 'no'. Exceptions are marked with ''. Try 'stats'");
Console.WriteLine();
void Stats()
{
    Console.WriteLine($"Health: {Player.Health} Potions: {Player.Potions} Attack: {Player.Damage} Torches: {Player.Torches}");
}

A1();
void A1()
{
    Console.WriteLine("You are an explorer in a distant land. You discover a mysterious cave. Do you enter?");
    var userInput = Console.ReadLine();

    if (userInput == "yes")
    {
        A2();
    }
    else if (userInput == "no")
    {
        A1O2();
    }
    else if (userInput == "stats")
    {
        Stats();
        A1();
    }
    else
    {
        Console.WriteLine("This is not the time for that!");
        A1();
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
    else if (userInput == "stats")
    {
        Stats();
        A1O2();
    }
    else
    {
        Console.WriteLine("This is not the time for that!");
        A1O2();
    }
}
void A2()
{
    Console.WriteLine("You enter the cave. It's terribly dark. Do you light a torch?");
    var userInput = Console.ReadLine();

    if (userInput == "yes")
    {
        Player.Torches--;
        Console.WriteLine($"Remaining torches: {Player.Torches}");
        A3O1();
    }
    else if (userInput == "no")
    {
        Console.WriteLine("You decide to save your torch for the time being. You can still see in a short vicinity and barely make out a path to follow");
    }
    else if (userInput == "stats")
    {
        Stats();
        A2();
    }
    else
    {
        Console.WriteLine("This is not the time for that!");
        A2();
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
    else if (userInput == "hide")
    {

    }
    else if (userInput == "stats")
        {
            Stats();
            A3O1();
        }
        else
        {
            Console.WriteLine("This is not the time for that!");
            A3O1();
        }
    }


static void FirstEncounter()
{
    Gamestate();
    Console.WriteLine("Monster health: " + Monster.Health);
    Console.WriteLine("'attack'" + "'defend'");
    var userInput = Console.ReadLine();
    if (userInput == "attack" && Monster.Health > 0)
    {
        Attack();
    }
    else if (userInput == "defend")
    {
        Defend();
    }
    else if (Monster.Health < 1)
    {
        A4();
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
    Monster.Health -= Player.Damage;
    Player.Health -= Monster.Damage;
    Gamestate();
}
static void Defend()
{
    Console.WriteLine("You take a sip of your trusty canteen and evade an incoming blow!");
    Console.WriteLine("The monster is so suprised by the maneuver that it falls on its face");
    Monster.Health--;
    Player.Potions--;
}
static void Gamestate()
{
    if (Player.Health < 1)
    {
        Console.WriteLine("You died. THE END");
    }
}

static void A4()
{
    Console.WriteLine("The creature has drawn its last breath and you let out a sigh of relief. You notice the creature is wearing a collar.");
    if (Player.Torches == 0)
    {
        Console.WriteLine("Your torch has dwindled. Use the fallen creatures claws to make a reinforced club?");
    }
    else {Console.WriteLine("This is not the time for that!");}
    A4();
}

Console.ReadLine();

