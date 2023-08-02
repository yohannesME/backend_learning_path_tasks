// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Input the String:");
string input = Console.ReadLine();

// case insensetive
char[] words= input.ToLower().ToCharArray();

// remove non letters
int count = 0;
char[] newWord = new char[words.Length];
for (int i = 0; i < words.Length; i++)
{
    if (char.IsLetter(words[i]))
    {
        newWord[i] = char.ToUpper(words[i]);
        count++;
    }
}

bool ispalindrome = true;
int j = count-1;
for(int i = 0; i < count; i++){
    if(newWord[i] != newWord[j]){
        ispalindrome = false;
        Console.WriteLine(newWord);
        Console.WriteLine(i);
        Console.WriteLine(j);
        break;
    }
    j--;
}

if(ispalindrome){
    Console.WriteLine("palindrome");
}
else{
    Console.WriteLine("Not a Palindrome");
}