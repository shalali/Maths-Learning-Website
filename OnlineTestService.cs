using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;



namespace SubsystemB
{
    public class OnlineTestService
    {

       

        //DATABASE FILE PATH must be correct here
        public OleDbConnection connection()
        {
            string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\Projects\SubsystemB\ChildrenTestingSubsystem.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
            return conn;
        }//connection

        //method to pull data from database to datatable 
        //returns firstly valid credentials and secondly, is admin  
        public Dictionary<bool, bool> validUser(String username, String password, out int userID)
        {
                
            OleDbConnection conn = connection();
            DataTable userAccountInfoTable = new DataTable();
            var query = "SELECT * FROM UserAccounts WHERE Username= '" + username + "' AND Password='" + password + "'";
            bool validUser = false;//check if valid user
            bool admin = false;//check if admin
            Dictionary<bool, bool> temp = new Dictionary<bool, bool>();

            userID = 0;
            admin = false;
           
           fillMyDataTable(conn,userAccountInfoTable,query);
                
            
            var rows= userAccountInfoTable.Rows;
            if (rows.Count == 1){
                validUser = true;
                userID = Convert.ToInt32(rows[0]["ID"].ToString());//i,j
                admin = Convert.ToBoolean(rows[0]["IsAdmin"].ToString());
            }

            temp.Add(validUser, admin);//convert isAdmin to boolean

            conn.Close();
            return temp;
        }//validUser


        public void insertQuestions(
            String topic,
            String question,
            int difficulty,
            int ageGroup,
            int questionType,
            String correctSingleAns,
            String ansA, String ansB, String ansC, String ansD,
            bool a, bool b, bool c, bool d)
        {
            int quizLevel = ageGroup;
            // string connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\UNI\SECOND YEAR\AWD_1551\SubsystemB\ChildrenTestingSubsystem.mdb";
            //OleDbConnection conn = new OleDbConnection(connString);
            OleDbConnection conn = connection();

            //insert questions first
            String query = "INSERT INTO Questions(Description, Topic, IsMultipleChoice, Difficulty,QuizAgeGroup) VALUES('" + question + "','" + topic + "'," + questionType + "," + difficulty + "," + ageGroup + ");";
            string query2 = "Select @@Identity";
            int questionID;
            OleDbCommand processQuery = new OleDbCommand(query, conn);//execute the query
            try
            {
                conn.Open();
                processQuery.ExecuteNonQuery();
                processQuery.CommandText = query2;
                questionID = (int)processQuery.ExecuteScalar();
                if (questionType == 0)
                {//single answer
                    insertAnswers(questionID, correctSingleAns, false, false, false, false, null, null, null, null, false);
                }
                else if (questionType == 1)
                {//multiple choice
                    insertAnswers(questionID, null, a, b, c, d, ansA, ansB, ansC, ansD, true);

                }

                //AddQuestions addQuestions = new AddQuestions();
                //addQuestions.lblQuestionAddedConfirmation.Visible = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();
            }
        }//insertQuestions

        public void insertAnswers(int questionID, String single, bool a, bool b, bool c, bool d, String ansA, String ansB, String ansC, String ansD, bool multipleChoice)
        {
            OleDbConnection conn = connection();
            //first get the questionID (foreign key in the answer table)
            //if single answer then questionID as foreign key (f.key) will only be there once
            conn.Open();
            if (multipleChoice == false)
            {
                String query = "INSERT INTO Answers(Answer, IsCorrect, QuestionID) VALUES('" + single + "'," + true + "," + questionID + ");";
                OleDbCommand processQuery = new OleDbCommand(query, conn);//execute the query
                processQuery.ExecuteNonQuery();

            }
            else if (multipleChoice == true)
            {//answers will be entered 4 times but the right and wrong ones shall be differentiated using boolean when stored in table
                OleDbCommand processQuery = new OleDbCommand();
                OleDbTransaction transaction = null;                           // Start a local transaction with ReadCommitted isolation level.
                transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                // Assign transaction object for a pending local transaction.
                processQuery.Connection = conn;
                processQuery.Transaction = transaction;
                processQuery.CommandText = "INSERT INTO Answers(Answer, IsCorrect, QuestionID) VALUES('" + ansA + "'," + a + "," + questionID + ");";
                processQuery.ExecuteNonQuery();
                processQuery.CommandText = "INSERT INTO Answers(Answer, IsCorrect, QuestionID) VALUES('" + ansB + "'," + b + "," + questionID + ");";
                processQuery.ExecuteNonQuery();
                processQuery.CommandText = "INSERT INTO Answers(Answer, IsCorrect, QuestionID) VALUES('" + ansC + "'," + c + "," + questionID + ");";
                processQuery.ExecuteNonQuery();
                processQuery.CommandText = "INSERT INTO Answers(Answer, IsCorrect, QuestionID) VALUES('" + ansD + "'," + d + "," + questionID + ");";
                processQuery.ExecuteNonQuery();
                // Commit the transaction.
                transaction.Commit();

            }
            conn.Close();


        }//insertAnswers

        public List<Object> fetchQuestions(int quizAge)
        {//1 = beginner 2 = intermediate 3 = advanced
            OleDbConnection conn = connection();
            DataTable qTable = new DataTable();
            String query = "SELECT * FROM Questions WHERE QuizAgeGroup= " + quizAge;
            fillMyDataTable(conn, qTable, query);
            List<Object> test = new List<Object>();

            foreach (DataRow row in qTable.Rows)//row = question
            {
                getQuestionData(test, row);
            }


            return test;
        }

        public void gatherAnswers(List<Object> qa, List<Object> ua,int questionID, String userSingleAnsInput, bool a, bool b, bool c, bool d,out List<Object> quizAnswers,out List<Object> userAnswers)
        {
            //correct ans is:
            OleDbConnection conn = connection();
            DataTable ansTable = new DataTable();
            String query = "SELECT * FROM Answers WHERE QuestionID= " + questionID;
            fillMyDataTable(conn, ansTable, query);

            quizAnswers = qa;
            userAnswers = ua;

            //find out if answer is of multiple or single type
            if (ansTable.Rows.Count > 1)//multiple choiced answers
            {
                int counter = 0;
                bool[] correctCheckedAns = new bool[4];//stores the correct checked/unchecked a,b,c,d
                bool[] userCheckedAns = new bool[4];//stores the correct checked/unchecked 

                while (counter < 4)
                {
                    //store correct
                    foreach (DataRow mRow in ansTable.Rows)//row = question
                    {
                        correctCheckedAns[counter] = Convert.ToBoolean(mRow["IsCorrect"].ToString());
                        counter++;
                    }//for each     
                    userCheckedAns[0] = a;
                    userCheckedAns[1] = b;
                    userCheckedAns[2] = c;
                    userCheckedAns[3] = d;

                }//while
                quizAnswers.Add(correctCheckedAns);
                userAnswers.Add(userCheckedAns);
            }//if
            else
            {
                DataRow singleRow = ansTable.Rows[0];
                var correctSingleAns = singleRow["Answer"].ToString();
                quizAnswers.Add(correctSingleAns);
                userAnswers.Add(userSingleAnsInput);
            }
        }


        public double checkAnswers(List<Object> correctAns, List<Object> studentAns, int userID, int testLevel) {
            int marks = 0;
            int questions = getTotalQuestionByAgeGroup(testLevel);//total marks
            for (int i = 0; i < questions ;i++) {
                if (correctAns[i].Equals(studentAns[i]))
                {
                    marks += 1;
                } else if (correctAns[i] is bool[]) {

                    bool[] correctMultiAns = (bool[])correctAns[i];//get the correct checked 4 booleans
                    bool[] givenMultiAns = (bool[])studentAns[i];//students checked answers

                    bool allCorrect = true;
                    for (int j = 0; j < 4; j++)
                    {
                        if (correctMultiAns[j]!=givenMultiAns[j]) {//user ans is wrong
                            allCorrect = false;//all 4 values must be correct
                            break;
                        }//if
                    }//for
                    if (allCorrect) {
                        marks += 1;
                    }
                }//elseif
            }
            //assuming each correct question = 1mark
            double percentage = ((double)marks /(double) questions) * 100;
            storeMarks(questions,marks, percentage,userID, testLevel);
            return percentage;
        }

        private int getTotalQuestionByAgeGroup(int ageGroup)
        {
            OleDbConnection conn = connection();
            DataTable questionsTable = new DataTable();
            String query = "SELECT * FROM Questions where QuizAgeGroup="+ ageGroup;
            fillMyDataTable(conn, questionsTable, query);
            return questionsTable.Rows.Count;
        }

        public void storeMarks(int totalMarks, int marks, double percentage,int userID, int testLevel)
        { bool gold = false;
          bool silver = false;
            if (percentage >=80) {
                 gold = true;
            }
            else if (percentage>=70 && percentage<=80)
            {
                silver = true;

            }

            OleDbConnection conn = connection();
            String query = "INSERT INTO Results(TestLevel,TotalMarks,Marks, Percentage,IsGoldMedallist,IsSilverMedallist,UserID) VALUES(" + testLevel + ","+ totalMarks+ "," + marks+ "," + percentage + "," + gold + "," + silver + ","+userID+")";
            using (conn)
            {    conn.Open();
                OleDbCommand processQuery = new OleDbCommand(query, conn);//execute the query
                var rowsAffected= processQuery.ExecuteNonQuery();
                
            }
            

        }

        public List<String> getGoldMeds()
        {//id & bool
            List<String> goldMedallistsNames = new List<String>();
            List<int> goldMedallistsIDs = new List<int>();

            DataTable hallTable = getResults();

            foreach (DataRow row in hallTable.Rows)
            {
                int userID = Convert.ToInt32(row["UserID"]);
                var isGold = Convert.ToBoolean(row["IsGoldMedallist"]);
                if (isGold) { 
                 goldMedallistsIDs.Add(userID);
                  }//if

            }//for each

            DataTable userTable = getMedallistNames(goldMedallistsIDs);
            foreach (DataRow row in userTable.Rows)
            {
                var firstName = row["FirstName"].ToString();
                var surname = row["LastName"].ToString();
                goldMedallistsNames.Add(firstName + " "+ surname);
                           }//for each

            return goldMedallistsNames;
        }//getGold
        public List<String> getSilverMeds()
        {//id & bool
            List<String> silverMedallistsNames = new List<String>();
            List<int> silverMedallistsIDs = new List<int>();

            DataTable hallTable = getResults();

            foreach (DataRow row in hallTable.Rows)
            {
                int userID = Convert.ToInt32(row["UserID"]);
                var isGold = Convert.ToBoolean(row["IsSilverMedallist"]);
                if (isGold)
                {
                    silverMedallistsIDs.Add(userID);
                }//if

            }//for each

            DataTable userTable = getMedallistNames(silverMedallistsIDs);
            foreach (DataRow row in userTable.Rows)
            {
                var firstName = row["FirstName"].ToString();
                var surname = row["LastName"].ToString();
                silverMedallistsNames.Add(firstName + " " + surname);
            }//for each

            return silverMedallistsNames;
        }//getSilver

        private DataTable getResults()
        {
            OleDbConnection conn = connection();
            DataTable hallTable = new DataTable();
            String query = "SELECT * FROM Results";
            fillMyDataTable(conn, hallTable, query);
            return hallTable;
        }

        private DataTable getMedallistNames(List<int> userIDs)
        {
            OleDbConnection conn = connection();
            DataTable userTable = new DataTable();
            String query = "SELECT * FROM UserAccounts WHERE ID IN(";

            foreach (var item in userIDs)
            {
                query += item + ",";
            }

            query += "0)";

            fillMyDataTable(conn, userTable, query);
            return userTable;
        }

        public void fillMyDataTable(OleDbConnection conn, DataTable qTable, string query)
        {
            using (conn)
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(qTable);
            }
        }

        public void getQuestionData(List<object> test, DataRow row)
        {
            var qDescription = row["Description"].ToString();
            var qTopic = row["Topic"].ToString();
            var qIsMultipleChoice = row["IsMultipleChoice"].ToString();
            var qDifficulty = row["Difficulty"].ToString();
            var qQuizAgeGroup = row["QuizAgeGroup"].ToString();
            var qQquestionID = row["QuestionID"].ToString();
            String abcd = "";

            String[] q = new String[7];

            q[0] = qDescription;
            q[1] = qTopic;
            q[2] = qIsMultipleChoice;
            qDifficulty = getDifficultyLevel(qDifficulty);
            q[3] = qDifficulty;
            qQuizAgeGroup = getQuizAgeGroup(qQuizAgeGroup);
            q[4] = qQuizAgeGroup;
            q[5] = qQquestionID;

            //get answers for mutiple choice question
            if (qIsMultipleChoice=="True") {
                String query = "SELECT * FROM Answers WHERE QuestionID= " + Convert.ToInt32(qQquestionID);
                OleDbConnection conn = connection();
                DataTable multiAnsTable = new DataTable();
                fillMyDataTable(conn, multiAnsTable, query);
                foreach (DataRow ans in multiAnsTable.Rows) {                    
                        abcd += ans["Answer"].ToString()+",";
                    //for
                }//for each
                q[6] = abcd;
              }//if
            if (qIsMultipleChoice == "False")
            {
                abcd = "";
            }

                test.Add(q);
        }

        private static string getQuizAgeGroup(string qQuizAgeGroup)
        {
            if (qQuizAgeGroup == "1")
            {
                qQuizAgeGroup = "6-10yrs";
            }
            if (qQuizAgeGroup == "2")
            {
                qQuizAgeGroup = "11-13yrs";
            }
            if (qQuizAgeGroup == "3")
            {
                qQuizAgeGroup = "14-16yrs";
            }

            return qQuizAgeGroup;
        }

        private static string getDifficultyLevel(string qDifficulty)
        {
            if (qDifficulty == "1")
            {
                qDifficulty = "Easy";
            }
            if (qDifficulty == "2")
            {
                qDifficulty = "Medium";
            }
            if (qDifficulty == "3")
            {
                qDifficulty = "Hard";
            }

            return qDifficulty;
        }
    }//onlineTestService

}//subsystemB
