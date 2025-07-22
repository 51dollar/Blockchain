namespace Blockchain;

public class Chain
{
    public List<Block> Blocks { get; private set; }
    public Block LastBlock { get; private set; }

    public Chain()
    {
        Blocks = new List<Block>();
        var genesisBlock = new Block();
        
        Blocks.Add(genesisBlock);
        LastBlock = genesisBlock;
    }

    public void Add(string data, string user)
    {
        var block = new Block(data, user, LastBlock);
        Blocks.Add(block);
        LastBlock = block;
    }
}