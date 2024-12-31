using System;
using System.Text;
using System.Text.Json;

namespace BlockChainLib;

public class Chain {

    private static string _fileName = "blockchain.json";

    private IDictionary<int, Block> _chain = new SortedDictionary<int, Block>();

    private static JsonSerializerOptions _jsonOptions = new() {
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    internal void Add(int key, Block block) {
        Block _lastBlock = LastBlock();
        block.BlockNbr = _lastBlock.BlockNbr + 1;
        // Nonce defaults to zero
        block.PrevHash = _lastBlock.CurrHash;
        block.CurrHash = CypherCode.Encrypt(block.ToStringData());
        while(!block.CurrHash.StartsWith("0000")) {
            block.Nonce++;
            block.CurrHash = CypherCode.Encrypt(block.ToStringData());
        }
        _chain.Add(block.BlockNbr, block);
    }

    internal void VerifyChain() 
    {
        foreach(var block in _chain) {
            var verifyHash = CypherCode.Encrypt(block.Value.ToStringData());
            if(verifyHash != block.Value.CurrHash) {
                Console.WriteLine($"Block {block.Value.BlockNbr} is invalid");
            }
            
        }
    }

    internal int BlockCount() 
    {
        return _chain.Count;
    }

    internal Block LastBlock() 
    {
        if(_chain.Count == 0) {
            return new Block();
        }
        return _chain.Last().Value;
    }

    // Clear the block chain
    public void ClearChain() 
    {
        
    }

    // Read existing block chain
    public void ReadChain() 
    {
        if(File.Exists(_fileName)) {
            string _json = File.ReadAllText(_fileName);
            List<Block>? _blocks = JsonSerializer.Deserialize<List<Block>>(_json, _jsonOptions);
            if (_blocks != null) {
                foreach(var block in _blocks) {
                    _chain.Add(block.BlockNbr, block);
                }
            }
        }
    }

    public void WriteChain() {
        WriteChainConverted();
    }

    // Write current block chain 
    public void WriteChainRaw() {

        Block _lastBlock = _chain.Last().Value;
        StringBuilder _sb = new();
        _sb.Append('[');
        foreach(var block in _chain) {
            _sb.Append($"{block.Value.ToJsonData()}");
            if(block.Value.BlockNbr != _lastBlock.BlockNbr) {
                _sb.Append(",");
            }
        }
        _sb.Append("]");
        File.WriteAllText(_fileName, _sb.ToString());

    }

    public void WriteChainConverted() {
        
        Block _lastBlock = _chain.Last().Value;
        List<Block> _blocks = new();
        foreach(var block in _chain) {
            _blocks.Add(block.Value);
        }
        string _json = JsonSerializer.Serialize(_blocks, _jsonOptions);
        File.WriteAllText(_fileName, _json);
    }
}
