namespace LightingDevice.Core.Enums
{
    /// <summary>
    /// 色温度を表す列挙型（ケルビン単位）
    /// </summary>
    public enum ColorTemperatures : int
    {
        /// <summary>
        /// 電球色（約2700K）
        /// </summary>
        BulbColor = 2700,

        /// <summary>
        /// 温白色（約3500K）
        /// </summary>
        WarmWhite = 3500,

        /// <summary>
        /// 白色（約4000K）
        /// </summary>
        NeutralWhite = 4000,

        /// <summary>
        /// 昼白色（約5000K）
        /// </summary>
        CoolWhite = 5000,

        /// <summary>
        /// 昼光色（約6500K）
        /// </summary>
        Daylight = 6500
    }
}
