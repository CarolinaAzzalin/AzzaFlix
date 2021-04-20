using System;

namespace Series
{
    public class Serie : EntidadeBase
    {
        //Atributos:

        private Genero genero {get;set;}
        private string Titulo{get;set;}
        private string Sinopse {get; set;}
        private int Ano {get; set;}
        private bool Excluido{get; set;}


        //Metodos

        public Serie(int Id, Genero genero, string titulo, string sinopse, int ano)
        {
            this.Id =Id;
            this.genero = genero;
            this.Titulo = titulo;
            this.Sinopse = sinopse;
            this.Ano =ano;
            this.Excluido =false;
        }

        public override string ToString()
        {
            // Environment.NewLine - verificar explicação no site da microsoft
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Sinopse: " + this.Sinopse + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;

            
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

          public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}