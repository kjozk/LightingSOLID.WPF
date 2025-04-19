namespace LightingDevice.Core.Interfaces
{
    /// <summary>
    /// 調光機能を持つ照明器具を表すインターフェース
    /// </summary>
    /// <remarks>
    /// 解説：ISP（インターフェース分離原則）
    /// 調光機能を持つ照明器具のインターフェースを定義しています。
    /// - ILightingDevice は、基本的な照明デバイスの操作（例: TurnOn, TurnOff）を定義しています。
    /// - IDimmable は、調光可能なデバイス専用の操作（例: IncreaseBrightness, DecreaseBrightness）を定義しています。
    /// - 調光機能を持たないデバイス（例: HidLightingDevice）は、IDimmable を実装する必要がありません。
    /// </remarks>
    public interface IDimmable
    {
        /// <summary>
        /// 明るさを増加させます
        /// </summary>
        void IncreaseBrightness();

        /// <summary>
        /// 明るさを減少させます
        /// </summary>
        void DecreaseBrightness();
    }

    /// <summary>
    /// 色温度調整機能を持つ照明器具を表すインターフェース
    /// </summary>
    public interface IColorTemperatureAdjustable
    {

    }

    /// <summary>
    /// タイマー機能を持つ照明器具を表すインターフェース
    /// </summary>
    public interface ITimerControllable
    {
        void SetOffTimer(TimeSpan time);
    }
}
