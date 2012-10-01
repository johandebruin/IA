using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace I.A
{
    class Binario
    {
        public static string Obtener(string primero, string segundo, bool pre)
        {
            //Ponemos al reves las cadenas
            string patron1;
            string patron2;
            if (pre)
            {
                patron1 = "|" + Reves(primero);
                patron2 = "|" + Reves(segundo);
            }
            else
            {
                patron1 = "|" + primero;
                patron2 = "|" + segundo;
            }

            StringBuilder binario = new StringBuilder();
            int seguidos = 0;
            for (int i = 0; i < patron1.Length; i++)
            {
                if (binario.ToString().Length > 10)
                    if (seguidos > 60)
                    {
                        binario = new StringBuilder().Append("000000000000000000000000000000000");
                        break;
                    }
                //En cuanto llegue a los 30 caracteres parar.
                if (binario.ToString().Length > 30)
                    break;
                if (patron1.Length - i < 4 || patron2.Length - i < 4)
                    break;
                if (i + 10 > patron1.Length)
                    break;
                if (patron1[i] == patron2[i])
                    binario.Append("1");
                else
                {
                    if (binario.ToString()[binario.ToString().Length - 1] != '0')
                    {
                        binario.Append("0");
                        seguidos = 0;
                    }
                    else
                        seguidos++;
                    bool echo = false;
                    for (int e = 0; e < 8; e++)
                    {
                        if (echo)
                            break;
                        int j;
                        if (i > 20)
                            j = -20;
                        else
                            j = -i;
                        while (j + 10 < patron1.Length || j < 30)
                        {
                            if (i + e + j + 30> patron1.Length)
                                break;
                            string sum1 = patron1[i + e].ToString() + patron1[i + e + 1] + patron1[i + e + 2] + patron1[i + e + 3] + patron1[i + e + 4];
                            string sum2 = patron2[i + j].ToString() + patron2[i + 1 + j] + patron2[i + 2 + j] + patron2[i + 3 + j] + patron2[i + 4 + j];
                            if (sum1 == sum2)
                            {
                                patron1 = patron1.Substring(e + i);
                                patron2 = patron2.Substring(i + j);
                                i = 0;
                                echo = true;
                                break;
                            }
                            j++;
                            if (j + 3 > (patron1.Length - i - e - j) || j + e + i > (patron2.Length - i - e - j))
                                break;
                        }
                    }
                }
            }
            if (binario.ToString().Length < 30)
                return "000000000000000000000000000000000";
            return binario.ToString();
        }


        public static string Reves(string cadena)
        {
            StringBuilder temp = new StringBuilder();
            for (int i = cadena.Length - 1; i > 0; i--)
                temp.Append(cadena[i]);
            return temp.ToString();
        }
    }
}
