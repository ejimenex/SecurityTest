namespace SecurityTest.Domain.Entities
{
    public class Users:BaseClass
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int Role {  get; set; }
    }
}
