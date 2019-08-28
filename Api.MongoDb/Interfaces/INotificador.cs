using Api.MongoDb.Notificacoes;
using System.Collections.Generic;

namespace Api.MongoDb.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
