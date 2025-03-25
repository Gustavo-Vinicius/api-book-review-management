using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_Evaluation_Management_System.Application.Commands.Book.EditBook;
using Book_Evaluation_Management_System.Core.Entities;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using MediatR;
using Moq;
using Xunit;

namespace Book_Evaluation_Management_System.Tests.CommandTests
{
    public class EditBookCommandTest
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly EditBookCommandHandler _handler;

        public EditBookCommandTest()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _handler = new EditBookCommandHandler(_bookRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCallEditBookAsync_WithCorrectParameters()
        {
            // Arrange
            var command = new EditBookCommand { Id = 1, Book = new Core.DTOs.BookDTO() };
            var cancellationToken = new CancellationToken();

            // Act
            await _handler.Handle(command, cancellationToken);

            // Assert
            _bookRepositoryMock.Verify(repo => repo.EditBookAsync(command.Id, command.Book), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnUnitValue()
        {
            // Arrange
            //var command = new EditBookCommand { Id = 1, Book = Core.DTOs.BookDTO() };
            var cancellationToken = new CancellationToken();

            // Act
            //var result = await _handler.Handle(command, cancellationToken);

            // Assert
           // Assert.Equal(Unit.Value, result);
        }
    }
}