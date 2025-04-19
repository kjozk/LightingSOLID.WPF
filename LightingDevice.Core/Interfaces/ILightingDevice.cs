namespace LightingDevice.Core.Interfaces
{
    /// <summary>
    /// 古典的な電気照明器具を表すインターフェース
    /// </summary>
    public interface ILightingDevice
    {
        /// <summary>
        /// 照明を点灯します
        /// </summary>
        void TurnOn();

        /// <summary>
        /// 照明を消灯します
        /// </summary>
        void TurnOff();

        /// <summary>
        /// 照明器具の名前（型番など）を取得します
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 現在点灯しているかどうか
        /// </summary>
        bool IsOn { get; }

        /// <summary>
        /// 現在の明るさ（ルーメン）
        /// 単位が分かるようにハンガリアン記法を用いた命名とする
        /// </summary>
        int BrightnessLm { get; }

        /// <summary>
        /// 現在の消費電力（ワット）
        /// </summary>
        double ConsumptionW { get; }

        /// <summary>
        /// 色温度（ケルビン、例: 2700K = 電球色、6500K = 昼光色）
        /// </summary>
        int ColorTemperature { get; }
    }
}
