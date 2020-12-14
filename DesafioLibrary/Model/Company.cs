namespace DesafioLibary.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}