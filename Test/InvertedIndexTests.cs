using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using SearchConsoleApp;
using Xunit;

namespace Test
{
    public class InvertedIndexTests
    {
        [Theory]
        [AutoData]
        public void WHEN_Search_ForBrown_RETURNS_Documents_With_RightIndex(
            [Frozen] Mock<IDocumentIndexer> documentIndexerMock,
            InvertedIndex invertedIndex, DocumentIndexer documentIndexer)
        {
            // Arrange
            var fixture = new Fixture();
            documentIndexerMock.Setup(d => d.IndexDocuments(It.IsAny<ISearchEngine>())).Callback<ISearchEngine>(engine =>
            {
                documentIndexer.IndexDocuments(engine);
            });
            documentIndexerMock.Object.IndexDocuments(invertedIndex);
            string term = "brown";

            // Act
            var result = invertedIndex.Search(term);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("the brown fox jumped over the brown dog", result[0]);
            Assert.Equal("the lazy brown dog sat in the corner", result[1]);
        }

        [Theory]
        [AutoData]
        public void WHEN_Search_ForFox_RETURNS_Documents_With_RightIndex(
            [Frozen] Mock<IDocumentIndexer> documentIndexerMock,
            InvertedIndex invertedIndex, DocumentIndexer documentIndexer)
        {
            // Arrange
            var fixture = new Fixture();
            documentIndexerMock.Setup(d => d.IndexDocuments(It.IsAny<ISearchEngine>())).Callback<ISearchEngine>(engine =>
            {
                documentIndexer.IndexDocuments(engine);
            });
            documentIndexerMock.Object.IndexDocuments(invertedIndex);
            string term = "fox";

            // Act
            var result = invertedIndex.Search(term);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("the red fox bit the lazy dog", result[0]);
            Assert.Equal("the brown fox jumped over the brown dog", result[1]);
        }
    }
}