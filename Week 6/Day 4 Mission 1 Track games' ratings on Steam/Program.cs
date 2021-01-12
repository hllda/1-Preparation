using System;
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

            string namePattern = @"<title>(.+) on Steam<\/title>";
            Match names = Regex.Match(htmlCode,namePattern);
            string gameName = names.Groups[1].ToString().ToUpper();

            string allReviewPattern = @"<span class=""game_review_summary \w+"" itemprop=""description"">(\w+ ?\w+)<\/span>";
            Match allReviews = Regex.Match(htmlCode,allReviewPattern);
            string allReview = allReviews.Groups[1].ToString();

            string recentReviewPattern = @"<span class=""game_review_summary \w+"">(\w+ ?\w+)<\/span>";
            Match recentReviews = Regex.Match(htmlCode,recentReviewPattern);
            string recentReview = recentReviews.Groups[1].ToString();

            Console.WriteLine(gameName);

            if(allReview == "")
                Console.WriteLine($"There are no reviews available.");

            else if(allReview == recentReview)
            {
                Console.WriteLine($"All reviews: {allReview}.");
            }

            else
            {
                Console.WriteLine($"Recent reviews: {recentReview}.");
                Console.WriteLine($"All reviews: {allReview}.");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            SteamReview("https://store.steampowered.com/app/413150/Stardew_Valley/");

            SteamReview("https://store.steampowered.com/app/1424330/Wobbledogs/");

            SteamReview("https://store.steampowered.com/app/105600/Terraria/");

            SteamReview("https://store.steampowered.com/app/275850/No_Mans_Sky/");

            SteamReview("https://store.steampowered.com/app/945360/Among_Us/");

            SteamReview("https://store.steampowered.com/app/488790/South_Park_The_Fractured_But_Whole/");
        }
    }
}