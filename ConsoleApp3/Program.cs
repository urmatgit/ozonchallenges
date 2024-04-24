
using var output = new StreamWriter(Console.OpenStandardOutput());
output.WriteLine(tribonacci(25));
int tribonacci(int n)
{
    if (n == 0) return 0;
    if (n ==1 || n==2) return 1;
    return tribonacci(n-1)+ tribonacci(n - 2)+ tribonacci(n - 3);
}

//using static System.Net.Mime.MediaTypeNames;
//using System.Text.RegularExpressions;

//using System.Text.RegularExpressions;

//using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{1}");
//using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{1}.a");

//int testsCount = Convert.ToInt32(Console.ReadLine());
//Regex reg = new Regex(@"^(M(RCM|CM)*D)+$", RegexOptions.Compiled);




//for (int i = 0; i < testsCount; i++)
//{
//    string strinput = Console.ReadLine();
//    Console.WriteLine(reg.IsMatch(strinput) ? "YES" : "NO");
//}