using System.Text;

namespace Compartilhado.Validacoes
{
    public static class Validacoes
    {
        #region Criptografia de Senhas
        /// <summary>
        /// Efetua a encriptação de um senha
        /// </summary>
        /// <param name="senha">senha a ser encriptada</param>
        /// <returns>Retorna a senha encriptada.</returns>
        public static string EncriptarSenha(string senha)
        {
            var segredoSenha = "9773cd3a387d11eaa1372e728ce88125";

            if (string.IsNullOrEmpty(senha)) return "";

            senha += segredoSenha;
            var novaSenha = senha;
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(novaSenha));
            var senhaEncriptada = new StringBuilder();

            foreach (var t in data)
                senhaEncriptada.Append(t.ToString("x2"));

            return senhaEncriptada.ToString();
        }

        #endregion
    }
}
