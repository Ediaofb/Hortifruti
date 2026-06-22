using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

    }
}
