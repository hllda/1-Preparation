using System;

namespace Mission_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string warriorName = "Nell";
            string mageName = "Joa";
            
                string dialogue = "The party stared down the stone stairs into darkness. \"We should've brought some torches with us\", remarked WARRIOR. MAGE turned around and replied, \"Worry not dear WARRIOR, let me shine some light for you\", as he cast a Continual light spell.";
       
                    dialogue = dialogue.Replace("MAGE", $"{mageName}");
                    dialogue = dialogue.Replace("WARRIOR", $"{warriorName}");

            Console.WriteLine($"{dialogue}");
        }
    }
}
