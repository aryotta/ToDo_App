using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ToDo_App
{
    public class TaskItem
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<TaskItem> _allTasks = new ObservableCollection<TaskItem>();

        public MainWindow()
        {
            InitializeComponent();
            TaskDataGrid.ItemsSource = _allTasks;
        }

        private void TaskCreateButton(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.Name.Text))
            {
                MessageBox.Show("Please enter a task name");
                return;
            }

            var newTask = new TaskItem()
            {
                Name = this.Name.Text.Trim(),
                Description = Description.Text.Trim(),
                Time = Time.Text.Trim()
            };

            _allTasks.Add(newTask);

            if (!SearchComboBox.Items.Contains(newTask.Name))
            {
                SearchComboBox.Items.Add(newTask.Name);
            }

            this.Name.Clear();
            Description.Clear();
            Time.Clear();
        }
    }
}