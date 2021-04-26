using System;
using System.Collections.Generic;
using System.Diagnostics;
using SimpleMvvmToolkit.Express;
using System.Text;
using System.Collections.ObjectModel;
using TaskManager.Common.Models;

namespace TaskManager.Common
{
    public class MainViewModel : ViewModelBase<MainViewModel>
    {

        public ObservableCollection<Application> Apps { get; set; }

        public DelegateCommand LoadProcessesCommand => new DelegateCommand(LoadProcesses);

        public MainViewModel()
        {

        }
        private void LoadProcesses()
        {
            Apps = new ObservableCollection<Application>();
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                var app = new Application();
                app.Name = process.ProcessName;
                Apps.Add(app);
            }
        }
    }
}
