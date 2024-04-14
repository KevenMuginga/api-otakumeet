using Core.domain;

namespace CoreShared.modelsView.mensagens
{
    public class NovaMensagem
    {
        public string Descricao { get; set; }
        public int PersonagemId { get; set; }
        public int ToGrupoId { get; set; }
    }
}
