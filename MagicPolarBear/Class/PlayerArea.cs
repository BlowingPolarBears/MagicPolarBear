using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MagicPolarBear.Class
{
    class PlayerArea
    {


        Grid _grid;
        Grid _areaGrid;
        TextBlock _playerTextBlock;

        TextBlock _winTextBlock;
        TextBlock _dealerTextBlock;

        Button _lifeButton;
        Button _addOneLifeButton;
        Button _addFiveLifeButton;


        Player _player;

        public PlayerArea(Player player, Grid grid, Style gridStyle ,ResourceDictionary Resources)
        {

            string dealer = "";
           

            RoutedEventHandler rehOneMore = new RoutedEventHandler(Life_One_More_Click);
            RoutedEventHandler rehFiveMore = new RoutedEventHandler(Life_Five_More_Click);
            RoutedEventHandler rehOneLess = new RoutedEventHandler(Life_One_Less_Click);
            

            this._player = player;
            this._grid = grid;

            if (_player.Dealer == true)
                dealer = "D";

            _areaGrid = CreateXAMLObj.CreateGrid(gridStyle, _grid);
            _playerTextBlock = CreateXAMLObj.CreateTextBlock(_player.Name, Resources["TextBlockPlayerNameStyle"] as Style, _areaGrid);
            _winTextBlock = CreateXAMLObj.CreateTextBlock(_player.Wins.ToString() + " W", Resources["TextBlockWinStyle"] as Style, _areaGrid);
            _dealerTextBlock = CreateXAMLObj.CreateTextBlock(dealer, Resources["TextBlockDealerStyle"] as Style, _areaGrid);

            _lifeButton = CreateXAMLObj.CreateButton("Life", Resources["ButtonLifeStyle"] as Style, _player.Life.ToString(), rehOneLess, _areaGrid);
            _addOneLifeButton = CreateXAMLObj.CreateButton("Add_One_Life", Resources["ButtonAddOneLifeStyle"] as Style, "+1", rehOneMore, _areaGrid);
            _addFiveLifeButton = CreateXAMLObj.CreateButton("Add_Five_Life", Resources["ButtonAddFiveLifeStyle"] as Style, "+5", rehFiveMore, _areaGrid);


        }


        private void Life_One_More_Click(object sender, RoutedEventArgs e)
        {
            
            _player.Life++;
            _lifeButton.Content = _player.Life.ToString();
        }
        private void Life_Five_More_Click(object sender, RoutedEventArgs e)
        {
            _player.Life = _player.Life + 5;
            _lifeButton.Content = _player.Life.ToString();
        }
        private void Life_One_Less_Click(object sender, RoutedEventArgs e)
        {
            _player.Life--;
            _lifeButton.Content = _player.Life.ToString();
        }




 
    }
}
