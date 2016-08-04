using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirtualServer
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Server serv;
        Simulator sim;
        BackgroundWorker simloader = new BackgroundWorker();
        string filepath;
        string SimStartTime;
        string SimStartDate;
        string SimEndTime;
        string SimEndDate;
        public MainWindow()
        {
            InitializeComponent();
            ContinueButton.IsEnabled = false;
            MessageEvents.WaitingForRecieve += MessageEvents_MessageSend;
            MessageEvents.RecievedMessage += MessageEvents_RecievedMessage;
            simloader.DoWork += Simloader_DoWork;
            simloader.RunWorkerCompleted += Simloader_RunWorkerCompleted;
            StartDate.IsEnabled = false;
            EndDate.IsEnabled = false;
            StartTime.IsEnabled = false;
            EndTime.IsEnabled = false;
        }

        private void Simloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Progress.Value = 100;
            OpenFileButton.IsEnabled = true;
            StartDate.IsEnabled = true;
            EndDate.IsEnabled = true;
            StartTime.IsEnabled = true;
            EndTime.IsEnabled = true;
            SimStartDate = sim.StartDate.ToShortDateString();
            SimEndDate = sim.EndDate.ToShortDateString();
            SimStartTime = sim.StartDate.ToLongTimeString();
            SimEndTime = sim.EndDate.ToLongTimeString();
            StartTime.Text = SimStartDate + " " + SimStartTime;
            EndTime.Text = SimEndDate + " " + SimEndTime;
        }

        private void Simloader_DoWork(object sender, DoWorkEventArgs e)
        {
            sim = new Simulator(filepath);
        }

        private void MessageEvents_RecievedMessage(object sender, MessageEvents.MessageEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                MessageInfoRecieved.Content = e.Message;
            }));
        }

        private void MessageEvents_MessageSend(object sender, MessageEvents.MessageEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                MessageInfoLabel.Content = e.Message;
            }));
        }

        private void StartServer_Click(object sender, RoutedEventArgs e)
        {
            if (serv == null)
            {
                sim.StartDate = DateTime.Parse(StartTime.Text);
                sim.EndDate = DateTime.Parse(EndTime.Text);
                serv = new Server(int.Parse(PortTextBox.Text), sim);
                StartServer.Content = "Перезапустить симуляцию";
                MessageInfoRecieved.Content = "Ожидание подключения";
                MessageInfoLabel.Content = "Ожидание подключения";
            }
            else
            {
                serv.StopServer();
                sim.StartDate = DateTime.Parse(StartTime.Text);
                sim.EndDate = DateTime.Parse(EndTime.Text);
                serv = new Server(int.Parse(PortTextBox.Text), sim);
                MessageInfoRecieved.Content = "Ожидание подключения";
                MessageInfoLabel.Content = "Ожидание подключения";
            }
            ContinueButton.IsEnabled = true;
            PortTextBox.IsEnabled = false;
            StartDate.IsEnabled = false;
            EndDate.IsEnabled = false;
            StartTime.IsEnabled = false;
            EndTime.IsEnabled = false;
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            if ((bool)diag.ShowDialog())
            {
                filepath = diag.FileName;
                StartDate.IsEnabled = false;
                EndDate.IsEnabled = false;
                StartTime.IsEnabled = false;
                EndTime.IsEnabled = false;
                Progress.Value = 1;
                OpenFileButton.IsEnabled = false;
                simloader.RunWorkerAsync();
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            MessageEvents.Continue();
        }

        private void StartTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
