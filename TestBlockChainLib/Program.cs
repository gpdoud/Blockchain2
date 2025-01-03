using BlockChainLib;

Console.WriteLine("BlockChainLib Test");

BlockChain _blockChain = new();

/*
Block _block = new();
_block.AddDataLine($"This should be the eleventh block");
_block.AddDataLine($"Deposit | 1000.00 | 2025-01-03 | GPD");
_block.AddDataLine($"Transfer | 100.00 | 2025-01-03 | GPD | CJD");
_block.AddDataLine($"Withdraw | 50.00 | 2025-01-03 | GPD");
_blockChain.Add(_block.BlockNbr, _block);
*/

_blockChain.Print(startBlockNbr: 10);

_blockChain.Dispose();