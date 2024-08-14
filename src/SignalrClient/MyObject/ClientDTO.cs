namespace SignalrClient.MyObject;

public class ClientDTO
{
    /// <summary>
    /// 应用密钥
    /// </summary>
    public string AppKey { get; set; } = null!;

    /// <summary>
    /// 平台
    /// </summary>
    public int? Platform { get; set; }

    /// <summary>
    /// ip地址
    /// </summary>
    public string? Ip { get; set; }

    /// <summary>
    /// mac地址
    /// </summary>
    public string? Mac { get; set; }

    /// <summary>
    /// 产品id
    /// </summary>
    public string? ProductId { get; set; }

    /// <summary>
    /// 所属分组id
    /// </summary>
    public string? GroupId { get; set; }
}