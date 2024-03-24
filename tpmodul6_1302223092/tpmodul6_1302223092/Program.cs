using System;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        this.id = GenerateRandomId();
        this.title = title.Length > 100 ? title.Substring(0, 100) : title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10_000_000)
        {
            throw new ArgumentException("Jumlah penambahan play count harus antara 0 dan 10.000.000");
        }

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID Video: {id}");
        Console.WriteLine($"Judul Video: {title}");
        Console.WriteLine($"Jumlah Play: {playCount}");
    }

    private int GenerateRandomId()
    {
        Random random = new Random();
        return random.Next(10000, 99999);
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - [Daffa_Fathoni]");
        try
        {
            SayaTubeVideo videoWithLongTitle = new SayaTubeVideo("The Industrial Revolution and its consequences has been a disaster for human race. They have greatly increased the life-expentancy of those of us who...");
            videoWithLongTitle.PrintVideoDetails(); // Cetak detail video

            video.IncreasePlayCount(10_000_001);
            video.IncreasePlayCount(-100);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
