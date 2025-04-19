
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LightingDevice.MVVM
{
    /// <summary>
    /// MVVM パターンにおける ViewModel の基本クラス。
    /// プロパティ変更通知機能を提供します。
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティ変更時に発生するイベント。
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged = null;

        /// <summary>
        /// プロパティ変更通知を発行します。
        /// </summary>
        /// <remarks>
        /// このメソッドは、プロパティの値が変更されたことを通知します。
        /// 通常、プロパティの setter 内で呼び出されます。
        /// </remarks>
        /// <param name="propertyName">変更されたプロパティの名前（省略可能）。</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// プロパティの値を設定し、変更通知を行います。
        /// </summary>
        /// <typeparam name="T">プロパティの型。</typeparam>
        /// <param name="field">プロパティのバックフィールド。</param>
        /// <param name="value">新しい値。</param>
        /// <param name="propertyName">変更されたプロパティの名前（省略可能）。</param>
        /// <returns>
        /// 値が変更された場合は <c>true</c>、それ以外の場合は <c>false</c>。
        /// </returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
