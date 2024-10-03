using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Web.Models;

public class Person
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Surname { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; } = string.Empty;
    public bool IsSalesman { get; set; }
    public Address Address { get; set; } = new();

    public Person() { }

    public Person(string email, string password)
    {
        this.Email = email;
        this.Password = HashPassword(password);
    }

    public Person(string name, string surname, string email, string password, bool isSalesman, Address address)
    {
        this.Name = name;
        this.Surname = surname;
        this.Email = email;
        this.Password = HashPassword(password);
        this.IsSalesman = isSalesman;
        this.Address = address;
    }

    private string HashPassword(string senha)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));

            }
            return builder.ToString();
        }
    }
}
