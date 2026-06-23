using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hortifruti
{
    class MetodosUteis
    {
        //link de conexao
        public string conectaBD()
        {
            return @"server = localhost; database = hortifruti_db; Uid = root; Pwd = 359423;";
        }
    }
}
