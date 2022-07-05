using DeliveryFaculdade.Dominio.Compartilhado;
using FluentValidation;
using System;

namespace DeliveryFaculdade.Dominio.ModuloPessoa
{
    public class ValidadorPessoa : ValidadorBase<Pessoa>
    {
        public ValidadorPessoa()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Estado)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataNascimento)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now)
                .WithMessage("Data de nascimento não pode ser superior a data atual");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Informe o e-mail do cliente")
                .EmailAddress()
                .WithMessage("E-mail inválido");

            RuleFor(x => x.Telefone)
                .NotNull()
                .NotEmpty();


        }
    }
}
