using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;



namespace SubsystemB
{
public partial class HomPage : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //open connection
            //set reference to database 

            //String query = "select * UserAccounts where Username= '" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'"; 

            //  OleDbConnection conn = Connections.connect();
            //OleDbCommand processQuery = new OleDbCommand(query, conn);//execute the query


            var service = new OnlineTestService();//create object
            int userID;
            var pulledData = service.validUser(txtUsername.Text, txtPassword.Text, out userID);
           

            if (pulledData.Keys.First() == false)
            {
                lblInvalidCredentials.Visible = true;
            } 
        if (pulledData.Keys.First() & pulledData.Values.First() == false)
            {
                Tests tests = new Tests();
                Response.Redirect($"~/Tests.aspx?userID={userID}");//INTERPOLATION
                   
            }
            else if ((pulledData.Keys.First() && pulledData.Values.First() == true)){
                AddQuestions addQuestions = new AddQuestions();
                Response.Redirect($"~/AddQuestions.aspx?userID={userID}");


            }
           
           
        }//buton click

    }//class

 




}

