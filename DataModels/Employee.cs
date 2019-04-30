namespace DataModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Name => $"{Firstname} {Lastname}";
        public int Age { get; set; }
        public int RoleId { get; set; }
    }
}
