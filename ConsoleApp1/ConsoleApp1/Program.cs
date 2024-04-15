using System;
using System.Collections.Generic;
using System.Linq;

class Player
{
    public string Name { get; set; }
    public List<int> Scores { get; set; }

    public Player(string name, List<int> scores)
    {
        Name = name;
        Scores = scores;
    }

    public int TotalScore()
    {
        return Scores.Sum();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Введення списку гравців та їх балів
        List<Player> players = new List<Player>();
        Console.WriteLine("Введіть інформацію про гравців:");
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Гравець {i + 1}: ");
            string name = Console.ReadLine();
            Console.Write("Бали за 3 останні гри (через пробіл): ");
            List<int> scores = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            players.Add(new Player(name, scores));
        }

        // Відібрати топ 3 гравців за сумою балів
        var topPlayers = players.OrderByDescending(player => player.TotalScore()).Take(3);

        // Виведення результатів
        Console.WriteLine("\nТоп 3 гравці за сумою балів:");
        foreach (var player in topPlayers)
        {
            Console.WriteLine($"{player.Name} - {player.TotalScore()} балів");
        }
    }
}
