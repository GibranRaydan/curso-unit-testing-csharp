using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        private readonly StringOperations strOperation = new();

        [Fact]
        public void ConcatenateStrings()
        {
            // Arrange

            // Act
            var result = strOperation.ConcatenateStrings("Hello", "World");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello World", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange

            // Act
            var result = strOperation.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange

            // Act
            var result = strOperation.IsPalindrome("Hello");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            // Arrange

            // Act
            var result = strOperation.RemoveWhitespace("a b c");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("abc", result);
        }

        [Fact]
        public void QuantityInWords()
        {
            // Arrange

            // Act
            var result = strOperation.QuantityInWords("cat", 10);

            // Assert
            Assert.StartsWith("ten", result);
            Assert.Contains("cats", result);
        }


        [Fact]
        public void GetStringLength_Exception()
        {
            Assert.ThrowsAny<ArgumentNullException>(()
               => strOperation.GetStringLength(null));
        }

        [Fact]
        public void GetStringLength()
        {
            // Arrange

            // Act
            var result = strOperation.GetStringLength("Hello");

            // Assert
            Assert.Equal(5, result);
        }

        
        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var result = strOperation.FromRomanToNumber(romanNumber);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperationsLoggerMock = new StringOperations(mockLogger.Object);

            var result = strOperationsLoggerMock.CountOccurrences("Hello World", 'l');
            
            Assert.Equal(3, result);
        }
        
        [Fact]
        public void ReadFile()
        {
            // Arrange
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");

            // Act
            var result = strOperation.ReadFile(mockFileReader.Object, "file.txt");

            // Assert
            Assert.Equal("Reading file", result);
        }
    }
}
