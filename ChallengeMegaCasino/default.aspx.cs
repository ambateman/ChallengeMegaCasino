using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeMegaCasino
{
    public partial class _default : System.Web.UI.Page
    {
        Random slots = new Random();
        int left;
        int middle;
        int right;
        int BetMultiplier;
        double yourBet;
        double bank;

        string[] slotValues = new string[]{ "/images/Bar.png", "/images/Cherry.png", "/images/Seven.png", "/images/Clover.png",
            "/images/Diamond.png", "/images/HorseShoe.png", "/images/Bell.png", "/images/Lemon.png",
            "/images/Orange.png", "/images/Plum.png", "/images/Strawberry.png", "/images/Watermelon.png" };



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bank = 100.00;
                ViewState.Add("bank",bank);
   
                bankMessage();
            }
        }

        protected void btnLever_Click(object sender, EventArgs e)
        {
            //This takes the place of our lever for the slot machine.
            //All this does is generate 3 random numbers to be used to decide 
            //if fake money is won or lost.
            left = slots.Next(0, 11);
            middle = slots.Next(0, 11);
            right = slots.Next(0, 11);
            updateSlots();
            calcBet();
            updateWinLoss();
            bankMessage();

        }

        private void updateSlots()
        {
            //This changes the images of the slot machine slots

            Image1.ImageUrl = slotValues[left];
            Image2.ImageUrl = slotValues[middle];
            Image3.ImageUrl = slotValues[right];
        }



        private void calcBet()
        {
            //This covers all of the possibilites
            //for a payout. It sets the bet multiplier
            //First, check for bars -- this is instant loss

            if (left == 0 || middle == 0 || right == 0)
            {
                BetMultiplier = -1; 
            }
            else
            {
                BetMultiplier = Math.Max(set7Flag(), set1CherryFlag());

            }

        }


        private int  set7Flag()
        {
            //Checks to see if all slots are lucky number seven.
            if (left == 2 && middle == 2 && right == 2) return 100;
            return -1; //means no soap
        }

        private int set1CherryFlag()
        {
            int cherryCount = 0;
            if (left == 1) ++cherryCount;
            if (middle == 1) ++cherryCount;
            if (right == 1) ++cherryCount;
            if (cherryCount > 0) return cherryCount + 1;
            else return -1;  
        }


        private void updateWinLoss()
        {
            
            if (double.TryParse(TextBox1.Text.ToString(), out yourBet))
            {
                ViewState["bank"] = (double)ViewState["bank"] + yourBet*BetMultiplier;
                setWinLossMessage(yourBet*BetMultiplier);
  
            }

        }

        private void setWinLossMessage(double betResult)
        {

            if (betResult > 0)
            {
                resultLabel.Text = String.Format("You bet {0:C} ", yourBet) + String.Format(" and won {0:C}", betResult) + "!";
            }
            else
            {
                resultLabel.Text = String.Format("Sad day for you. You lost {0:C}", -1 * betResult) + " Better Luck Next Time";
            }

        }

        private void bankMessage()
        {
            moneyLabel.Text = String.Format("Player's Money: {0:C},", (double)ViewState["bank"]);

        }
    }
}