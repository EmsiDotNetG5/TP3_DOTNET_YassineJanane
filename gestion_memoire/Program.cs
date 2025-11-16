using System;
using System.IO;

class Logger : IDisposable
{
    private StreamWriter writer;

    public Logger(string path)
    {
        writer = new StreamWriter(path, true);
    }

    public void Ecrire(string message)
    {
        writer.WriteLine(DateTime.Now + " : " + message);
    }

    public void Dispose()
    {
        writer?.Close();
        Console.WriteLine("fichier journal fermé");
    }
}

class Program
{
    static void Main(string[] args)
    {

        using (StreamWriter sw = new StreamWriter("etudiants.txt"))
        {
            sw.WriteLine("Bonjour EMSI !");
            sw.WriteLine("Ce fichier est cree avec StreamWriter");
        }
        Console.WriteLine("Fichier créé et fermé automatiquement");

        using (StreamReader sr = new StreamReader("etudiants.txt"))
        {
            Console.WriteLine("Contenu du fichier :");
            Console.WriteLine(sr.ReadToEnd());
        }

        using (StreamReader sr = new StreamReader("etudiants.txt"))
        using (StreamWriter sw = new StreamWriter("copie.txt"))
        {
            string ligne;
            while ((ligne = sr.ReadLine()) != null)
            {
                sw.WriteLine(ligne);
            }
        }
        Console.WriteLine("Copie terminée !");

        using (var log = new Logger("journal.txt"))
        {
            log.Ecrire("démarrage du programme");
            log.Ecrire("fin du programme");
        }
    }
}