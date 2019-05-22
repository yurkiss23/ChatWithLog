﻿using Client.Entities;
using Client.Models;
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
using System.Windows.Shapes;

namespace Client.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private EFContext _context;
        public string UserName { get; set; }
        public string UserPass { get; set; }
        //private List<UserModel> _userList;
        public LoginWindow()
        {
            InitializeComponent();
            _context = new EFContext();
        }

        //public bool IsVer()
        //{

        //    try
        //    {
        //        MessageBox.Show("!!!");
        //        foreach (var item in _userList)
        //        {
        //            MessageBox.Show(item.Id.ToString());
        //            if (item.Name == txtLoginName.Text)
        //            {
        //                MessageBox.Show("is find!");
        //                break;
        //            }
        //        }
        //        var user = _context.Users.Where(u => u.Name == txtLoginName.Text).First();
        //        MessageBox.Show(user.ToString());
        //        MessageBox.Show("is find!");
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserName = txtLoginName.Text;
            UserPass = txtPass.Password;
            MessageBox.Show(UserName + " " + UserPass);
            //User tmp = _context.Users.Select()
            //MessageBox.Show(tmp.Id.ToString() + " " + tmp.Photo);
            if (string.IsNullOrEmpty(txtPass.Password))
            {
                lblErr.Content = "pass null or empty!";
                if (MessageBox.Show("try again?", "!!!", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(txtLoginName.Text+" "+txtPass.Password);
                
            }

            MainWindow main = new MainWindow();
            main.ShowDialog();


            //if (main.ShowDialog() == false)
            //{
            //    this.Close();
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_userList = new List<UserModel>(_context.Users.Select(u => new UserModel()
            //{
            //    Id = u.Id,
            //    Name = u.Name,
            //    Password = u.Password,
            //    Photo = u.Photo
            //}).ToList());
            txtLoginName.Focus();
        }

        private void SelectionChanged_Text(object sender, RoutedEventArgs e)
        {
            btnLogin.IsEnabled = true;
        }
    }
}
