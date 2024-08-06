using MediatR;

namespace Book_Evaluation_Management_System.Application.DomainEvents.ReviewBooks
{
    public class AddReviewBookEvent : INotification
    {
        public AddReviewBookEvent(int id, int livroId, int usuarioId, DateTime dataCriacao)
        {
            Id = id;
            LivroId = livroId;
            UsuarioId = usuarioId;
            DataCriacao = dataCriacao;
        }

        public int Id { get; }
        public int LivroId { get; }
        public int UsuarioId { get; }
        public DateTime DataCriacao { get; }
    }
}