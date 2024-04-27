

using System.Text.RegularExpressions;

for (int testNumber = 1; testNumber < 76; testNumber++)
{
    using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
    using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{testNumber}.a");


    var tSet = int.Parse(input.ReadLine());
    Regex reg = new Regex(@"^(M(RCM|CM)*D)+$", RegexOptions.Compiled);
    for (int i = 0; i < tSet; i++)
    {
        int  xyxzyzCount =int.Parse(input.ReadLine());
        string xyxzyz = input.ReadLine();
        var result= reg.IsMatch(xyxzyz) ? "YES" : "NO";
        output.WriteLine(result);

        
    }

}