using ClientApp.API;
using ClientApp.Model;
using ClientApp.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ClientApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {        
        private DispatcherTimer _dispTimer;
        private Stopwatch _stopWatch;
        //TODO move to config
        //interval beetween requests to api service
        private static int _queryInterval = 30;
        private string _currentTime;
        private string _logMessage;
        //counter tick every second
        private int _counter;

        //TODO services
        private IOpenViewService _openViewService;
        private ILogService _logService;

        private int reqId = 0;     

        #region Properties
        public string CurrentTime
        {
            get { return _currentTime; }
            set { Set(() => CurrentTime, ref _currentTime, value); }
        }

        public string LogMessage
        {
            get { return _logMessage; }
            set { Set(() => LogMessage, ref _logMessage, value); }
        }
        #endregion Properties

        #region Commands
        public RelayCommand StartTimerCommand { get; private set; }
        public RelayCommand StopTimerCommand { get; private set; }
        public RelayCommand ResetTimerCommand { get; private set; }
        public RelayCommand ClearLogCommand { get; private set; }
        #endregion Commands        

        public MainViewModel(IOpenViewService openViewService, ILogService logService)
        {
            //_openViewService = openViewService;
            //_logService = logService;
            CurrentTime = "00:00:00";
            _queryInterval = 5;
            reqId = 1;
            StartTimerCommand = new RelayCommand(StartTimer, CanStartTimer);
            StopTimerCommand = new RelayCommand(StopTimer, CanStopTimer);
            ResetTimerCommand = new RelayCommand(ResetTimer, CanResetTimer);
            ClearLogCommand = new RelayCommand(ClearLog);
        }

        #region Methods
        private async Task CallFunction()
        {
            ComputerInfo info = new ComputerInfo();
            info.Id = reqId;
            info.ComputerName = MachineName();
            info.DiskCfreeSpace = TotalFreeSpace("C:\\");
            info.UpdateTimestamp = DateTime.Now.ToUniversalTime();

            var logMessage = string.Format("Request to web service: {0}", JsonConvert.SerializeObject(info));
            WriteLogMessage(logMessage);
            try
            {
                reqId++;
                var api = new RetailGroupWebService();
                var response = await api.SendInfo(info);
                logMessage = string.Format("Response from web service: {0}", JsonConvert.SerializeObject(response));
                WriteLogMessage(logMessage);
            }
            catch (Exception ex)
            {
                logMessage = string.Format("Error: {0}", JsonConvert.SerializeObject(ex));
                WriteLogMessage(logMessage);
            }

        }

        private bool CanStartTimer()
        {
            return _dispTimer == null || (_dispTimer != null && !_stopWatch.IsRunning);
        }

        private void StartTimer()
        {
            if (_dispTimer == null)
            {
                _dispTimer = new DispatcherTimer
                {
                    Interval = new TimeSpan(0, 0, 0, 1, 0)
                };
                _dispTimer.Tick += new EventHandler(TimerTick);
                _dispTimer.Start();
            }

            if (_stopWatch == null)
                _stopWatch = new Stopwatch(); 
            _stopWatch.Start();
           
            WriteLogMessage("Timer started.");
        }

        private void WriteLogMessage(string message)
        {
            LogMessage += string.Format("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
            LogMessage += "\n\n";
        }

        private async void TimerTick(object send, EventArgs e)
        {
            if (!_stopWatch.IsRunning)
                return;

            _counter++;
            TimeSpan ts = _stopWatch.Elapsed;
            CurrentTime = string.Format("{0:00}:{1:00}:{2:00}",
            ts.Hours, ts.Minutes, ts.Seconds);

            if ((_counter % _queryInterval) == 0)
                await CallFunction();
        }

        private bool CanStopTimer()
        {
            return true;
        }

        private void StopTimer()
        {
            if (_dispTimer == null)
                return;

            _dispTimer.Stop();
            _dispTimer = null;
            _stopWatch.Stop();
            WriteLogMessage("Timer stoped.");
        }

        private bool CanResetTimer()
        {
            return true;
        }

        private void ResetTimer()
        {
            if (_stopWatch == null)
                return;

            _stopWatch.Reset();
            CurrentTime = "00:00:00";
            _counter = 0;
            WriteLogMessage("Timer reseted.");
        }

        private void ClearLog()
        {
            LogMessage = null;
        }

        private long TotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.AvailableFreeSpace;
                }
            }
            return -1;
        }

        private string MachineName()
        {
            return Environment.MachineName;
        }

        #endregion Methods
    }
}
