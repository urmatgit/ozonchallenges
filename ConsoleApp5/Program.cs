//using var input = new StreamReader(Console.OpenStandardInput());
using System.Text;
using System.Text.Json;


using var input = new StreamReader(@"C:\Temp\Inputes\23");
//using var output = new StreamWriter(Console.OpenStandardOutput());
using var output = new StreamWriter(@"C:\Temp\Inputes\23r");

var tSet = int.Parse(input.ReadLine());
//if (tSet < 1 || tSet > 1000) return;
int LineCount = 0;
StringBuilder stringBuilder = new StringBuilder();
for (int i = 0; i < tSet; i++)
{
     LineCount=int.Parse(input.ReadLine());
    stringBuilder.Clear();
    for(int line = 0; line < LineCount; line++)
    {
        stringBuilder.Append(input.ReadLine());
        
    }
    output.WriteLine(infectedCount(GetObject(stringBuilder.ToString()), false));
}
int infectedCount(Folders folder,bool infected)
{
    int count = 0;
    infected = infected || folder.files != null && folder.files.Any(f => f.EndsWith(".hack"));
    if (folder.folders != null)
    {
        foreach(Folders fld in folder.folders)
        {
            count += infectedCount(fld,infected);
        }
        
    }
    if (infected  && folder.files != null )
         return count+ folder.files.Length; 
    else 
        return count;

}
Folders GetObject(string str)
{
    return JsonSerializer.Deserialize<Folders>(str, new JsonSerializerOptions() { MaxDepth = int.MaxValue });
    
}
class Folders
{
    public string dir { get; set; }
    public string[] files { get; set; }
    public Folders[] folders { get; set; }
}