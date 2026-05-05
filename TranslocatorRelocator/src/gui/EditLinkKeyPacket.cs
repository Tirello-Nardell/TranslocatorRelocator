using ProtoBuf;

[ProtoContract]
public class EditLinkKeyPacket
{
    [ProtoMember(1)]
    public string LinkKey;
}
