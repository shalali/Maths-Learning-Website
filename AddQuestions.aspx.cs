using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SubsystemB
{
    public partial class AddQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //define an event 
            ddlQuestionType.SelectedIndexChanged += DdlQuestionType_SelectedIndexChanged;

            if (!Page.IsPostBack) {//page load not post back i.e. first page load
                pnlMutipleChoice.Style.Add("display","none");
            }
        }

        private void DdlQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(((DropDownList)sender).SelectedValue) == 2) {//multiple
                //hide panel
                pnlSingleAns.Style.Add("display", "none");//want the pnl to render but to be invisible
                //show this one instead
                pnlMutipleChoice.Style.Add("display","block");
            }
            else if (Convert.ToInt32(((DropDownList)sender).SelectedValue) == 1)//single
            {
                pnlSingleAns.Style.Add("display","block");//visible true
                pnlMutipleChoice.Style.Add("display","none");//visible false
            }
        }

        protected void btnAddQuestion_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            String topic = txtTopic.Text;
            String question = txtQuestion.Text;
            //1=easy 2==medium 3=hard
            int difficulty = Convert.ToInt32(ddlDifficulty.SelectedValue.ToString());
            String questionTypeA = ddlQuestionType.SelectedValue;
            int questionType= 0;

            if (Convert.ToInt32(questionTypeA) == 1)
            {
                if (txtTopic.Text.Equals("") || txtQuestion.Text.Equals("") || txtSingleAns.Text.Equals("")) {
                    lblError.Visible = true;
                    lblQuestionAddedConfirmation.Visible = false;

                }
            }

            //if (Convert.ToInt32(questionTypeA) == 2) {//2 value = multiple choice selected 
              //  questionType = 1;
            //}

            if (Convert.ToInt32(questionTypeA) == 2)
            {
                if (txtTopic.Text.Equals("") || txtQuestion.Text.Equals("") || txtA.Text.Equals("") || txtB.Text.Equals("") || txtC.Text.Equals("") || txtD.Text.Equals("")) {

                    lblError.Visible = true;
                    lblQuestionAddedConfirmation.Visible = false;

                }
            }

            if (lblError.Visible == false) {
                //1=6-10yrs 2=11-13yrs 3=14-16yrs
                int level = Convert.ToInt32(ddlQuizLevel.SelectedValue.ToString());


                String correctSingleAns = txtSingleAns.Text;
                //collect 4 answers for mutiple choice type questions
                String ansA = txtA.Text;
                String ansB = txtB.Text;
                String ansC = txtC.Text;
                String ansD = txtD.Text;
                //identify the correct answers **there can be more than one correct answer for the mutiple choice
                //correct answer is the one that admin chooses to tick
                bool isA_right = chkA.Checked;
                bool isB_right = chkB.Checked;
                bool isC_right = chkC.Checked;
                bool isD_right = chkD.Checked;

                var service = new OnlineTestService();//create object
                                                      //insert the new question created
                service.insertQuestions(topic, question, difficulty, level, questionType, correctSingleAns, ansA, ansB, ansC, ansD, isA_right, isB_right, isC_right, isD_right);
                //insert the corresponding answers
                lblQuestionAddedConfirmation.Visible = true;
                lblError.Visible = false;
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}