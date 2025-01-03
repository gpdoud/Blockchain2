using System;
using System.Text;

namespace BlockChainLib;
// alll properties must be public in order to serialize & deserialize
public class Block
{
    public int BlockNbr { get; set; } = 0;
    public int Nonce { get; set; } = 0;
    public string Data { get; set; } = "";
    public string PrevHash { get; set; } = "000000000000000000000000000000000000000000000000000000000000000";
    public string CurrHash { get; set; } = "000000000000000000000000000000000000000000000000000000000000000";

    public string ToStringData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(BlockNbr.ToString());
        sb.Append(Nonce.ToString());
        sb.Append(Data);
        sb.Append(PrevHash);
        return sb.ToString();
    }

    public string ToJsonData()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        sb.Append($"\"BlockNbr\":{BlockNbr},");
        sb.Append($"\"Nonce\":{Nonce},");
        sb.Append($"\"Data\":\"{Data}\",");
        sb.Append($"\"PrevHash\":\"{PrevHash}\",");
        sb.Append($"\"CurrHash\":\"{CurrHash}\"");
        sb.Append("}");
        return sb.ToString();
    }

    public override string ToString()
    {
        return $"Block {BlockNbr} Nonce: {Nonce} \nData: {Data} \nPrevHash: {PrevHash} \nCurrHash: {CurrHash}";
    }
}
