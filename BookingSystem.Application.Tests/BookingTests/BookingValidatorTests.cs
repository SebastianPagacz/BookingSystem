using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Application.Services;

namespace BookingSystem.Application.Tests.BookingTests;

public class BookingValidatorTests
{
    private readonly DateTime _firstDate = new DateTime(2020, 1, 1);
    private readonly DateTime _secodnDate = new DateTime(2020, 1, 2);
    private readonly DateTime _thirdDate = new DateTime(2020, 12, 2);
    private readonly DateTime _fourthDate = new DateTime(2020, 12, 1);
    private readonly DateTime _fifthDate = new DateTime(2020, 12, 12);
    [Theory]
    [InlineData(2020, 1, 1, 2020, 1, 2, true)]
    [InlineData(2020, 12, 2, 2020, 12, 1, false)]
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
}
