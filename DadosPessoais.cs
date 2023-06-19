using Bogus;
using Bogus.Extensions.Brazil;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using static Bogus.DataSets.Name;

namespace TesteProjeto
{
    public class DadosPessoais
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Cpf { get; set; }
        public string DateOfBirth { get; set; }
        public Gender Sexo { get; set; }
        public string PhoneNumber { get; set; }

        private Faker faker;

        public DadosPessoais()
        {
            faker = new Faker("pt_BR");
            PreencherCampos();

        }

        private void PreencherCampos()
        {
            FirstName = faker.Person.FirstName;
            LastName = faker.Person.LastName;
            Email = faker.Person.Email;
            Password = GerarSenha();
            ConfirmPassword = Password;
            Cpf = faker.Person.Cpf();
            DateOfBirth = faker.Person.DateOfBirth.ToString("dd/MM/yyyy");
            Sexo = faker.Person.Gender;
            PhoneNumber = faker.Person.Phone;
        }

        private string GerarSenha()
        {
            var passwordRegex = new Regex(@"^(?=.*[@#!%])(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,}$");

            while (true)
            {
                var password = faker.Internet.Password();

                password = $"%!@{password}";

                if (passwordRegex.IsMatch(password))
                {
                    return password;
                }
            }
        }
    }
}
