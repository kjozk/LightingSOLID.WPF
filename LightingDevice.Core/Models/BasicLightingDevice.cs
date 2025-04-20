using LightingDevice.Core.Interfaces;
using LightingDevice.Core.Models.Units;

namespace LightingDevice.Core.Models
{
    /// <summary>
    /// 抽象クラス: 基本的な電気照明器具を表します。
    /// </summary>
    public abstract class BasicLightingDevice : ILightingDevice
    {
        private bool _isOn;
        private Lumen _brightness;
        private double _ratedPowerW;
        private double _maintenanceRate;

        /// <summary>
        /// コンストラクタ: HID照明器具の基本情報を設定します。
        /// </summary>
        /// <param name="name">照明器具の名前（型番など）</param>
        /// <param name="brightness">明るさ（ルーメン）</param>
        /// <param name="ratedPowerW">定格電力（ワット）</param>
        /// <param name="colorTemperature">色温度（ケルビン）</param>
        protected BasicLightingDevice(string name, Lumen brightness, double ratedPowerW, int colorTemperature)
        {
            Name = name;
            _brightness = brightness.Clone();
            _ratedPowerW = ratedPowerW;
            ColorTemperature = colorTemperature;
            _maintenanceRate = 1.0; // 初期状態は新品
            _isOn = false; // 初期状態は消灯
        }

        /// <summary>
        /// 照明器具の名前（型番など）
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 現在点灯しているかどうか
        /// </summary>
        public bool IsOn => _isOn;

        /// <summary>
        /// 現在の明るさ（ルーメン）
        /// 点灯している場合は設定された明るさに保守率を掛けた値を返し、消灯している場合は 0 を返します。
        /// </summary>
        public Lumen Brightness => new Lumen(_isOn ? (int)(_brightness.Value * _maintenanceRate) : 0);

        /// <summary>
        /// 現在の消費電力（ワット）
        /// 点灯している場合は定格電力を返し、消灯している場合は 0 を返します。
        /// </summary>
        public double ConsumptionW => _isOn ? _ratedPowerW : 0;

        /// <summary>
        /// 色温度（ケルビン）
        /// </summary>
        public int ColorTemperature { get; }

        /// <summary>
        /// 保守率（0.0 ～ 1.0）
        /// 経年劣化を考慮した明るさの割合を表します。
        /// </summary>
        public double MaintenanceRate
        {
            get => _maintenanceRate;
            set
            {
                if (value < 0.0 || value > 1.0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Maintenance rate must be between 0.0 and 1.0.");
                _maintenanceRate = value;
            }
        }

        /// <summary>
        /// 照明を点灯または消灯します。
        /// </summary>
        /// <param name="turnOn">true の場合は点灯、false の場合は消灯。</param>
        private void SetPowerState(bool turnOn)
        {
            _isOn = turnOn;
        }

        /// <summary>
        /// 照明を点灯します。
        /// </summary>
        public void TurnOn() => SetPowerState(true);

        /// <summary>
        /// 照明を消灯します。
        /// </summary>
        public void TurnOff() => SetPowerState(false);

        /// <summary>
        /// 保守率を更新します。
        /// 経年劣化をシミュレートするために使用します。
        /// </summary>
        /// <param name="degradationRate">劣化率（0.0 ～ 1.0）</param>
        public void Degrade(double degradationRate)
        {
            if (degradationRate < 0.0 || degradationRate > 1.0)
                throw new ArgumentOutOfRangeException(nameof(degradationRate), "Degradation rate must be between 0.0 and 1.0.");
            MaintenanceRate = Math.Max(0.0, _maintenanceRate - degradationRate);
        }
    }
}
