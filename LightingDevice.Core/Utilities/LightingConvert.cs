using LightingDevice.Core.Models.Units;

namespace LightingDevice.Core.Utilities
{
    /// <summary>
    /// 照明関連の単位変換を行うユーティリティクラス
    /// </summary>
    public static class LightingConvert
    {
        /// <summary>
        /// ルーメンをカンデラに変換します。
        /// </summary>
        /// <param name="lumen">ルーメン値</param>
        /// <param name="beamAngle">ビーム角（度）。例: 120度。</param>
        /// <returns>カンデラ値</returns>
        public static Candela LumenToCandela(Lumen lumen, double beamAngle)
        {
            if (beamAngle <= 0 || beamAngle > 360)
                throw new ArgumentOutOfRangeException(nameof(beamAngle), "ビーム角は0度より大きく、360度以下である必要があります。");

            // カンデラ = ルーメン / (2π * (1 - cos(ビーム角/2)))
            double beamAngleRadians = beamAngle * Math.PI / 180.0;
            double candelaValue = lumen.Value / (2 * Math.PI * (1 - Math.Cos(beamAngleRadians / 2)));

            return new Candela(candelaValue);
        }

        /// <summary>
        /// カンデラをルーメンに変換します。
        /// </summary>
        /// <param name="candela">カンデラ値</param>
        /// <param name="beamAngle">ビーム角（度）。例: 120度。</param>
        /// <returns>ルーメン値</returns>
        public static Lumen CandelaToLumen(Candela candela, double beamAngle)
        {
            if (beamAngle <= 0 || beamAngle > 360)
                throw new ArgumentOutOfRangeException(nameof(beamAngle), "ビーム角は0度より大きく、360度以下である必要があります。");

            // ルーメン = カンデラ * (2π * (1 - cos(ビーム角/2)))
            double beamAngleRadians = beamAngle * Math.PI / 180.0;
            double lumenValue = candela.Value * (2 * Math.PI * (1 - Math.Cos(beamAngleRadians / 2)));

            return new Lumen((int)lumenValue);
        }
    }
}