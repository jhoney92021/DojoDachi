using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace Dojodachi.Models
{
    //Dachi == shorthand for Tomodachi
    //Tomodachi == Friend
    public class Dachi
    {
        //PROPERTIES
        //PROPERTIES
        [Required]
        [Range(0,100)]
        public int Happiness { get; set; }
        [Required]
        [Range(0,100)]
        public int Fullness { get; set; }
        [Required]
        [Range(0,100)]
        public int Energy { get; set; }
        [Required]
        [Range(0,10)]
        public int Meals { get; set; }
        [Required]
        public bool isEndGame { get; set; }
        //PROPERTIES
        //PROPERTIES
        //CONSTRUCTORS
        //CONSTRUCTORS
        public Dachi()
        {
            Happiness = 20;
            Fullness = 20;
            Energy = 20;
            Meals = 3;
            isEndGame = false;
        }
        //CONSTRUCTORS
        //CONSTRUCTORS
        //METHODS FOR DACHI
        //METHODS FOR DACHI
        public string endGame()
        {
            if(Happiness == 0)
            {
                isEndGame = true;
                return "Wow you really were a bad friend, Billy died of Unhappiness \n \n \n";
            }
            if(Fullness == 0)
            {
                isEndGame = true;
                return "Wow you really were a bad friend, Billy died of STARVATION!!! \n THE WORST FRIEND EVER YOU ARE!!! \n \n \n";
            }
            if(Fullness == 100 && Happiness== 100 )
            {
                isEndGame = true;
                return "Cool, Billy is thrilled with you, you win \n YOU ARE SUCH A GREAT FRIEND!! \n \n \n";
            }
            else
            {
                return null;
            }
        }
        public string Feed()
        {
            if(Meals > 0)
            {
                Random rand = new Random();
                int successChance = rand.Next(1,5);
                if(successChance == 1)
                {                    
                    return $"Billy did not like that, guess it sucks to suck, {Meals} meals left";
                }
                else
                {
                    Meals -= 1;
                    int full = rand.Next(5,11);
                    Fullness += full;
                    string lost = endGame();
                    return $"{lost}Billy gained {full} Fullness, {Meals} meals left";
                }
            }
            else
            {
                Fullness -= 5;
                Happiness -= 5;
                string lost = endGame();
                return $"{lost}No Meals Left";
            }

        }

        public string Play()
        {
            if(Energy > 0)
            {
                Random rand = new Random();
                int successChance = rand.Next(1,5);
                if(successChance == 1)
                {
                    return $"Billy did not like that, guess it sucks to suck, {Energy} energy left";
                }
                else
                {
                    Energy -= 5;
                    int happy = rand.Next(5,11);
                    Happiness += happy;
                    string lost = endGame();
                    return $"{lost}Played with Billy, {Energy} energy left, {happy} happiness gained" ;
                }
            }
            else
            {
                Fullness -= 5;
                Happiness -= 5;
                string lost = endGame();
                return $"{lost}Not enough energy" ;
            }
        }
        public string Work()
        {
            Random rand = new Random();
            int earned = rand.Next(1,4);
            Energy -= 5;
            Meals += earned;
            return $"Earned {earned} meals";
        }
        public string Sleep()
        {
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            endGame();
            return $"Slept to gain 15 energy, unfortunately this act of greed has resulted in Billy being less full and happy.... way to go....";
        }
    
        //METHODS FOR DACHI
        //METHODS FOR DACHI
    }
}