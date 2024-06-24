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
            if (IsTemperatureOutOfRange(temperature)) {
                Console.WriteLine("Temperature is out of range!");
                return false;
            }
            if (IsSocOutOfRange(soc)) {
                Console.WriteLine("State of Charge is out of range!");
                return false;
            }
            if (IsChargeRateOutOfRange(chargeRate)) {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }
            return true;
        }

        static void ExpectTrue(bool expression) {
            if (!expression) {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
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
