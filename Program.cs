using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new  SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = OpcaoDoUsuario();
            
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Incluir();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                       Excluir();
                        break;
                    case "5":
                       Assistir();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException ("Obrigado por utilizar nossos serviços.");

                }

                opcaoUsuario = OpcaoDoUsuario();
            }

        }

        private static void Listar()
        {
           Console.WriteLine ("Listar Séries");

           var lista = repositorio.Lista();
           if(lista.Count ==0)
           {
               Console.WriteLine("Nenhuma série cadastrada!");               
           } 
           foreach (var serie in lista)
           {
               Console.WriteLine("#ID {0}: -{1}", serie.retornaId(), serie.retornaTitulo());
           }
        }

        private static void Incluir()
        { 
            Console.WriteLine("Incluir nova Série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradagenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite título da série: ");
            string entradatitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de criação da série: ");
            int entradaano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Sinopse da Série: ");
            string entradasinopse = Console.ReadLine();

            Serie novaSerie = new Serie( Id: repositorio.ProximoId(), 
                                        genero: (Genero)entradagenero, 
                                        titulo:entradatitulo, 
                                        ano:entradaano,
                                        sinopse:entradasinopse);

            repositorio.Insere(novaSerie);        

        }
           
        
        
        private static void Atualizar()
        { 
            Console.WriteLine("Digite o ID da Série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradagenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite título da série: ");
            string entradatitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de criação da série: ");
            int entradaano = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Sinopse da Série: ");
            string entradasinopse = Console.ReadLine();

            Serie atualizaSerie = new Serie( Id: indiceSerie, 
                                        genero: (Genero)entradagenero, 
                                        titulo:entradatitulo, 
                                        ano:entradaano,
                                        sinopse:entradasinopse);

            repositorio.Atualiza(indiceSerie,atualizaSerie);        

        }

        private static void Excluir()
        {
            Console.WriteLine("Digite o ID da Série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);           

        }

        private static void Assistir()
        {
            Console.WriteLine("Digite o ID da Série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);

        }

    
        
        private static string OpcaoDoUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Bem vindo ao AzzaFlix! ");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Incluir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Assistir série");
            Console.WriteLine("C - Limpar");
            Console.WriteLine("X - SAIR");
            Console.WriteLine();

            String opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
