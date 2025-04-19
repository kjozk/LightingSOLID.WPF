using LightingDevice.Core.Interfaces;

namespace LightingDevice.Core.Models
{
    /// <summary>
    /// 調光可能なLED照明器具を表す抽象クラス
    /// </summary>
    public abstract class DimmableLedDevice : IDimmable, ILightingDevice
    {
        private bool _isOn;
        private int _brightness;
        private int _maxBrightness = 500;
        private int _minBrightness = 100;
        private double _consumptionW;
        private int _colorTemperature;

        public DimmableLedDevice(string name, int brightness = 500, double powerConsumption = 5.0, int colorTemperature = 3000)
        {
            Name = name;
            _brightness = brightness;
            _consumptionW = powerConsumption;
            _colorTemperature = colorTemperature;
            _isOn = false;
        }

        public string Name { get; private set; }

        public bool IsOn => _isOn;

        public int BrightnessLm
        {
            get => _isOn ? _brightness : 0;
        }

        protected int MaxBrightnessLm
        {
            get => _maxBrightness;
            set => _maxBrightness = value;
        }

        protected int MinBrightnessLm
        {
            get => _minBrightness;
            set => _minBrightness = value;
        }

        public double ConsumptionW
        {
            get => _consumptionW;
        }

        public int ColorTemperature
        {
            get => _colorTemperature;
            set
            {
                if (value < 2000 || value > 6500)
                    throw new ArgumentOutOfRangeException(nameof(value), "Color temperature must be between 2000K and 6500K.");
                _colorTemperature = value;
            }
        }

        public void TurnOn()
        {
            if (!_isOn)
            {
                _isOn = true;
                Console.WriteLine($"{Name} is now ON.");
            }
        }

        public void TurnOff()
        {
            if (_isOn)
            {
                _isOn = false;
                Console.WriteLine($"{Name} is now OFF.");
            }
        }

        private double CalculatePowerConsumption(int brightness)
        {
            // 消費電力は明るさに比例して計算（例: 最大1000ルーメンで10W）
            return brightness / 100.0 * 10.0;
        }

        public void IncreaseBrightness()
        {
            _brightness = Math.Clamp(_brightness + 10, _minBrightness, _maxBrightness);
            _consumptionW = CalculatePowerConsumption(_brightness);
        }

        public void DecreaseBrightness()
        {
            _brightness = Math.Clamp(_brightness - 10, _minBrightness, _maxBrightness);
            _consumptionW = CalculatePowerConsumption(_brightness);
        }
    }

    /// <summary>
    /// 実在する調光LEDの品番の具象クラス
    /// </summary>
    public class AnyDimmableLedDevice : DimmableLedDevice
    {
        public AnyDimmableLedDevice()
            : base("調光LED XXXXX", 500, 5.0, 5000)
        {
            this.MaxBrightnessLm = 1000;
            this.MinBrightnessLm = 100;
        }
    }
}
