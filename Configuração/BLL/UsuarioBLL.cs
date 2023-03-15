using Models;
using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        public void Inserir(Usuario _usuario, string _confirmacaodeSenha)
        {
            ValidarDados(_usuario, _confirmacaodeSenha);

            Usuario usuario = new Usuario();

            usuario = BuscarPorNome(_usuario.NomeUsuario);
            if (usuario.NomeUsuario == _usuario.NomeUsuario)
            {
                throw new Exception("Usuário já existente");
            }
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Inserir(_usuario);
        }

        public Usuario BuscarPorNome( string _nomeUsuario)
        {
            if (String.IsNullOrEmpty(_nomeUsuario))
            {
                throw new Exception("Informe o nome de Usuário.");
            }
            UsuarioDAL usuarioDAL=new UsuarioDAL();
            return usuarioDAL.BuscarPorNome(_nomeUsuario);
        }

        public void Alterar(Usuario _usuario, string _confirmacaodeSenha)
        {
            ValidarDados(_usuario, _confirmacaodeSenha);

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Alterar(_usuario);
        }
        public Usuario BuscarPorID(int _id_usuario)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarPorID(_id_usuario);
        }

        private static void ValidarDados(Usuario _usuario, string _confirmacaodeSenhaUsuario)
        {
            if (_usuario.NomeUsuario.Length <= 3 || _usuario.NomeUsuario.Length >= 50)
                throw new Exception("O nome de usuário deve ter mais de três caracteres.");

            if (_usuario.NomeUsuario.Contains(" "))
                throw new Exception("O nome de usuário não pode conter espaço em branco.");

            if (_usuario.Senha.Contains("1234567"))
                throw new Exception("Não é permitido um número sequencial.");

            if (_usuario.Senha.Length < 7 || _usuario.Senha.Length > 11)
                throw new Exception("A senha deve ter entre 7 e 11 caracteres.");

            if (_confirmacaodeSenhaUsuario != _usuario.Senha)
                throw new Exception("O Campo Senha e a Confirmação de Senha não são iguais.");
        }
   
        public List<Usuario> BuscarTodos()
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarTodos();
        }

        public void Excluir(Usuario _usuario)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.Excluir(_usuario);
        }
    }

}

