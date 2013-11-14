using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;

namespace MagicPolarBear.Class
{
    class Player
    {

        public string Name { get; set; }
        public bool Dealer {get; set;}
        int _life;
        int _wins;
        int _draws;
        int _losses;      
        int _numberOfGames;

        

        public int Life 
        {
            get
            {
                return _life;
            }
            set
            {
                _life = value;
            }
        }

        public int Wins
        {
            get
            {
                return _wins;
            }
            set
            {
                this._wins = value;
                this._numberOfGames = this._wins + this._draws + this._losses;

            }
        }
        public int Draws
        {
            get
            {
                return _draws;
            }
            set
            {
                this._draws = value;
                this._numberOfGames = this._wins + this._draws + this._losses;

            }
        }
        public int Losses
        {
            get
            {
                return _losses;
            }
            set
            {
                this._losses = value;
                this._numberOfGames = this._wins + this._draws + this._losses;

            }
        }
        public int NumberOfGames
        {
            get
            {
                return _numberOfGames; 
            }
        }

        protected Player()
        {
 
        }

        
        public Player(string name)
        {
            if (name != "")
                this.Name = name;
            else
                throw new Exception("name can't be \"\"");

            this.Life = 20;

            this.Wins = 0;
            this.Draws = 0;
            this.Losses = 0;

            this._numberOfGames = this._wins + this._draws + this._losses;
            
        }



    }
}
