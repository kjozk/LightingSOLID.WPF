using LightingDevice.Core.Models.Units;

namespace LightingDevice.Core.Models
{

    /// <summary>
    /// メタルハライドを表す具象クラス
    /// </summary>
    /// <remarks>
    /// このクラスは、HidLightingDevice を継承し、メタルハライドランプの仕様を実装します。
    /// </remarks>
    public class MetalHalideLightingDevice : BasicLightingDevice
    {
        private const string DeviceName = "メタルハライド MH1000";
        private const int BrightnessLm = 100000;
        private const double Power = 1000;
        private const int ColorTemp = 5500;

        public MetalHalideLightingDevice()
            : base(DeviceName, new Lumen(BrightnessLm), Power, ColorTemp)
        {
        }
    }

    /// <summary>
    /// 高圧ナトリウム灯を表す具象クラス
    /// </summary>
    public class HighPressureSodiumLightingDevice : BasicLightingDevice
    {
        private const string DeviceName = "高圧ナトリウム灯 HPS400";
        private const int BrightnessLm = 50000;
        private const double Power = 400;
        private const int ColorTemp = 2000;

        public HighPressureSodiumLightingDevice()
            : base(DeviceName, new Lumen(BrightnessLm), Power, ColorTemp)
        {
        }
    }

    /// <summary>
    /// 低圧ナトリウム灯を表す具象クラス
    /// </summary>
    public class LowPressureSodiumLightingDevice : BasicLightingDevice
    {
        private const string DeviceName = "低圧ナトリウム灯 LPS180";
        private const int BrightnessLm = 23000;
        private const double Power = 180;
        private const int ColorTemp = 1800;

        public LowPressureSodiumLightingDevice()
            : base(DeviceName, new Lumen(BrightnessLm), Power, ColorTemp)
        {
        }
    }

    /// <summary>
    /// 水銀灯ランプを表す具象クラス
    /// </summary>
    public class MercuryVaporLightingDevice : BasicLightingDevice
    {
        private const string DeviceName = "水銀灯 MV400";
        private const int BrightnessLm = 50000;
        private const double Power = 400;
        private const int ColorTemp = 4500;

        public MercuryVaporLightingDevice()
            : base(DeviceName, new Lumen(BrightnessLm), Power, ColorTemp)
        {
        }
    }
}
