using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());
var tSet = int.Parse(input.ReadLine());
int fX = 0;
int fY = 0;
int pXY = 0;
int cXYXZ = 0;

for (int i = 0; i < tSet; i++)
{
     fX = 0;
     fY = 0;
     pXY = 0;
     cXYXZ = 0;

    int xyxzyzCount = int.Parse(input.ReadLine());

    string xyxzyz = input.ReadLine();


    if (xyxzyz.First() == 'Z' || xyxzyz.Last() == 'X')
    {
        output.WriteLine("No");
        continue;
    }
     


    var result = checkAllText(xyxzyz);
    output.WriteLine(result ? "Yes" : "No");
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