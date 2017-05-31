using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubsystemB

{//this class will be used to diplay the tests regardless of the age group 
    public partial class GenericQuizTemplate : System.Web.UI.Page
    {
        //int count = 0;
        int questionCount = 0;
        int totalItems;
        String[] questionN = new String[7];
        OnlineTestService service = new OnlineTestService();//to access the services
        int marks;  //gathers total marks for each right question



        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {//first time load
                var testLevel = Convert.ToInt32(Request["testLevel"]);
                populateQuiz(testLevel);
                ViewState.Add("questionCount", questionCount);
                List<Object> quizAnswers = new List<Object>();
                List<Object> userAnswers = new List<Object>();
                ViewState.Add("quizAnswers", quizAnswers);
                ViewState.Add("userAnswers", userAnswers);

            }            
        }
        public void populateQuiz(int quizAgeGroup)
        {
            if (IsPostBack) {//not first load
                var qID = ViewState["QuestionID"];

                List<Object> quizAnswers = (List<Object>)ViewState["quizAnswers"];
                List<Object> userAnswers = (List<Object>)ViewState["userAnswers"];

                service.gatherAnswers(quizAnswers, userAnswers,Convert.ToInt32(qID), txtSingleAns.Text, chkA.Checked, 
                    chkB.Checked, chkC.Checked, chkC.Checked,out quizAnswers, out userAnswers);
                ViewState.Add("quizAnswers", quizAnswers);
                ViewState.Add("userAnswers", userAnswers);


            }

            btnTestFinished.Style.Add("display", "none");//visible false
 
            //GenericQuizTemplate quiz = new GenericQuizTemplate();
            // GenericQuizTemplate quiz = (GenericQuizTemplate)LoadControl("GenericQuizTemplate.ascx");
            List<Object> test = service.fetchQuestions(quizAgeGroup);//1 represnts beginner quiz
            totalItems = test.Count;

            questionCount = Convert.ToInt32(ViewState["questionCount"]);
            
            if (questionCount < totalItems )
            {
                questionN = (String[])test[questionCount];
                int temp = questionCount + 1;//couting from 0
                lblQuestionCount.Text = "Question " + temp.ToString() + "/"+totalItems;
                lblAgeGroup.Text = questionN[4];
                lblTopic.Text = questionN[1];
                lblQuestion.Text = questionN[0];
                lblDifficulty.Text = questionN[3];
                if (!String.IsNullOrEmpty(questionN[6])) {//if there is a value
                    String[] abcdValues = questionN[6].Split(',').ToArray();
                    txtA.Text = abcdValues[0];
                    txtB.Text = abcdValues[1];
                    txtC.Text = abcdValues[2];
                    txtD.Text = abcdValues[3];

                }
                ViewState.Add("QuestionID", questionN[5]);
                //display the appropriate panel for the student to answer in
                bool multiple = Convert.ToBoolean(questionN[2]);
                if (multiple == true)
                {//if question type is multiplechoice
                    pnlSingleAns.Style.Add("display", "none");//want the pnl to render but to be invisible
                                                              //show this one instead
                    pnlMutipleChoice.Style.Add("display", "block");
                }
                else if (multiple == false)
                {//if question type is input answer
                    pnlSingleAns.Style.Add("display", "block");//visible true
                    pnlMutipleChoice.Style.Add("display", "none");//visible false
                }

                //}
            }//if
             if(questionCount == totalItems){

                btnTestFinished.Style.Add("display", "block");//visible true
                btnNextQuestion.Style.Add("display", "none");//visible false
        }
        }//populateQuiz
       
        void add()
        {
            int a, b, trueAns, userAns;
            a = randomNoGenerator();
            b = randomNoGenerator();
            trueAns = a + b;

            //output topic
            //Topic.Text = "Addition";

            //output question
            //txtQuestion.Text = "Add " + a + " and " + b + ".";

            //get student answer
            userAns = Convert.ToInt32(txtSingleAns.Text);

            if (userAns == trueAns)
            { //if the answer is right
                marks++;
            }




        }

        public int randomNoGenerator()
        {

            Random rnd = new Random();
            int no = rnd.Next(101);     // creates a number between 0 and 100        
            return 0;

        }

     
        protected void btnTestFinished_Click(object sender, EventArgs e)
        {
            var testLevel = Convert.ToInt32(Request["testLevel"]);
            int userID = Convert.ToInt32(Request["userID"]);
            double percentage = service.checkAnswers((List<Object>)ViewState["quizAnswers"], (List<Object>)ViewState["userAnswers"],userID,testLevel);
            lblMarksAdded.Visible = true;
            lblPercentage.Text = "You have scored "+percentage.ToString()+"%";
            btnTestFinished.Visible = false;
            pnlMain.Visible = false;
            
        }

        protected void btnNextQuestion_Click1(object sender, EventArgs e)
        {
            var qno = Convert.ToInt32(ViewState["questionCount"]) + 1;
            ViewState.Add("questionCount", qno);
            var testLevel = Convert.ToInt32(Request["testLevel"]);
            populateQuiz(testLevel);
            txtSingleAns.Text = String.Empty;//doestn remeber la

        }

        protected void lnkBtnHome_Click(object sender, EventArgs e)
        {
            var userID = Request["userID"];
            Response.Redirect($"~/Tests.aspx?userID={userID}");
        }
    }
}