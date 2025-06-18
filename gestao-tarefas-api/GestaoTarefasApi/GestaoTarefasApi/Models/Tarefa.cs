namespace GestaoTarefasApi.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string Prioridade { get; set; } = "Media"; //baixa, média e alta
        public string Status { get; set; } = "Pendente"; //pendente, em andamento, concluido
    }
}
