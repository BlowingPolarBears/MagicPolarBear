using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MagicPolarBear
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

       
        const int _MAXPlayers = 4;
    

        TextBox[] textBoxPlayer;
        TextBlock[] textBlockPlayer;
        
        int noPlayers;

        

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            textBlockPlayer = new TextBlock[_MAXPlayers];
            textBoxPlayer = new TextBox[_MAXPlayers];

           
            for (int i = 0; i < _MAXPlayers; i++)
            {
                textBlockPlayer[i] = Class.CreateXAMLObj.CreateTextBlock("Player " + (i + 1), Resources["TextBlockStyle_"+i] as Style ,Grid_1);
                textBoxPlayer[i] = Class.CreateXAMLObj.CreateTextBox("Player" + i, Resources["TextBoxStyle_" + i] as Style, Grid_1); 
            }
                 


        }


        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {



            ComboBox comboBox = (ComboBox)sender;
            
            ComboBoxItem currentItem = ((Windows.UI.Xaml.Controls.ComboBoxItem)ComboBoxNoPlayers.SelectedItem);

            noPlayers = Convert.ToInt32(currentItem.Content);

            for (int i = 0; i < _MAXPlayers ; i++)
            {


                if (i < noPlayers)
                {
                    textBoxPlayer[i].Visibility = Visibility.Visible;
                    textBlockPlayer[i].Visibility = Visibility.Visible;
                }
                else
                {
                    textBoxPlayer[i].Visibility = Visibility.Collapsed;
                    textBlockPlayer[i].Visibility = Visibility.Collapsed;
                }

            }

            
      
            StartGameButton.Visibility = Visibility.Visible;
        }

        private void StartGameButton_Click_1(object sender, RoutedEventArgs e)
        {
            Class.Player[] player = new Class.Player[noPlayers];


            for (int i = 0; i < noPlayers; i++)
            {
                if (textBoxPlayer[i].Text == "")
                    player[i] = new Class.Player("Player" + (i + 1));
                else
                    player[i] = new Class.Player(textBoxPlayer[i].Text);
            }
    



            player[int.Parse(Class.Dice.Rnd(noPlayers))].Dealer = true;

            this.Frame.Navigate(typeof(MagicPage),player);
        }
        

    }
}
