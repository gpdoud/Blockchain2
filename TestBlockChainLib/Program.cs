using BlockChainLib;

Console.WriteLine("BlockChainLib Test");

BlockChain _blockChain = new();

for(var i = 1; i <= 5; i++) {

    Block lastBlock = _blockChain.LastBlock();

    Block block = new Block {
        BlockNbr = lastBlock.BlockNbr + 1,
        Nonce = 0,
        Data = $"{i}",
        PrevHash = lastBlock.CurrHash
    };

    block.CurrHash = CypherCode.Encrypt(block.ToStringData());
    while(!block.CurrHash.StartsWith("0000")) {
        block.Nonce++;
        block.CurrHash = CypherCode.Encrypt(block.ToStringData());
    }
    _blockChain.Add(block.BlockNbr, block);

}

_blockChain.Dispose();