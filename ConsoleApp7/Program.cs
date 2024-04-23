using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
//using var input = new StreamReader(Console.OpenStandardInput());
//using var output = new StreamWriter(Console.OpenStandardOutput());
int testNumber = 90;
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
using var output = new StreamWriter($"{"C:\\Temp\\Inputes\\"}{testNumber}r");
var tSet = int.Parse(input.ReadLine());
//if (tSet < 1 || tSet > 1000) return;
int nWindow;
int mPatient;
string[] line1 = null;
string result = "";
bool ResultX = false;
bool EndCheck = false;
int preValue = 0;
int decValue = 0;
for (int i = 0; i < tSet; i++)
{
    line1 = input.ReadLine().Split();

    nWindow = int.Parse(line1[0]);
    mPatient = int.Parse(line1[1]);
    //result = "".PadRight(mPatient, '0');
    var entries = input.ReadLine().Split()
                .Select((x, i) =>
                            new Entry()
                            {
                                Value = int.Parse(x),
                                
                                Index = i,
                                Result = '0'
                            })
                .OrderBy(o => o.Value)
                .ToList();
    ResultX = false;
    // int minValue = entries.Min(m => m.Value);
    //
    //if (entries[0].Value > 1)
    //{
    //    entries[0].Result = '-';
    //    entries[0].Value = entries[0].Value - 1;
    //}

    int preKey = 0;
    EndCheck = false;
    var groupValue = entries.GroupBy(o => o.Value)
                   .ToDictionary(y => y.Key, y => y.ToArray())
                   .Where(x=>x.Value.Count()>1);
    EndCheck = groupValue == null;
    ResultX = !EndCheck && groupValue.Any(x => x.Value.Count() > 3);
    
    if (EndCheck && entries.Min(x => x.Value>1)){

        result = "".PadRight(entries.Count(), '-');
        output.WriteLine(result);
        continue;
    }
    while (!ResultX && !EndCheck)
    {
        
         
            foreach (var item in groupValue.Where(x => x.Value.Count() > 1))
            {

                decValue = item.Value[0].Value - 1;
                if (decValue > 1 && (decValue != preKey))
                {
                    item.Value[0].OldValue = item.Value[0].Value;
                    item.Value[0].Value = decValue;
                    item.Value[0].Result = '-';
                }
                else
                {

                    item.Value[1].OldValue = item.Value[1].Value;
                    item.Value[1].Value = item.Value[1].Value + 1;
                    item.Value[1].Result = '+';
                }
                preKey = item.Key;
            }
        groupValue = entries.GroupBy(o => o.Value)
               .ToDictionary(y => y.Key, y => y.ToArray())
               .Where(x => x.Value.Count() > 1);
        EndCheck = groupValue == null;
        ResultX = !EndCheck && groupValue.Any(x => x.Value.Count() > 3);
        

    }
        //for (int ind = 1; ind < entries.Count(); ind++)
    //{
    //    preValue = entries[ind - 1].Value;
    //    decValue = entries[ind].Value - 1;
    //    if (preValue != entries[ind].Value && preValue != decValue)
    //    {
    //        //result = ReplaceByIndex(result, entries[ind].Index, "-");
    //        entries[ind].Result = '-';


    //        if (decValue <= 0 || entries.Any(x => x.Value == decValue))
    //        {
    //            ResultX = true;
    //            break;
    //        }

    //        entries[ind].Value = decValue;


    //    }
    //    else

    //    if (preValue == entries[ind].Value)
    //    {
    //        //result = ReplaceByIndex(result, entries[ind].Index, "+");
    //        entries[ind].Result = '+';
    //        int incValue = entries[ind].Value + 1;
    //        if (incValue > nWindow)
    //        {
    //            ResultX = true;
    //            break;
    //        }
    //        entries[ind].Value = incValue;
    //       // continue;
    //    }
    //    //else
    //    //    if (entries[ind].Value > preValue)
    //    //{
    //    //    // entries[ind].Result = '0';
    //    //    //result = ReplaceByIndex(result, entries[ind].Index, "0");
    //    //    continue;
    //    //}
    //    //ResultX = true;
    //}
    if (ResultX)
        result = "x";
    else
    {
        result = string.Join("", entries.OrderBy(x => x.Index).Select(x => x.Result));
    }
    output.WriteLine(result);
    
}
stopwatch.Stop();
output.WriteLine( $"time {TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).TotalMilliseconds}");
string ReplaceByIndex(string result, int index, string ch)
{
    return result.Remove(index, 1).Insert(index, ch);
}
class Entry
{
    public int Index;
    public int Value;
    public int OldValue;
    public char Result;
}
