using System;

namespace paradigm_shift_csharp
{
    class Checker
    {
        static bool IsTemperatureOutOfRange(float temperature) {
            return temperature < 0 || temperature > 45;
        }

        static bool IsSocOutOfRange(float soc) {
            return soc < 20 || soc > 80;
        }

        static bool IsChargeRateOutOfRange(float chargeRate) {
            return chargeRate > 0.8f;
        }

static bool BatteryIsOk(float temperature, float soc, float chargeRate) {
    bool isTemperatureOk = !IsTemperatureOutOfRange(temperature);
    bool isSocOk = !IsSocOutOfRange(soc);
    bool isChargeRateOk = !IsChargeRateOutOfRange(chargeRate);

    if (!isTemperatureOk) {
        Console.WriteLine("Temperature is out of range!");
    }
    if (!isSocOk) {
        Console.WriteLine("State of Charge is out of range!");
    }
    if (!isChargeRateOk) {
        Console.WriteLine("Charge Rate is out of range!");
    }

    return isTemperatureOk && isSocOk && isChargeRateOk;
}

        static void ExpectFalse(bool expression) {
            if (expression) {
                Console.WriteLine("Expected false, but got true");
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
