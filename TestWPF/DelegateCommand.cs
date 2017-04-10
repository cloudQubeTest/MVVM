﻿//using System;
//using System.Windows.Input;

//namespace PatientMVVM
//{
//    internal class DelegateCommand : ICommand
//    {
//        private Action convertText;

//        public DelegateCommand(Action convertText)
//        {
//            this.convertText = convertText;
//        }
//    }
//}

using System;
using System.Windows.Input;

namespace PatientMVVM
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged { add { } remove { } }
#pragma warning restore 67
    }
}