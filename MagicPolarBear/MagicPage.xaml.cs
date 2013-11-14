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

using MagicPolarBear.Class;

//using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238


namespace MagicPolarBear
{
    enum Reset
    {
        resetScore, Draw
    }


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MagicPage : Page
    {
        Class.Player[] _player;
        Class.PlayerArea[] pArea;


        public MagicPage()
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


            _player = (Class.Player[])e.Parameter;


            pArea = new Class.PlayerArea[_player.Length];

            switch (_player.Length)
            {
                case 2:
                    drawPlayerArea("Grid2PlayerAreaStyle_");
                    break;
                case 3:
                    drawPlayerArea("Grid3PlayerAreaStyle_");
                    break;

                case 4:
                    drawPlayerArea("Grid4PlayerAreaStyle_");
                    break;
                default:
                    break;
            }

           
            

            

            //switch (_player.Length)
            //{
            //    case 2:
            //        pArea[0] = new Class.PlayerArea(_player[0], Grid_1, playerNameStyle, HorizontalAlignment.Left, VerticalAlignment.Center);              
            //            pArea[0].DrawArea();
            //            pArea[1] = new Class.PlayerArea(_player[1], Grid_1, playerNameStyle, HorizontalAlignment.Right, VerticalAlignment.Center);              
            //            pArea[1].DrawArea();
            //            break;
            //    case 3:
            //            pArea[0] = new Class.PlayerArea(_player[0], Grid_1, playerNameStyle, HorizontalAlignment.Left, VerticalAlignment.Top);
            //            pArea[0].DrawArea();
            //            pArea[1] = new Class.PlayerArea(_player[1], Grid_1, playerNameStyle, HorizontalAlignment.Right, VerticalAlignment.Top);
            //            pArea[1].DrawArea();
            //            pArea[2] = new Class.PlayerArea(_player[2], Grid_1, playerNameStyle, HorizontalAlignment.Center, VerticalAlignment.Bottom);
            //            pArea[2].DrawArea();
            //            break;
            //    case 4:
            //            pArea[0] = new Class.PlayerArea(_player[0], Grid_1, playerNameStyle, HorizontalAlignment.Left, VerticalAlignment.Top);
            //            pArea[0].DrawArea();
            //            pArea[1] = new Class.PlayerArea(_player[1], Grid_1, playerNameStyle, HorizontalAlignment.Right, VerticalAlignment.Top);
            //            pArea[1].DrawArea();
            //            pArea[2] = new Class.PlayerArea(_player[2], Grid_1, playerNameStyle, HorizontalAlignment.Left, VerticalAlignment.Bottom);
            //            pArea[2].DrawArea();
            //            pArea[3] = new Class.PlayerArea(_player[3], Grid_1, playerNameStyle, HorizontalAlignment.Right, VerticalAlignment.Bottom);
            //            pArea[3].DrawArea();
            //            break;
            //    default:
            //        break;
            //}

            GameCounter.Text = _player[0].NumberOfGames.ToString();

                                  
 
        }

        //ResetMenu. 
        private void ResetMenu_Invoke(Windows.UI.Popups.IUICommand iUIC)
        {
            
            
      
            switch ((int)iUIC.Id)
            {
                case (int)Reset.Draw:
                    foreach (Player p in _player)
                    {
                        p.Draws++;
                    }
                    break;

                case (int)Reset.resetScore:
                    foreach (Player p in _player)
                    {
                        p.Losses = 0;
                        p.Wins = 0;
                        p.Draws = 0;
                    }
                    break;

                default:
                    for (int i = 0; i < _player.Length;i++)
                    {
                        if (i == (int)iUIC.Id-2)
                        {
                            _player[_player.Length - i-1].Wins++;
                        }
                        else
                        {
                            _player[_player.Length - i-1].Losses++;
                        }
                    }
                    break;
            }

            foreach (Player p in _player)
            {
                p.Life = 20;
            }

            for (int i = 0; i < _player.Length; i++)
            {
                if (_player[_player.Length - 1].Dealer == true)
                {
                    _player[_player.Length - 1].Dealer = false;
                    _player[0].Dealer = true;
                    break;
                }
                else if (_player[i].Dealer == true)
                {
                    _player[i].Dealer = false;
                    _player[i + 1].Dealer = true;
                    break;

                }
            }

            this.Frame.Navigate(typeof(MagicPage), _player);
        }

        //Exit
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        //Back
        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        //Reset
        private void Button_Restart_Click(object sender, RoutedEventArgs e)
        {

            
            Class.ResetPopup resetPopup = new Class.ResetPopup(_player, this.Frame, ResetMenu_Invoke);
            resetPopup._posX = (int)this.Frame.ActualWidth / 2;
            resetPopup._posY = (int)this.Frame.ActualHeight -80;
            resetPopup.ShowAsync();            
                 
           
        }

        void drawPlayerArea(string s)
        {

            for (int i = 0; i < _player.Length; i++)
            {
                pArea[i] = new Class.PlayerArea(_player[i], Grid_1, Resources[s + i] as Style, Resources);
            }
        }


    }
}
