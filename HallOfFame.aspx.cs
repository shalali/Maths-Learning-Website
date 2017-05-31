using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubsystemB
{
    public partial class HallOfFame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OnlineTestService service = new OnlineTestService();
            List<String> goldMedallistsList = service.getGoldMeds();
            List<String> silverMedallistsList = service.getSilverMeds();
            foreach (String name in goldMedallistsList)
            {
                txtGold.Text += name +Environment.NewLine;

            }
            foreach (String name in silverMedallistsList)
            {
                txtSilver.Text += name + Environment.NewLine;

            }

        }

        protected void lnkBtnHome_Click(object sender, EventArgs e)
        {
            var userID = Request["userID"];
            Response.Redirect($"~/Tests.aspx?userID={userID}");
        }
    }
}