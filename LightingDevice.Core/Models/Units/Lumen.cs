namespace LightingDevice.Core.Models.Units
{
    public class Lumen
    {
        public int Value { get; }

        public static Lumen Zero => new Lumen(0);

        public Lumen(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "明るさは0以上である必要があります。");
            Value = value;
        }

        public override string ToString() => $"{Value.ToString("N0") ?? "0"} lm";

        public Lumen Clone() => new Lumen(this.Value);

        // Clamp メソッドの追加
        public Lumen Clamp(int min, int max)
        {
            return new Lumen(Math.Clamp(Value, min, max));
        }

        public static Lumen operator +(Lumen lumen, int increment)
        {
            return new Lumen(lumen.Value + increment);
        }

        public static Lumen operator -(Lumen lumen, int decrement)
        {
            return new Lumen(lumen.Value - decrement);
        }
    }
}
