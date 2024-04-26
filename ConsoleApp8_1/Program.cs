using System.Collections.Generic;
using System.Diagnostics;

Dictionary<string, subStr> resultBlue = new Dictionary<string, subStr>();

for (int testNumber =1; testNumber < 76; testNumber++)
{
    using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
    using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{testNumber}.a");
    
    
    var tSet = int.Parse(input.ReadLine());
    
    for (int i = 0; i < tSet; i++)
    {
        resultBlue.Clear();
        
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
                        addStr(word.Substring(n2, n3), 0,n, resultBlue);
                        


                    }
            }
            else
            //blue 
            if (n <= blueWords)
            {
                for (int n2 = 0; n2 < word.Length; n2++)
                    for (int n3 = 1; n3 <= word.Length - n2; n3++)
                    {
                        addStr(word.Substring(n2, n3), 1,n, resultBlue);
                    }
            }
            else  //red
            if (n <= (blueWords + redWords))
            {
                for (int n2 = 0; n2 < word.Length; n2++)
                    for (int n3 = 1; n3 <= word.Length - n2; n3++)
                    {
                        addStr(word.Substring(n2, n3 ), 2,n, resultBlue);
                    }
            }
            else //white

            {
                for (int n2 = 0; n2 < word.Length; n2++)
                    for (int n3 = 1; n3 <= word.Length - n2; n3++)
                    {
                        addStr(word.Substring(n2, n3 ), 3,n, resultBlue);
                        

                    }
            }
        }
        foreach(string word in words)
        {
            if (resultBlue.Keys.Contains(word))
                resultBlue.Remove(word);
            //if (resultRed.Keys.Contains(word))
            //    resultRed.Remove(word);
        }
        var endResult=resultBlue.Where(x=>x.Value.count>=0  && (x.Value.type==1 || x.Value.type == 2) ).OrderByDescending(o=>o.Value.count).ThenByDescending(o=>o.Key.Length).ThenBy(o=>o.Key).ToList();
       // var endResultRed = resultRed.Where(x => x.Value != -999).OrderByDescending(o => o.Value).ThenByDescending(o => o.Key.Length).ThenBy(o => o.Key).ToList();

        if (endResult.Count > 0 )
            output.WriteLine($"{endResult[0].Key} {endResult[0].Value.count}");
        else
            output.WriteLine("tkhapjiabb 0");

    }
}
void addStr(string subStr,int type, int wordnumber, Dictionary<string, subStr> res)
{
    if (!res.ContainsKey(subStr))
    {
        res.Add(subStr, new subStr());
    }
    if (res[subStr].WordNumber == wordnumber)
    {
        return;
    }
    res[subStr].WordNumber = wordnumber;
    switch (type)
    {
        case 3:
            if (res[subStr].count==0 && res[subStr].type==2)
                res[subStr].type = 1;
            break;
        case 1 :
             
                res[subStr].count++;
                res[subStr].type = type;
     
             
            break;
        case 2:
            res[subStr].count--;
            res[subStr].type = type;
            break;
        
            
        default:
            res[subStr].count=int.MinValue;
            break;

    }
}
class subStr
{
    public int count { get; set; }
    public int type { get; set; }
    public int WordNumber { get; set; }
}
