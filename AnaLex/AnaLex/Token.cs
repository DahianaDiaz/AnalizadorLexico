using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaLex
{
    class Token
    {
        public enum Tipo
        {
            NUMERO_ENTERO,
            NUMERO_REAL,
            SIGNO_MAS,
            SIGNO_MEN,
            SIGNO_POR,
            SIGNO_DIV,
            SIGNO_POW,
            PARENTESIS_IZQ,
            PARENTESIS_DER
        }
        private Tipo tipoToken;
        private String valor;
        public Token(Tipo tipoDelToken, string val)
        {
            this.tipoToken = tipoDelToken;
            this.valor = val;

        }
        public String Getval()
        {
            return valor;
        }
        public String GetTipo()
        {
            switch (tipoToken)
            {
                case Tipo.NUMERO_ENTERO:
                    return "Numero Entero";
                case Tipo.NUMERO_REAL:
                    return "Numero Real";
                case Tipo.SIGNO_MAS:
                    return "Signo Mas";
                case Tipo.SIGNO_MEN:
                    return "Signo Menos";
                case Tipo.SIGNO_POR:
                    return "Signo Multiplicacion";
                case Tipo.SIGNO_DIV:
                    return "Signo Division";
                case Tipo.SIGNO_POW:
                    return "Signo Potencia";
                case Tipo.PARENTESIS_IZQ:
                    return "Parentesis Abre";
                case Tipo.PARENTESIS_DER:
                    return "Parentesis Cierra";
                default:
                    return "Desconocido";

            }

        }


    }
}
