using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Bogus;
using Book_Evaluation_Management_System.Core.Interfaces.Repositories;
using Book_Evaluation_Management_System.Application.Commands.Book.RegisterNewBook;

namespace Book_Evaluation_Management_System.Tests.CommandTests
{
    public class RegisterNewBookCommandTests
    {
        [Fact]
        public async Task Handle_Should_Call_AddBookAsync_With_Correct_Parameters()
        {
            // Arrange
            var faker = new Faker();
            var mockRepository = new Mock<IBookRepository>();

            var handler = new RegisterNewBookCommandHandler(mockRepository.Object);

            // Cria um arquivo temporário para o teste
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllBytes(tempFilePath, faker.Random.Bytes(100)); // Dados simulados para a imagem

            var fakeCommand = new RegisterNewBookCommand
            {
                Title = faker.Lorem.Sentence(),
                Description = faker.Lorem.Paragraph(),
                ISBN = faker.Random.String2(13, "0123456789"),
                Author = faker.Name.FullName(),
                PublishingCompany = faker.Company.CompanyName(),
                Gender = faker.Commerce.Categories(1)[0],
                YearOfPublication = faker.Date.Past(20).Year,
                QuantityPages = faker.Random.Int(50, 1000),
                CreationDate = faker.Date.Recent(),
                AverageGrade = Convert.ToDecimal(faker.Random.Double(1.0, 5.0)),
                BookCover = tempFilePath
            };

            // Act
            await handler.Handle(fakeCommand, CancellationToken.None);

            // Assert
            mockRepository.Verify(repo => repo.AddBookAsync(
                fakeCommand.Title,
                fakeCommand.Description,
                fakeCommand.ISBN,
                fakeCommand.Author,
                fakeCommand.PublishingCompany,
                fakeCommand.Gender,
                fakeCommand.YearOfPublication,
                fakeCommand.QuantityPages,
                fakeCommand.CreationDate,
                fakeCommand.AverageGrade,
                File.ReadAllBytes(tempFilePath) // Verifica se os bytes do arquivo foram usados
            ), Times.Once);

            // Remove o arquivo temporário após o teste
            File.Delete(tempFilePath);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_BookCover_Path_Is_Invalid()
        {
            // Arrange
            var mockRepository = new Mock<IBookRepository>();
            var handler = new RegisterNewBookCommandHandler(mockRepository.Object);

            var invalidCommand = new RegisterNewBookCommand
            {
                Title = "Test Book",
                Description = "Test Description",
                ISBN = "1234567890123",
                Author = "Test Author",
                PublishingCompany = "Test Publisher",
                Gender = "Fiction",
                YearOfPublication = 2023,
                QuantityPages = 100,
                CreationDate = DateTime.Now,
                AverageGrade = Convert.ToDecimal(4.5),
                BookCover = "invalidPath.jpg" // Caminho inválido
            };

            // Act & Assert
            await Assert.ThrowsAsync<FileNotFoundException>(() => handler.Handle(invalidCommand, CancellationToken.None));

            // Verifica que AddBookAsync não foi chamado
            mockRepository.Verify(repo => repo.AddBookAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<DateTime>(),
                It.IsAny<decimal>(),
                It.IsAny<byte[]>()
            ), Times.Never);
        }
    }
}