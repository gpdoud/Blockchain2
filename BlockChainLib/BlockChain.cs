namespace BlockChainLib;

public class BlockChain : IDisposable
{
    public static string About = "BlockChainLib v1.0";

    private Chain _chain = new();

    public void Add(int key, Block block)
    {
        _chain.Add(key, block);
    }

    public Block LastBlock()
    {
        if (_chain.BlockCount() == 0)
        {
            return new Block();
        }
        return _chain.LastBlock(); ;
    }

    public BlockChain()
    {
        Console.WriteLine("ReadChain()");
        _chain.ReadChain();
        _chain.VerifyChain();
    }

    public void Print(int startBlockNbr = 1, int endBlockNbr = int.MaxValue)
    {
        Console.WriteLine($"Print blocks from {startBlockNbr} to {(endBlockNbr != int.MaxValue ? endBlockNbr.ToString() : "end")}");
        foreach (var block in _chain.GetAll())
        {
            if(block.BlockNbr > endBlockNbr) return;
            if (block.BlockNbr >= startBlockNbr)
            {
                Console.WriteLine($"Block: {block.BlockNbr}");
                Console.WriteLine($"Data: ");
                string[] lines = block.Data.Split("\n");
                foreach(string line in lines) 
                {
                    Console.WriteLine($"       {line}");
                }
                Console.WriteLine($"-------------");
            }
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~BlockChain()
    {
        Dispose(false);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            Console.WriteLine("WriteChain()");
            _chain.WriteChain();
        }
    }

}
