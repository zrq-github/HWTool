using System.Text.Json.Serialization;

namespace HW.Tool.Data;

/// <summary>
/// 红瓦的产品信息
/// </summary>
public class Product : IProduct
{
    public Product()
    { }

    /// <summary>
    /// 产品的简写
    /// </summary>
    [JsonPropertyName("Abbr")]
    public string Abbr { get; set; } = string.Empty;

    /// <summary>
    /// 产品的描述
    /// </summary>
    [JsonPropertyName("Description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 产品的标识
    /// </summary>
    [JsonPropertyName("Id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// 产品的名字
    /// </summary>
    [JsonPropertyName("Name")]
    public string Name { get; set; } = string.Empty;
}
