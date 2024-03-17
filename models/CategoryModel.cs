namespace rf
{
    public class db_category
    {
        public int id { get; set; }
        public int parentId { get; set; }

        public string name { get; set; }
        public string image { get; set; }
        public string level { get; set; }

        public string slug { get; set; }
    }
}