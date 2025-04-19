using System.Windows.Input;

namespace LightingDevice.MVVM
{
    /// <summary>
    /// 汎用的なコマンドを実装するクラス。
    /// MVVM パターンにおける ICommand の実装として使用されます。
    /// </summary>
    public class DelegateCommand : ICommand
    {
        private readonly Action<object>? _execute;
        private readonly Predicate<object>? _canExecute;

        /// <summary>
        /// 実行アクションのみを指定してコマンドを初期化します。
        /// </summary>
        /// <param name="execute">コマンド実行時に呼び出されるアクション。</param>
        /// <exception cref="ArgumentNullException">execute が null の場合にスローされます。</exception>
        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        /// <summary>
        /// 実行アクションと実行可能条件を指定してコマンドを初期化します。
        /// </summary>
        /// <param name="execute">コマンド実行時に呼び出されるアクション。</param>
        /// <param name="canExecute">コマンドが実行可能かどうかを判定する条件。</param>
        /// <exception cref="ArgumentNullException">execute が null の場合にスローされます。</exception>
        public DelegateCommand(Action<object> execute, Predicate<object>? canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// コマンドが実行可能かどうかを判定します。
        /// </summary>
        /// <param name="parameter">コマンドに渡されるパラメータ。</param>
        /// <returns>コマンドが実行可能な場合は true、それ以外の場合は false。</returns>
        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        /// <param name="parameter">コマンドに渡されるパラメータ。</param>
        public void Execute(object parameter) => _execute?.Invoke(parameter);

        /// <summary>
        /// コマンドの実行可能状態が変更されたことを通知します。
        /// </summary>
        /// <remarks>
        /// このメソッドを呼び出すことで、UI に対してコマンドの状態が変更されたことを通知できます。
        /// 通常、プロパティ変更時に呼び出されます。
        /// </remarks>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// コマンドの実行可能状態が変更されたときに発生するイベント。
        /// </summary>
        public event EventHandler? CanExecuteChanged = null;
    }
}