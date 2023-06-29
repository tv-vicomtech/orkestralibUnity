/**
 *  << Copyright 2022 Iñigo Tamayo Uria, Ana Domínguez Fanlo, Mikel Joseba Zorrilla Berasategui, Guillermo Pacho Rodríguez, Bruno Simões and Stefano Masneri. >>
 *  This file is part of orkestralibUnity.
 *  orkestralibUnity is free software: you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
 *  orkestralibUnity is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 *  You should have received a copy of the GNU Lesser General Public License along with orkestralibUnity. If not, see <https://www.gnu.org/licenses/>.
 **/
using System;
using System.Threading;
using System.Threading.Tasks;

namespace H.WebSockets.Utilities
{
    /// <summary>
    /// A class designed to run code using <see cref="Task"/> with <see cref="TaskCreationOptions.LongRunning"/> <br/>
    /// and supporting automatic cancellation after Dispose <br/>
    /// <![CDATA[Version: 1.0.0.8]]> <br/>
    /// </summary>
    internal class TaskWorker : IDisposable
#if NETSTANDARD2_1
        , IAsyncDisposable
#endif
    {
        #region Fields

        private volatile bool _isDisposed;

        #endregion

        #region Properties

        /// <summary>
        /// Is Disposed
        /// </summary>
        public bool IsDisposed => _isDisposed;

        /// <summary>
        /// Internal task
        /// </summary>
        public Task Task { get; set; } = Task.FromResult(false);

        /// <summary>
        /// Internal task CancellationTokenSource
        /// </summary>
        public CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

        #endregion

        #region Events

        /// <summary>
        /// When canceled
        /// </summary>
        public event EventHandler? Canceled;

        /// <summary>
        /// When completed(with any result)
        /// </summary>
        public event EventHandler? Completed;

        /// <summary>
        /// When completed(without exceptions and cancellations)
        /// </summary>
        public event EventHandler? SuccessfulCompleted;

        /// <summary>
        /// When completed(without exceptions)
        /// </summary>
        public event EventHandler<OperationCanceledException?>? SuccessfulCompletedOrCanceled;

        /// <summary>
        /// When canceled or exceptions
        /// </summary>
        public event EventHandler<Exception>? FailedOrCanceled;

        /// <summary>
        /// When a exception occurs(without OperationCanceledException's)
        /// </summary>
        public event EventHandler<Exception>? ExceptionOccurred;

        private void OnCanceled()
        {
            Canceled?.Invoke(this, EventArgs.Empty);
        }

        private void OnCompleted()
        {
            Completed?.Invoke(this, EventArgs.Empty);
        }

        private void OnSuccessfulCompleted()
        {
            SuccessfulCompleted?.Invoke(this, EventArgs.Empty);
        }

        private void OnSuccessfulCompletedOrCanceled(OperationCanceledException? value)
        {
            SuccessfulCompletedOrCanceled?.Invoke(this, value);
        }

        private void OnFailedOrCanceled(Exception value)
        {
            FailedOrCanceled?.Invoke(this, value);
        }

        private void OnExceptionOccurred(Exception value)
        {
            ExceptionOccurred?.Invoke(this, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts <see cref="TaskWorker"/>
        /// </summary>
        /// <param name="func"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Start(Func<CancellationToken, Task> func)
        {
            func = func ?? throw new ArgumentNullException(nameof(func));

            if (_isDisposed)
            {
                throw new InvalidOperationException("The task worker is disposed");
            }
            if (!Task.IsCompleted)
            {
                throw new InvalidOperationException("The task worker already started");
            }

            Task = Task.Factory.StartNew(async () =>
            {
                try
                {
                    await func(CancellationTokenSource.Token).ConfigureAwait(false);

                    OnSuccessfulCompleted();
                    OnSuccessfulCompletedOrCanceled(null);
                }
                catch (OperationCanceledException exception)
                {
                    OnCanceled();
                    OnFailedOrCanceled(exception);
                    OnSuccessfulCompletedOrCanceled(exception);
                }
                catch (Exception exception)
                {
                    OnExceptionOccurred(exception);
                    OnFailedOrCanceled(exception);
                }

                OnCompleted();
            }, CancellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        /// <summary>
        /// Starts <see cref="TaskWorker"/>
        /// </summary>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Start(Action<CancellationToken> action)
        {
            action = action ?? throw new ArgumentNullException(nameof(action));

            Start(cancellationToken =>
            {
                action(cancellationToken);

                return Task.FromResult(false);
            });
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// Cancel task(if it's not completed) and dispose internal resources <br/>
        /// Prefer DisposeAsync if possible <br/>
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;

            CancellationTokenSource.Cancel();
            CancellationTokenSource.Dispose();
        }

#if NETSTANDARD2_1
    /// <summary>
    /// Cancel task(if it's not completed) and dispose internal resources <br/>
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;

        if (Task != Task.CompletedTask)
        {
            CancellationTokenSource.Cancel();

            try
            {
                await Task.ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
            }

            // Some system code can still use CancellationToken, so we wait
            await Task.Delay(TimeSpan.FromMilliseconds(1)).ConfigureAwait(false);
        }

        CancellationTokenSource.Dispose();
        Task.Dispose();
    }
#endif

        #endregion
    }

}

