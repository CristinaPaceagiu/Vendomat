internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bonus Exercitiul 5");

        /*
        Am creat trei fisiere text cu cele 3 exemple din Vendomat.pdf
        Input1.txt, Input2.txt, Input3.txt.
        Am testat programul cu aceste date.
        Numele fisierului .txt trebuie scris la Linia 14.
        Nu am implementat citirea datelor de intrare de la tastatura.
        Am inceput rezolvarea ca problemele anterioare, prin citirea datelor din fisier text,
        si la final nu am mai avut timp pentru a dezvolta si partea de date de intrare.
        */

        string[] lines = File.ReadAllLines("Input1.txt");
        int nrCategProduse = int.Parse(lines[0]);
        Console.WriteLine($"categorii produse = {nrCategProduse}");

        int[] stocProduse = new int[nrCategProduse];
        string[] parts = lines[1].Split(" ");

        for (int i = 0; i < nrCategProduse; i++)
        {
            stocProduse[i] = int.Parse(parts[i]);
        }

        Console.WriteLine("Stoc produse initial: ");
        AfisareStocuri(nrCategProduse, stocProduse);

        int nrOperatii = int.Parse(lines[2]);

        Console.WriteLine($"nr operatii = {nrOperatii}");


        int[,] operatii = new int[nrOperatii, nrCategProduse];
        for (int i = 3; i < nrOperatii + 3; i++)
        {
            string[] parts2 = lines[i].Split(" ");
            for (int j = 0; j < nrCategProduse; j++)
            {
                operatii[i - 3, j] = int.Parse(parts2[j]);
            }
            Array.Clear(parts2);
        }

        for (int i = 0; i < nrOperatii; i++)
        {
            for (int j = 0; j < nrCategProduse; j++)
            {
                Console.Write(operatii[i, j] + " ");
            }
            Console.WriteLine();
        }

        int vanzare =0;
        int aprovizionare = 0;
        int vanzareNeonorata = 0;
        int nrAprovizionari = 0;


        for (int i = 0; i < nrOperatii; i++)
        {
            aprovizionare = 0;
            for (int j = 0; j < nrCategProduse; j++)
            {
                if (operatii[i, j] == 0)
                {
                    aprovizionare++;
                }
                else
                {
                    aprovizionare = -1;
                }
            }
            if (aprovizionare == nrCategProduse)
            {
                nrAprovizionari++;
                Aprovizionare(stocProduse, nrCategProduse, 10);
                Console.WriteLine();
                Console.WriteLine($"i= {i} aprovizionare");
                Console.WriteLine("stoc dupa aprovizionare: ");
                AfisareStocuri(nrCategProduse, stocProduse);
            }
            else
            {
                vanzare = 0;
                for (int k = 0; k < nrCategProduse; k++)
                {
                    if (stocProduse[k] >= operatii[i, k])
                    {
                        vanzare++;
                    }
                    else { vanzare = -1; }
                }
                if (vanzare == nrCategProduse)
                {
                    for (int m = 0; m < nrCategProduse; m++)
                    {
                        stocProduse[m] = stocProduse[m] - operatii[i, m];
                    }
                    Console.WriteLine();
                    Console.WriteLine($"i= {i} vanzare");
                    Console.WriteLine("stoc dupa vanzare:");
                    AfisareStocuri(nrCategProduse, stocProduse);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"i= {i} vanzare neonorata");
                    Console.WriteLine("stoc:");
                    AfisareStocuri(nrCategProduse, stocProduse);
                    vanzareNeonorata++;
                }
            }
        }


        Console.WriteLine();
        Console.WriteLine($"vanzare neonorata = {vanzareNeonorata}");
        Console.WriteLine($"numar aprovizionari = {nrAprovizionari}");

        Console.WriteLine();
        Console.WriteLine("Stoc produse final: ");
        AfisareStocuri(nrCategProduse, stocProduse);

        Console.WriteLine();
        Console.WriteLine("Rezultat:");
        Console.WriteLine(vanzareNeonorata);
        Console.WriteLine(nrAprovizionari);

        Console.ReadLine();
    }

    private static void AfisareStocuri(int nrCategProduse, int[] stocProduse)
    {
        for (int i = 0; i < nrCategProduse; i++)
        {
            Console.Write(stocProduse[i] + " ");
        }
        Console.WriteLine();
    }

    static void Aprovizionare(int[] stoc, int n, int cantitateAprovizionare)
    {
        for (int i = 0; i < n; i++)
        {
            stoc[i] += cantitateAprovizionare;
        }
    }

}