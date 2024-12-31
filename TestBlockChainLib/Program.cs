using BlockChainLib;

Console.WriteLine("BlockChainLib Test");

BlockChain _blockChain = new();

Block block = new Block {
    Data = "This should be the ninth block"
};
_blockChain.Add(block.BlockNbr, block);

_blockChain.Dispose();