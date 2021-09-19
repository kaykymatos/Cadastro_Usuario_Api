﻿using Api_Cadastro_Usuario.ClassConvert;
using Api_Cadastro_Usuario.Interfaces.Repository;
using Api_Cadastro_Usuario.Interfaces.Service;
using Api_Cadastro_Usuario.Models;
using Api_Cadastro_Usuario.POCO;
using Api_Cadastro_Usuario.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Api_Cadastro_Usuario.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioViewModel Create(UsuarioViewModel usuario)
        {
            if (usuario.GetType() != typeof(UsuarioViewModel))
                return null;

            var response = usuario.ViewModelToUsuario();
            _repository.Create(response);
            return usuario;

        }

        public UsuarioModel Delet(Guid model)
        {
            var usuario = _repository.GetOne(model);
            if (usuario == null)
                return null;
            _repository.Delet(usuario);
            return usuario;
        }

        public IEnumerable<UsuarioModel> GetAll()
        {
            return _repository.GetAll();
        }

        public UsuarioModel GetByEmail(string email)
        {
            var response = _repository.GetByEmail(email);
            if (response == null)
                return null;
            return response;
        }
        public UsuarioModel GetByPassword(string senha)
        {
            var response = _repository.GetByPassword(senha);
            if (response == null)
                return null;
            return response;
        }
        public DbSet<UsuarioModel> GetContext()
        {
            return _repository.GetContext();
        }

        public UsuarioModel GetOne(Guid codigo)
        {
            var response = _repository.GetOne(codigo);
            if (response == null)
                return null;
            return response;
        }

        public UsuarioLogin Login(UsuarioLogin loginUsuario)
        {
            var usuario = loginUsuario.LoginModelToUsuario();
            var response = _repository.Login(usuario);
            if (response == null)
                return null;
            return loginUsuario;
        }

        public UsuarioModel Put(Guid id, UsuarioModel usuario)
        {
            var response = _repository.GetOne(id);
            if (response == null)
                return null;

            var putUser = _repository.Put(id, usuario);
            return putUser;
        }
    }
}
