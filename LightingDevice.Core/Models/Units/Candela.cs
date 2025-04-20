namespace LightingDevice.Core.Models.Units
{
    public class Candela
    {
        public double Value { get; }

        public Candela(double value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "カンデラは0以上である必要があります。");
            Value = value;
        }

        public override string ToString() => $"{Value} cd";
    }
}
