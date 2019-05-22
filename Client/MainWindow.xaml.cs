using Client.Entities;
using Client.Helpers;
using Client.Models;
using Client.Windows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EFContext _context;
        public int UserId { get; set; }
        public string ImgBase64string { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            _context = new EFContext();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var msg = new MessegeModel
                {
                    Id = UserId,
                    Messege = txtMessege.Text
                };

                var strJson = JsonConvert.SerializeObject(msg);

                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint ep = new IPEndPoint(ip, 1098);
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                try
                {
                    s.Connect(ep);
                    if (s.Connected)
                    {
                        s.Send(Encoding.UTF8.GetBytes(strJson));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
                MessageBox.Show("sending to server complite");
                scope.Complete();
            }
            MessageBox.Show("transaction complite");
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            imgSender.Source = ImageHelper.BitmapToImageSource(ImageHelper.Base64ToImg(
                _context.Users.Where(u => u.Id == UserId).First().Photo));
            txtMessege.Focus();
        }
    }
}
