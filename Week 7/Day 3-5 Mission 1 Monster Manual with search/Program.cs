using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace Day_3_5_Mission_1_Monster_Manual_with_search
{
    class MonsterEntry
    {
        public string Name;
        public string Description;
        public string Alignment;
        public string HitPoints;
        public ArmorInformation Armor = new ArmorInformation();
    }

    class ArmorInformation
    {
        public int Class;
        public string Type;
    }

    enum ArmorType
    {
        Unspecified,
        Natural,
        Leather,
        StuddedLeather,
        Hide,
        ChainShirt,
        ChainMail,
        ScaleMail,
        Plate,
        Other

    }

    class ArmorTypeEntry
    {
        public string Name;
        public ArmorCategory Category;
        public int Weight;
    }

    enum ArmorCategory
    {
        Light,
        Medium,
        Heavy
    }

    class Program
    {
        // READ FROM THE MONSTERMANUAL TEXT FILE
        static string pathManual = @"D:\Projects\TheIndieQuest\Week 7\Day 3-5 Mission 1 Monster Manual with search\MonsterManual.txt";
        static string manual = File.ReadAllText(pathManual);

        // SPLIT THE MANUAL INTO INDIVIDUAL MONSTER ENTRIES
        static String[] monster = manual.Split("\n\n");

        // READ FROM THE ARMOR TEXT FILE
        static string pathArmor = @"D:\Projects\TheIndieQuest\Week 7\Day 3-5 Mission 1 Monster Manual with search\ArmorTypes.txt";
        static string armors = File.ReadAllText(pathArmor);

        // SPLIT THE ARMORS INTO INDIVIDUAL ARMOR INFORMATION
        static String[] armor = armors.Split("\n");

        // LIST FOR MATCHING SEARCH RESULTS
        static List<string> searchResults = new List<string>();

        static void Main(string[] args)
        {
            var monsterEntries = new List<MonsterEntry>();
            var armorTypeEntries = new Dictionary<ArmorType, ArmorTypeEntry>();

            ArmorData(armorTypeEntries);
            MonsterData(monsterEntries);

            retrySearchBy:
            Console.WriteLine("MONSTER MANUAL\n");
            Console.WriteLine("Do you want to search by (n)ame or (a)rmor?");
            string searchBy = Console.ReadLine();

            if(searchBy == "n")
            {
                Console.Clear();
                retrySearch:
                Console.WriteLine("MONSTER MANUAL\n");
                Console.WriteLine("Enter a query to search monsters by name:");
                string search = Console.ReadLine();

                nameSearch(monsterEntries, search);

                if(searchResults.Count == 0)
                {
                    Console.WriteLine("\nNo monsters were found. Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                    goto retrySearch;
                }

                else if(searchResults.Count == 1)
                {
                    DisplayMonsterInfo(monsterEntries, searchResults[0]);
                }

                else
                {
                    Console.WriteLine("MONSTER MANUAL\n");
                    string result = DisplaySearchResults();
                    DisplayMonsterInfo(monsterEntries, result);
                }
            }

            else if(searchBy == "a")
            {
                Console.WriteLine("\nWhich armor type do you want to display?");
                string[] armorTypes = Enum.GetNames(typeof(ArmorType));

                for(int i = 0; i < armorTypes.Length; i++)
                {
                    Console.WriteLine($"{i+1}: {armorTypes[i]}");
                }

                Console.WriteLine("\nEnter number:");
                retryArmorNumber:
                int chosen;
                try
                {
                    chosen = Int32.Parse(Console.ReadLine()) - 1;
                    armorSearch(monsterEntries, armorTypes[chosen]);

                    if(searchResults.Count == 0)
                    {
                        goto retryArmorNumber;
                    }

                    else if(searchResults.Count == 1)
                    {
                        DisplayMonsterInfo(monsterEntries, searchResults[0]);
                    }

                    else
                    {
                        Console.WriteLine("MONSTER MANUAL\n");
                        string result = DisplaySearchResults();
                        DisplayMonsterInfo(monsterEntries, result);
                    }

                }

                catch
                {
                    int cursor = Console.CursorTop;
                    Console.SetCursorPosition(0, Console.CursorTop-1);
                    Console.Write(new String(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, cursor-1);
                    goto retryArmorNumber;
                }
            }

            else
            {
                int cursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop-1);
                Console.Write(new String(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, cursor-1);
                goto retrySearchBy;
            }
        }

        static void nameSearch(List<MonsterEntry> monsterEntries, string search)
        {
            for(int i = 0; i < monsterEntries.Count; i++)
            {
                if(Regex.IsMatch(monsterEntries[i].Name, $"({search} ?)", RegexOptions.IgnoreCase))
                {
                    searchResults.Add(monsterEntries[i].Name);
                }
            }
        }

        static void armorSearch(List<MonsterEntry> monsterEntries, string search)
        {
            for(int i = 0; i < monsterEntries.Count; i++)
            {
                if(Regex.IsMatch(monsterEntries[i].Armor.Type, $"({search})", RegexOptions.IgnoreCase))
                {
                    searchResults.Add(monsterEntries[i].Name);
                }
            }
        }

        static string DisplaySearchResults()
        {
            Console.WriteLine("\nWhich monster did you want to look up?");
            for(int i = 0; i < searchResults.Count; i++)
            {
                Console.WriteLine($"{i+1}: {searchResults[i]}");
            }
            Console.WriteLine("\nEnter number:");
            retryNumber:
            int chosen;
            try
            {
                chosen = Int32.Parse(Console.ReadLine()) - 1;
                return searchResults[chosen];
            }

            catch
            {
                int cursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop-1);
                Console.Write(new String(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, cursor-1);
                goto retryNumber;
            }
        }

        static void DisplayMonsterInfo(List<MonsterEntry> monsterEntries, string result)
        {
            int index = -1;
            for(int i = 0; i < monsterEntries.Count; i++)
            {
                if(Regex.IsMatch(monsterEntries[i].Name, $"(^{result}$)", RegexOptions.IgnoreCase))
                {
                    index = i;
                    break;
                }
            }

            Console.WriteLine($"\nDisplaying information for {monsterEntries[index].Name}.\n");

            Console.WriteLine($"Name: {monsterEntries[index].Name}");
            Console.WriteLine($"Description: {monsterEntries[index].Description}");
            Console.WriteLine($"Alignment: {monsterEntries[index].Alignment}");
            Console.WriteLine($"Hit points: {monsterEntries[index].HitPoints}");

            Console.WriteLine($"Armor class: {monsterEntries[index].Armor.Class}");

            if(monsterEntries[index].Armor.Type != "")
            {
                Console.WriteLine($"Armor type: {monsterEntries[index].Armor.Type}");
                Console.WriteLine($"Armor category: {armor}");
                Console.WriteLine($"Armor weight: {armor}");

            }





        }

        static void MonsterData(List<MonsterEntry> monsterEntries)
        {
            for(int i = 0; i < monster.Length; i++)
            {
                var monsterEntry = new MonsterEntry();
                String[] info = monster[i].Split("\n");
                monsterEntry.Name = info[0];

                String[] description = info[1].Split(", ");
                monsterEntry.Description = description[0];
                monsterEntry.Alignment = description[1];

                string diceNotation = @"(\dd\d.?\d?)";
                monsterEntry.HitPoints = Regex.Match(monster[i], diceNotation).ToString();

                Match armorClass = Regex.Match(info[3], @" (\d+) \(?.*\)?");
                monsterEntry.Armor.Class = Int32.Parse(armorClass.Groups[1].ToString());

                try
                {
                    Match armorType = Regex.Match(info[3], @" \d+ \(*(.*)\)");

                    if(Regex.IsMatch(armorType.Groups[1].ToString(), "Natural", RegexOptions.IgnoreCase))
                    {
                        monsterEntry.Armor.Type = ArmorType.Natural.ToString();
                    }

                    else if(Regex.IsMatch(armorType.Groups[1].ToString(), "Studded Armor", RegexOptions.IgnoreCase))
                    {
                        monsterEntry.Armor.Type = ArmorType.StuddedLeather.ToString();
                    }

                    else if(Regex.IsMatch(armorType.Groups[1].ToString(), "Leather", RegexOptions.IgnoreCase))
                    {
                        monsterEntry.Armor.Type = ArmorType.Leather.ToString();
                    }

                    else if(Regex.IsMatch(armorType.Groups[1].ToString(), "Hide", RegexOptions.IgnoreCase))
                    {
                        monsterEntry.Armor.Type = ArmorType.Hide.ToString();
                    }

                    else if(Regex.IsMatch(armorType.Groups[1].ToString(), "Chain Shirt", RegexOptions.IgnoreCase))
                    {
                        monsterEntry.Armor.Type = ArmorType.ChainShirt.ToString();
                    }

                    else if(Regex.IsMatch(armorType.Groups[1].ToString(), "Chain Mail", RegexOptions.IgnoreCase))
                    {
                        monsterEntry.Armor.Type = ArmorType.ChainMail.ToString();
                    }

                    else if(Regex.IsMatch(armorType.Groups[1].ToString(), "Plate", RegexOptions.IgnoreCase))
                    {
                        monsterEntry.Armor.Type = ArmorType.Plate.ToString();                        
                    }

                    else
                    {
                        monsterEntry.Armor.Type = ArmorType.Other.ToString();
                    }
                }

                catch
                {
                    monsterEntry.Armor.Type = ArmorType.Unspecified.ToString();
                }

                monsterEntries.Add(monsterEntry);
            }
        }

        static void ArmorData(List<ArmorTypeEntry> armorTypeEntries)
        {
            
            for(int i = 0; i < )
            {
                String[] info = armor[i].Split(",");


            }
            
            info = armor[0].Split(",");

            if(armorType == "Leather")
            {
                info = armor[0].Split(",");
            }

            else if(armorType == "StuddedLeather")
            {
                info = armor[1].Split(",");

            }

            else if(armorType == "Hide")
            {
                info = armor[2].Split(",");

            }

            else if(armorType == "ChainShirt")
            {
                info = armor[3].Split(",");

            }

            else if(armorType == "ScaleMail")
            {
                info = armor[4].Split(",");
            }

            else if(armorType == "ChainMail")
            {
                info = armor[5].Split(",");
            }

            else if(armorType == "Plate")
            {
                info = armor[6].Split(",");
            }

            monsterEntries[0].Armor.Type.


          
            monsterEntry.Armor.Type = ArmorType.StuddedLeather.ToString();
            monsterEntry.Armor.Type = ArmorType.Leather.ToString();
            monsterEntry.Armor.Type = ArmorType.Hide.ToString();
            monsterEntry.Armor.Type = ArmorType.ChainShirt.ToString();
            monsterEntry.Armor.Type = ArmorType.ChainMail.ToString();
            monsterEntry.Armor.Type = ArmorType.Plate.ToString();


              ArmorTypeEntry armorTypeEntry = armorTypeEntries[selectedMonsterEntry.Armor.Type];

            monsterEntries.Add(monsterEntry);

        }     
    }
}


/*
0 Winter Wolf
1 Large monstrosity, neutral evil
2 Hit Points: 75 (10d10+20) 
3 Armor Class: 13 (Natural Armor) 
4 Speed: 50 ft. 
5 Challenge Rating: 3 (700 XP)
*/