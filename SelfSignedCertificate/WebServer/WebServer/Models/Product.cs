namespace WebServer.Models
{
    /// <summary>
    /// 製品
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 価格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// カテゴリー
        /// </summary>
        public string Category { get; set; }
    }
}