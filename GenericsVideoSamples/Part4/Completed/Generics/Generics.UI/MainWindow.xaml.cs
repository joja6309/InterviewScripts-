using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using Generics.Common;
using Generics.Common.Factory;
using Generics.Common.Interface;
using Generics.Repository.PersonRepository;
using System.Linq;

namespace Generics.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NonGenericButton_Click(object sender, RoutedEventArgs e)
        {
            ArrayList people = People.GetNonGenericPeople();
            people.Add("Hello");
            people.Add(42);

            foreach (object person in people)
                PersonListBox.Items.Add(person);
        }

        private void GenericButton_Click(object sender, RoutedEventArgs e)
        {
            List<Person> people = People.GetGenericPeople();
            //people.Add("Hello");
            //people.Add(42);

            foreach (Person person in people)
                PersonListBox.Items.Add(person);
        }

        private void RepositoryButton_Click(object sender, RoutedEventArgs e)
        {
            IRepository<Person, string> repository = 
                Factory.Get<IRepository<Person, string>>();
            IEnumerable<Person> people = repository.GetItems();

            foreach (var person in people)
                PersonListBox.Items.Add(person);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PersonListBox.Items.Clear();
        }
    }
}
