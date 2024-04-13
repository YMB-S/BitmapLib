using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace BitmapLib
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly int TARGET_FRAMES_PER_SECOND = 60;

        SimulationDisplay display;
        DispatcherTimer timer;

        public MainWindow()
        {
            display = new SimulationDisplay();
            SetupSimulationTimer(TARGET_FRAMES_PER_SECOND);

            InitializeComponent();
        }

        private void SetupSimulationTimer(int targetFramesPerSecond)
        {
            int milliseconds = 1000 / targetFramesPerSecond;
            timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, milliseconds)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            display.Update();

            var image = display.GetImage();
            ImageDisplay.Source = image;
        }

    }
}
