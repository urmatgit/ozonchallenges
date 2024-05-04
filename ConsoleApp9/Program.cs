

using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
int fX = 0;
int fY = 0;
int pXY = 0;
int cXYXZ = 0;
for (int testNumber = 1; testNumber < 28; testNumber++)
{
    using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
    using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{testNumber}.a");


    var tSet = int.Parse(input.ReadLine());
    

    for (int i = 0; i < tSet; i++)
    {
         fX = 0;
         fY = 0;
         pXY = 0;
         cXYXZ = 0;

        int xyxzyzCount =int.Parse(input.ReadLine());
        
        string xyxzyz = input.ReadLine();
        //int xMax = xyxzyz.LastIndexOf('X');
        //int yMax= xyxzyz.LastIndexOf('Y');
        //int zMax= xyxzyz.LastIndexOf('Z');
        
        if (xyxzyz.First() =='Z' || xyxzyz.Last()=='X')
        {
            output.WriteLine("No");
            continue;
        }
        //var grouping=xyxzyz.GroupBy(x=>x).Select((g,l)=>new {let=g.Key,count=g.Count()}).OrderBy(o=>o.let);
        //output.WriteLine();
        //foreach (var group in grouping)
        //    output.Write($"{group.let}:{group.count} " );
        //output.Write($" {xyxzyz}");


        var result = checkAllText(xyxzyz);
        output.WriteLine(result? "Yes":"No");
        
    }

}
bool checkAllText(string xyxzyz)
{
    foreach (char ch in xyxzyz)
    {
        switch (ch)
        {
            case 'X':
                CheckX();
                break;
            case 'Y':
                CheckY();
                break;
            case 'Z':
                if (!CheckZ())
                {
                    //output.WriteLine("No");
                    return false;
                }
                break;
        }
    }
    return (fX == 0 && fY == 0);
}
bool CheckZ()
{
    //if (fX == 0 && fY == 0) return false;
    if (fY > 0)
    {
        fY--;
    }
    else
    if (pXY > 0 && fX > 0)
    {
        cXYXZ++;
        pXY--;
        fX--;
    }
    else
   
    if (pXY > 0)
    {
        fX++;
        pXY--;
    }
    else if (fX > 0)
    {
        fX--;
    }
    else if (cXYXZ > 0)
    {
        cXYXZ--;
        fX++;
    }
    else
        return false;
    return true;
}

void CheckY()
{
    if (fX > 0)
    {
        fX--;
        pXY++;

    }
    else if (cXYXZ > 0)
    {
        cXYXZ--;
        fX++;
        pXY++;
    }
    else
        fY++;
}

void CheckX()
{
    fX++;
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