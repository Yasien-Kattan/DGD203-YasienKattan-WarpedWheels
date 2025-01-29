using System;
using System.Collections.Generic;
using System.IO;

namespace WarpedWheels
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                DisplayMainMenu();
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartNewGame();
                        break;
                    case "2":
                        LoadGame();
                        break;
                    case "3":
                        ShowCredits();
                        break;
                    case "4":
                        ShowStates(); // Show information about vehicles and maps
                        break;
                    case "5":
                        ExtraFeature(); // Placeholder for extra feature
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("==== Warped Wheels ===");
            Console.WriteLine("Welcome to the ultimate vehicular combat tournament!");
            Console.WriteLine();
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Credits");
            Console.WriteLine("4. States");
            Console.WriteLine("5. Extra");
            Console.WriteLine("6. Exit");
        }

        static void ExtraFeature()
        {
            Console.Clear();
            Console.WriteLine("\n=== Extra Features ===");
            Console.WriteLine("1. Other Game");
            Console.WriteLine("2. ASCII Art Work");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    OtherGame();
                    break;
                case "2":
                    Console.WriteLine("For ASCII art, please view the ASCII art text file for a better experience.");
                    Console.WriteLine("Press Enter to return to the menu...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Returning to menu...");
                    break;
            }
        }

        static void OtherGame()
        {
            Console.Clear();
            Console.WriteLine("=== Guessing Number Game ===");
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int userGuess = 0;

            Console.WriteLine("Guess a number between 1 and 100!");

            while (userGuess != numberToGuess)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userGuess))
                {
                    if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("Higher!");
                    }
                    else if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("Lower!");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You've guessed the number!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        static void ShowStates()
        {
            Console.Clear();
            Console.WriteLine("==== Vehicle Information ===");
            Console.WriteLine("1. Muscle Car (Road Warrior)");
            Console.WriteLine("  Speed: 2/5");
            Console.WriteLine("  Armor: 3/5");
            Console.WriteLine("  Special Ability: Nitro Boost");
            Console.WriteLine();

            Console.WriteLine("2. Tank (Ironclad)");
            Console.WriteLine("  Speed: 1/5");
            Console.WriteLine("  Armor: 5/5");
            Console.WriteLine("  Special Ability: Shield Bash");
            Console.WriteLine();

            Console.WriteLine("3. Speedster (Lightning Bolt)");
            Console.WriteLine("  Speed: 5/5");
            Console.WriteLine("  Armor: 2/5");
            Console.WriteLine("  Special Ability: Quick Strike");
            Console.WriteLine();

            Console.WriteLine("==== Map Information ===");
            Console.WriteLine("1. Scrapyard: A junkyard filled with debris and hidden weapons. Hazards: Exploding barrels, collapsing structures.");
            Console.WriteLine("2. City Ruins: A destroyed urban area with narrow streets and explosive traps. Hazards: Falling buildings, fire traps.");
            Console.WriteLine("3. Desert Wasteland: A vast desert with sandstorms and limited visibility. Hazards: Sandstorms, quicksand.");
            Console.WriteLine();

            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        static void StartNewGame()
        {
            Console.Clear();
            Console.WriteLine("==== Choose Your Mode ===");
            Console.WriteLine("1. Deathmatch");
            Console.WriteLine("2. Racing");
            Console.Write("Choose a mode: ");
            string modeChoice = Console.ReadLine();

            if (modeChoice != "1" && modeChoice != "2")
            {
                Console.WriteLine("Invalid choice. Defaulting to Deathmatch.");
                modeChoice = "1";
            }

            Console.Clear();
            Console.WriteLine("==== Choose Your Vehicle ===");
            Console.WriteLine();

            Console.WriteLine("1. Muscle Car (Road Warrior)");
            Console.WriteLine("2. Tank (Ironclad)");
            Console.WriteLine("3. Speedster (Lightning Bolt)");
            Console.WriteLine();

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Vehicle playerVehicle = null;
            List<Vehicle> availableVehicles = new List<Vehicle>
            {
                new Vehicle("Muscle Car (Road Warrior)", 2, 3, "Nitro Boost"),
                new Vehicle("Tank (Ironclad)", 1, 5, "Shield Bash"),
                new Vehicle("Speedster (Lightning Bolt)", 5, 2, "Quick Strike")
            };

            switch (choice)
            {
                case "1":
                    playerVehicle = availableVehicles[0];
                    availableVehicles.RemoveAt(0);
                    break;
                case "2":
                    playerVehicle = availableVehicles[1];
                    availableVehicles.RemoveAt(1);
                    break;
                case "3":
                    playerVehicle = availableVehicles[2];
                    availableVehicles.RemoveAt(2);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Speedster.");
                    playerVehicle = availableVehicles[2];
                    availableVehicles.RemoveAt(2);
                    break;
            }

            Player player = new Player("Player 1");
            player.ChosenVehicle = playerVehicle;
            Console.WriteLine($"\nYou have chosen the {playerVehicle.Name}!");
            Console.WriteLine($"Speed: {playerVehicle.Speed}, Armor: {playerVehicle.Armor}, Special Ability: {playerVehicle.SpecialAbility}");

            // Assign remaining vehicles to NPCs
            List<NPC> npcs = new List<NPC>
            {
                new NPC("The Jester", 50, availableVehicles[0].Name, availableVehicles[0].SpecialAbility),
                new NPC("The Host", 100, availableVehicles[1].Name, availableVehicles[1].SpecialAbility)
            };

            // Create locations with mileage
            List<Arena> locations = new List<Arena>
            {
                new Arena("Scrapyard", "A junkyard filled with debris and hidden weapons.", "Exploding barrels, collapsing structures", 5),
                new Arena("City Ruins", "A destroyed urban area with narrow streets and explosive traps.", "Falling buildings, fire traps", 10),
                new Arena("Desert Wasteland", "A vast desert with sandstorms and limited visibility.", "Sandstorms, quicksand", 15)
            };

            // Choose and explore locations
            while (locations.Count > 0)
            {
                Console.WriteLine("\n=== Choose a Location ===");
                for (int i = 0; i < locations.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {locations[i].Name} ({locations[i].Mileage} miles)");
                }
                Console.Write("Enter your choice: ");
                int locationChoice = int.Parse(Console.ReadLine()) - 1;

                if (locationChoice >= 0 && locationChoice < locations.Count)
                {
                    ExploreLocation(player, locations[locationChoice], modeChoice, npcs);
                    locations.RemoveAt(locationChoice); // Remove the location after exploring
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }

            // Final battle
            Console.WriteLine("\n=== Final Battle ===");
            StartCombat(player, npcs[1], modeChoice); // Fight The Host

            if (player.ChosenVehicle.Armor > 0)
            {
                GoodEnding();
            }
            else
            {
                BadEnding();
            }
        }

        static void ExploreLocation(Player player, Arena location, string mode, List<NPC> npcs)
        {
            Console.WriteLine($"\n=== Entering {location.Name} ===");
            location.DisplayDescription();

            // Spawn an NPC in the location
            NPC npc = npcs[0]; // The Jester
            if (mode == "1") // Deathmatch
            {
                StartCombat(player, npc, mode);
            }
            else if (mode == "2") // Racing
            {
                StartRace(player, npc);
            }

            if (player.ChosenVehicle.Armor > 0)
            {
                Console.WriteLine($"\nYou survived the {location.Name}!");
                player.Inventory.Add(new HealthPack("Health Pack", 20));
                Console.WriteLine("You found a Health Pack!");
            }
            else
            {
                Console.WriteLine($"\nYou were defeated in the {location.Name}...");
                BadEnding();
                return; 
            }
        }

        static void StartCombat(Player player, NPC opponent, string mode)
        {
            Console.WriteLine($"\n=== Combat with {opponent.Name} ===");
            while (player.ChosenVehicle.Armor > 0 && opponent.Health > 0)
            {
                Console.WriteLine("\nYour turn!");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use Item");
                Console.WriteLine("3. Retreat and Replan");
                Console.WriteLine("4. Save Game");
                Console.Write("Choose an action: ");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        player.Attack(opponent);
                        break;
                    case "2":
                        player.UseItem();
                        break;
                    case "3":
                        if (mode == "2") // Racing mode
                        {
                            Console.WriteLine("You focus on racing and ignore your turn!");
                        }
                        else
                        {
                            Console.WriteLine("You retreat to a new map and restart the mission!");
                            return; // Exit combat and restart mission
                        }
                        break;
                    case "4":
                        SaveGame(player);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. You lose your turn!");
                        break;
                }

                // NPC's turn
                if (opponent.Health > 0)
                {
                    NPCTurn(player, opponent);
                }
            }

            if (player.ChosenVehicle.Armor > 0)
            {
                Console.WriteLine($"\nYou defeated {opponent.Name}!");
            }
            else
            {
                Console.WriteLine($"\nYou were defeated by {opponent.Name}...");
                BadEnding();
            }
        }

        static void StartRace(Player player, NPC opponent)
        {
            Console.WriteLine($"\n=== Racing against {opponent.Name} ===");
            Random random = new Random();
            int playerSpeed = player.ChosenVehicle.Speed + random.Next(1, 6); // Random boost
            int opponentSpeed = opponent.GetSpeed() + random.Next(1, 6); // Random boost

            Console.WriteLine($"{player.Name}'s Speed: {playerSpeed}");
            Console.WriteLine($"{opponent.Name}'s Speed: {opponentSpeed}");

            if (playerSpeed > opponentSpeed)
            {
                Console.WriteLine($"{player.Name} wins the race!");
            }
            else
            {
                Console.WriteLine($"{opponent.Name} wins the race...");
                player.ChosenVehicle.Armor -= 1; // Penalty for losing
            }
        }

        static void NPCTurn(Player player, NPC opponent)
        {
            Console.WriteLine($"\n{opponent.Name}'s turn!");
            Random random = new Random();
            int damage = random.Next(5, 15); // Random damage
            Console.WriteLine($"{opponent.Name} attacks {player.Name} for {damage} damage!");
            player.ChosenVehicle.Armor -= damage;
            Console.WriteLine($"{player.Name}'s vehicle has {player.ChosenVehicle.Armor} armor remaining.");
        }

        static void GoodEnding()
        {
            Console.WriteLine("\n=== Victory ===");
            Console.WriteLine("You won the tournament and made your wish!");
            Console.WriteLine("However, The Host twisted your wish in a horrifying way...");
            Console.WriteLine("Game Over. Thanks for playing!");
            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }

        static void BadEnding()
        {
            Console.WriteLine("\n=== Defeated ===");
            Console.WriteLine("You were defeated in the tournament...");
            Console.WriteLine("The Host laughs as your vehicle crumbles to dust.");
            Console.WriteLine("Game Over. Thanks for playing!");
            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }

        static void ShowCredits()
        {
            Console.WriteLine("\n=== Credits ===");
            Console.WriteLine("Game developed by Yasien_Kattan.");
            Console.WriteLine("Special thanks to\n 1) Deepseek AI for organization, Tips, and correcting the errors.\n 2) asciiart.eu for image-to-ascii. \n");
            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        static void SaveGame(Player player)
        {
            using (StreamWriter writer = new StreamWriter("save.txt"))
            {
                writer.WriteLine(player.Name);
                writer.WriteLine(player.ChosenVehicle.Name);
                writer.WriteLine(player.ChosenVehicle.Armor);
                foreach (var item in player.Inventory)
                {
                    writer.WriteLine(item.Name);
                }
            }
            Console.WriteLine("Game saved!");
        }

        static void LoadGame()
        {
            if (!File.Exists("save.txt"))
            {
                Console.WriteLine("No save file found!");
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader("save.txt"))
                {
                    string name = reader.ReadLine();
                    string vehicleName = reader.ReadLine();
                    int armor = int.Parse(reader.ReadLine());

                    Vehicle vehicle = new Vehicle(vehicleName, 0, armor, "");
                    Player player = new Player(name);
                    player.ChosenVehicle = vehicle;

                    while (!reader.EndOfStream)
                    {
                        string itemName = reader.ReadLine();
                        if (itemName == "Health Pack")
                        {
                            player.Inventory.Add(new HealthPack(itemName, 20));
                        }
                        else if (itemName == "Energy Shield")
                        {
                            player.Inventory.Add(new Shield(itemName, 3));
                        }
                        else if (itemName == "Machine Gun")
                        {
                            player.Inventory.Add(new Weapon(itemName, 10, 20));
                        }
                        else if (itemName == "Missile")
                        {
                            player.Inventory.Add(new Weapon(itemName, 30, 5));
                        }
                    }

                    Console.WriteLine("Game loaded!");
                    StartCombat(player, new NPC("The Jester", 50, "Carnival Cruiser", "Flamethrower"), "1");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading game: {ex.Message}");
            }
        }
    }

    // Vehicle class
    class Vehicle
    {
        public string Name { get; }
        public int Speed { get; }
        public int Armor { get; set; }
        public string SpecialAbility { get; }

        public Vehicle(string name, int speed, int armor, string specialAbility)
        {
            Name = name;
            Speed = speed;
            Armor = armor;
            SpecialAbility = specialAbility;
        }
    }

    // Player class
    class Player
    {
        public string Name { get; }
        public Vehicle ChosenVehicle { get; set; }
        public List<Item> Inventory { get; } = new List<Item>();

        public Player(string name)
        {
            Name = name;
        }

        public void Attack(NPC target)
        {
            Random random = new Random();
            int damage = random.Next(5, 15); // Random damage between 5 and 15
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.Health -= damage;
            Console.WriteLine($"{target.Name} has {target.Health} health remaining.");
        }

        public void UseItem()
        {
            Console.WriteLine("Using an item...");
            // Implement item usage logic here
        }
    }

    // NPC class
    class NPC
    {
        public string Name { get; }
        public int Health { get; set; }
        public string VehicleName { get; }
        public string SpecialAbility { get; }

        public NPC(string name, int health, string vehicleName, string specialAbility)
        {
            Name = name;
            Health = health;
            VehicleName = vehicleName;
            SpecialAbility = specialAbility;
        }

        public int GetSpeed()
        {
            // Implement logic to return NPC speed
            return 3; // Placeholder value
        }

        public void Attack(Player target)
        {
            Random random = new Random();
            int damage = random.Next(5, 15); // Random damage between 5 and 15
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.ChosenVehicle.Armor -= damage;
            Console.WriteLine($"{target.Name}'s vehicle has {target.ChosenVehicle.Armor} armor remaining.");
        }
    }

    // Item base class
    abstract class Item
    {
        public string Name { get; }

        protected Item(string name)
        {
            Name = name;
        }
    }

    // HealthPack class
    class HealthPack : Item
    {
        public int HealthRestored { get; }

        public HealthPack(string name, int healthRestored) : base(name)
        {
            HealthRestored = healthRestored;
        }
    }

    // Shield class
    class Shield : Item
    {
        public int Durability { get; }

        public Shield(string name, int durability) : base(name)
        {
            Durability = durability;
        }
    }

    // Weapon class
    class Weapon : Item
    {
        public int Damage { get; }
        public int Ammo { get; }

        public Weapon(string name, int damage, int ammo) : base(name)
        {
            Damage = damage;
            Ammo = ammo;
        }
    }

    // Arena class
    class Arena
    {
        public string Name { get; }
        public string Description { get; }
        public string Hazards { get; }
        public int Mileage { get; } 

        public Arena(string name, string description, string hazards, int mileage)
        {
            Name = name;
            Description = description;
            Hazards = hazards;
            Mileage = mileage;
        }

        public void DisplayDescription()
        {
            Console.WriteLine(Description);
            Console.WriteLine($"Hazards: {Hazards}");
            Console.WriteLine($"Mileage: {Mileage} miles");
        }
    }
}
