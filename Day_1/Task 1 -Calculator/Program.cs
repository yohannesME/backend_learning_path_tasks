// See https://aka.ms/new-console-template for more information

Console.WriteLine("Please Input Your Name:");
string name = Console.ReadLine();


//Input the number of grades and handle invalid inputs
int number = 0;
bool isValidNumber = false;

while (!isValidNumber)
{
    Console.WriteLine("please input the number of subjects:");
    isValidNumber = int.TryParse(Console.ReadLine(), out number);

    if (isValidNumber)
    {
        Console.WriteLine($"Your name is {name} and your number of subjects is {number}");
    }
    else
        Console.WriteLine("Invalid Input");
}

//Input the Subject and Grades using a dictionary

Dictionary<string, float> subjects = new Dictionary<string, float>();

for (int i = 0; i < number; i++)
{
    Console.WriteLine("Input subject and the grade space separated: ");
    string[] input = Console.ReadLine().Split(' ');

    //add to the dictionary the subject and the grade
    try
    {
        float grade = float.Parse(input[1]);
        subjects.Add(input[0], grade);

        if (grade < 0 || grade > 100)
        {
            throw new FormatException();
        }

    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid Input");
    }
}

float avg = 0;
foreach (var subject in subjects)
{
    avg += subject.Value;
    Console.WriteLine($"{subject.Key} - {subject.Value}");
}

Console.WriteLine($"The average is {avg / number}");