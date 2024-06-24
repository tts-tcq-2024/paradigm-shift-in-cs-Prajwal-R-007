using System;

class Checker
{
    static bool IsBatteryOk(float temperature, float soc, float chargeRate)
    {
        bool isTemperatureOk = RangeChecker.CheckTemperature(temperature) == RangeChecker.RangeStatus.Ok;
        bool isSocOk = RangeChecker.CheckSoc(soc) == RangeChecker.RangeStatus.Ok;
        bool isChargeRateOk = RangeChecker.CheckChargeRate(chargeRate) == RangeChecker.RangeStatus.Ok;

        return isTemperatureOk && isSocOk && isChargeRateOk;
    }

    static void ReportBatteryStatus(float temperature, float soc, float chargeRate)
    {
        if (RangeChecker.CheckTemperature(temperature) != RangeChecker.RangeStatus.Ok)
        {
            ReportOutOfRange("Temperature", temperature);
        }

        if (RangeChecker.CheckSoc(soc) != RangeChecker.RangeStatus.Ok)
        {
            ReportOutOfRange("State of Charge", soc);
        }

        if (RangeChecker.CheckChargeRate(chargeRate) != RangeChecker.RangeStatus.Ok)
        {
            ReportOutOfRange("Charge Rate", chargeRate);
        }
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

    static class RangeChecker
    {
        public enum RangeStatus
        {
            Ok,
            Low,
            High
        }

        public static RangeStatus CheckTemperature(float temperature)
        {
            if (temperature < 0)
                return RangeStatus.Low;
            else if (temperature > 45)
                return RangeStatus.High;
            else
                return RangeStatus.Ok;
        }

        public static RangeStatus CheckSoc(float soc)
        {
            if (soc < 20)
                return RangeStatus.Low;
            else if (soc > 80)
                return RangeStatus.High;
            else
                return RangeStatus.Ok;
        }

        public static RangeStatus CheckChargeRate(float chargeRate)
        {
            if (chargeRate > 0.8f)
                return RangeStatus.High;
            else
                return RangeStatus.Ok;
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
