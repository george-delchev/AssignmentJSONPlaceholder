using JSONPlaceholder.Svc.Managers.Posts;
using JSONPlaceholder.Svc.Models.Posts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        bool working = false;
        IPostsManager postsManager;
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                postsGridOnly.RowDefinitions.Add(new RowDefinition());
                postsGridOnly.ColumnDefinitions.Add(new ColumnDefinition());
            }
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
                MakeTextBox(item);
            }
        }
        private void MakeTextBox(Post post)
        {
            var id = post.Id;
            var col = (id - 1) % 10;
            var row = (id - 1) / 10;

            var text = new Button();
            text.Content = id.ToString();
            text.DataContext = post.UserId.ToString();
            //text.IsReadOnly = true;
            //find a different event, maybe change the element type???
            text.Click += ChangeTexts_Click;
            ;

            postsGridOnly.Children.Add(text);
            Grid.SetColumn(text, col);
            Grid.SetRow(text, row);
        }
        private void ChangeTexts_Click(object sender, RoutedEventArgs e)
        {
            if (working) return;
            working = true;
            Thread T1 = new Thread(new ThreadStart(ChangeTestsInternal));
            T1.Start();
        }
        private void ChangeTestsInternal()
        {
            this.Dispatcher.Invoke(() =>
            {
                foreach (var item in postsGridOnly.Children)
                {
                    var textBox = (Button)item;
                    var id = textBox.Content;
                    var userId = (string)textBox.DataContext;
                    textBox.Content = userId;
                    textBox.DataContext = id;
                }
            });
            working = false;
        }
    }
}
