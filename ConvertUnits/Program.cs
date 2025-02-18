using System.Threading.Channels;

Dictionary<string, Dictionary<string, double>> Conversions = new Dictionary<string, Dictionary<string, double>>()
{
    {
        "Length", new Dictionary<string, double>()
        {
            {"meters_To_kilometers", 0.001}, {"kilometers_To_meters", 1000},
            {"meters_To_miles", 0.000621371}, {"miles_To_meters", 1609.34},
            {"meters_To_feet", 3.28084}, {"feet_To_meters", 0.3048},
            {"meters_To_inches", 39.3701}, {"inches_To_meters", 0.0254},
            {"meters_To_centimeters", 100}, {"centimeters_To_meters", 0.01},
            {"kilometers_To_miles", 0.621371}, {"miles_To_kilometers", 1.60934},
            {"miles_To_feet", 5280}, {"feet_To_miles", 0.000189394},
            {"feet_To_inches", 12}, {"inches_To_feet", 0.0833333},
            {"inches_To_centimeters", 2.54}, {"centimeters_To_inches", 0.393701},
            {"feet_To_kilometers", 0.0003048}, {"kilometers_To_feet", 3280.84}
        }
    },
    {
        "Volume", new Dictionary<string, double>()
        {
            {"liters_To_milliliters", 1000}, {"milliliters_To_liters", 0.001},
            {"liters_To_cups", 4.22675}, {"cups_To_liters", 0.236588},
            {"liters_To_gallons", 0.264172}, {"gallons_To_liters", 3.78541},
            {"liters_To_fluidOunces", 33.814}, {"fluidOunces_To_liters", 0.0295735},
            {"milliliters_To_cups", 0.00422675}, {"cups_To_milliliters", 236.588},
            {"cups_To_gallons", 0.0625}, {"gallons_To_cups", 16},
            {"gallons_To_fluidOunces", 128}, {"fluidOunces_To_gallons", 0.0078125},
            {"milliliters_To_fluidOunces", 0.033814}, {"fluidOunces_To_milliliters", 29.5735}
        }
    },
    {
        "Weight", new Dictionary<string, double>()
        {
            {"kilograms_To_pounds", 2.20462}, {"pounds_To_kilograms", 0.453592},
            {"kilograms_To_grams", 1000}, {"grams_To_kilograms", 0.001},
            {"kilograms_To_ounces", 35.274}, {"ounces_To_kilograms", 0.0283495},
            {"pounds_To_grams", 453.592}, {"grams_To_pounds", 0.00220462},
            {"grams_To_ounces", 0.035274}, {"ounces_To_grams", 28.3495},
            {"pounds_To_ounces", 16}, {"ounces_To_pounds", 0.0625}
        }
    }
};
double Convert_Value(string UnitType, string Unit1, string Unit2, float Value)
{
    string SearchKey = Unit1 + "_To_" + Unit2;
    if (Conversions.ContainsKey(UnitType) && Conversions[UnitType].ContainsKey(SearchKey))
    {
        return Value * Conversions[UnitType][SearchKey];
    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Not a valid conversion");
    Console.ResetColor();
    return 0;

}
double Convert_Temperature(string Unit1, string Unit2, float Value)
{
    if (Unit1 == "Celsius")
    {
        if (Unit2 == "Kelvin")
        {
            return Value + 273.15;
        }
        if (Unit2 == "Fahrenheit")
        {
            return (Value * 9 / 5) + 32;
        }
    }
    else if (Unit1 == "Kelvin")
    {
        if (Unit2 == "Celsius")
        {
            return Value - 273.15;
        }
        if (Unit2 == "Fahrenheit")
        {
            return ((Value - 273.15) * 9 / 5) + 32;
        }
    }
    else if (Unit1 == "Fahrenheit")
    {
        if (Unit2 == "Kelvin")
        {
            return ((Value - 32) * 5 / 9) + 273.15;
        }
        if (Unit2 == "Celsius")
        {
            return (Value - 32) * 5 / 9;
        }
    }
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Invalid temperature conversion");
    Console.ResetColor();
    return 0;
}

void Convertion()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("============================");
    Console.WriteLine("      Unit Converter       ");
    Console.WriteLine("============================");
    Console.ResetColor();

    Console.Write("Enter conversion category (Length, Weight, Temperature, Volume): ");
    string Category = Console.ReadLine();
    Console.Write("Enter from unit: ");
    string Unit1 = Console.ReadLine();
    Console.Write("Enter to unit: ");
    string Unit2 = Console.ReadLine();
    Console.Write("Enter value to convert: ");
    float Value = Convert.ToInt32(Console.ReadLine());

    double Result;
    if (Category == "Temperature")
    {
         Result = Convert_Temperature(Unit1, Unit2, Value);
    }
    else 
    {
        Result = Convert_Value(Category,Unit1, Unit2, Value);
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Converted Value: " + Result);
    Console.ResetColor();
}

Convertion();