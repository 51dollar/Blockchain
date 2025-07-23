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
        Save(block);
    }

    public bool Check()
    {
        var genesisBlock = new Block();
        var previousHash = genesisBlock.Hash;

        foreach (var block in Blocks.Skip(1))
        {
            var hash = block.PreviousHash;

            if (previousHash != hash) 
            {
                return false;
            }

            previousHash = block.Hash;
        } 
        return true;
    }

    private void Save(Block block)
    {
        using (var context = new BlockchainContext())
        {
            context.Blocks.Add(block);
            context.SaveChanges();
        }
    }
}