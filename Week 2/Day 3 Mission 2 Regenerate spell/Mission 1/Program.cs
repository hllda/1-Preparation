using System;

namespace Mission_1
{
    class Program
    {
        static void Main(string[] args)
        {

            var random = new Random();
            int randomInteger = random.Next(0, 101);
            int HP = randomInteger;
            

            string reg = "*Regenerate spell is cast*";
            string com = "*Regenerate spell is complete*";

            Console.WriteLine($"Warrior HP: {HP}\n");
           
            if (HP < 1)
            {
                Console.WriteLine("The warrior has perished.");
            }

            else
            {
                Console.WriteLine("Warrior: Healing needed!");

                if (HP < 50)
                {
                    
                    Console.Write("Mage: I'll cast a healing spell at once! \n");  
                    Console.Write($"\n{reg}\n\n");
                    while (HP < 50)
                    
                           {
                            HP += 10;
                            Console.WriteLine(HP);
                           }

                    Console.WriteLine($"\n{com}\n");       
                    Console.WriteLine("Warrior: Thank you.\n\n"!);
                    Console.WriteLine($"Warrior HP: {HP}");

                }

                else
                {
                    Console.WriteLine($"Mage: I'm not wasting my mana on papercuts!");
                }
            }

        }

    }
}