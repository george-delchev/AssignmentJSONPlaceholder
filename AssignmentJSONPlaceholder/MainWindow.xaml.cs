using DnDApp.DataAccess.API.Services;
using JSONPlaceholder.APIAccess.Interfaces;
using JSONPlaceholder.APIAccess.Interfaces.Models;
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

namespace AssignmentJSONPlaceholder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        public Posts posts = new Posts();
        List<int> integers = new List<int>();
        bool showId;
        IJSONPlaceholderService service;
        public MainWindow()
        {
            InitializeComponent();

            //posts.Items = new List<Post>();
            //for (int i = 1; i <= 100; i++)
            //{
            //    posts.Items.Add(new Post() { id = i, userId = i });
            //    integers.Add(i);
            //}
            // postsGrid.ItemsSource = posts.Items;
            for (int i = 0; i < 10; i++)
            {
                postsGridOnly.RowDefinitions.Add(new RowDefinition());
                postsGridOnly.ColumnDefinitions.Add(new ColumnDefinition());
            }
           
            showId = true;
        }
        public MainWindow(IJSONPlaceholderService service) : this()
        {
            this.service = service;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            posts.Items = await service.GetPosts();
            foreach (var item in posts.Items)
            {
                var col = (item.id - 1) % 10;
                var row = (item.id - 1) / 10;
                var text = new TextBox();
                text.Text = item.id.ToString();
                text.IsReadOnly = true;
                text.PreviewMouseUp += ChangeTexts;
                postsGridOnly.Children.Add(text);
                Grid.SetColumn(text, col);
                Grid.SetRow(text, row);
            }
            // do some other stuff
        }
        public void ChangeTexts(object sender, RoutedEventArgs e)
        {

            foreach (var item in postsGridOnly.Children)
            {
                var id = ((TextBox)item).Text;
                var newId = 0;
                if (showId)
                {
                    newId = posts.Items.Where(x => x.id == int.Parse(id)).FirstOrDefault().userId;
                }
                else
                {
                    newId = posts.Items.Where(x => x.userId == int.Parse(id)).FirstOrDefault().id;
                }
                ((TextBox)item).Text = newId.ToString();
            }
            showId = !showId;
        }
    }
}
