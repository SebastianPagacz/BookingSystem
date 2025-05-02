using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Application.Services;
using BookingSystem.Domain.BookingExceptions;

namespace BookingSystem.Application.Tests.BookingTests;

public class BookingValidatorTests
{
    [Theory]
    [InlineData(2020, 1, 1, 2020, 1, 2, true)]
    [InlineData(2020, 12, 2, 2021, 1, 1, true)]
    [InlineData(2020, 12, 12, 2020, 12, 12, true)]
    public void ValidateDates_ChecksStartAndEnd_ReturnsCorrectValue(int startYear,int startMonth, int startDay, int endYear, int endMonth, int endDay, bool expected)
    {
        // Arrange
        var startDate = new DateTime(startYear, startMonth, startDay);
        var endDate = new DateTime(endYear, endMonth, endDay);
        var validator = new BookingValidator();

        // Act
        var result = validator.ValidateDates(startDate, endDate);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ValidateDates_ChecksStartAndEnd_ThrowsInvalidDateException()
    {
        // Arrange
        var validator = new BookingValidator();
        var startDate = new DateTime(2020, 2, 3);
        var endDate = new DateTime(2020, 2, 2);

        // Act & Assert
        Assert.Throws<InvalidDateException>(() => validator.ValidateDates(startDate, endDate));
    }
}
