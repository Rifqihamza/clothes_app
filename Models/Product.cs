namespace clothes_app.Models
{
    class Product
    {
        public int Id { get; set; }
        public string NameProduct { get; set; } = "";
        public string CategoryProduct { get; set; } = "";
        public int PriceProduct { get; set; }
        public int StockProduct { get; set; }
    }
}
