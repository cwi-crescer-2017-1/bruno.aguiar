﻿using Dominio.Entidades;
using SpeedLocadora.api.App_Start;
using SpeedLocadora.api.Models;
using SpeedLocadora.Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace SpeedLocadora.api.Controllers
{
    // Permite usuário não autenticados acessarem a controller
    [AllowAnonymous]
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ControllerBasica
    {
        readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        [HttpPost, Route("registrar")]
        public HttpResponseMessage Registrar([FromBody]RegistrarUsuarioModel model)
        {
            if (_usuarioRepositorio.Obter(model.Email) == null)
            {
                var usuario = new Usuario(model.Nome, model.Email, model.Senha);

                if (usuario.Validar())
                {
                    _usuarioRepositorio.Criar(usuario);
                }
                else
                {
                    return ResponderErro(usuario.Mensagens);
                }
            }
            else
            {
                return ResponderErro("Usuário já existe.");
            }

            return ResponderOK();
        }

        [HttpPost, Route("resetarsenha")]
        public HttpResponseMessage ResetarSenha(string email)
        {
            var usuario = _usuarioRepositorio.Obter(email);
            if (usuario == null)
                return ResponderErro(new string[] { "Usuário não encontrado." });

            var novaSenha = usuario.ResetarSenha();

            if (usuario.Validar())
            {
                _usuarioRepositorio.Alterar(usuario);
                // EmailService.Enviar(usuario.Email, "Crescer 2017-1", $"Olá! sua senha foi alterada para: {novaSenha}");
            }
            else
                return ResponderErro(usuario.Mensagens);

            return ResponderOK();
        }

        // Exige que o usuário se autentique
        [BasicAuthorization]
        [HttpGet, Route("usuario")]
        public HttpResponseMessage Obter()
        {
            // só pode obter as informações do usuário corrente (logado, autenticado)
            var usuario = _usuarioRepositorio.Obter(Thread.CurrentPrincipal.Identity.Name);

            if (usuario == null)
                return ResponderErro("Usuário não encontrado.");

            return ResponderOK(new { usuario.NomeUsuario, usuario.Permissoes, usuario.Email });
        }
    }
}