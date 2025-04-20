using LightingDevice.Core.Interfaces;
using LightingDevice.Core.Models.Units;

namespace LightingDevice.Core.Models
{
    /// <summary>
    /// 昼光色 LED 照明器具を表す具象クラス
    /// </summary>
    public class DaylightLedLightingDevice : BasicLightingDevice
    {
        private const string DeviceName = "LED照明（昼光色）";
        private const int BrightnessLm = 600;
        private const double RatedPower = 6.0;
        private const int ColorTemp = 6000;

        public DaylightLedLightingDevice()
            : base(DeviceName, new Lumen(BrightnessLm), RatedPower, ColorTemp)
        {
        }
    }

    /// <summary>
    /// 昼白色 LED 照明器具を表す具象クラス
    /// </summary>
    public class CoolWhiteLedLightingDevice : BasicLightingDevice
    {
        private const string DeviceName = "LED照明（昼白色）";
        private const int BrightnessLm = 500;
        private const double RatedPower = 5.0;
        private const int ColorTemp = 5000;

        public CoolWhiteLedLightingDevice()
            : base(DeviceName, new Lumen(BrightnessLm), RatedPower, ColorTemp)
        {
        }
    }

    /// <summary>
    /// 電球色 LED 照明器具を表す具象クラス
    /// </summary>
    public class WarmWhiteLedLightingDevice : BasicLightingDevice
    {
        private const string DeviceName = "LED照明（電球色）";
        private const int BrightnessLm = 400;
        private const double RatedPower = 4.0;
        private const int ColorTemp = 3000;

        public WarmWhiteLedLightingDevice()
            : base(DeviceName, new Lumen(BrightnessLm), RatedPower, ColorTemp)
        {
        }
    }
}

