using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubsystemB
{
    public partial class Tests : System.Web.UI.Page
    {
        GenericQuizTemplate quiz = new GenericQuizTemplate();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBeginner_Click(object sender, EventArgs e)
        {
            var userID = Request["userID"];
           Response.Redirect($"~/GenericQuizTemplate.aspx?testLevel=1&userID={userID}");

        }
        protected void btnIntermediate_Click(object sender, EventArgs e)
        {
            var userID = Request["userID"];
            Response.Redirect($"~/GenericQuizTemplate.aspx?testLevel=2&userID={userID}");


        }

        protected void btnAdvanced_Click(object sender, EventArgs e)
        {
            var userID = Request["userID"];
            Response.Redirect($"~/GenericQuizTemplate.aspx?testLevel=3&userID={userID}");


        }

        protected void btnHallOfFame_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HallOfFame.aspx");
        }
    }//tests
}//SubsytemB