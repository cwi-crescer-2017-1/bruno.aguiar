﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class Funcionario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public TurnoTrabalho TurnoTrabalho { get; set; }
        public Cargo Cargo { get; set; }
        public int Idade { get; internal set; }

        public Funcionario(int id, string nome, DateTime dataNascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }
    }
}
