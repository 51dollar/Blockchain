using System.Security.Cryptography;
using System.Text;

namespace Blockchain;

public class Block
{
    public int Id { get; private set;}
    public string Data { get; private set; }
    public DateTime Created { get; private set; }
    public string Hash { get; private set; }
    public string PreviousHash { get; private set; }
    public string User { get; set; }

    public Block()
    {
        Id = 1;
        Data = "Hello World";
        Created = DateTime.Parse("20.07.2025 00:00:00");
        PreviousHash = "111111";
        User = "Admin";

        var blockData = GetData();
        Hash = GetHash(blockData);
    }

    public Block(string data, string user, Block block)
    {
        if (string.IsNullOrWhiteSpace(data))
            throw new ArgumentNullException($"Empty argument date", nameof(data));
        if (block == null)
            throw new ArgumentNullException($"Empty argument date", nameof(block));
        if (string.IsNullOrWhiteSpace(user))
            throw new ArgumentNullException($"Empty argument date", nameof(user));
        
        Id = block.Id + 1;
        Data = data;
        Created = DateTime.UtcNow;
        PreviousHash = block.Hash;
        User = user;
        
        var blockData = GetData();
        Hash = GetHash(blockData);
    }

    private string GetData()
    {
        string result = "";

        result += Id.ToString();
        result += Data;
        result += Created.ToString("dd.MM.yyyy HH:mm:ss");
        result += PreviousHash;
        result += User;
        
        return result;
    }

    private string GetHash(string data)
    {
        var message = Encoding.ASCII.GetBytes(data);
        var hashString = new SHA256Managed();
        string hex = "";
        
        var hashValue = hashString.ComputeHash(message);
        foreach (byte b in hashValue)
        {
            hex += String.Format("{0:x2}", b);
        }
        return hex;
    }

    public override string ToString()
    {
        return Data;
    }
}