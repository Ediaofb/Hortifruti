using System;
using System.Security.Cryptography;
using System.Text;

namespace Hortifruti
{
    
    public static class GeradorSenha
    {
        // _____ CHAVE SECRETA ________________________________________________
        // Esta string só existe no código-fonte (nao fica no banco,
        // nem em arquivo, nem visível ao cliente).
        private const string CHAVE_SECRETA = "Hortifruti-2026-#Suporte!";

        /// <summary>
        /// Gera a senha de desbloqueio para um determinado mês/ano.
        /// Use esta função em uma ferramenta separada (ex: um pequeno
        /// console app) para gerar a senha que voce passa ao cliente.
        /// </summary>
        
        public static string GerarSenha(int mes, int ano)
        {
            //Monta a string base: "MM-yyyy" + chave secreta
            string base_ = $"{mes:D2}-{ano}-{CHAVE_SECRETA}";

            //Gera hash SHA256
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(base_));

                //Converte o hash para string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                string hashCompleto = sb.ToString();

                //Pega só os primeiros 8 caracteres + formata
                //Ex: "A3F92B1C"

                return hashCompleto.Substring(0, 8).ToUpper();
            }
        }
    }
}
