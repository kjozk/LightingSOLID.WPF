using LightingDevice.Core.Interfaces;
using LightingDevice.Core.Models;
using LightingDevice.MVVM;

namespace LightingDevice.UI.ViewModels
{
    /// <summary>
    /// 照明器具の状態を表示するための ViewModel
    /// </summary>
    /// <remaks>
    /// 解説：SRP（単一責任原則）
    /// 
    /// LightingDeviceViewModel クラスは、照明器具の状態を UI に表示するためのロジックを管理する責任を持っています。
    /// このクラスは、以下のように単一の責任を果たしています：
    /// 
    /// 1. 照明器具（ILightingDevice）の状態（電源のオン/オフ、明るさ、消費電力、色温度など）を取得し、UI に表示するデータを提供します。
    /// 2. 照明器具の操作（電源のオン/オフ、明るさの増減）を管理し、その結果を UI に反映します。
    /// 
    /// これにより、UI ロジックと照明器具の内部ロジックが分離され、コードの可読性と保守性が向上しています。
    /// 照明器具の具体的な動作（例: 明るさの増減や消費電力の計算）は、ILightingDevice や IDimmable を実装する具象クラスに委譲されています。
    /// 
    /// この設計により、LightingDeviceViewModel は単一の責任（UI ロジックの管理）に専念しており、SRP を満たしています。
    /// </remaks>
    public class LightingDeviceViewModel : ViewModelBase
    {
        private ILightingDevice _device = null!;

        public string PowerButtonText => _device?.IsOn == true ? "電源OFF" : "電源ON";
        public string BrightnessText => $"{_device?.BrightnessLm.ToString("N0") ?? "0"} lm";
        public string PowerText => $"{_device?.ConsumptionW.ToString("N1") ?? "0.0"} W";
        public string ColorTemperatureText => $"{_device?.ColorTemperature ?? 0} K";
        public bool IsSupportedBrightnessControl => _device is IDimmable;


        public LightingDeviceViewModel()
        {
        }

        /// <summary>
        /// 照明器具を設定します。
        /// </summary>
        /// <param name="device">設定する照明器具（ILightingDevice 型）。</param>
        /// <remarks>
        /// このメソッドは、指定された照明器具を ViewModel に設定し、
        /// UI に表示されるデータを更新します。
        /// </remarks>
        public void SetDevice(ILightingDevice device)
        {
            _device = device;
            NotifyAll();
        }

        /// <summary>
        /// 全てのプロパティ変更通知を発行します。
        /// </summary>
        /// <remarks>
        /// このメソッドは、UI にバインドされているプロパティの変更を通知し、
        /// UI を最新の状態に更新します。
        /// </remarks>
        private void NotifyAll()
        {
            OnPropertyChanged(nameof(PowerButtonText));
            OnPropertyChanged(nameof(BrightnessText));
            OnPropertyChanged(nameof(PowerText));
            OnPropertyChanged(nameof(ColorTemperatureText));
            OnPropertyChanged(nameof(IsSupportedBrightnessControl));
        }

        /// <summary>
        /// 照明器具の電源をオンにします。
        /// </summary>
        /// <remarks>
        /// このメソッドは、現在設定されている照明器具の電源をオンにし、UI を更新します。
        /// </remarks>
        public void TurnOn()
        {
            _device.TurnOn();
            NotifyAll();
        }

        /// <summary>
        /// 照明器具の電源をオフにします。
        /// </summary>
        /// <remarks>
        /// このメソッドは、現在設定されている照明器具の電源をオフにし、UI を更新します。
        /// </remarks>
        public void TurnOff()
        {
            _device.TurnOff();
            NotifyAll();
        }

        /// <summary>
        /// 照明器具の明るさを増加させます。
        /// </summary>
        /// <remarks>
        /// 調光機能を持つ照明器具（IDimmable）に対して、明るさを増加させる操作を行います。
        /// 調光機能がサポートされていない場合、このメソッドは何も行いません。
        /// </remarks>
        public void IncreaseBrightness()
        {
            // 悪い例：SOLID違反
            // この実装は、具体的な型（DimmableLedDevice）に依存しており、DIP（依存性逆転の原則）に違反しています。
            // また、OCP（開放/閉鎖原則）にも違反しており、新しいデバイス型を追加するたびにこのメソッドを修正する必要があります。
            if (_device is DimmableLedDevice dimmable /*ダウンキャスト*/)
            {
                dimmable.IncreaseBrightness();
                NotifyAll();
            }
        }

            /// <summary>
            /// 照明器具の明るさを減少させます。
            /// </summary>
            /// <remarks>
            /// 調光機能を持つ照明器具（IDimmable）に対して、明るさを減少させる操作を行います。
            /// 調光機能がサポートされていない場合、このメソッドは何も行いません。
            /// </remarks>
            public void DecreaseBrightness()
        {
            // 良い例：SOLID準拠
            // この実装は、抽象型（IDimmable）に依存しており、DIP（依存性逆転の原則）を満たしています。
            // また、OCP（開放/閉鎖原則）にも準拠しており、新しいデバイス型を追加してもこのメソッドを修正する必要がありません。
            if (_device is IDimmable dimmable)
            {
                dimmable.DecreaseBrightness();
                NotifyAll();
            }
        }
    }
}
