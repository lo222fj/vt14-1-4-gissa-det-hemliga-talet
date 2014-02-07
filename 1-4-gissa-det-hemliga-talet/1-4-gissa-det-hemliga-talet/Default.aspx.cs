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
                int guess = int.Parse(GuessTextBox.Text);
                Outcome outcome = mySecretNumber.MakeGuess(guess);
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
                        break;
                    case Outcome.PreviousGuess:
                        ResultLabel.Text = "Du har redan gissat på det talet";
                        break;
                }
                string prevGuesses = null;
                foreach (int nr in mySecretNumber.PreviousGuesses)
                {
                    string nrString =nr.ToString();

                    prevGuesses += nrString + " ";
                }
                FormerGuessesLabel.Text = prevGuesses;
            }
        }
    } //När jag har ny knapp och ska börja om SecretNumber.Initialize();
}