using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnbased_RPG;

namespace Turnbased_RPG
{
    internal class Progress
    {
        public void Run()
        {
            var player = new Player();
            List<String> items = new List<String>();
            bool activeTorch = false;
            var monster = new Monster();
            bool combat = false;

            Console.WriteLine("Answer questions with 'yes' or 'no'. Exceptions are marked with ''. Try 'stats' or 'items'");
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
                else if (userInput == "no")
                {
                    A1O2();
                }
                else if (userInput == "stats")
                {
                    player.ShowStats();
                    A1();
                }
                else if (userInput == "items")
                {
                    ShowItems();
                    A1();
                }
                else
                {
                    Console.WriteLine("This is not the time for that!");
                    A1();
                }
            }
            void ShowItems()
            {
                while (items.Count == 0 && combat == false) 
                { Console.WriteLine("You rummage through your rucksack, inside you see some crumbs and a nervous looking mouse");
                  Console.WriteLine("The rascal appears to have feasted on your rations. It makes no effort to escape. Let it stay?");
                    var input = Console.ReadLine();
                    if (input == "yes") { items.Add("Mysterious mouse"); Console.WriteLine("You decide to let it stay. You leave a small opening in the rucksack"); }
                    else if (input == "no")
                    {
                        items.Add("Crumbs");
                        Console.WriteLine("You kindly tell the mouse to leave and it reluctantly adheres to your request.");
                    }
                    else if (input == "sing")
                    {
                        Console.WriteLine("You hum a gentle lullaby and the mouse gratefully goes to sleep. The feeling of not being alone invigorates you");
                        player.Health++;
                        Console.WriteLine("Health: +1. Current health: " + player.Health);
                    }
                    else
                    {
                        Console.WriteLine("This is not the time for that!");
                        ShowItems();
                    }   break; 
                }
                
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine(items[i]);
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
                    player.ShowStats();
                    A1O2();
                }
                else if (userInput == "items")
                {
                    ShowItems();
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
                    player.Torches--;
                    Console.WriteLine($"Remaining torches: {player.Torches}");
                    activeTorch = true;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("You light a torch and can now see clearly, but the light has drawn the attention of some creature coming your way.");
                    A3O1();
                }
                else if (userInput == "no")
                {
                    Console.WriteLine("You decide to save your torch for the time being. You walk deeper into the darkness as you hear strange noises nearby");
                    A3O1();
                }
                else if (userInput == "stats")
                {
                    player.ShowStats();
                    A2();
                }
                else if (userInput == "items")
                {
                    ShowItems();
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
                Console.WriteLine("Will you 'fight' or attempt to 'hide'?");
                var userInput = Console.ReadLine();
                if (userInput == "yes" || userInput == "fight")
                {
                    Console.WriteLine("You prepare to fight. Press a button when ready");
                    Console.ReadKey();
                    combat = true;
                    FirstEncounter();
                }
                else if (userInput == "hide")
                {
                    HideEncounter();
                }
                else if (userInput == "stats")
                {
                    player.ShowStats();
                    A3O1();
                }
                else if (userInput == "items")
                {
                    ShowItems();
                    A3O1();
                }
                else
                {
                    Console.WriteLine("This is not the time for that!");
                    A3O1();
                }
            }

            void HideEncounter()
            {
                if (activeTorch)
                {
                    Console.WriteLine("You attempt to hide behind a crevice on the wall, but the light from your torch gave your position away.");
                    player.Health -= monster.Damage;
                    Console.WriteLine($"The creature attacks while you are still preparing to fight. It did: " + monster.Damage + " damage!");
                  //  Console.WriteLine("Health remaining: " + player.Health);
                    FirstEncounter();
                }
                else
                {
                    Console.WriteLine("Though it's hard to see you can hear their footsteps and snarls nearby.");
                    Console.WriteLine("You sneak attack the creature. It did: " + player.Damage + " damage!");
                    monster.Health -= player.Damage;
                    FirstEncounter();
                }
                combat = true;
            }

            void FirstEncounter()
            {
                if (player.Health < 1)
                {
                    Console.WriteLine("YOU DIED. Press a button to try again");
                    Console.ReadLine();
                    Run();
                }
                else if (monster.Health < 1)
                {
                    combat = false;
                    A4();
                }
                else
                {
                    CombatSequence();
                }
            }

            void CombatSequence()
            {
                Console.WriteLine($"Health: {player.Health}. Monster health: {monster.Health}");
                Console.WriteLine("'attack'" + "'defend'");
                var userInput = Console.ReadLine();

                if (userInput == "attack")
                {
                    Attack();
                    FirstEncounter();
                }
                else if (userInput == "defend")
                {
                    Defend();
                    FirstEncounter();
                }
                else if (userInput == "stats")
                {
                    player.ShowStats();
                    FirstEncounter();
                }
                else if (userInput == "items")
                {
                    ShowItems();
                    FirstEncounter();
                }
                else
                {
                    Console.WriteLine("This is not the time for that!");
                    CombatSequence();
                }
            }

            void Attack()
            {
                Console.WriteLine("You attack the creature. It did: " + player.Damage + " damage!");
                Console.WriteLine("The creature hits back. It did: " + monster.Damage + " damage!");
                monster.Health -= player.Damage;
                player.Health -= monster.Damage;
            }

            void Defend()
            {
                if (player.Potions < 1)
                {
                    Console.WriteLine($"Your potions are: {player.Potions}. You are going to need to find more!");
                }
                else
                {
                    Console.WriteLine("You take a sip of your trusty canteen and evade an incoming blow!");
                    Console.WriteLine("The monster is so suprised by the maneuver that it falls on its face");
                    monster.Health--;
                    player.Potions--;
                    player.Health++;
                }
            }

            void A4()
            {
                    Console.WriteLine("You have won the battle. Press a button to continue");
                    Console.ReadLine();
                    Console.WriteLine("The creature has drawn its last breath and you let out a sigh of relief.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    if (activeTorch)
                    {   
                        activeTorch = false; 
                        Console.WriteLine("Your torch has dwindled. In the final glimmers you get a good look at the creature.");
                        Console.WriteLine("It looks like a shark with the legs of a man. It wears a neclace decorated with teeth");
                        items.Add("Charred wooden stick");
                        items.Add("Sharkteeth necklace");
                        Console.WriteLine("Obtained Charred wooden stick & Shark teeth necklace. Attempt crafting?");
                        var input = Console.ReadLine();
                        if (input == "yes")
                        {
                        items.Remove("Charred wooden stick");
                        items.Remove("Sharkteeth necklace");
                        items.Add("Reinforced Club of the Inverse Merman");
                        Console.WriteLine("Crafted: Reinforced Club of the Inverse Merman!");
                        player.Damage++;
                        A5();
                        }
                        else if (input == "no")
                        {
                        Console.WriteLine("You decide to hang on to your items for the time being.");
                        A5();
                        }
                        else
                        {
                        Console.WriteLine("This is not the time for that!");
                        A4();
                        }
                    } 
                    else
                    {
                    LightTorch();
                    A5();
                    }
                                                        
                    void LightTorch()
                    {
                        Console.WriteLine("Light a torch?");
                        var userInput = Console.ReadLine();
                        if (player.Torches < 1)
                        {
                            Console.WriteLine($"You have: {player.Torches} Torches remaining");
                        }
                        else if (userInput == "yes")
                        {
                            activeTorch = true;
                            player.Torches--;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("You light a torch");
                            Console.WriteLine($"Remaining torches: {player.Torches}");
                        }
                        else if (userInput == "no")
                        {
                            Console.WriteLine("You decide not to light a torch");
                        }
                        else if (userInput == "stats")
                        {
                            player.ShowStats();
                            LightTorch();
                        }
                        else if (userInput == "items")
                        {
                            ShowItems();
                            LightTorch();
                        }
                        else
                        {
                             Console.WriteLine("This is not the time for that!");
                             LightTorch();
                        }
                    }

                    void A5()
                    {
                        Console.WriteLine("You venture deeper into the cave and find yourself at a crossroads.");
                        Console.WriteLine("The 'left' path is covered in moss and moisture. The 'right' path is covered in boulders though you feel a gentle breeze");
                    }
            }
        }
      public void GameOver()
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("** To be continued. Thanks for playing! **");
                Console.ReadLine();
            }
        }
    }
