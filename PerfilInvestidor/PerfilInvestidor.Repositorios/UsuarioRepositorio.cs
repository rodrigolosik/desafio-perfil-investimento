﻿using Dapper;
using PerfilInvestidor.Modelos.Enumeradores;
using PerfilInvestidor.Modelos.Usuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PerfilInvestidor.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        const string ConnectionString = "Data Source=DESKTOP-LIPBPBP;Initial Catalog=PerfilInvestidor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Adicionar(Usuario usuario)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(ConnectionString))
                {
                    var usuarios = conexaoBD.Execute($"INSERT INTO Usuarios (Nome, Email, Senha) values (@Nome, @Email, @Senha)", usuario);
                }
            }
            catch (Exception)
            {
            }
        }

        public void AtualizarTipoPerfil(int usuarioId, TipoPerfil tipoPerfil)
        {
            try
            {
                using (var conexaoBD = new SqlConnection(ConnectionString))
                {
                    conexaoBD.Execute($"UPDATE Usuarios SET TipoPerfil = @TipoPerfil WHERE Id = @usuarioId", new { tipoPerfil, usuarioId } );
                }
            }
            catch (Exception)
            {
            }
        }

        public IEnumerable<Usuario> Listar()
        {
            try
            {
                using (var conexaoBD = new SqlConnection(ConnectionString))
                {
                    IEnumerable<Usuario> usuarios = conexaoBD.Query<Usuario>($"SELECT * FROM Usuarios");
                    return usuarios;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
