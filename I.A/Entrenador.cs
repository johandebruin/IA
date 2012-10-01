using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Data;
using Bot;
using HeatonResearch;
using HeatonResearchNeural;
using HeatonResearchNeural.Feedforward;
using HeatonResearchNeural.Feedforward.Train;
using HeatonResearchNeural.Feedforward.Train.Backpropagation;

namespace I.A
{
    class MiException : Exception { }

    class Entrenador
    {
        public int[] posMedia;
        public int campos;
        public int ejemplos;

        public FeedforwardNetwork[,] redes;

        public string[,] pre1;
        public string[,] pre2;
        public string[,] pre3;
        public string[,] pre4;
        public string[,] pre5;
        public string[,] pos1;
        public string[,] pos2;
        public string[,] pos3;
        public string[,] pos4;
        public string[,] pos5;

        public string[] Maestro1;
        public string[] Maestro2;
        public string[] Maestro3;
        public string[] Maestro4;
        public string[] Maestro5;


        public class Win32
        {
            [DllImport("kernel32.dll")]
            public static extern Boolean AllocConsole();
            [DllImport("kernel32.dll")]
            public static extern Boolean FreeConsole();
        }

        public Entrenador(string[] url, string[] campo1, string[] campo2, string[] campo3, 
            string[] campo4, string[] campo5)
        {
            Win32.AllocConsole();  // Abrir una consola
            ejemplos = url.Count() - 1;

            posMedia = new int[5];
            pre1 = new string[url.Count(), 2];
            pre2 = new string[url.Count(), 2];
            pre3 = new string[url.Count(), 2];
            pre4 = new string[url.Count(), 2];
            pre5 = new string[url.Count(), 2];
            pos1 = new string[url.Count(), 2];
            pos2 = new string[url.Count(), 2];
            pos3 = new string[url.Count(), 2];
            pos4 = new string[url.Count(), 2];
            pos5 = new string[url.Count(), 2];

            redes = new FeedforwardNetwork[5,2];

            campos = 1;

            //Obtenemos las cadenas de texto
            for (int i = 0; i < url.Count(); i++)
            {
                //ni�os, 
                Console.WriteLine("Obteniendo codigo: " + url[i]);
                string codigo = MiembrosEstaticos.DescargarCadena(new Uri(url[i]), null);
                int posicion = codigo.IndexOf(campo1[i]);
                if (posicion < 300)
                    posicion = codigo.IndexOf(campo1[i], posicion + 100);
                if (posMedia[0] == 0)
                    posMedia[0] = posicion;
                else
                    posMedia[0] = (int)Math.Round((decimal)(posMedia[0] + posicion) / 2);
                pre1[i, 0] = codigo.Substring(posicion - 300, 300);
                pos1[i, 0] = codigo.Substring(posicion + campo1[i].Length, 300);

                if (campo2[i] != null)
                {
                    posicion = codigo.IndexOf(campo2[i]);
                    if (posicion < 300)
                        posicion = codigo.IndexOf(campo2[i], posicion + 100);
                    if (posMedia[campos] == 0)
                        posMedia[campos] = posicion;
                    else
                        posMedia[campos] = (int)Math.Round((decimal)(posMedia[campos] + posicion) / 2);
                    pre2[i, 0] = codigo.Substring(posicion - 300, 300);
                    pos2[i, 0] = codigo.Substring(posicion + campo2[i].Length, 300);
                    campos = 2;
                }
                if (campo3[i] != null)
                {
                    posicion = codigo.IndexOf(campo3[i]);
                    if (posicion < 300)
                        posicion = codigo.IndexOf(campo3[i], posicion + 100);
                    if (posMedia[campos] == 0)
                        posMedia[campos] = posicion;
                    else
                        posMedia[campos] = (int)Math.Round((decimal)(posMedia[campos] + posicion) / 2);
                    pre3[i, 0] = codigo.Substring(posicion - 300, 300);
                    pos3[i, 0] = codigo.Substring(posicion + campo3[i].Length, 300);
                    campos = 3;
                }
                if (campo4[i] != null)
                {
                    posicion = codigo.IndexOf(campo4[i]);
                    if (posicion < 300)
                        posicion = codigo.IndexOf(campo4[i], posicion + 100);
                    if (posMedia[campos] == 0)
                        posMedia[campos] = posicion;
                    else
                        posMedia[campos] = (int)Math.Round((decimal)(posMedia[campos] + posicion) / 2);
                    pre4[i, 0] = codigo.Substring(posicion - 300, 300);
                    pos4[i, 0] = codigo.Substring(posicion + campo4[i].Length, 300);
                    campos = 4;
                }
                if (campo5[i] != null)
                {
                    posicion = codigo.IndexOf(campo4[i]);
                    if (posicion < 300)
                        posicion = codigo.IndexOf(campo5[i], posicion + 100);
                    if (posMedia[campos] == 0)
                        posMedia[campos] = posicion;
                    else
                        posMedia[campos] = (int)Math.Round((decimal)(posMedia[campos] + posicion) / 2);
                    pre5[i, 0] = codigo.Substring(posicion - 300, 300);
                    pos5[i, 0] = codigo.Substring(posicion + campo5[i].Length, 300);
                    campos = 5;
                }
            }

            //Obtenemos los datos binarios
            for (int i = campos; i > 0; i--)
            {
                if (i == 5)
                {
                    for (int o = 1; o < url.Count(); o++)
                    {
                        pre5[o - 1, 1] = Binario.Obtener(pre5[0, 0], pre5[o, 0], true);
                        pos5[o - 1, 1] = Binario.Obtener(pos5[0, 0], pos5[o, 0], false);
                        Console.WriteLine("PreBinario" + i + o + ": " + pre5[o - 1, 1]);
                        Console.WriteLine("PosBinario" + i + o + ": " + pos5[o - 1, 1]);
                    }
                }
                if (i == 4)
                {
                    for (int o = 1; o < url.Count(); o++)
                    {
                        pre4[o - 1, 1] = Binario.Obtener(pre4[0, 0], pre4[o, 0], true);
                        pos4[o - 1, 1] = Binario.Obtener(pos4[0, 0], pos4[o, 0], false);
                        Console.WriteLine("PreBinario" + i + o + ": " + pre4[o - 1, 1]);
                        Console.WriteLine("PosBinario" + i + o + ": " + pos4[o - 1, 1]);
                    }
                }
                if (i == 3)
                {
                    for (int o = 1; o < url.Count(); o++)
                    {
                        pre3[o - 1, 1] = Binario.Obtener(pre3[0, 0], pre3[o, 0], true);
                        pos3[o - 1, 1] = Binario.Obtener(pos3[0, 0], pos3[o, 0], false);
                        Console.WriteLine("PreBinario" + i + o + ": " + pre3[o - 1, 1]);
                        Console.WriteLine("PosBinario" + i + o + ": " + pos3[o - 1, 1]);
                    }
                }
                if (i == 2)
                {
                    for (int o = 1; o < url.Count(); o++)
                    {
                        pre2[o - 1, 1] = Binario.Obtener(pre2[0, 0], pre2[o, 0], true);
                        pos2[o - 1, 1] = Binario.Obtener(pos2[0, 0], pos2[o, 0], false);
                        Console.WriteLine("PreBinario" + i + o + ": " + pre2[o - 1, 1]);
                        Console.WriteLine("PosBinario" + i + o + ": " + pos2[o - 1, 1]);
                    }
                }
                if (i == 1)
                {
                    for (int o = 1; o < url.Count(); o++)
                    {
                        pre1[o-1, 1] = Binario.Obtener(pre1[0, 0], pre1[o, 0], true);
                        pos1[o-1, 1] = Binario.Obtener(pos1[0, 0], pos1[o, 0], false);
                        Console.WriteLine("PreBinario" + i + o + ": " + pre1[o - 1, 1]);
                        Console.WriteLine("PosBinario" + i + o + ": " + pos1[o - 1, 1]);
                    }
                }
            }
            CrearMaestros();
            //Entrenamos a las redes neuronales
            for (int i = 1; i <= campos; i++)
            {
                Entrenar(i, 0);
                Entrenar(i, 1);
            }
            Win32.FreeConsole();
        }

        private void CrearMaestros()
        {
            Maestro1 = new string[4];
            Maestro2 = new string[4];
            Maestro3 = new string[4];
            Maestro4 = new string[4];
            Maestro5 = new string[4];

            int[] matriz;
            int[] matriz2;

            for (int i = campos; i > 0; i--)
            {
                if (i == 5)
                {
                    matriz = new int[30];
                    matriz2 = new int[30];
                    int ceros = 0;
                    int ceros2 = 0;
                    //Obtenemos la suma de los patrones
                    for (int o = 0; o < ejemplos; o++)
                    {
                        int temp1 = 0;
                        int temp2 = 0;
                        for (int x = 0; x < 30; x++)
                        {
                            matriz[x] += int.Parse(pre5[o, 1][x].ToString());
                            matriz2[x] += int.Parse(pos5[o, 1][x].ToString());
                            if (int.Parse(pre5[o, 1][x].ToString()) == 0)
                                temp1++;
                            if (int.Parse(pos5[o, 1][x].ToString()) == 0)
                                temp2++;
                        }
                        if (temp1 > ceros)
                            for (int l = ceros; l < temp1; l++)
                                ceros++;
                        if (temp2 > ceros2)
                            for (int l = ceros2; l < temp2; l++)
                                ceros2++;
                    }
                    StringBuilder sb1 = new StringBuilder();
                    StringBuilder sb2 = new StringBuilder();
                    //Tabulamos los numeros > 1
                    for (int x = 0; x < 30; x++)
                    {
                        if (matriz[x] > 0)
                            matriz[x] = 1;

                        if (matriz2[x] > 0)
                            matriz2[x] = 1;

                        //Creamos las cadenas
                        sb1.Append(matriz[x]);
                        sb2.Append(matriz2[x]);
                    }
                    //Otorgamos al maestro su valor...
                    Maestro5[0] = sb1.ToString();
                    Console.WriteLine("MaestroPre4: " + Maestro4[0]);
                    Maestro5[1] = ceros.ToString();
                    Maestro5[2] = sb2.ToString();
                    Console.WriteLine("MaestroPos4: " + Maestro4[2]);
                    Maestro5[3] = ceros2.ToString();
                }
                if (i == 4)
                {
                    matriz = new int[30];
                    matriz2 = new int[30];
                    int ceros = 0;
                    int ceros2 = 0;
                    //Obtenemos la suma de los patrones
                    for (int o = 0; o < ejemplos; o++)
                    {
                        int temp1 = 0;
                        int temp2 = 0;
                        for (int x = 0; x < 30; x++)
                        {
                            matriz[x] += int.Parse(pre4[o, 1][x].ToString());
                            matriz2[x] += int.Parse(pos4[o, 1][x].ToString());
                            if (int.Parse(pre4[o, 1][x].ToString()) == 0)
                                temp1++;
                            if (int.Parse(pos4[o, 1][x].ToString()) == 0)
                                temp2++;
                        }
                        if (temp1 > ceros)
                            for(int l = ceros; l < temp1; l++)
                                ceros++;
                        if (temp2 > ceros2)
                            for (int l = ceros2; l < temp2; l++)
                                ceros2++;
                    }
                    StringBuilder sb1 = new StringBuilder();
                    StringBuilder sb2 = new StringBuilder();
                    //Tabulamos los numeros > 1
                    for (int x = 0; x < 30; x++)
                    {
                        if (matriz[x] > 0)
                            matriz[x] = 1;

                        if (matriz2[x] > 0)
                            matriz2[x] = 1;

                        //Creamos las cadenas
                        sb1.Append(matriz[x]);
                        sb2.Append(matriz2[x]);
                    }
                    //Otorgamos al maestro su valor...
                    Maestro4[0] = sb1.ToString();
                    Console.WriteLine("MaestroPre4: " + Maestro4[0]);
                    Maestro4[1] = ceros.ToString();
                    Maestro4[2] = sb2.ToString();
                    Console.WriteLine("MaestroPos4: " + Maestro4[2]);
                    Maestro4[3] = ceros2.ToString();
                }
                if (i == 3)
                {
                    matriz = new int[30];
                    matriz2 = new int[30];
                    int ceros = 0;
                    int ceros2 = 0;
                    //Obtenemos la suma de los patrones
                    for (int o = 0; o < ejemplos; o++)
                    {
                        int temp1 = 0;
                        int temp2 = 0;
                        for (int x = 0; x < 30; x++)
                        {
                            matriz[x] += int.Parse(pre3[o, 1][x].ToString());
                            matriz2[x] += int.Parse(pos3[o, 1][x].ToString());
                            if (int.Parse(pre3[o, 1][x].ToString()) == 0)
                                temp1++;
                            if (int.Parse(pos3[o, 1][x].ToString()) == 0)
                                temp2++;
                        }
                        if (temp1 > ceros)
                            for (int l = ceros; l < temp1; l++)
                                ceros++;
                        if (temp2 > ceros2)
                            for (int l = ceros2; l < temp2; l++)
                                ceros2++;
                    }
                    StringBuilder sb1 = new StringBuilder();
                    StringBuilder sb2 = new StringBuilder();
                    //Tabulamos los numeros > 1
                    for (int x = 0; x < 30; x++)
                    {
                        if (matriz[x] > 0)
                            matriz[x] = 1;

                        if (matriz2[x] > 0)
                            matriz2[x] = 1;

                        //Creamos las cadenas
                        sb1.Append(matriz[x]);
                        sb2.Append(matriz2[x]);
                    }
                    //Otorgamos al maestro su valor...
                    Maestro3[0] = sb1.ToString();
                    Console.WriteLine("MaestroPre3: " + Maestro3[0]);
                    Maestro3[1] = ceros.ToString();
                    Maestro3[2] = sb2.ToString();
                    Console.WriteLine("MaestroPos3: " + Maestro3[2]);
                    Maestro3[3] = ceros2.ToString();
                }
                if (i == 2)
                {
                    matriz = new int[30];
                    matriz2 = new int[30];
                    int ceros = 0;
                    int ceros2 = 0;
                    //Obtenemos la suma de los patrones
                    for (int o = 0; o < ejemplos; o++)
                    {
                        int temp1 = 0;
                        int temp2 = 0;
                        for (int x = 0; x < 30; x++)
                        {
                            matriz[x] += int.Parse(pre2[o, 1][x].ToString());
                            matriz2[x] += int.Parse(pos2[o, 1][x].ToString());
                            if (int.Parse(pre2[o, 1][x].ToString()) == 0)
                                temp1++;
                            if (int.Parse(pos2[o, 1][x].ToString()) == 0)
                                temp2++;
                        }
                        if (temp1 > ceros)
                            for (int l = ceros; l < temp1; l++)
                                ceros++;
                        if (temp2 > ceros2)
                            for (int l = ceros2; l < temp2; l++)
                                ceros2++;
                    }
                    StringBuilder sb1 = new StringBuilder();
                    StringBuilder sb2 = new StringBuilder();
                    //Tabulamos los numeros > 1
                    for (int x = 0; x < 30; x++)
                    {
                        if (matriz[x] > 0)
                            matriz[x] = 1;

                        if (matriz2[x] > 0)
                            matriz2[x] = 1;

                        //Creamos las cadenas
                        sb1.Append(matriz[x]);
                        sb2.Append(matriz2[x]);
                    }
                    //Otorgamos al maestro su valor...
                    Maestro2[0] = sb1.ToString();
                    Console.WriteLine("MaestroPre2: " + Maestro2[0]);
                    Maestro2[1] = ceros.ToString();
                    Maestro2[2] = sb2.ToString();
                    Console.WriteLine("MaestroPos2: " + Maestro2[2]);
                    Maestro2[3] = ceros2.ToString();
                }
                if (i == 1)
                {
                    matriz = new int[30];
                    matriz2 = new int[30];
                    int ceros = 0;
                    int ceros2 = 0;
                    //Obtenemos la suma de los patrones
                    for (int o = 0; o < ejemplos; o++)
                    {
                        int temp1 = 0;
                        int temp2 = 0;
                        for (int x = 0; x < 30; x++)
                        {
                            matriz[x] += int.Parse(pre1[o, 1][x].ToString());
                            matriz2[x] += int.Parse(pos1[o, 1][x].ToString());
                            if (int.Parse(pre1[o, 1][x].ToString()) == 0)
                                temp1++;
                            if (int.Parse(pos1[o, 1][x].ToString()) == 0)
                                temp2++;
                        }
                        Console.WriteLine("temp1:"+temp1);
                        Console.WriteLine("temp2:" + temp2);
                        Console.ReadLine();
                        if (temp1 > ceros)
                            for (int l = ceros; l < temp1; l++)
                                ceros++;
                        if (temp2 > ceros2)
                            for (int l = ceros2; l < temp2; l++)
                                ceros2++;
                    }
                    StringBuilder sb1 = new StringBuilder();
                    StringBuilder sb2 = new StringBuilder();
                    //Tabulamos los numeros > 1
                    for (int x = 0; x < 30; x++)
                    {
                        if (matriz[x] > 0)
                            matriz[x] = 1;

                        if (matriz2[x] > 0)
                            matriz2[x] = 1;

                        //Creamos las cadenas
                        sb1.Append(matriz[x]);
                        sb2.Append(matriz2[x]);
                    }
                    //Otorgamos al maestro su valor...
                    Maestro1[0] = sb1.ToString();
                    Console.WriteLine("MaestroPre1: " + Maestro1[0]);
                    Maestro1[1] = ceros.ToString();
                    Maestro1[2] = sb2.ToString();
                    Console.WriteLine("MaestroPos1: " + Maestro1[2]);
                    Maestro1[3] = ceros2.ToString();
                }
            }
        }

        private void Entrenar(int red, int pre)
        {
            string[] patrones = new string[ejemplos];

            switch (red)
            {
                case 1:
                    for (int i = 0; i < ejemplos; i++)
                        if (pre == 0)
                            patrones[i] = pre1[i, 1];
                        else
                            patrones[i] = pos1[i, 1];
                    break;
                case 2:
                    for (int i = 0; i < ejemplos; i++)
                        if (pre == 0)
                            patrones[i] = pre2[i, 1];
                        else
                            patrones[i] = pos2[i, 1];
                    break;
                case 3:
                    for (int i = 0; i < ejemplos; i++)
                        if (pre == 0)
                            patrones[i] = pre3[i, 1];
                        else
                            patrones[i] = pos3[i, 1];
                    break;
                case 4:
                    for (int i = 0; i < ejemplos; i++)
                        if (pre == 0)
                            patrones[i] = pre4[i, 1];
                        else
                            patrones[i] = pos4[i, 1];
                    break;
                case 5:
                    for (int i = 0; i < ejemplos; i++)
                        if (pre == 0)
                            patrones[i] = pre5[i, 1];
                        else
                            patrones[i] = pos5[i, 1];
                    break;
            }

            Double[][] entrada = new double[ejemplos+3][];
            double[] matriz = new double[30];
            double[] matriz2 = new double[30];
            double[] matriz3 = new double[30];
            //Creamos las matrices de los patrones
            for (int i = 0; i < ejemplos; i++)
            {
                double[] matrix = new double[30];
                for (int o = 0; o < 30; o++)
                    matrix[o] = double.Parse(patrones[i][o].ToString());
                entrada[i] = matrix;
            }
            //Creamos 3 matrices orientativas
            bool control = true;
            for (int i = 0; i < 30; i++)
            {
                matriz3[i] = 0;
                if (control)
                {
                    matriz[i] = 1;
                    matriz2[i] = 0;
                    control = false;
                }
                else
                {
                    matriz[i] = 0;
                    matriz2[i] = 1;
                    control = true;
                }
            }
            entrada[ejemplos] = matriz;
            entrada[ejemplos + 1] = matriz2;
            entrada[ejemplos + 2] = matriz3;
            //Creamos la matriz ideal
            Double[][] ideal = new double[ejemplos + 3][];
            for (int i = 0; i < ejemplos; i++)
                ideal[i] = new double[] { 1 };
            for (int i = ejemplos; i < ejemplos + 3; i++)
                ideal[i] = new double[] { 0 };

            //COMENZAMOS A CREAR LA RED NEURONAL!!!!
            FeedforwardNetwork neurosis = new FeedforwardNetwork();
            neurosis.AddLayer(new FeedforwardLayer(30));
            neurosis.AddLayer(new FeedforwardLayer(30));
            neurosis.AddLayer(new FeedforwardLayer(1));
            neurosis.Reset();
            Train entrenador = new HeatonResearchNeural.Feedforward.Train.Backpropagation.Backpropagation
                (neurosis, entrada, ideal, 0.09, 0.9);
            for (int e = 0; e < 1000; e++)
            {
                Console.WriteLine("Error: " + entrenador.Error);
                entrenador.Iteration();
                if (entrenador.Error < 0.012)
                    break;
            }
            redes[red-1, pre] = neurosis;
        }

        private void ImprimirMatriz(double[] matriz)
        {
            StringBuilder x = new StringBuilder();
            for (int i = 0; i < matriz.Count(); i++)
                x.Append(matriz[i]);
            Console.WriteLine(x.ToString());
        }

        public void EjecutarPagina(string url)
        {
            try
            {
                //Win32.AllocConsole();  // Abrir una consola

                Console.WriteLine("Ejecutando: " + url);
                string codigo = MiembrosEstaticos.DescargarCadena(new Uri(url), null);
                int[,] posiciones = new int[campos, 2];

                //Por cada campo debemos ejecutar el bot 2 veces
                for (int i = 0; i < campos; i++)
                {
                    for (int o = 0; o < 2; o++)
                    {
                        int cer = 0;
                        string patron = "";
                        switch (i + 1)
                        {
                            case 1:
                                if (o == 0)
                                {
                                    patron = pre1[0, 0];
                                    cer = int.Parse(Maestro1[1]);
                                    Console.WriteLine(patron);
                                }
                                else
                                {
                                    patron = pos1[0, 0];
                                    cer = int.Parse(Maestro1[3]);
                                }
                                break;
                            case 2:
                                if (o == 0)
                                {
                                    patron = pre2[0, 0];
                                    cer = int.Parse(Maestro2[1]);
                                }
                                else
                                {
                                    patron = pos2[0, 0];
                                    cer = int.Parse(Maestro2[3]);
                                }
                                break;
                            case 3:
                                if (o == 0)
                                {
                                    patron = pre3[0, 0];
                                    cer = int.Parse(Maestro3[1]);
                                }
                                else
                                {
                                    patron = pos3[0, 0];
                                    cer = int.Parse(Maestro3[3]);
                                }
                                break;
                            case 4:
                                if (o == 0)
                                {
                                    patron = pre4[0, 0];
                                    cer = int.Parse(Maestro4[1]);
                                }
                                else
                                {
                                    patron = pos4[0, 0];
                                    cer = int.Parse(Maestro4[3]);
                                }
                                break;
                            case 5:
                                if (o == 0)
                                {
                                    patron = pre5[0, 0];
                                    cer = int.Parse(Maestro1[1]);
                                }
                                else
                                {
                                    patron = pos5[0, 0];
                                    cer = int.Parse(Maestro5[3]);
                                }
                                break;
                        }
                        //Obtenemos los 2/3 de la posicion media en la que se suele encontrar la variable.
                        /*int num = (int)Math.Round((decimal)posMedia[i] * 2 / 3);
                        if (num < 1500)
                            num = 0;
                        if ((posMedia[i] - num) > 1500)
                            num = posMedia[i] - 1500;
                        if (o == 1)
                            num = posiciones[i, 0];*/
                        //int fias = num;
                        int num = 0;
                        bool echo = false;
                        Console.WriteLine("Posicion media: " + posMedia[i]);
                        //Console.ReadLine();
                        int posneta = posMedia[i];
                        if (o == 1)
                            posneta = posiciones[i, 0];
                        bool primero = true;
                        while (!echo)
                        {
                            //Podemos directamente buscar el patron.
                            if (cer == 0)
                            {
                                if (o == 1)
                                {
                                    posiciones[i, o] = codigo.IndexOf(patron.Substring(0, 30),posiciones[i,0]);
                                }
                                else
                                    posiciones[i, o] = codigo.IndexOf(patron.Substring(270, 30),posneta-200) + 30;
                                if (posiciones[i, o] == -1)
                                    cer++;
                                else
                                {
                                    Console.WriteLine("posicion de lo encontrado: " + posiciones[i, o]);
                                    Console.WriteLine("Encontrado algo:");
                                    Console.ReadLine();
                                    if (o == 1)
                                        Console.WriteLine(codigo.Substring(posiciones[i, 0], posiciones[i, o] - posiciones[i, 0]));
                                    else
                                        Console.WriteLine(codigo.Substring(posiciones[i, o], 300));
                                    posMedia[i] = (int)Math.Round((decimal)(posMedia[i] + posiciones[i, o]) / 2);
                                    //Console.ReadLine();
                                    echo = true;
                                    break;
                                }
                            }
                            for (int ii = 0; ii < 2; ii++)
                            {
                                // Los pos no pueden retroceder.
                                if (ii == 1 && o == 1)
                                {
                                    //Cosa especial!
                                    /*if (i == 3)
                                    {
                                        posiciones[i, 1] = posiciones[i, 0] + codigo.Substring(posiciones[i, 0], 100).Substring(0, codigo.Substring(posiciones[i, 0], 100).IndexOf(".swf")).Length;
                                    Console.WriteLine(codigo.Substring(posiciones[i, 0],100));
                                    Console.WriteLine(posiciones[i, 0]);
                                    Console.WriteLine(patron);
                                    echo = true;
                                    break;
                                    }
                                    num++;*/
                                }
                                if (ii == 1 && posneta - num > 0)
                                    num = -num;
                                else if (ii == 0 && num < 0)
                                    num = num * (-1);
                                else if (posneta - num < 0 && num < 0)
                                {
                                    num = num * (-1);
                                    num++;
                                    break;
                                }
                                Console.WriteLine("num: " + num + ", posicion: " + (posneta + num));
                                string a1 = codigo.Substring(posneta + num, 300);
                                //string a1 = codigo.Substring(num, 300);
                                bool pre = false;
                                if (o == 0)
                                    pre = true;
                                else
                                {
                                    pre = false;
                                }
                                string j = Binario.Obtener(patron, a1, pre);
                                double[] cinco = new double[30];
                                Console.WriteLine("Patron obtenido: " + j);
                                int ceros = 0;
                                for (int x = 0; x < 30; x++)
                                {
                                    cinco[x] = double.Parse(j[x].ToString());
                                    if (cinco[x] == 0)
                                        ceros++;
                                }
                                Console.WriteLine("ceros: " + ceros + " , cer: " + cer + ", i: " + i + ", o: " + o);
                                if (ceros <= cer)
                                {
                                    double[] actual = redes[i, o].ComputeOutputs(cinco);
                                    Console.WriteLine("ceros: " + ceros);
                                    Console.WriteLine("resultado2: " + actual[0]);
                                    if (actual[0] > 0.8)
                                    {
                                        if (o == 1 && posneta + num < posiciones[i, 0])
                                                break;
                                        //falta que no se añada si o == 1
                                        if (o == 1)
                                        {
                                            
                                            posiciones[i, o] = posneta + num;
                                        }
                                        else
                                            posiciones[i, o] = posneta + num + 299;
                                        Console.WriteLine("posicion[" + i + "," + o + "]: " + posiciones[i, o]);

                                        Console.WriteLine("Encontrado algo:");
                                        if (o == 1)
                                            Console.WriteLine(codigo.Substring(posiciones[i, 0], posiciones[i, o] - posiciones[i, 0]));
                                        else
                                            Console.WriteLine(codigo.Substring(posiciones[i, o], 70));
                                        posMedia[i] = (int)Math.Round((decimal)(posMedia[i] + posiciones[i, o]) / 2);
                                        //Console.ReadLine();
                                        echo = true;
                                    }
                                }
                                if (num < 0)
                                    num *= (-1);
                                if (ii == 1)
                                    num++;
                                if (num == 1200)
                                    if (primero)
                                    {
                                        cer++;
                                        primero = false;
                                    }
                                    else
                                        throw new MiException();
                            }
                        }
                    } // FIN FOR o
                } //FIN FOR i
                //Dado que se encontraron todos los datos procedemos a insertarlos en la BD
                string[] datos = new string[5];
                for (int i = 0; i < campos; i++)
                {
                    datos[i] = codigo.Substring(posiciones[i, 0], posiciones[i, 1] - posiciones[i, 0]);
                }
                for (int i = campos; i < 5; i++)
                    datos[i] = "vacio";

                string strConexion = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=./BD.mdb";
                OleDbConnection conexion2 = new OleDbConnection(strConexion);
                conexion2.Open();
                OleDbCommand comando2 = new OleDbCommand();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("INSERT INTO Tabla " +
                    "(campo1, campo2, campo3, campo4, campo5) " +
                    "VALUES ('" + datos[0] + "','" + url + "','" + datos[2] + "','" + datos[3] + "','" + datos[4] + "')", conexion2);
                DataSet conjunto = new DataSet();
                adaptador.Fill(conjunto);
                conexion2.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("No se encontraron los patrones o algun fallo a ocurrido");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            finally
            {
                //Win32.FreeConsole();
            }
        }
    }
}