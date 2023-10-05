using Xunit;

public class ProgramTest {
    [Theory]
	[InlineData("DOGE", 0.00000000001)]
    public void Check_that_setting_and_getting_price_works(string currencyName, double price) {
		// Arrange
        Converter crypto = new();

		// Act
        crypto.SetPricePerUnit(currencyName, price);

		// Assert
        Assert.Equal(price, crypto.GetPricePerUnit(currencyName));
    }

    [Theory]
	[InlineData("ETC", 0)]
	[InlineData("BTC", -0.00000000001)]
    public void Check_that_less_than_or_equal_to_zero_throws_an_exception(string currencyName, double price) {
		// Arrange
        Converter crypto = new();

		// Assert
        Assert.Throws<ArgumentException>(() => crypto.SetPricePerUnit(currencyName, price));
    }
	
    [Theory]
	[InlineData("DOGE", 0.01, "BTC", 10000, 1, 0.000001)]
	[InlineData("DOGE", 0.01, "BTC", 10000, -1, -0.000001)]
    public void Check_that_price_can_be_converted_correctly(string fromCurrencyName, double fromCurrencyUSDValue, string toCurrencyName, double toCurrencyUSDValue, double amount, double expected) {
		// Arrange
        Converter crypto = new();

		// Act
        crypto.SetPricePerUnit(fromCurrencyName, fromCurrencyUSDValue);
        crypto.SetPricePerUnit(toCurrencyName, toCurrencyUSDValue);

		// Assert
        Assert.Equal(expected, crypto.Convert(fromCurrencyName, toCurrencyName, amount));
    }
}