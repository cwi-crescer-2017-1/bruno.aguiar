﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedLocadora.api.Models
{
    public class RegistrarLocacaoModel
    {
        public int IdLocacao { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime PrevisaoEntrega { get; set; }
        public double PrecoFinal { get; set; }
        public double PrecoPrevisto { get; set; }
        public PacoteAcessorio PacoteAcessorios { get; set; }
        public VideoGame VideoGame { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public virtual List<LocacaoAcessorio> Acessorios { get; set; }
    }
}