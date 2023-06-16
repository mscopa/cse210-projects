using System;
using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            };
        }
    }
    public void LoadToFile(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] splitLines = line.Split("|");
            Entry entry = new Entry();
            entry._date = splitLines[0];
            entry._promptText = splitLines[1];
            entry._entryText = splitLines[2];
            AddEntry(entry);
            splitLines.ToList().Clear();
        }
    }
}