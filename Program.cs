public class Converter {
    public static void Main(string[] args) {}

	Dictionary<string, double> currencyPriceList = new() { };

    /// <summary>
    /// Angiver prisen for en enhed af en kryptovaluta. Prisen angives i dollars.
    /// Hvis der tidligere er angivet en værdi for samme kryptovaluta, 
    /// bliver den gamle værdi overskrevet af den nye værdi
    /// </summary>
    /// <param name="currencyName">Navnet på den kryptovaluta der angives</param>
    /// <param name="price">Prisen på en enhed af valutaen målt i dollars. Prisen kan ikke være negativ</param>
    public void SetPricePerUnit(String currencyName, double price) {
		if(price <= 0) {
			throw new ArgumentException("Error: Please enter a positive price.");
		}

		currencyPriceList[currencyName] = price;
    }

	public double GetPricePerUnit(String currencyName) {
		return currencyPriceList[currencyName];
	}

    /// <summary>
    /// Konverterer fra en kryptovaluta til en anden. 
    /// Hvis en af de angivne valutaer ikke findes, kaster funktionen en ArgumentException
    /// 
    /// </summary>
    /// <param name="fromCurrencyName">Navnet på den valuta, der konverterers fra</param>
    /// <param name="toCurrencyName">Navnet på den valuta, der konverteres til</param>
    /// <param name="amount">Beløbet angivet i valutaen angivet i fromCurrencyName</param>
    /// <returns>Værdien af beløbet i toCurrencyName</returns>
    public double Convert(String fromCurrencyName, String toCurrencyName, double amount) {
		double fromCurrencyUSDValuePerUnit = GetPricePerUnit(fromCurrencyName);
		double toCurrencyUSDValuePerUnit = GetPricePerUnit(toCurrencyName);
		double toCurrencyUSDTotalValue = fromCurrencyUSDValuePerUnit * amount / toCurrencyUSDValuePerUnit;

        return toCurrencyUSDTotalValue;
    }
}