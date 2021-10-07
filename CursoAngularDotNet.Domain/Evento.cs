using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoAngularDotNet.Domain
{

    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}

//DataType Annotations
//[Table("Festas")] alterar o nome da tabela na criação do banco = data annotations
//[Key] Chave primária = data annotations
//[ForeignKey("Festas")] Chave estrangeira referenciando a tabela onde Id seria chave primária = data annotations
//[Required] campo obrigatório no banco = data annotations
//[NotMapped] campo não será mapeado ou criado no banco de dados = data annotations
//[MaxLength(50)] especificar tamanho máximo = data annotations
//[MinLength(50)] especificar tamanho minímo = data annotations