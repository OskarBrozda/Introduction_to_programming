string pangram = "The quick brown fox jumps over the lazy dog";
string[] words = pangram.Split(' ');
string[] result = new string[words.Length];

for (int i = 0; i < words.Length; i++)
{
    char[] items = words[i].ToCharArray();
    Array.Reverse(items);
    result[i] = new string(items);
}

string print = String.Join(" ", result);
Console.WriteLine(print);

