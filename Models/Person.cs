namespace Web.Models
{
    public class Person
    {
        private Int128 PersonId { get; set; }
        private String Name { get; set; }
        private String Surname { get; set; }
        private String Email { get; set; }
        private String Password { get; set; }
        private Boolean IsSalesman { get; set; }
        private Int128 AddressId { get; set; }
    }
}
