//using var input = new StreamReader(Console.OpenStandardInput());
using System.Text;

using var input = new StreamReader(@"C:\Temp\Inputes\53");
//using var output = new StreamWriter(Console.OpenStandardOutput());
using var output = new StreamWriter(@"C:\Temp\Inputes\53r");

var line1 = input.ReadLine().Split();

int nFriendCount = int.Parse(line1[0]);
int mCardCount = int.Parse(line1[1]);

var Cards=input.ReadLine().Split().Select(x=>int.Parse(x)).ToList();

var FrientdCards = Enumerable.Range(1, mCardCount).Select(x => new cardOjb() { Index = x }).ToArray() ;

var max = Cards.Max();
if (!FrientdCards.Any(x => x.Index > max) )
{
    output.WriteLine("-1");
    return;
}
//var result =new  int[nFriendCount];
bool Finded = false;
StringBuilder result=new StringBuilder();
int lasFindIndex = 0;
for (int i = 0; i < nFriendCount; i++)
{
    Finded = false;
    lasFindIndex = FrientdCards[Cards[i]].LinkToNextIndex==0?  Cards[i] : FrientdCards[Cards[i]].LinkToNextIndex;

    for (int j = lasFindIndex;j< mCardCount; j++)
    {
        if (FrientdCards[j].Index != 0 )
        {
            //result[i] = FrientdCards[j];
            result.Append($"{FrientdCards[j].Index} ");
            FrientdCards[j].Index = 0;
            FrientdCards[Cards[i]].LinkToNextIndex=j+1;

            Finded = true;
            break;
        }
    }
    if (!Finded)
    {
        output.WriteLine("-1");
        return;
    }

}
//for (int j = 0; j < result.Length; j++)
//{
    output.Write(result.ToString());
//}


class cardOjb
{
    public int Index { get; set; }
    public int LinkToNextIndex { get; set; }
}