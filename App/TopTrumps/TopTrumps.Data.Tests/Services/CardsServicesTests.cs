﻿using TopTrumps.Data.Helpers;

namespace TopTrumps.Data.Tests.Services
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using DTOs;
    using Moq;
    using Repository;
    using TopTrumps.Data.Services;
    using Xunit;

    public class CardsServicesTests
    {
        private readonly Mock<IRepository> _repo = new Mock<IRepository>();
        private readonly Mock<ISqlHelper> _helper = new Mock<ISqlHelper>();

        [Fact]
        public async Task GetCard_ShouldReturnUsersCard()
        {
            // Arrange
            const int id = 1;
            const string sql = "SELECT";
            var expected = new Card();

            _helper.Setup(x => x.GetCardQuery(id))
                .Returns(sql);

            _repo.Setup(x => x.QuerySingleAsync<Card>(sql, It.IsAny<CancellationToken>(), id))
                .ReturnsAsync(expected);

            // Act
            var actual = await GetSubject().GetCard(id);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public async Task GetCard_ShouldReturnNull_IfCardNotFound()
        {
            // Arrange
            const int id = 1;
            const string sql = "SELECT";

            _helper.Setup(x => x.GetCardQuery(id))
                .Returns(sql);

            _repo.Setup(x => x.QuerySingleAsync<Card>(sql, It.IsAny<CancellationToken>(), null))
                .ReturnsAsync((Card)null);

            // Act
            var actual = await GetSubject().GetCard(id);

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        public async Task GetAllCards_ShouldReturnAllCardsInTheDatabase()
        {
            // Arrange
            const string sql = "SELECT";
            var expected = new List<Card> { new Card() };

            _helper.Setup(x => x.GetAllUsersQuery())
                .Returns(sql);

            _repo.Setup(x => x.QueryAsync<Card>(sql, It.IsAny<CancellationToken>(), null))
                .ReturnsAsync(expected);

            // Act
            var actual = await GetSubject().GetAllCards();

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public async Task GetPlayersCollection_ShouldReturnAllCardsInTheDatabase()
        {
            // Arrange
            const string email = "email";
            const string sql = "SELECT";

            var expected = new List<PlayersCard> { new PlayersCard() };
            
            _helper.Setup(x => x.GetCollectionSql(email))
                .Returns(sql);
            
            _repo.Setup(x => x.QueryAsync<PlayersCard>(sql, It.IsAny<CancellationToken>(), It.IsAny<object>()))
                .ReturnsAsync(expected);

            // Act
            var actual = await GetSubject().GetPlayersCollection(email);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public async Task CreateNewCard_ShouldReturnNewCardId()
        {
            // Arrange
            const string sql = "SELECT";
            const int expected = 10;
            var card = new Card();
            var token = new CancellationToken();
            
            _helper.Setup(x => x.CreateNewCardSql())
                .Returns(sql);

            _repo.Setup(x => x.QuerySingleAsync<int>(sql, token, card))
                .ReturnsAsync(expected);

            // Act
            var actual = await GetSubject().CreateNewCard(card);

            // Assert
            Assert.Equal(actual, expected);
        }

        private CardsService GetSubject()
        {
            return new CardsService(_repo.Object, _helper.Object);
        }
    }
}
