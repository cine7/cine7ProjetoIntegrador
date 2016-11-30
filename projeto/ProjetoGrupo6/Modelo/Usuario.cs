using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGrupo6.Modelo
{
    public class Usuario
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }
        public string pais { get; set; }
        public string sexo { get; set; }
        public string caminhoImagem { get; set; }

        // Construtor
        public Usuario()
        {
            this.usuario = "";
            this.nome = "";
            this.senha = "";
            this.email = "";
            this.dataNascimento = DateTime.Now;
            this.pais = "";
            this.sexo = "";
            this.caminhoImagem = "";
        }
        public Usuario(string ausuario, string anome, string aemail, DateTime adataNascimento, string apais, string asenha, string acaminhoImagem)
        {
            this.usuario = ausuario;
            this.nome = anome;
            this.email = aemail;
            this.dataNascimento = adataNascimento;
            this.pais = apais;
            this.senha = asenha;
        }
        public Usuario(string ausuario, string asenha, string anome, string aemail, DateTime adataNascimento, string apais, string asexo, string acaminhoImagem)
        {
            this.usuario = ausuario;
            this.senha = asenha;
            this.nome = anome;
            this.email = aemail;
            this.dataNascimento = adataNascimento;
            this.pais = apais;
            this.sexo = asexo;
            this.caminhoImagem = acaminhoImagem;
        }
    }
}