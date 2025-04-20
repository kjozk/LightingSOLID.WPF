namespace LightingDevice.Core.Models.Units
{
    public class Lumen
    {
        public int Value { get; }

        public Lumen(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "明るさは0以上である必要があります。");
            Value = value;
        }

        public override string ToString() => $"{Value.ToString("N0") ?? "0"} lm";
    }
}
