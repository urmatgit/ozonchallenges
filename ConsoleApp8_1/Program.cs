using System.Collections.Generic;
Dictionary<string, int> resultBlue = new Dictionary<string, int>();
Dictionary<string, int> resultRed = new Dictionary<string, int>();
for (int testNumber = 1; testNumber < 12; testNumber++)
{
    using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
    using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{testNumber}.a");
    
    
    var tSet = int.Parse(input.ReadLine());
    
    for (int i = 0; i < tSet; i++)
    {
        resultBlue.Clear();
        resultRed.Clear();
        var line1 = input.ReadLine().Split();
        var nAllWords = int.Parse(line1[0]);
        var blueWords = int.Parse(line1[1]);
        var redWords= int.Parse(line1[2]);
        var blackWord= int.Parse(line1[3]);
        var words=new List<string>();
        for (int n = 1; n <= nAllWords; n++)
        {
            string word= input.ReadLine();
            words.Add(word);


            // if (n2==0 && n3 == word.Length) continue;
            //black
            if (n == blackWord)
            {
                for (int n2 = 0; n2 < word.Length; n2++)
                    for (int n3 = 1; n3 <=word.Length-n2; n3++)
                    {
                        addStr(word.Substring(n2, n3), 0, resultBlue);
                        addStr(word.Substring(n2, n3), 0, resultRed);


                    }
            }
            else
            //blue 
            if (n <= blueWords)
            {
                for (int n2 = 0; n2 < word.Length; n2++)
                    for (int n3 = 1; n3 <= word.Length - n2; n3++)
                    {
                        addStr(word.Substring(n2, n3), 1, resultBlue);
                    }
            }
            else  //red
            if (n <= (blueWords + redWords))
            {
                for (int n2 = 0; n2 < word.Length; n2++)
                    for (int n3 = 1; n3 <= word.Length - n2; n3++)
                    {
                        addStr(word.Substring(n2, n3 ), 2, resultRed);
                    }
            }
            else //white

            {
                for (int n2 = 0; n2 < word.Length; n2++)
                    for (int n3 = 1; n3 <= word.Length - n2; n3++)
                    {
                        addStr(word.Substring(n2, n3 ), 3, resultBlue);
                        addStr(word.Substring(n2, n3 ), 3, resultRed);

                    }
            }
        }
        foreach(string word in words)
        {
            if (resultBlue.Keys.Contains(word))
                resultBlue.Remove(word);
            if (resultRed.Keys.Contains(word))
                resultRed.Remove(word);
        }
        var endResult=resultBlue.Where(x=>x.Value!= -999).OrderByDescending(o=>o.Value).ThenByDescending(o=>o.Key.Length).ThenBy(o=>o.Key).ToList();
        var endResultRed = resultRed.Where(x => x.Value != -999).OrderByDescending(o => o.Value).ThenByDescending(o => o.Key.Length).ThenBy(o => o.Key).ToList();

        if (endResult.Count > 0)
            output.WriteLine($"{endResult[0].Key} {endResult[0].Value}");
        else
            output.WriteLine("tkhapjiabb 0");

    }
}
void addStr(string subStr,int type, Dictionary<string,int> res)
{
    if (!res.ContainsKey(subStr))
    {
        res.Add(subStr, 0);
    }
    switch(type)
    {
        case 1:
            res[subStr]++;break;
        case 2:
            res[subStr]--; break;
        default:
            res[subStr]=-999; break;

    }
}