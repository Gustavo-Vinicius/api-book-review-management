using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Book_Evaluation_Management_System.Application.Commands.Book.DeleteBook;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using Moq;
using Xunit;

namespace Book_Evaluation_Management_System.Tests.CommandTests
{
    public class DeleteBookCommandTests
    {
        [Fact]
        public async Task Handle_Should_Call_DeleteBookAsync_With_Correct_Id()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();
            var handler = new DeleteBookCommandHandler(mockRepository.Object);

            var validCommand = new DeleteBookCommand
            {
                Id = 1 // Simula um ID válido
            };

            // Act
            await handler.Handle(validCommand, CancellationToken.None);

            // Assert
            mockRepository.Verify(repo => repo.DeleteBookAsync(validCommand.Id), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Id_Is_Zero()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();
            var handler = new DeleteBookCommandHandler(mockRepository.Object);

            var invalidCommand = new DeleteBookCommand
            {
                Id = 0 // Simula um ID inválido (0)
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(invalidCommand, CancellationToken.None));

            // Verifica que o método DeleteBookAsync nunca foi chamado
            mockRepository.Verify(repo => repo.DeleteBookAsync(It.IsAny<int>()), Times.Never);
        }
    }
}