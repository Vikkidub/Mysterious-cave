using System;
using System.Collections.Generic;
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
            var monster = new Monster(3,1);
            bool activeTorch = false;

            Console.WriteLine("Answer questions with 'yes' or 'no'. Exceptions are marked with ''. Try 'stats'");
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
                    player.ShowStats();
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
                    player.Health--;
                    Console.WriteLine($"The creature attacks while you are still preparing to fight. Health: {player.Health}");
                    FirstEncounter();
                }
                else
                {
                    Console.WriteLine("Though it's hard to see you can hear their footsteps and snarls nearby.");
                    Console.WriteLine("You sneak attack the creature. It did: " + player.Damage + " damage!");
                    monster.Health -= player.Damage;
                    FirstEncounter();
                }
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
                    A4();
                }
                else
                {
                    CombatSequence();
                }
            }

            void CombatSequence()
            {
                Console.WriteLine("Monster health: " + monster.Health);
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
                        Console.WriteLine("Your torch has dwindled. Use the fallen creatures claws to make a reinforced club?");
                    }
                    else
                    {
                        LightTorch();
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
                        else
                        {
                             Console.WriteLine("This is not the time for that!");
                             LightTorch();
                        }
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
