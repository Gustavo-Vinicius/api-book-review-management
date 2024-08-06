using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Book_Evaluation_Management_System.Application.DomainEvents.ReviewBooks
{
    public class AddReviewBookEventHandler : INotificationHandler<AddReviewBookEvent>
    {
        private readonly ILogger<AddReviewBookEventHandler> _logger;

        public AddReviewBookEventHandler(ILogger<AddReviewBookEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(AddReviewBookEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Avaliação criada: {notification.Id} para o livro {notification.LivroId} pelo usuário {notification.UsuarioId} em {notification.DataCriacao}");
            // Aqui você pode adicionar lógica adicional, como enviar notificações ou atualizar outros sistemas

            return Task.CompletedTask;
        }
    }
}