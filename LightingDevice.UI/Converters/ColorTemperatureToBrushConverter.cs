using LightingDevice.Core.Enums;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace LightingDevice.UI.Converters
{
    public class ColorTemperatureToBrushConverter : IValueConverter
    {
        // 色温度と対応するRGB値のペア
        private readonly (ColorTemperatures Temperature, Color Color)[] _colorMap =
        [
            (ColorTemperatures.Daylight, Color.FromRgb(173, 216, 230)), // 昼光色（青白い色）
            (ColorTemperatures.CoolWhite, Color.FromRgb(224, 255, 255)), // 昼白色（クールホワイト）
            (ColorTemperatures.NeutralWhite, Color.FromRgb(255, 250, 240)), // 白色（ニュートラルホワイト）
            (ColorTemperatures.WarmWhite, Color.FromRgb(255, 239, 213)), // 温白色（ウォームホワイト）
            (ColorTemperatures.BulbColor, Color.FromRgb(255, 228, 181)) // 電球色（オレンジ系）
        ];

        // 色温度からRGB値を計算するための関数
        private Color GetColorForTemperature(int colorTemperature)
        {
            // 色温度が範囲外の場合、最も近い色を返す
            if (colorTemperature >= (int)_colorMap[0].Temperature)
                return _colorMap[0].Color;
            if (colorTemperature <= (int)_colorMap[^1].Temperature)
                return _colorMap[^1].Color;

            // 範囲内の2つの色を見つける
            for (int i = 0; i < _colorMap.Length - 1; i++)
            {
                var (temp1, color1) = _colorMap[i];
                var (temp2, color2) = _colorMap[i + 1];

                if (colorTemperature <= (int)temp1 && colorTemperature >= (int)temp2)
                {
                    // 線形補完を計算
                    double ratio = (double)(colorTemperature - (int)temp2) / ((int)temp1 - (int)temp2);
                    return InterpolateColor(color1, color2, ratio);
                }
            }

            // デフォルト（ここには到達しないはず）
            return Colors.Gray;
        }

        // 2つの色を線形補完する
        private Color InterpolateColor(Color color1, Color color2, double ratio)
        {
            byte r = (byte)(color1.R + (color2.R - color1.R) * ratio);
            byte g = (byte)(color1.G + (color2.G - color1.G) * ratio);
            byte b = (byte)(color1.B + (color2.B - color1.B) * ratio);
            return Color.FromRgb(r, g, b);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int colorTemperature)
            {
                return new SolidColorBrush(GetColorForTemperature(colorTemperature));
            }
            return Brushes.Gray; // デフォルトの色
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
