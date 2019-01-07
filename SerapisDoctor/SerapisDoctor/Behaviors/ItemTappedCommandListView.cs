using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisDoctor.Behaviors
{
    public sealed class ItemTappedCommandListView
    {

        public static readonly BindableProperty ItemTappedCommandProperty =
          BindableProperty.Create(
              "ItemTappedCommand",
              typeof(ICommand),
              typeof(ItemTappedCommandListView),
              default(ICommand),
              BindingMode.OneWay,
              null,
              PropertyChanged);

        private static void PropertyChanged(BindableObject bindable, object newValue, object oldValue)
        {
            var listview = bindable as ListView;

            if (listview != null)
            {
                listview.ItemTapped -= ListViewOnItemTapped;
                listview.ItemTapped += ListViewOnItemTapped;
            }
        }

        private static void ListViewOnItemTapped(object sender, ItemTappedEventArgs args)
        {
            var list = sender as ListView;

            if (list != null && list.IsEnabled && !list.IsRefreshing)
            {
                list.SelectedItem = null;
                var command = GetItemTappedCommand(list);
                if (command != null && command.CanExecute(args.Item))
                {
                    command.Execute(args.Item);
                }
            }
        }


        public static ICommand GetItemTappedCommand(BindableObject bindableobject)
        {
            return (ICommand)bindableobject.GetValue(ItemTappedCommandProperty);
        }

        public static void SetItemTappedCommand(BindableObject bindable, object value)
        {
            bindable.SetValue(ItemTappedCommandProperty, value);
        }

    }
}
