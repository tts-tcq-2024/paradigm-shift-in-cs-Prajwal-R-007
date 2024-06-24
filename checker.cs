using System;

class Checker
{
    static bool BatteryIsOk(float temperature, float soc, float chargeRate)
    {
        bool isOk = true;

        if (RangeChecker.CheckTemperature(temperature) != RangeChecker.RangeStatus.Ok)
        {
            ReportOutOfRange("Temperature", temperature);
            isOk = false;
        }

        if (RangeChecker.CheckSoc(soc) != RangeChecker.RangeStatus.Ok)
        {
            ReportOutOfRange("State of Charge", soc);
            isOk = false;
        }

        if (RangeChecker.CheckChargeRate(chargeRate) != RangeChecker.RangeStatus.Ok)
        {
            ReportOutOfRange("Charge Rate", chargeRate);
            isOk = false;
        }

        return isOk;
    }

    static void ReportOutOfRange(string parameterName, float value)
    {
        RangeChecker.RangeStatus status;

        switch (parameterName)
        {
            case "Temperature":
                status = RangeChecker.CheckTemperature(value);
                Console.WriteLine($"Temperature is {(status == RangeChecker.RangeStatus.Low ? "low" : "high")}!");
                break;
            case "State of Charge":
                status = RangeChecker.CheckSoc(value);
                Console.WriteLine($"State of Charge is {(status == RangeChecker.RangeStatus.Low ? "low" : "high")}!");
                break;
            case "Charge Rate":
                status = RangeChecker.CheckChargeRate(value);
                Console.WriteLine("Charge Rate is high!");
                break;
            default:
                break;
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
