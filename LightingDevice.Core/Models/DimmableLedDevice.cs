using LightingDevice.Core.Interfaces;
using LightingDevice.Core.Models.Units;

namespace LightingDevice.Core.Models
{
    /// <summary>
    /// 調光可能なLED照明器具を表す抽象クラス
    /// </summary>
    public abstract class DimmableLedDevice : IDimmable, ILightingDevice
    {
        private bool _isOn;
        private Lumen _brightness;
        private Lumen _maxBrightness = new Lumen(500);
        private Lumen _minBrightness = new Lumen(100);
        private double _consumptionW;
        private int _colorTemperature;

        public DimmableLedDevice(string name, Lumen brightness, double powerConsumption = 5.0, int colorTemperature = 3000)
        {
            Name = name;
            _brightness = brightness;
            _consumptionW = powerConsumption;
            _colorTemperature = colorTemperature;
            _isOn = false;
        }

        public string Name { get; private set; }

        public bool IsOn => _isOn;

        public Lumen Brightness
        {
            get => _isOn ? _brightness : new Lumen(0);
        }

        protected Lumen MaxBrightness
        {
            get => _maxBrightness;
            set => _maxBrightness = value;
        }

        protected Lumen MinBrightness
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
            }
        }

        public void TurnOff()
        {
            if (_isOn)
            {
                _isOn = false;
            }
        }

        private double CalculatePowerConsumption(int brightness)
        {
            // 消費電力は明るさに比例して計算（例: 最大1000ルーメンで10W）
            return brightness / 100.0 * 10.0;
        }

        public void IncreaseBrightness()
        {
            _brightness = new Lumen(Math.Clamp(_brightness.Value + 10, _minBrightness.Value, _maxBrightness.Value));
            _consumptionW = CalculatePowerConsumption(_brightness.Value);
        }

        public void DecreaseBrightness()
        {
            _brightness = new Lumen(Math.Clamp(_brightness.Value - 10, _minBrightness.Value, _maxBrightness.Value));
            _consumptionW = CalculatePowerConsumption(_brightness.Value);
        }
    }

    /// <summary>
    /// 実在する調光LEDの品番の具象クラス
    /// </summary>
    public class AnyDimmableLedDevice : DimmableLedDevice
    {
        public AnyDimmableLedDevice()
            : base("調光LED XXXXX", new Lumen(500), 5.0, 5000)
        {
            this.MaxBrightness = new Lumen(1000);
            this.MinBrightness = new Lumen(100);
        }
    }
}
