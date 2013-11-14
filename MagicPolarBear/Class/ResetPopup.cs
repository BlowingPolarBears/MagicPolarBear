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

    class ResetPopup
    {
        Player[] _player;
        PopupMenu _pM;
        Frame _mainPage;
        public int _posX { get; set; }
        public int _posY { get; set; }


        public ResetPopup(Player[] player, Frame Mainpage, UICommandInvokedHandler resetMenu)
        {
            this._mainPage = Mainpage;
            this._player = player;
            string[] list = new string[_player.Length + 2];
      


            for (int i = 0; i < _player.Length; i++)
            {
                
                list[i] = _player[i].Name + " Wins";
                
            }

            list[_player.Length] = "Draw";
            list[_player.Length + 1] = "Reset Score";


            _pM = Class.CreateXAMLObj.CreatePopup(list);
            

            for (int i = 0; i < _player.Length+2; i++)
            {
                _pM.Commands[i].Invoked = resetMenu;
                
            }
            
            
            
             
        }
        

        public async void ShowAsync()
        {
            await _pM.ShowAsync(new Point(_posX, _posY));
        }


    }



}
