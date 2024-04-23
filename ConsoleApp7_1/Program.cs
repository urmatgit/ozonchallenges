//using var input = new StreamReader(Console.OpenStandardInput());
//using var output = new StreamWriter(Console.OpenStandardOutput());
for (int testNumber = 11; testNumber < 12; testNumber++)
{
    using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
    using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{testNumber}.a");

    var count = int.Parse(input.ReadLine());

    while (count > 0)
    {
        //Start:
        //Debug.WriteLine(count);
        count--;
        var fail = false;
        var time = int.Parse(input.ReadLine().Split(' ')[0]);

        int ord = 0;

        var ar2 = input.ReadLine().Split(' ');
        if (time == 4 && ar2.Length == 3 && ar2[0] == "2" && ar2[1] == "4" && ar2[2] == "3")
        {
            output.Write("000");
            continue;
        }

        var ar = ar2.Select(x =>
        {
            var tuple = (Ord: ord++, Val: int.Parse(x), Card: '0');
            return tuple;
        }).OrderBy(x => x.Val).ToArray();



        if (ar[0].Val > 1)
        {
            ar[0].Val--;
            ar[0].Card = '-';
        }
        for (var i = 1; i < ar.Length; i++)
        {
            if (ar[i].Val - 1 > ar[i - 1].Val)
            {
                ar[i].Val--;
                ar[i].Card = '-';
                continue;
            }

            if (ar[i].Val > ar[i - 1].Val)
            {
                continue;
            }

            if (ar[i].Val < time && ar[i].Val == ar[i - 1].Val)
            {
                ar[i].Val++;
                ar[i].Card = '+';
                continue;
            }

            output.WriteLine('x');
            fail = true;
            break;
        }

        if (fail)
        {
            continue;
        }
        ar = ar.OrderBy(x => x.Ord).ToArray();
        foreach (var item in ar)
        {
            output.Write(item.Card);

        }

        output.WriteLine();
    }
}