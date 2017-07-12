using System;
using System.IO;

namespace Pendrive
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("INFORME A LETRA DA UNIDADE PARA O PENDRIVE INSERIDO...");
            Console.WriteLine("ATENCAO: CASO INFORME A UNIDADE ERRADA, SEUS ARQUIVOS SERAO DELETADOS!");
            Console.Write(">> ");
            var letter = Console.ReadLine();

            //Segurança!
            if (letter == null || letter.ToUpper().Equals("C") || letter.ToUpper().Equals("D"))
            {
                Console.WriteLine("\nUNIDADE NAO PERMITIDA...");
                Finalizar();
                return;
            }

            letter = $@"{letter.ToUpper()}:\";
            Console.WriteLine("\nCONFIRMA A UNIDADE {0}?", letter);
            Console.Write(">> (S/N) ");
            var confirm = Console.ReadLine();

            if (confirm == null || !confirm.ToUpper().Equals("S"))
            {
                Console.WriteLine("\nENCERRANDO APLICATIVO...");
                Finalizar();
                return;
            }
            
            DirSearch(letter); //Pendrive 
            Finalizar();
        }

        private static void Finalizar()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(">> FINALIZADO");
            Console.WriteLine("@ BY MORELATO =)");
            Console.WriteLine("======================================================================");
            Console.ReadKey();
        }

        private static void DirSearch(string sDir)
        {

            foreach (var d in Directory.GetDirectories(sDir))
            {
                foreach (var f in Directory.GetFiles(d))
                {
                    var file = new FileInfo(f);
                    if (file.Extension.ToLower().Equals(".mp3") || 
                        file.Extension.ToLower().Equals(".wma") || 
                        file.Extension.ToLower().Equals(".flac"))
                        continue;

                    Console.WriteLine(f);
                    try
                    {
                        File.SetAttributes(f, FileAttributes.Normal);
                        file.Delete();
                    }
                    catch (Exception excpt)
                    {
                        Console.WriteLine(excpt.Message);
                    }
                }
                DirSearch(d);
            }
        }
    }
}
