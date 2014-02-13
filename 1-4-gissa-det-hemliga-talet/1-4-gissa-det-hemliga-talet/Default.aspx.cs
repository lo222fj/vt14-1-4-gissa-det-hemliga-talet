using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _1_4_gissa_det_hemliga_talet.Model;

namespace _1_4_gissa_det_hemliga_talet
{
    public partial class Default : System.Web.UI.Page
    {
        SecretNumber mySecretNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["GuessSession"] == null)
            {
                mySecretNumber = new SecretNumber();
                Session["GuessSession"] = mySecretNumber;
            }
            else
                mySecretNumber = Session["GuessSession"] as SecretNumber;
        }
        protected void SendGuessButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (mySecretNumber.CanMakeGuess == true)
                {
                    RenderGuess();
                }
                if (mySecretNumber.CanMakeGuess == false && mySecretNumber.Outcome != Outcome.Correct)
                {
                    ResultLabel.Text = String.Format("Du har inga gissningar kvar. Det hemliga talet var {0}", mySecretNumber.Number);
                    ChangeSettings();
                }
            }
        }

        private void RenderGuess()
        {

            Outcome outcome = Outcome.Indefinite;
            try
            {
                int guess = int.Parse(GuessTextBox.Text);
                //Outcome outcome = mySecretNumber.MakeGuess(guess);

                outcome = mySecretNumber.MakeGuess(guess);
            }
            catch (Exception)
            {

                //throw;//Sätt en label med felmeddelande istället för throw
                var validator = new CustomValidator 
                {
                    IsValid = false, 
                    ErrorMessage = "Gissningen var utanför intervallet 1 - 100." 
                }; 
                Page.Validators.Add(validator);

            }
            switch (outcome)
            {
                case Outcome.Low:
                    ResultLabel.Text = "För lågt!";
                    break;
                case Outcome.High:
                    ResultLabel.Text = "För högt";
                    break;
                case Outcome.Correct:
                    ResultLabel.Text = String.Format("Grattis! Du klarade det på {0} gissningar!", mySecretNumber.Count);
                    ChangeSettings();
                    break;
                case Outcome.PreviousGuess:
                    ResultLabel.Text = "Du har redan gissat på det talet";
                    break;
            }
            string prevGuesses = null;
            foreach (int nr in mySecretNumber.PreviousGuesses)
            {
                string nrString = nr.ToString();

                prevGuesses += nrString + " ";
            }
            FormerGuessesLabel.Text = prevGuesses;
        }

        private void ChangeSettings()
        {
            GuessTextBox.Enabled = false;
            SendGuessButton.Enabled = false;
            NewSecretNrButton.Visible = true;
            NewSecretNrButton.Focus();
        }

        protected void NewSecretNrButton_Click(object sender, EventArgs e)
        {
            mySecretNumber.Initialize();
        }
    }
}