// See https://aka.ms/new-console-template for more information
string inp = Console.ReadLine();

Dictionary<char, int> freqCounter(string input)
{

    // case insensetive
    char[] words = input.ToLower().ToCharArray();

    // remove non letters
    Dictionary<char, int> freqCount = new Dictionary<char, int>();
    for (int i = 0; i < words.Length; i++)
    {
        if (char.IsLetter(words[i]))
        {
            if (freqCount.ContainsKey(words[i]))
                freqCount[words[i]]++;
            else
            {
                freqCount.Add(words[i], 1);
            }
        }
    }
    return freqCount;
}

Dictionary<char, int> freqCount = freqCounter(inp);
// Each Input Count
Console.WriteLine("Word Count");
foreach (var item in freqCount)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}

