using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
//using var input = new StreamReader(Console.OpenStandardInput());
//using var output = new StreamWriter(Console.OpenStandardOutput());
//int testNumber = 9;
Stopwatch stopwatch = new Stopwatch();
for (int testNumber = 1; testNumber < 101; testNumber++)
{

    stopwatch.Start();
    using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
    using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{testNumber}.a");
    var tSet = int.Parse(input.ReadLine());
    //if (tSet < 1 || tSet > 1000) return;
    int nWindow;
    int mPatient;
    string[] line1 = null;
    string result = "";
    bool ResultX = false;
    int preValue = 0;
    int decValue = 0;
    for (int i = 0; i < tSet; i++)
    {
        line1 = input.ReadLine().Split();

        nWindow = int.Parse(line1[0]);
        mPatient = int.Parse(line1[1]);
        result = "".PadRight(mPatient, '0');
        var entries = input.ReadLine().Split()
                    .Select((x, i) =>
                                new Entry()
                                {
                                    Value = int.Parse(x),
                                    Index = i,
                                    Result = '0'
                                })
                    .OrderBy(o => o.Value)
                    .ToArray();
        ResultX = false;
        // int minValue = entries.Min(m => m.Value);
        //
        if (entries[0].Value > 1)
        {
            entries[0].Result = '-';
            entries[0].Value--;
        }
        for (int ind = 1; ind < entries.Count(); ind++)
        {
            preValue = entries[ind - 1].Value;
            decValue = entries[ind].Value - 1;
            if (decValue > preValue)
            {
                entries[ind].Value--;
                entries[ind].Result = '-';
                continue;
            }
            if (entries[ind].Value > preValue) continue;
            if (entries[ind].Value<nWindow && entries[ind].Value==preValue)
            {
                entries[ind].Value++;
                entries[ind].Result = '+';
                continue;
            }
            output.WriteLine("x");
            ResultX = true;
            break;
             
        }
        if (ResultX)
            continue;
        
        result = string.Join("", entries.OrderBy(x => x.Index).Select(x => x.Result));
        output.WriteLine(result);
    }

}  
class Entry
{
    public int Index;
    public int Value;
    public char Result;
}
    
 