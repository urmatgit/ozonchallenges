

using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

for (int testNumber = 1; testNumber < 27; testNumber++)
{
    using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
    using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{testNumber}.a");


    var tSet = int.Parse(input.ReadLine());
    
    for (int i = 0; i < tSet; i++)
    {
        int  xyxzyzCount =int.Parse(input.ReadLine());
        
        string xyxzyz = input.ReadLine();
        int xMax = xyxzyz.LastIndexOf('X');
        int yMax= xyxzyz.LastIndexOf('Y');
        int zMax= xyxzyz.LastIndexOf('Z');
        
        if (xyxzyz.First() =='Z' || xyxzyz.Last()=='X')
        {
            output.WriteLine("No");
            continue;
        }
        var grouping=xyxzyz.GroupBy(x=>x).Select((g,l)=>new {let=g.Key,count=g.Count()}).OrderBy(o=>o.let);
        output.WriteLine();
        foreach (var group in grouping)
            output.Write($"{group.let}:{group.count} " );
        output.Write($" {xyxzyz}");
        
    }

}
(string,bool) CheckString(string xyxzyz)
{
    int xMax = GetIndex0(xyxzyz.LastIndexOf('X'));
    int yMax = GetIndex0(xyxzyz.LastIndexOf('Y'));
    int zMax = GetIndex0(xyxzyz.LastIndexOf('Z'));
    int xMin = GetIndex0(xyxzyz.IndexOf('X'));
    int yMin = GetIndex0(xyxzyz.IndexOf('Y'));
    int zMin = GetIndex0(xyxzyz.IndexOf('Z'));
    if (xMax<yMax || xMax < zMax || xMin<zMin || yMin<zMin)
    {

    }
    return (xyxzyz, false);
}
int GetIndex0(int index) => index + 1;