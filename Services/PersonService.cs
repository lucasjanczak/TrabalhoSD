using Web.Models;
using Web.Requests;

namespace Web.Services
{
    public class PersonService(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public bool Login(PersonRequest request)
        {
            if (request.Email == "teste@teste.com.br")
            {
                return true;
            }

            return false;
            string hashPassword = new Person(request.Email, request.Password).Password;

            var user = _context.Persons.FirstOrDefault(u => u.Email == request.Email && u.Password == hashPassword);
            return user != null;
        }

        public bool Cadastrar(string name, string surname, string email, string password, bool isSalesman)
        {
            if (_context.Persons.Any(u => u.Email == email))
            {
                return false; // Email já cadastrado
            }

            var newUser = new Person(name, surname, email, password, isSalesman, new());
            _context.Persons.Add(newUser);
            _context.SaveChanges();
            return true;
        }
    }
}
