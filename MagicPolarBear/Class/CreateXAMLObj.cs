using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.UI.Popups;
namespace MagicPolarBear.Class
{
    static class CreateXAMLObj
    {

        public static Grid CreateGrid(Style s, Grid g)
        {
            Grid newG = new Grid();
            newG.Style = s;


            g.Children.Add(newG);

            return newG;

        }
   
        public static TextBox CreateTextBox(string name,Style s, Grid g)
        {

            TextBox tB = new TextBox();

            tB.Name = name;
            tB.Style = s;
           

            g.Children.Add(tB);

            return tB;
        }

        public static TextBlock CreateTextBlock(string txt, Style s, Grid g)
        {
            TextBlock tB = new TextBlock();

            tB.Text = txt;
            tB.Style = s;
            g.Children.Add(tB);

            return tB;
        }

        public static Button CreateButton(string name, Style s, string content, RoutedEventHandler button_Click, Grid g)
        {
            Button button = new Button();

            button.Name = name + "_Button";
            button.Style = s;
            button.Content = content;
            button.Click += button_Click;

            g.Children.Add(button);

            return button;
        }
        


        public static PopupMenu CreatePopup(String[] list)
        {
            PopupMenu p = new PopupMenu();
            
            
            for (int i = 0; i < list.Length; i++)
            {
                p.Commands.Add(new UICommand(list[i]));

                p.Commands[i].Id = list.Length - i - 1;
            }
            

            return p;
        }

    }
}
