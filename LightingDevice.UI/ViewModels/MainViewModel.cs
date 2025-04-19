using LightingDevice.Core.Interfaces;
using LightingDevice.Core.Models;
using LightingDevice.MVVM;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LightingDevice.UI.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private LightingDeviceViewModel _lightingDeviceViewModel;

        public LightingDeviceViewModel LightingDeviceViewModel
        {
            get => _lightingDeviceViewModel;
            set => SetProperty(ref _lightingDeviceViewModel, value);
        }

        private ILightingDevice _currentLightingDevice;

        // CurrentLightingDevice プロパティ
        public ILightingDevice CurrentLightingDevice
        {
            get => _currentLightingDevice;
            set
            {
                if (SetProperty(ref _currentLightingDevice, value))
                {
                    // 現在の照明器具が変更されたとき、新しい ViewModel を設定
                    LightingDeviceViewModel.SetDevice(CurrentLightingDevice);
                }
            }
        }

        public ObservableCollection<ILightingDevice> AvailableLightingDevices { get; } = [];


        public ICommand TurnOnCommand { get; }
        public ICommand TurnOffCommand { get; }
        public ICommand IncreaseBrightnessCommand { get; }
        public ICommand DecrementBrightnessCommand { get; }

        public MainViewModel()
        {
            this.LightingDeviceViewModel = new LightingDeviceViewModel();

            // サンプルの照明器具を追加（実際の照明器具クラスを追加する）
            this.AvailableLightingDevices.Add(new AnyDimmableLedDevice());
            this.AvailableLightingDevices.Add(new MetalHalideLightingDevice());
            this.AvailableLightingDevices.Add(new HighPressureSodiumLightingDevice());
            this.AvailableLightingDevices.Add(new LowPressureSodiumLightingDevice());
            this.AvailableLightingDevices.Add(new MercuryVaporLightingDevice());

            // 初期の照明器具設定（デフォルトで LED 照明器具を選択）
            this.CurrentLightingDevice = AvailableLightingDevices.First();

            TurnOnCommand = new DelegateCommand(_ => LightingDeviceViewModel.TurnOn(), _ => LightingDeviceViewModel != null);
            TurnOffCommand = new DelegateCommand(_ => LightingDeviceViewModel.TurnOff(), _ => LightingDeviceViewModel != null);
            IncreaseBrightnessCommand = new DelegateCommand(_ => LightingDeviceViewModel.IncreaseBrightness(), _ => LightingDeviceViewModel.IsSupportedBrightnessControl);
            DecrementBrightnessCommand = new DelegateCommand(_ => LightingDeviceViewModel.DecreaseBrightness(), _ => LightingDeviceViewModel.IsSupportedBrightnessControl);
        }

        // 追加のロジック（必要なら）
        public void Initialize()
        {
            // 例えば、初期化処理や設定があればここに記述
        }
    }
}
