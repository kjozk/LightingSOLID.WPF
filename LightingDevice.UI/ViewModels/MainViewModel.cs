using LightingDevice.Core.Interfaces;
using LightingDevice.Core.Models;
using LightingDevice.MVVM;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace LightingDevice.UI.ViewModels
{
    /// <summary>
    /// アプリケーションのメイン ViewModel クラス。
    /// 照明デバイスの管理や、UI バインディング用のプロパティとコマンドを提供します。
    /// </summary>    
    internal class MainViewModel : ViewModelBase
    {
        private LightingDeviceViewModel _lightingDeviceViewModel;

        /// <summary>
        /// 現在の照明デバイスの ViewModel。
        /// 照明デバイスの操作や状態管理を担当します。
        /// </summary>
        public LightingDeviceViewModel LightingDeviceViewModel
        {
            get => _lightingDeviceViewModel;
            set => SetProperty(ref _lightingDeviceViewModel, value);
        }

        private ILightingDevice _currentLightingDevice;

        /// <summary>
        /// 現在選択されている照明デバイス。
        /// 選択が変更されると、対応する ViewModel にデバイスが設定されます。
        /// </summary>
        public ILightingDevice CurrentLightingDevice
        {
            get => _currentLightingDevice;
            set
            {
                if (SetProperty(ref _currentLightingDevice, value))
                {
                    try
                    {
                        LightingDeviceViewModel.SetDevice(CurrentLightingDevice);
                    }
                    catch (Exception ex)
                    {
                        // ログ出力やエラーハンドリングを追加
                        Debug.WriteLine($"Error setting device: {ex.Message}"); 
                    }     
                }
            }
        }

        /// <summary>
        /// 利用可能な照明デバイスのコレクション。
        /// UI でデバイスを選択するために使用されます。
        /// </summary>
        public ObservableCollection<ILightingDevice> AvailableLightingDevices { get; } = new ObservableCollection<ILightingDevice>();

        /// <summary>
        /// 照明デバイスをオンにするコマンド。
        /// </summary>
        public ICommand TurnOnCommand { get; }

        /// <summary>
        /// 照明デバイスをオフにするコマンド。
        /// </summary>
        public ICommand TurnOffCommand { get; }

        /// <summary>
        /// 照明デバイスの明るさを増加させるコマンド。
        /// </summary>
        public ICommand IncreaseBrightnessCommand { get; }

        /// <summary>
        /// 照明デバイスの明るさを減少させるコマンド。
        /// </summary>
        public ICommand DecrementBrightnessCommand { get; }

        /// <summary>
        /// MainViewModel のコンストラクタ。
        /// 照明デバイスの初期化とコマンドの設定を行います。
        /// </summary>
        public MainViewModel()
        {
            // 照明デバイスの ViewModel を初期化
            this.LightingDeviceViewModel = new LightingDeviceViewModel();

            // サンプルの照明デバイスを追加（実際のデバイスクラスを使用）
            this.AvailableLightingDevices.Add(new AnyDimmableLedDevice());
            this.AvailableLightingDevices.Add(new MetalHalideLightingDevice());
            this.AvailableLightingDevices.Add(new HighPressureSodiumLightingDevice());
            this.AvailableLightingDevices.Add(new LowPressureSodiumLightingDevice());
            this.AvailableLightingDevices.Add(new MercuryVaporLightingDevice());

            // 初期の照明デバイスを設定（デフォルトで最初のデバイスを選択）
            this.CurrentLightingDevice = AvailableLightingDevices.First();

            // コマンドを初期化
            TurnOnCommand = new DelegateCommand(
                _ => LightingDeviceViewModel.TurnOn(),
                _ => LightingDeviceViewModel != null);

            TurnOffCommand = new DelegateCommand(
                _ => LightingDeviceViewModel.TurnOff(),
                _ => LightingDeviceViewModel != null);

            IncreaseBrightnessCommand = new DelegateCommand(
                _ => LightingDeviceViewModel.IncreaseBrightness(),
                _ => LightingDeviceViewModel.IsSupportedBrightnessControl);

            DecrementBrightnessCommand = new DelegateCommand(
                _ => LightingDeviceViewModel.DecreaseBrightness(),
                _ => LightingDeviceViewModel.IsSupportedBrightnessControl);
        }
    }
}
