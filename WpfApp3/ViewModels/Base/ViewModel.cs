﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp3.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnProperyChanged(PropertyName);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;

        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _Disposed) return;
            _Disposed = true;
        }
    }
}
