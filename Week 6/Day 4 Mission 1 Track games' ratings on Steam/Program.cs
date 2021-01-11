using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Day_4_Mission_1_Track_games__ratings_on_Steam
{
    class Program
    {
        
        static void SteamReview(string link)
        {
            
            var httpClient = new HttpClient();
            string htmlCode = httpClient.GetStringAsync(link).Result;

            string reviewPattern = @"<span class=""game_review_summary \w+"" itemprop=""description"">(\w+ ?\w+)<\/span>";

            Match reviews = Regex.Match(htmlCode,reviewPattern);
            string review = reviews.Groups[1].ToString();

            string namePattern = @"<title>(.+) on Steam<\/title>";
            Match names = Regex.Match(htmlCode,namePattern);
            string gameName = names.Groups[1].ToString();

            if(review == "")
                Console.WriteLine($"The rating of the game {gameName} is not available.");

            else
            Console.WriteLine($"The rating of the game {gameName} is {review}.");

        }
        
        static void Main(string[] args)
        {
            SteamReview("https://store.steampowered.com/app/413150/Stardew_Valley/");

            SteamReview("https://store.steampowered.com/app/1424330/Wobbledogs/");

            SteamReview("https://store.steampowered.com/app/105600/Terraria/");

            SteamReview("https://store.steampowered.com/app/275850/No_Mans_Sky/");
        }
    }
}



/*
95 - 99% : Overhwelmingly Positive.
94 - 80% : Very Positive.
80 - 99% + few reviews: Positive.
70 - 79% : Mostly Positive.
40 - 69% : Mixed.
20? - 39% : Mostly Negative.
0 - 39% + rew reviews: Negative.
0 - 19% : Very Negative.
*/