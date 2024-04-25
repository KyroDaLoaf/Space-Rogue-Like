using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

class Game
{
    static int distanceGoal = 10000;
    static int distanceTraveled = 0;
    static Ship playerShip = new Ship();
    static int difficultyLevel = 0;
    static int time = 200;
    static int combatTime = 500;

    static void Main(string[] args)
    {
        bool playing = true;
        bool validResponse = false;
        string keepPlaying = "";
        Console.WriteLine("Welcome to the Space Rogue-Like!");
        Console.WriteLine("");
        Console.WriteLine("Your goal is to travel 10000 light years across the universe to reach the Intergalactic Space Station.");
        Console.WriteLine("Press enter to start.");
        Console.ReadLine();

        while (playing == true)
        {
            playGame();
            validResponse = false;
            Console.WriteLine("");
            Console.WriteLine("Would you like to play again? (y/n)");
            while (validResponse == false)
            {
                keepPlaying = Console.ReadLine();
                keepPlaying = keepPlaying.ToLower();
                if (keepPlaying == "y" || keepPlaying == "n" || keepPlaying == "yes" || keepPlaying == "no")
                {
                    validResponse = true;
                    if (keepPlaying == "y" || keepPlaying == "yes")
                    {
                        playerShip = new Ship();
                        distanceTraveled = 0;
                        difficultyLevel = 0;
                        continue;
                    }
                    else if (keepPlaying == "n" || keepPlaying == "no")
                    {
                        playing = false;
                    }
                }
                else
                {
                    Console.WriteLine("Please select yes or no. (y/n)");
                }
            }
        }
    } 

    static void playGame()
    {
        int startTime = 1000;
        Console.Clear();
        bool traveling = true;
        Console.WriteLine("The ship has departed from the station.");
        Thread.Sleep(startTime);
        while (traveling == true)
        {
            Console.Clear();
            distanceTraveled += playerShip.speed;
            playerShip.fuel -= playerShip.fuelUsage;
            playerShip.hp += playerShip.passiveHealing;
            difficultyLevel += 1;
            Console.WriteLine("Distance traveled: " + distanceTraveled + " lightyears");
            Console.WriteLine("");
            Console.WriteLine("Your ship's health points: " + playerShip.hp);
            Console.WriteLine("Your ship's damage: " + playerShip.damage);
            Console.WriteLine("Credits: " + playerShip.credits);
            Console.WriteLine("Remaining fuel: " + playerShip.fuel);
            Console.WriteLine("");
            selectEvent();
            
            if(distanceTraveled == distanceGoal)
            {
                Console.Clear();
                Console.WriteLine("You've reached your destination!");
                traveling = false;
            }
            else if(playerShip.hp <= 0)
            {
                Console.Clear();
                Console.WriteLine("Your ship was destroyed!");
                traveling = false;
            }
            else if(playerShip.fuel <= 0)
            {
                Console.Clear();
                Console.WriteLine("Your ship ran out of fuel!");
                traveling = false;
            }
        }
    }

    static void selectEvent()
    {
        Random random = new Random();
        int randomEvent = random.Next(0, 10001);
        if (randomEvent >= 0 && randomEvent <= 7500)
        {
            Console.WriteLine("No event.");
            Thread.Sleep(time);
        }
        else if (randomEvent >= 7500 && randomEvent <= 8500)
        {
            Console.WriteLine("An enemy ship approaches!");
            Console.WriteLine("");
            enemyCombat();
        }
        else if (randomEvent >= 8510 && randomEvent <= 9000)
        {
            Console.WriteLine("You've reached a space outpost!");
            Console.WriteLine("");
            spaceOutpost();
        }
        else if (randomEvent >= 9010 && randomEvent <= 9100)
        {
            Console.WriteLine("You've found a derelict cruiser drifting through space.");
            Console.WriteLine();
            derelictCruiser();
        }
        else if (randomEvent >= 9101 && randomEvent <= 9105)
        {
            Console.WriteLine("Your ship has collided with an asteroid!");
            Console.WriteLine("");
            asteroidCollision();
        }
        else if (randomEvent >= 9106 && randomEvent <= 9107)
        {
            Console.WriteLine("A black hole has pulled your ship out of hyperspace.");
            Console.WriteLine("");
            blackHole();
        }
        else if (randomEvent >= 9108)
        {
            Console.WriteLine("No event.");
        }
    }

    static void enemyCombat()
    {
        bool inCombat = true;
        Random random = new Random();
        int creditsReceived = 0;
        int fuelSalvaged = 0;
        Ship enemyShip = new Ship();
        if (difficultyLevel >= 0 && difficultyLevel <= 50)
        {
            enemyShip.hp = random.Next(10,21);
            enemyShip.damage = random.Next(2,6);
            creditsReceived = random.Next(100, 201);
            fuelSalvaged = random.Next(0, 21);
        }
        else if(difficultyLevel >= 51 && difficultyLevel <= 100)
        {
            enemyShip.hp = random.Next(20, 31);
            enemyShip.damage = random.Next(5, 11);
            creditsReceived = random.Next(200, 301);
            fuelSalvaged = random.Next(10, 31);
        }
        else if(difficultyLevel >= 101 && difficultyLevel <= 150)
        {
            enemyShip.hp = random.Next(30, 41);
            enemyShip.damage = random.Next(10, 21);
            creditsReceived = random.Next(300, 401);
            fuelSalvaged = random.Next(30, 41);
        }
        else if(difficultyLevel >= 151 && difficultyLevel <= 200)
        {
            enemyShip.hp = random.Next(40, 51);
            enemyShip.damage = random.Next(10, 31);
            creditsReceived = random.Next(300, 501);
            fuelSalvaged = random.Next(30, 51);
        }
        else if (difficultyLevel >= 201 && difficultyLevel <= 250)
        {
            enemyShip.hp = random.Next(40, 61);
            enemyShip.damage = random.Next(10, 31);
            creditsReceived = random.Next(500, 801);
            fuelSalvaged = random.Next(30, 61);
        }
        else if (difficultyLevel >= 251 && difficultyLevel <= 300)
        {
            enemyShip.hp = random.Next(50, 71);
            enemyShip.damage = random.Next(20, 41);
            creditsReceived = random.Next(500, 901);
            fuelSalvaged = random.Next(40, 71);
        }
        else if (difficultyLevel >= 301 && difficultyLevel <= 350)
        {
            enemyShip.hp = random.Next(50, 81);
            enemyShip.damage = random.Next(20, 61);
            creditsReceived = random.Next(600, 1001);
            fuelSalvaged = random.Next(40, 81);
        }
        else if (difficultyLevel >= 351 && difficultyLevel <= 400)
        {
            enemyShip.hp = random.Next(60, 81);
            enemyShip.damage = random.Next(30, 61);
            creditsReceived = random.Next(800, 1101);
            fuelSalvaged = random.Next(50, 81);
        }
        else if (difficultyLevel >= 401 && difficultyLevel <= 450)
        {
            enemyShip.hp = random.Next(70, 91);
            enemyShip.damage = random.Next(30, 71);
            creditsReceived = random.Next(900, 1201);
            fuelSalvaged = random.Next(50, 91);
        }
        else if (difficultyLevel >= 451 && difficultyLevel <= 500)
        {
            enemyShip.hp = random.Next(80, 101);
            enemyShip.damage = random.Next(40, 81);
            creditsReceived = random.Next(1000, 1501);
            fuelSalvaged = random.Next(50, 101);
        }
        else if (difficultyLevel >= 501 && difficultyLevel <= 600)
        {
            enemyShip.hp = random.Next(100, 141);
            enemyShip.damage = random.Next(50, 101);
            creditsReceived = random.Next(2000, 3001);
            fuelSalvaged = random.Next(50, 101);
        }
        else if (difficultyLevel >= 601 && difficultyLevel <= 700)
        {
            enemyShip.hp = random.Next(150, 201);
            enemyShip.damage = random.Next(100, 151);
            creditsReceived = random.Next(3000, 6001);
            fuelSalvaged = random.Next(50, 101);
        }
        else if (difficultyLevel >= 701 && difficultyLevel <= 800)
        {
            enemyShip.hp = random.Next(200, 251);
            enemyShip.damage = random.Next(150, 201);
            creditsReceived = random.Next(4000, 8001);
            fuelSalvaged = random.Next(50, 101);
        }
        else if (difficultyLevel >= 801 && difficultyLevel <= 900)
        {
            enemyShip.hp = random.Next(250, 300);
            enemyShip.damage = random.Next(200, 301);
            creditsReceived = random.Next(5000, 10001);
            fuelSalvaged = random.Next(50, 101);
        }
        else if (difficultyLevel >= 901 && difficultyLevel <= 1000)
        {
            enemyShip.hp = random.Next(400, 501);
            enemyShip.damage = random.Next(200, 400);
            creditsReceived = random.Next(2000, 3001);
            fuelSalvaged = random.Next(50, 101);
        }
        Console.WriteLine("Your ship's health points: " + playerShip.hp);
        Console.WriteLine("Your ship's damage: " + playerShip.damage);
        Console.WriteLine("");
        Console.WriteLine("Enemy ship's health points: " + enemyShip.hp);
        Console.WriteLine("Enemy ship's damage: " + enemyShip.damage);
        Console.WriteLine("");
        Console.WriteLine("Press enter to begin combat.");
        Console.ReadLine();
        while(inCombat == true)
        {
            Console.Clear();
            if(playerShip.hp < 0)
            {
                playerShip.hp = 0;
            }
            if(enemyShip.hp < 0)
            {
                enemyShip.hp = 0;
            }
            Console.WriteLine("Your ship's remaining health points: " + playerShip.hp);
            Console.WriteLine("");
            Console.WriteLine("Enemy ship's remaining health points: " + enemyShip.hp);
            Thread.Sleep(combatTime);
            if(enemyShip.hp <= 0)
            {
                Console.Clear();
                playerShip.credits += creditsReceived;
                playerShip.fuel += fuelSalvaged;
                Console.WriteLine("The enemy ship has been defeated!");
                Console.WriteLine("");
                Console.WriteLine("Credits received: " + creditsReceived);
                Console.WriteLine("");
                Console.WriteLine("Fuel salvaged: " + fuelSalvaged);
                Console.WriteLine("");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                inCombat = false;
                continue;
            }
            if(playerShip.hp <= 0)
            {
                inCombat = false;
                continue;
            }
            playerShip.hp -= enemyShip.damage;
            enemyShip.hp -= playerShip.damage;
        }
    }

    static void spaceOutpost()
    {
        int shipArmorUpgrade = 0;
        int shipWeaponUpgrade = 0;
        int costOne = 0;
        int costTwo = 0;
        int costThree = 1000;
        int costFour = 500;
        int hpRepaired = 100;
        int costFive = 1000;
        if(difficultyLevel >= 300 && difficultyLevel <= 500)
        {
            costFour = 1000;
            hpRepaired = 200;
            costFive = 2000;
        }
        else if(difficultyLevel >= 501 && difficultyLevel <= 600)
        {
            costFour = 1000;
            hpRepaired = 200;
            costFive = 2500;
        }
        else if(difficultyLevel >= 601 && difficultyLevel <= 700)
        {
            costFour = 1000;
            hpRepaired = 200;
            costFive = 3000;
        }
        else if (difficultyLevel >= 701 && difficultyLevel <= 800)
        {
            costFour = 1000;
            hpRepaired = 200;
            costFive = 4000;
        }
        else if (difficultyLevel >= 701 && difficultyLevel <= 800)
        {
            costFour = 1000;
            hpRepaired = 200;
            costFive = 8000;
        }
        else if (difficultyLevel >= 801 && difficultyLevel <= 900)
        {
            costFour = 1000;
            hpRepaired = 200;
            costFive = 12000;
        }
        else if (difficultyLevel >= 901 && difficultyLevel <= 1000)
        {
            costFour = 1000;
            hpRepaired = 200;
            costFive = 20000;
        }
        string itemPurchased = "";
        int item = 0;
        Random random = new Random();
        Console.WriteLine("Press enter to trade with the station.");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Current ship health points: " + playerShip.hp);
        Console.WriteLine("Max ship health points: " + playerShip.maxHp);
        Console.WriteLine("Current ship damage: " + playerShip.damage);
        Console.WriteLine("Current ship fuel: " + playerShip.fuel);
        Console.WriteLine("");
        Console.WriteLine("Credits: " + playerShip.credits);
        Console.WriteLine("");
        Console.WriteLine("Upgrades for sale:");
        Console.WriteLine("");
        if(playerShip.hpUpgradeLevel == 1)
        {
            Console.WriteLine("1. Ship Armor Upgrade I - 250 Credits");
            shipArmorUpgrade = 50;
            costOne = 250;
        }
        else if(playerShip.hpUpgradeLevel == 2)
        {
            Console.WriteLine("1. Ship Armor Upgrade II - 750 Credits");
            shipArmorUpgrade = 100;
            costOne = 750;
        }
        else if(playerShip.hpUpgradeLevel == 3)
        {
            Console.WriteLine("1. Ship Armor Upgrade III - 1250 Credits");
            shipArmorUpgrade = 200;
            costOne = 1250;
        }
        else if(playerShip.hpUpgradeLevel == 4)
        {
            Console.WriteLine("1. Ship Armor Upgrade IV - 3000 Credits");
            shipArmorUpgrade = 300;
            costOne = 3000;
        }
        else if (playerShip.hpUpgradeLevel == 5)
        {
            Console.WriteLine("1. Ship Armor Upgrade V - 5000 Credits");
            shipArmorUpgrade = 500;
            costOne = 5000;
        }
        else if (playerShip.hpUpgradeLevel == 6)
        {
            Console.WriteLine("1. Ship Armor Upgrade VI - 10000 Credits");
            shipArmorUpgrade = 800;
            costOne = 10000;
        }
        else if (playerShip.hpUpgradeLevel == 7)
        {
            Console.WriteLine("1. Ship Armor Upgrade VII - 20000 Credits");
            shipArmorUpgrade = 1000;
            costOne = 20000;
        }
        else if (playerShip.hpUpgradeLevel == 8)
        {
            Console.WriteLine("1. Ship Armor Upgrade VIII - 50000 Credits");
            shipArmorUpgrade = 1500;
            costOne = 50000;
        }
        else if (playerShip.hpUpgradeLevel == 9)
        {
            Console.WriteLine("1. Ship Armor Upgrade VIII - MAX LEVEL");
        }
        if (playerShip.damageUpgradeLevel == 1)
        {
            Console.WriteLine("2. Plasma Cannon Mk. I - 250 Credits");
            shipWeaponUpgrade = 5;
            costTwo = 250;
        }
        else if(playerShip.damageUpgradeLevel == 2)
        {
            Console.WriteLine("2. Plasma Cannon Mk. II - 750 Credits");
            shipWeaponUpgrade = 10;
            costTwo = 750;
        }
        else if(playerShip.damageUpgradeLevel == 3)
        {
            Console.WriteLine("2. Plasma Cannon Mk. III - 1250 Credits");
            shipWeaponUpgrade = 15;
            costTwo = 1250;
        }
        else if (playerShip.damageUpgradeLevel == 4)
        {
            Console.WriteLine("2. Plasma Cannon Mk. IV - 3000 Credits");
            shipWeaponUpgrade = 20;
            costTwo = 3000;
        }
        else if (playerShip.damageUpgradeLevel == 5)
        {
            Console.WriteLine("2. Plasma Cannon Mk. V - 5000 Credits");
            shipWeaponUpgrade = 30;
            costTwo = 5000;
        }
        else if (playerShip.damageUpgradeLevel == 6)
        {
            Console.WriteLine("2. Plasma Cannon Mk. VI - 10000 Credits");
            shipWeaponUpgrade = 40;
            costTwo = 10000;
        }
        else if (playerShip.damageUpgradeLevel == 7)
        {
            Console.WriteLine("2. Plasma Cannon Mk. VII - 20000 Credits");
            shipWeaponUpgrade = 50;
            costTwo = 20000;
        }
        else if (playerShip.damageUpgradeLevel == 8)
        {
            Console.WriteLine("2. Plasma Cannon Mk. VIII - 50000 Credits");
            shipWeaponUpgrade = 80;
            costTwo = 50000;
        }
        else if (playerShip.damageUpgradeLevel == 9)
        {
            Console.WriteLine("2. Plasma Cannon Mk. VIII - MAX LEVEL");
        }

        Console.WriteLine("3. 500 Fuel - 1000 Credits");
        Console.WriteLine("4. Repair " + hpRepaired + " ship health points - " + costFour + " Credits");
        Console.WriteLine("5. Full Ship Repair - " + costFive + " Credits");
        Console.WriteLine("");
        Console.WriteLine("Type 1, 2, 3, 4, or 5 to choose which item to purchase:");
        Console.WriteLine("Or, type 6 to skip the shop.");
        bool enoughCredits = false;
        while(enoughCredits == false)
        {
            
            itemPurchased = Console.ReadLine();
            if(itemPurchased == "1" || itemPurchased == "2" || itemPurchased == "3" || itemPurchased == "4" || itemPurchased == "5" || itemPurchased == "6")
            {
                item = Int32.Parse(itemPurchased);
            }
            else
            {
                Console.WriteLine("Invalid item, please select again.");
                continue;
            }
            if(item == 1)
            {
                if(playerShip.credits < costOne)
                {
                    Console.WriteLine("Not enough credits. Please select a different item to purchase.");
                    continue;
                }
                else if(playerShip.hpUpgradeLevel == 9)
                {
                    Console.WriteLine("That upgrade is at max level. Please select a different item to purchase.");
                    continue;
                }
            }
            else if(item == 2)
            {
                if(playerShip.credits < costTwo)
                {
                    Console.WriteLine("Not enough credits. Please select a different item to purchase.");
                    continue;
                }
                else if(playerShip.damageUpgradeLevel == 9)
                {
                    Console.WriteLine("That upgrade is at max level. Please select a differet item to purchase.");
                    continue;
                }
            }
            else if(item == 3)
            {
                if(playerShip.credits < costThree)
                {
                    Console.WriteLine("Not enough credits. Please select a different item to purchase.");
                    continue;
                }
            }
            else if(item == 4)
            {
                if(playerShip.credits < costFour)
                {
                    Console.WriteLine("Not enough credits. Please select a different item to purchase.");
                    continue;
                }
            }
            else if(item == 5)
            {
                if(playerShip.credits < costFive)
                {
                    Console.WriteLine("Not enough credits. Please select a different item to purchase.");
                    continue;
                }
            }
            enoughCredits = true;
        }
        Console.Clear();
        if(item == 1)
        {
            playerShip.hp += shipArmorUpgrade;
            playerShip.maxHp += shipArmorUpgrade;
            playerShip.credits -= costOne;
            playerShip.hpUpgradeLevel += 1;
            Console.WriteLine("Current ship health points and max ship health points increased by " + shipArmorUpgrade + ".");
            Console.WriteLine("");
            Console.WriteLine("Current ship health points: " + playerShip.hp);
            Console.WriteLine("Max ship health points: " + playerShip.maxHp);
            Console.WriteLine("");
            Console.WriteLine("Credits remaining: " + playerShip.credits);
        }
        else if(item == 2)
        {
            playerShip.damage += shipWeaponUpgrade;
            playerShip.credits -= costTwo;
            playerShip.damageUpgradeLevel += 1;
            Console.WriteLine("Ship damage increased by " + shipWeaponUpgrade + ".");
            Console.WriteLine("");
            Console.WriteLine("Current ship damage: " + playerShip.damage);
            Console.WriteLine("");
            Console.WriteLine("Credits remaining: " + playerShip.credits);
        }
        else if(item == 3)
        {
            playerShip.fuel += 500;
            playerShip.credits -= costThree;
            Console.WriteLine("500 fuel added to ship fuel reserves.");
            Console.WriteLine("");
            Console.WriteLine("Current ship fuel: " + playerShip.fuel);
            Console.WriteLine("");
            Console.WriteLine("Credits remaining: " + playerShip.credits);
        }
        else if(item == 4)
        {
            playerShip.hp += hpRepaired;
            if(playerShip.hp > playerShip.maxHp)
            {
                playerShip.hp = playerShip.maxHp;
            }
            playerShip.credits -= costFour;
            Console.WriteLine("Ship repaired by " + hpRepaired + " health points.");
            Console.WriteLine("");
            Console.WriteLine("Current ship health points: " + playerShip.hp);
            Console.WriteLine("");
            Console.WriteLine("Credits remaining: " + playerShip.credits);
        }
        else if(item == 5)
        {
            playerShip.hp = playerShip.maxHp;
            playerShip.credits -= costFive;
            Console.WriteLine("Ship fully repaired.");
            Console.WriteLine("");
            Console.WriteLine("Current ship health points: " + playerShip.hp);
            Console.WriteLine("");
            Console.WriteLine("Credits remaining: " + playerShip.credits);
        }
        else if(item == 6)
        {
            Console.WriteLine("You didn't purchase anything from the space outpost.");
        }
        Console.WriteLine("");
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }

    static void derelictCruiser()
    {
        bool valid = false;
        string explore = "";
        int loot = 0;
        int creditsFound = 0;
        int fuelFound = 0;
        int damageTaken = 0;
        int healing = 0;
        Random random = new Random();
        Console.WriteLine("Your ship's engineering crew says that it may be possible to salvage useful parts from the abandoned cruiser.");
        Console.WriteLine("Would you like to further examine the derelict cruiser? (y/n)");
        explore = Console.ReadLine();
        explore = explore.ToLower();
        while(valid == false)
        {
            if(explore == "y" || explore == "n" || explore == "yes" || explore == "no")
            {
                valid = true;
                continue;
            }
            else
            {
                Console.WriteLine("Please select yes or no. (y/n)");
                explore = Console.ReadLine();
                explore = explore.ToLower();
                continue;
            }
        }
        Console.Clear();
        if(explore == "y" || explore == "yes")
        {
            loot = random.Next(0, 101);
            if(loot >= 0 && loot <= 60)
            {
                if(difficultyLevel >= 0 && difficultyLevel <= 300)
                {
                    creditsFound = random.Next(1000, 2001);
                }
                else if(difficultyLevel >= 301 && difficultyLevel <= 500)
                {
                    creditsFound = random.Next(5000, 10001);
                }
                else if (difficultyLevel >= 501 && difficultyLevel <= 600)
                {
                    creditsFound = random.Next(10000, 15001);
                }
                else if (difficultyLevel >= 601 && difficultyLevel <= 700)
                {
                    creditsFound = random.Next(15000, 20001);
                }
                else if (difficultyLevel >= 701 && difficultyLevel <= 800)
                {
                    creditsFound = random.Next(20000, 25001);
                }
                else if (difficultyLevel >= 801 && difficultyLevel <= 900)
                {
                    creditsFound = random.Next(25000, 30001);
                }
                else if (difficultyLevel >= 901 && difficultyLevel <= 1000)
                {
                    creditsFound = random.Next(30000, 35001);
                }
                playerShip.credits += creditsFound;
                Console.WriteLine("You found " + creditsFound + " credits in the derelict cruiser.");
                Console.WriteLine("");
                Console.WriteLine("Credits remaining: " + playerShip.credits);
            }
            else if(loot >= 61 && loot <= 80)
            {
                if (difficultyLevel >= 0 && difficultyLevel <= 300)
                {
                    fuelFound = random.Next(100, 200);
                }
                else if (difficultyLevel >= 301 && difficultyLevel <= 500)
                {
                    fuelFound = random.Next(200, 400);
                }
                else if (difficultyLevel >= 501 && difficultyLevel <= 600)
                {
                    fuelFound = random.Next(400, 600);
                }
                else if (difficultyLevel >= 601 && difficultyLevel <= 700)
                {
                    fuelFound = random.Next(600, 800);
                }
                else if (difficultyLevel >= 701 && difficultyLevel <= 800)
                {
                    fuelFound = random.Next(800, 1000);
                }
                else if (difficultyLevel >= 801 && difficultyLevel <= 900)
                {
                    fuelFound = random.Next(800, 1000);
                }
                else if (difficultyLevel >= 901 && difficultyLevel <= 1000)
                {
                    fuelFound = random.Next(800, 1000);
                }
                playerShip.fuel += fuelFound;
                Console.WriteLine("You found " + fuelFound + " fuel.");
                Console.WriteLine("");
                Console.WriteLine("Fuel remaining: " + playerShip.fuel);
            }
            else if(loot >= 81 && loot <= 95)
            {
                if (difficultyLevel >= 0 && difficultyLevel <= 300)
                {
                    damageTaken = random.Next(50, 81);
                }
                else if (difficultyLevel >= 301 && difficultyLevel <= 500)
                {
                    damageTaken = random.Next(60, 101);
                }
                else if (difficultyLevel >= 501 && difficultyLevel <= 600)
                {
                    damageTaken = random.Next(80, 121);
                }
                else if (difficultyLevel >= 601 && difficultyLevel <= 700)
                {
                    damageTaken = random.Next(100, 151);
                }
                else if (difficultyLevel >= 701 && difficultyLevel <= 800)
                {
                    damageTaken = random.Next(200, 301);
                }
                else if (difficultyLevel >= 801 && difficultyLevel <= 900)
                {
                    damageTaken = random.Next(400, 600);
                }
                else if (difficultyLevel >= 901 && difficultyLevel <= 1000)
                {
                    damageTaken = random.Next(500, 1000);
                }
                playerShip.hp -= damageTaken;
                Console.WriteLine("Your ship collided with the derelict cruiser and takes " + damageTaken + " damage.");
                Console.WriteLine("");
                Console.WriteLine("Your ship's remaining health points: " + playerShip.hp);
            }
            else if(loot >= 96 && loot <= 100)
            {
                if (difficultyLevel >= 0 && difficultyLevel <= 300)
                {
                    healing = 5;
                }
                else if (difficultyLevel >= 301 && difficultyLevel <= 500)
                {
                    healing = 10;
                }
                else if (difficultyLevel >= 501 && difficultyLevel <= 600)
                {
                    healing = 10;
                }
                else if (difficultyLevel >= 601 && difficultyLevel <= 700)
                {
                    healing = 15;
                }
                else if (difficultyLevel >= 701 && difficultyLevel <= 800)
                {
                    healing = 15;
                }
                else if (difficultyLevel >= 801 && difficultyLevel <= 900)
                {
                    healing = 20;
                }
                else if (difficultyLevel >= 901 && difficultyLevel <= 1000)
                {
                    healing = 20;
                }
                playerShip.passiveHealing += healing;
                Console.WriteLine("The crew that boarded the derelict cruiser have found something interesting in the cruisers cargo hold.");
                Console.WriteLine("They found a strange device that seems to repair damage metal around it over time.");
                Console.WriteLine("Your ship's engineering crew is able to attach this device to the ship's systems, giving your ship the ability to slowly regain health points as it travels.");
                Console.WriteLine("This specific device allows your ship to regain " + healing + " health points over time.");
                Console.WriteLine("");
                Console.WriteLine("Your ship's health regeneration every " + playerShip.speed + " lightyears traveled: " + playerShip.passiveHealing);
            }
        }
        else if(explore == "n" || explore == "no")
        {
            Console.WriteLine("You decided not to explore the derelict cruiser.");
        }
        Console.WriteLine("");
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }

    static void asteroidCollision()
    {
        int asteroidDamage = 0;
        Random random = new Random();

        if (difficultyLevel >= 0 && difficultyLevel <= 300)
        {
            asteroidDamage = random.Next(1, 101);
        }
        else if (difficultyLevel >= 301 && difficultyLevel <= 500)
        {
            asteroidDamage = random.Next(100, 201);
        }
        else if (difficultyLevel >= 501 && difficultyLevel <= 600)
        {
            asteroidDamage = random.Next(200, 301);
        }
        else if (difficultyLevel >= 601 && difficultyLevel <= 700)
        {
            asteroidDamage = random.Next(300, 501);
        }
        else if (difficultyLevel >= 701 && difficultyLevel <= 800)
        {
            asteroidDamage = random.Next(500, 801);
        }
        else if (difficultyLevel >= 801 && difficultyLevel <= 900)
        {
            asteroidDamage = random.Next(800, 1001);
        }
        else if (difficultyLevel >= 901 && difficultyLevel <= 1000)
        {
            asteroidDamage = random.Next(1000, 1501);
        }
        playerShip.hp -= asteroidDamage;
        Console.WriteLine("Your ship has taken " + asteroidDamage + " damage.");
        Console.WriteLine("");
        Console.WriteLine("Your ship's remaining health points: " + playerShip.hp);
        Console.WriteLine("");
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }

    static void blackHole()
    {
        int requiredFuel = 0;
        int chance = 0;
        string choice = "";
        bool validResponse = false;
        Random random = new Random();

        if (difficultyLevel >= 0 && difficultyLevel <= 300)
        {
            requiredFuel = random.Next(300, 401);
        }
        else if (difficultyLevel >= 301 && difficultyLevel <= 500)
        {
            requiredFuel = random.Next(500, 601);
        }
        else if (difficultyLevel >= 501 && difficultyLevel <= 600)
        {
            requiredFuel = random.Next(700, 801);
        }
        else if (difficultyLevel >= 601 && difficultyLevel <= 700)
        {
            requiredFuel = random.Next(800, 901);
        }
        else if (difficultyLevel >= 701 && difficultyLevel <= 800)
        {
            requiredFuel = random.Next(900, 1001);
        }
        else if (difficultyLevel >= 801 && difficultyLevel <= 900)
        {
            requiredFuel = random.Next(1000, 1501);
        }
        else if (difficultyLevel >= 901 && difficultyLevel <= 1000)
        {
            requiredFuel = random.Next(1500, 2001);
        }
        Console.WriteLine("Your ship's engineering crew calculates that it will require " + requiredFuel + " fuel to escape the gravitational pull of the black hole.");
        Console.WriteLine("");
        Console.WriteLine("Would you like to try and escape the black hole's gravitational field? (y/n)");
        while (validResponse == false)
        {
            choice = Console.ReadLine();
            choice = choice.ToLower();
            if (choice == "y" || choice == "n" || choice == "yes" || choice == "no")
            {
                validResponse = true;
            }
            else
            {
                Console.WriteLine("Please select yes or no. (y/n)");
                continue;
            }
        }
        Console.Clear();
        if (choice == "y" || choice == "yes")
        {
            if (playerShip.fuel >= requiredFuel)
            {
                playerShip.fuel -= requiredFuel;
                Console.WriteLine("Your ship has successfully escaped the black hole's gravitational pull!");
                Console.WriteLine("");
                Console.WriteLine("Fuel remaining: " + playerShip.fuel);
            }
            else if (playerShip.fuel < requiredFuel)
            {
                playerShip.hp -= 100000;
                Console.WriteLine("Your ship was unable to escape the black hole's gravitational pull and was destroyed upon entry.");
            }
        }
        else if (choice == "n" || choice == "no")
        {
            chance = random.Next(1, 101);
            if (chance >= 1 && chance <= 50)
            {
                playerShip.hp -= 100000;
                Console.WriteLine("Your ship was destroyed upon entering the black hole.");
            }
            else if (chance >= 51 && chance <= 100)
            {
                playerShip.maxHp *= 2;
                Console.WriteLine("As your ship was entering the black hole, a strange energy collided with it, seeming to alter the molecular structure of your ship's armor.");
                Console.WriteLine("When the strange energy collided with your ship, it sent your ship flying out of the black hole and out of its gravitation pull.");
                Console.WriteLine("");
                Console.WriteLine("Your ship's max health points have been doubled!");
                Console.WriteLine("");
                Console.WriteLine("Current ship health points: " + playerShip.hp);
                Console.WriteLine("Max ship health points: " + playerShip.maxHp);
            }
        }
        Console.WriteLine("");
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }
}

class Ship
{
    public int hp = 100;
    public int maxHp = 100;
    public int passiveHealing = 0;
    public int speed = 10;
    public int hpUpgradeLevel = 1;
    public int damage = 5;
    public int damageUpgradeLevel = 1;
    public int fuel = 500;
    public int fuelUsage = 5;
    public int credits = 1000;
}