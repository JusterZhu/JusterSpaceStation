namespace X.NetCore.Packet
{
    public interface IPacket
    {
        byte[] Serialize();

        void Deserialize(ref byte[] data);
    }
}
