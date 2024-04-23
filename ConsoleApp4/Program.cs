


//using var input = new StreamReader(Console.OpenStandardInput());
using var input = new StreamReader(@"C:\Temp\Inputes\13");
//using var output = new StreamWriter(Console.OpenStandardOutput());
using var output = new StreamWriter(@"C:\Temp\Inputes\13r");

var tSet = int.Parse(input.ReadLine());
//if (tSet < 1 || tSet > 1000) return;

for (int i = 0; i < tSet; i++)
{
    int nSportsMen=int.Parse(input.ReadLine());
    //if (nSportsMen < 1 || nSportsMen > 200000) continue;
    var times=input.ReadLine().Split().Select(x=>int.Parse(x)).ToList();
    //if (times.Count() != nSportsMen) continue;
    
    int[] result = new int[nSportsMen];
    var orderedTimes = times.Order().ToList();
    int Place = 1;
    int oIndex = 0;
    //int OrderTimesCount = nSportsMen;
    int PlaceCount = 1;
    while (nSportsMen > oIndex)
    {
        var find= times.IndexOf(orderedTimes[oIndex]);
        times[find] = -1;
        result[find] = Place;
        if ((oIndex + 1 < nSportsMen && orderedTimes[oIndex] != orderedTimes[oIndex + 1]) && orderedTimes[oIndex] + 1 != orderedTimes[oIndex + 1])
        {
            Place += PlaceCount;
            PlaceCount = 1;
        }
        else
            ++PlaceCount;
        oIndex++;
    }
    output.WriteLine();
    for(int j  = 0; j < result.Length; j++)
    {
        output.Write($"{result[j]} ");
    }
    
}

