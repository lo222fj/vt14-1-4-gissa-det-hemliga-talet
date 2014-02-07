using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_4_gissa_det_hemliga_talet.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess };

    [Serializable]
    public class SecretNumber
    {
        //det hemliga talet
        private int? _number;
        //alla gissningar m aktuellt hemligt tal
        private List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;

        //Egenskaper
        //Kan en gissning göras?
        public bool CanMakeGuess
        {
            get
            {
                if (Count < 6)
                    return true;
                else
                    return false;
            }
        }
        //Antal gissningar med aktuellt hemligt tal
        public int Count { get; private set; }
        //Ger eller sätter hemliga talet
        public int? Number
        {
            get
            {
                if (CanMakeGuess == true)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _number = value;
                }
            }
        }
        //Resultatet av senaste gissningen
        public Outcome Outcome { get; private set; }
        //Referens till samling gissningar
        public IEnumerable<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }

        public SecretNumber()
        {
            _previousGuesses = new List<int>(7);
            Initialize();
        }
        public void Initialize()
        {
            Random newRandom = new Random();
            Number = newRandom.Next(1, 101);

            if (_previousGuesses != null)
            {
                _previousGuesses.Clear();
            }

            Outcome = Outcome.Indefinite;
        }
        public Outcome MakeGuess(int guess)
        {
            if (guess < _number)
            {
                Outcome = Outcome.Low;
            }
            else if (guess > _number)
            {
                Outcome = Outcome.High;
            }
            else if (guess == _number)
            {
                Outcome = Outcome.Correct;
            }
            _previousGuesses.Add(guess);
            Count += 1;
            return Outcome;
        }
    }
}