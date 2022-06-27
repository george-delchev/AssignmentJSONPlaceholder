using JSONPlaceholder.Svc.Managers.Posts;
using JSONPlaceholder.Svc.Models.Posts;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AssignmentJSONPlaceholder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    public partial class MainWindow : Window
    {
        List<Post> posts = new List<Post>();
        bool showId;
        IPostsManager postsManager;
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                postsGridOnly.RowDefinitions.Add(new RowDefinition());
                postsGridOnly.ColumnDefinitions.Add(new ColumnDefinition());
            }

            showId = true;
        }
        public MainWindow(IPostsManager postsManager) : this()
        {
            this.postsManager = postsManager;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            posts = await postsManager.GetPosts();
            foreach (var item in posts)
            {
                MakeTextBox(item.Id);
            }
        }
        private void MakeTextBox(int id)
        {
            var col = (id - 1) % 10;
            var row = (id - 1) / 10;

            var text = new TextBox();
            text.Text = id.ToString();
            text.IsReadOnly = true;
            //find a different event, maybe change the element type???
            text.MouseDoubleClick += ChangeTexts;

            postsGridOnly.Children.Add(text);
            Grid.SetColumn(text, col);
            Grid.SetRow(text, row);
        }
        private void ChangeTexts(object sender, RoutedEventArgs e)
        {
            foreach (var item in postsGridOnly.Children)
            {
                var id = ((TextBox)item).Text;
                var newId = 0;
                if (showId)
                {
                    newId = posts.Where(x => x.Id == int.Parse(id)).FirstOrDefault().UserId;
                }
                else
                {
                    newId = posts.Where(x => x.UserId == int.Parse(id)).FirstOrDefault().Id;
                }
                ((TextBox)item).Text = newId.ToString();
            }
            showId = !showId;
        }
    }
}
