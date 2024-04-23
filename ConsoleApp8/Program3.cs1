
using System.Text;

//using var input = new StreamReader(Console.OpenStandardInput());
using var input = new StreamReader(@"C:\Temp\Inputes\28.txt");
using var output = new StreamWriter(Console.OpenStandardOutput());
var s = input.ReadLine().Split();

int UserCount = int.Parse(s[0]);
int QueryCount = int.Parse(s[1]);
if (UserCount < 1 || QueryCount < 1 || UserCount > 300000 || QueryCount > 300000) return;

int typeQuery = 0;
int idUser = 0;
int indexQuery = 0;
Dictionary<int, int> QueryExists = new Dictionary<int, int>();
StringBuilder results = new StringBuilder();
for (int i = 0; i < QueryCount; i++)
{
    var query = input.ReadLine().Split();
    typeQuery = int.Parse(query[0]);
    idUser = int.Parse(query[1]);
    if (typeQuery < 1 || typeQuery > 2) continue;
    if (typeQuery == 1)
    {
        if (idUser < 0 || idUser > UserCount)
            continue;
    }
    else if (idUser < 1 || idUser > UserCount)
        continue;
    if (typeQuery == 2)
    {
        if (!QueryExists.ContainsKey(idUser))
        {

            results.AppendLine($"{(QueryExists.ContainsKey(0) ? QueryExists[0] : 0)}");
        }else
        {
            results.AppendLine($"{QueryExists[idUser]}");
        }
    }else
    {
        ++indexQuery;
        if (!QueryExists.ContainsKey(idUser))
             QueryExists.Add(idUser,indexQuery);
        else
            QueryExists[idUser] = indexQuery;

        if (idUser == 0)
        {
            foreach (var item in QueryExists.Keys)
            {
                QueryExists[item] = indexQuery;
            }
        }
        
        
    }
        
}
output.WriteLine(results.ToString());