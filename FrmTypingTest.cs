using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;

namespace TypingTest
{
    /// <summary>
    /// This form will check the user typing speed, accuracy, count the number of words and get the total time taken.
    /// </summary>
    public partial class FrmTypingTest : Form
    {   
        //Costructor
        public FrmTypingTest()
        {
            InitializeComponent();
        }
        //Private Variable Declaration
        private int numOfSec;
        private int numOfWord;
        private int Speed;
        private int wrongCharacter;
        private int errorPercentage;

        //Properties Declaration      
        [DefaultValue(0)]
        public string SampleText { get; set; }
        [DefaultValue(0)]
        public int Mistakes { get; set; }        
        public double ErrorPercentage { get; set; }
        [DefaultValue(0)]
        public int NumberOfSeconds { get; set; }
        [DefaultValue(0)]
        public int NumberOfWords { get; set; }
        [DefaultValue(0)]
        public double TypingSpeed { get; set; }
        
        #region Methods
        /// <summary>
        /// Reset the Typing form value.
        /// </summary>
        private void ResetForm()
        {
            NumberOfSeconds = 0;
            NumberOfWords = 0;
            TypingSpeed = 0;
            Mistakes = 0;
            ErrorPercentage = 0;
            textPharase.Enabled = false;
            textWrite.Clear();
            textWrite.Enabled = true;            
            lstStatistics.Items.Clear();
            lstStatistics.Items.Add("Start typing sample text to begin test");
        }

        /// <summary>
        /// Check the SampleText contains text or empty.
        /// </summary>
        private void StartTyping()
        {
            if (SampleText.Any())
            {
                textPharase.Text = SampleText;
                SampleText = string.Empty;
            }
            else
            {
                MessageBox.Show("Hey your Test are completed.", "Done");
                DisplayStatus();
            }
        }

        /// <summary>
        /// Initialize all the Statistics.
        /// </summary>
        private void Init()
        {
            lstStatistics.Items.Clear();
            lstStatistics.Items.Add("Result:");
            lstStatistics.Items.Add("Current Time (in Seconds): ");
            numOfSec = lstStatistics.Items.Add(NumberOfSeconds);
            lstStatistics.Items.Add("Number Of Words: ");
            numOfWord = lstStatistics.Items.Add(NumberOfWords);            
            lstStatistics.Items.Add("Words per min: ");
            Speed = lstStatistics.Items.Add(TypingSpeed);
            lstStatistics.Items.Add("Total No. Of Character Errors: ");
            wrongCharacter = lstStatistics.Items.Add(Mistakes);
            lstStatistics.Items.Add("Error in Percentage (%): ");          
            errorPercentage = lstStatistics.Items.Add(ErrorPercentage);            
        }       

        /// <summary>
        /// Display all the status information.
        /// </summary>
        private void DisplayStatus()
        {
            lstStatistics.Items[numOfSec] = numOfSec;
            lstStatistics.Items[numOfWord] = numOfWord;
            lstStatistics.Items[Speed] = Speed;
            lstStatistics.Items[wrongCharacter] = wrongCharacter;
            lstStatistics.Items[errorPercentage] = errorPercentage.ToString() + "%";
        }

        /// <summary>
        /// Calculate CharacterMistakes in typing.
        /// </summary>
        private void CharacterMistakes()
        {
            Mistakes = Math.Abs(textPharase.TextLength - textWrite.TextLength);
            int Counter = textPharase.TextLength > textWrite.TextLength ? textWrite.TextLength : textPharase.TextLength;

            for (int i = 0; i < Counter; i++)
            {
                if (textPharase.Text.Substring(i, 1) != textWrite.Text.Substring(i, 1))
                {
                    Mistakes += 1;
                    textWrite.Select(i, 1);
                    textWrite.SelectionBackColor = Color.Red;                    
                }
            }
        }

        /// <summary>
        /// Calculate the errors in typing text.
        /// </summary>
        private void CalculateTypingErrors()
        {
            int correct = 0;
            int incorrect = 0;
            string[] SplitedData = textPharase.Text.Split(' ');            
            string[] strValue = textWrite.Text.Split(' ');

            for (int j = 0; j < strValue.Length; j++)
            {
                if (strValue[j] == SplitedData[j])
                {
                    correct++;
                }
                else if (strValue[j] != SplitedData[j])
                {
                    incorrect++;
                }
            }
            ErrorPercentage = ((double)incorrect * 100 / SplitedData.Length);
        }

        /// <summary>
        /// Test is completed provodes the all result like NumberOfWords,TypingSpeed,CharacterMistakes etc.
        /// </summary>
        private void TestCompleted()
        {
            NumberOfWords++;
            timerTyping.Stop();
            TypingSpeed = (double)NumberOfWords / NumberOfSeconds * 60;
            CharacterMistakes();
            CalculateTypingErrors();
            StartTyping();
        }
        #endregion

        #region Events
        private void FrmTypingTest_Load(object sender, EventArgs e)
        {
            try
            {
                ResetForm();
                var reader = new StreamReader("TestData.txt");

                while (!reader.EndOfStream)
                SampleText = reader.ReadToEnd();

                textWrite.Focus();
                StartTyping();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Key press event fire on textWrite in textbox
        /// </summary>
        private void textWrite_OnKeyPressed(object sender, KeyEventArgs e)
        {
            try
            {                
               
                switch (e.KeyCode)
                {
                    case Keys.Back:
                    case Keys.Delete:
                    case Keys.Left:
                    case Keys.Up:
                    case Keys.Enter:
                        e.SuppressKeyPress = true;
                        break;
                }

                if (e.KeyCode == Keys.Space)
                {
                    NumberOfWords += 1;
                    DisplayStatus();
                }

                if (NumberOfWords == 0)
                {
                    Init();
                    timerTyping.Start(); 
                }

                if (textWrite.TextLength == textPharase.TextLength)
                    TestCompleted();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Incrementing TimerTyping.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTyping_Tick(object sender, EventArgs e)
        {
            try
            {
                NumberOfSeconds += 1;
                DisplayStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        /// <summary>
        /// cnf from user to completed the test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTestDone_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drTestDone = MessageBox.Show("Are you sure you have completed [Yes/No]? ", "Test Done", MessageBoxButtons.YesNo);
                if (drTestDone == DialogResult.Yes)
                {
                    TestCompleted();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Reset the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }        

        /// <summary>
        /// Close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion
    }
}
