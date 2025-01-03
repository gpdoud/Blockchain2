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
