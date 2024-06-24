class Checker
{
    static bool BatteryIsOk(float temperature, float soc, float chargeRate)
    {
        bool isTemperatureOk = RangeChecker.CheckTemperature(temperature) == RangeChecker.RangeStatus.Ok;
        bool isSocOk = RangeChecker.CheckSoc(soc) == RangeChecker.RangeStatus.Ok;
        bool isChargeRateOk = RangeChecker.CheckChargeRate(chargeRate) == RangeChecker.RangeStatus.Ok;

        if (!isTemperatureOk || !isSocOk || !isChargeRateOk)
        {
            ReportOutOfRange(temperature, soc, chargeRate);
        }

        return isTemperatureOk && isSocOk && isChargeRateOk;
    }

    static void ReportOutOfRange(float temperature, float soc, float chargeRate)
    {
        if (RangeChecker.CheckTemperature(temperature) != RangeChecker.RangeStatus.Ok)
        {
            Console.WriteLine($"Temperature is {(temperature < 0 ? "low" : "high")}!");
        }
        if (RangeChecker.CheckSoc(soc) != RangeChecker.RangeStatus.Ok)
        {
            Console.WriteLine($"State of Charge is {(soc < 20 ? "low" : "high")}!");
        }
        if (RangeChecker.CheckChargeRate(chargeRate) != RangeChecker.RangeStatus.Ok)
        {
            Console.WriteLine("Charge Rate is high!");
        }
    }
    
    static void ExpectFalse(bool expression) {
            if (expression) {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
        }

        static void ExpectTrue(bool expression) {
            if (!expression) {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
        }

        static int Main() {
            ExpectTrue(BatteryIsOk(25, 70, 0.7f));
            ExpectFalse(BatteryIsOk(50, 85, 0.0f));
            Console.WriteLine("All ok");
            return 0;
        }
    }
}
