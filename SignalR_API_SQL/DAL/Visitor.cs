namespace SignalR_API_SQL.DAL
{
    public enum ECity
    {
        Edirne = 1,
        Istanbul = 2,
        Ankara = 3,
        Antalya = 4,
        Bursa = 5
    }
    public class Visitor
    {
        public int VisitorId { get; set; }
        public ECity City { get; set; }
        public int VisitorCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
