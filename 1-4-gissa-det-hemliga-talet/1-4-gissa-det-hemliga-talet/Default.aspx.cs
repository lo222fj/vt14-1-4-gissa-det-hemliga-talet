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
        protected void Page_Load(object sender, EventArgs e)
        {
            //SecretNumber mySecretNumber = new SecretNumber();
            //Session["GuessSession"] = mySecretNumber;
        }

        protected void SendGuessButton_Click(object sender, EventArgs e)
        {
            SecretNumber mySecretNumber = new SecretNumber();
            Session["GuessSession"] = mySecretNumber;

            if (IsValid)
            {
                int guess = int.Parse(GuessTextBox.Text);

            }
        }
    }
}