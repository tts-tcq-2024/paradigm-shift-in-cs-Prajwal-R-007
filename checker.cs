using System;

public static class Checker
{
    public static bool BatteryIsOk(float temperature, float soc, float chargeRate)
    {
        bool isTemperatureOk = RangeChecker.CheckTemperature(temperature) == RangeChecker.RangeStatus.Ok;
        bool isSocOk = RangeChecker.CheckSoc(soc) == RangeChecker.RangeStatus.Ok;
        bool isChargeRateOk = RangeChecker.CheckChargeRate(chargeRate) == RangeChecker.RangeStatus.Ok;

        return isTemperatureOk && isSocOk && isChargeRateOk;
    }

    private static void ValidateSoc(float soc)
    {
        if (RangeChecker.CheckSoc(soc) != RangeChecker.RangeStatus.Ok)
        {
            Console.WriteLine($"State of Charge is {(soc < 20 ? "low" : "high")}!");
        }
    }

    private static void ValidateTemperature(float temperature)
    {
        if (RangeChecker.CheckTemperature(temperature) != RangeChecker.RangeStatus.Ok)
        {
            Console.WriteLine($"Temperature is {(temperature < 0 ? "low" : "high")}!");
        }
    }

    private static void ValidateChargeRate(float chargeRate)
    {
        if (RangeChecker.CheckChargeRate(chargeRate) != RangeChecker.RangeStatus.Ok)
        {
            Console.WriteLine("Charge Rate is high!");
        }
    }

    private static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }

    private static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }

    public static int Main()
    {
        ExpectTrue(BatteryIsOk(25, 70, 0.7f));
        ExpectFalse(BatteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
}

internal static class RangeChecker
{
    internal enum RangeStatus
    {
        Ok,
        Low,
        High
    }

    internal static RangeStatus CheckTemperature(float temperature)
    {
        if (temperature < 0)
            return RangeStatus.Low;
        else if (temperature > 45)
            return RangeStatus.High;
        else
            return RangeStatus.Ok;
    }

    internal static RangeStatus CheckSoc(float soc)
    {
        if (soc < 20)
            return RangeStatus.Low;
        else if (soc > 80)
            return RangeStatus.High;
        else
            return RangeStatus.Ok;
    }

    internal static RangeStatus CheckChargeRate(float chargeRate)
    {
        if (chargeRate > 0.8f)
            return RangeStatus.High;
        else
            return RangeStatus.Ok;
    }
}
