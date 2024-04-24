using System.Collections.Generic;

for (int testNumber = 11; testNumber < 12; testNumber++)
{
    using var input = new StreamReader($"{"C:\\Temp\\Inputes\\"}{testNumber}");
    using var output = new StreamWriter($"{"C:\\Temp\\results\\"}{testNumber}.a");

    var tSet = int.Parse(input.ReadLine());
    for (int i = 0; i < tSet; i++)
    {
        var line1 = input.ReadLine().Split();
        var nAllWords = int.Parse(line1[0]);
        var blueWords = int.Parse(line1[1]);
        var redWords= int.Parse(line1[2]);
        var blackWord= int.Parse(line1[3]);
        for (int n = 0; n < nAllWords; n++)
        {
            string word= input.ReadLine();
            //black
            if (n == blueWords)
            {

                continue;
            }
            //blue 
            if (n < blueWords)
            {

                
            }else  //red
            if (n<blueWords+redWords) {
                
            }else //white
             
            {

            }
            

        }
    }
}