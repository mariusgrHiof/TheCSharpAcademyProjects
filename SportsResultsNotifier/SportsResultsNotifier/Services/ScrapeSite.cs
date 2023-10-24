using HtmlAgilityPack;

namespace SportsResultsNotifier.Services;
public class ScrapeSite
{

    public readonly string URL = "https://www.basketball-reference.com/boxscores/";

    HtmlWeb web = new HtmlWeb();



    public void GetData()
    {
        var htmlDoc = web.Load(URL);

        var table = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"content\"]/div[3]/div/table[1]");

        var team1 = table.SelectSingleNode("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[1]/a").InnerText;
        int team1Score = Int32.Parse(table.SelectSingleNode("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[2]").InnerText);

        var team2 = table.SelectSingleNode("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[2]/td[1]/a").InnerText;
        int team2Score = Int32.Parse(table.SelectSingleNode("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[2]/td[2]").InnerText);

        Console.WriteLine(team1);
        Console.WriteLine(team1Score);

        Console.WriteLine(team2);
        Console.WriteLine(team2Score);

        MailService mailService = new MailService();
        mailService.SendEmail();
    }

}

