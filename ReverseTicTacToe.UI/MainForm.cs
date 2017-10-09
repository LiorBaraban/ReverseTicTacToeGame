using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ReverseTicTacToe.Logic;

namespace ReverseTicTacToe.UI
{
    public partial class MainForm : Form
    {
        private int m_SizeOfBoard;
        private List<Button> m_GameButtons = new List<Button>();
        private Player[] m_Players = new Player[2];
        private GameManager m_GameManager;
        private System.Timers.Timer m_Timer = new System.Timers.Timer();

        public MainForm()
        {
            InitializeComponent();
            initializeGameSettings();
            m_GameManager = new GameManager(m_SizeOfBoard, m_Players);
            initializeGameButtonsAndBoard();
            initilizeOtherGameControls();
        }

        private void initializeGameSettings()
        {
            int playerCounter = 0;
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            gameSettingsForm.ShowDialog();
            if (gameSettingsForm.DialogResult == DialogResult.OK)
            {
                string player1NameStr = gameSettingsForm.textBoxPlayer1Name.Text;
                eGameTokenValue player1GameToken = eGameTokenValue.Player1Token;
                bool player1isAI = false;
                m_Players[playerCounter++] = new Player(player1NameStr, player1GameToken, player1isAI);

                string player2NameStr = gameSettingsForm.textBoxPlayer2Name.Text;
                eGameTokenValue player2GameToken = eGameTokenValue.Player2Token;
                bool player2isAI = !gameSettingsForm.checkBoxPlayer2Type.Checked;
                m_Players[playerCounter++] = new Player(player2NameStr, player2GameToken, player2isAI);

                m_SizeOfBoard = (int)gameSettingsForm.numericUpDownRows.Value;
            }
            else if (gameSettingsForm.DialogResult == DialogResult.Cancel)
            {
                this.Dispose();
                Environment.Exit(1);
            }
        }

        private void initializeGameButtonsAndBoard()
        {
            int marginBetweenButtons = 10;
            int buttonWidth = 60;
            int buttonHeight = 60;
            int boardSize = 0;
            Size buttonSize = new Size(buttonWidth, buttonHeight);
            Point buttonLocation = new Point(marginBetweenButtons, marginBetweenButtons);
            for (int i = 1; i <= m_SizeOfBoard; i++)
            {
                for (int j = 1; j <= m_SizeOfBoard; j++)
                {
                    GameButton gameButton = new GameButton(i, j, buttonSize, marginBetweenButtons, buttonLocation);
                    gameButton.Click += new EventHandler(this.button_Click);
                    m_GameManager.GameBoard.Board[i - 1, j - 1].PlaceToken += new EventHandler(gameButton.Board_DrawPlaceToken);
                    buttonLocation.X += buttonWidth + marginBetweenButtons;
                    m_GameButtons.Add(gameButton);
                    panelGameButtons.Controls.Add(gameButton);
                }

                buttonLocation.X = marginBetweenButtons;
                buttonLocation.Y += buttonHeight + marginBetweenButtons;
            }

            boardSize = buttonLocation.Y;
            this.ClientSize = new Size(boardSize, boardSize + panelScores.Height);
        }

        private void initilizeOtherGameControls()
        {
            this.Text = "Reverse Tic Tac Toe";
            labelPlayer1State.Text = string.Format("{0}: {1}", m_Players[0].PlayerName, m_Players[0].PlayerScore);
            labelPlayer2State.Text = string.Format("{0}: {1}", m_Players[1].PlayerName, m_Players[1].PlayerScore);
            int margin = (labelPlayer1State.Width + labelPlayer2State.Width + 10) / 2;
            labelPlayer1State.Left = (this.ClientSize.Width / 2) - margin;
            labelPlayer2State.Left = labelPlayer1State.Right + 10;
            labelPlayer1State.Font = new Font(labelPlayer1State.Font, FontStyle.Bold);
            m_GameManager.TurnEnd += m_GameManager_TurnEnd;
            m_GameManager.GameEnd += m_GameManager_GameEnd;
            m_Timer.Interval = 100;
            m_Timer.Elapsed += M_Timer_Elapsed;
        }

        private void button_Click(object sender, EventArgs e)
        {
            (sender as GameButton).Enabled = false;
            playRound(sender);
        }

        private void playRound(object sender)
        {
            GameButton button = sender as GameButton;
            eActionStatus roundStatus = m_GameManager.GameRound(button.RowValue - 1, button.ColValue - 1);
            handleRoundResults(roundStatus);
        }

        private void handleRoundResults(eActionStatus i_RoundStatus)
        {
            if (i_RoundStatus == eActionStatus.Valid)
            {
                m_GameManager.OnTurnEnd();
            }
            else
            {
                string titleMsg;
                string bodyMsg;
                if (i_RoundStatus == eActionStatus.EndGameDraw)
                {
                    titleMsg = string.Format("A Tie!");
                    bodyMsg = string.Format("Tie!{0}Would you like to play another round?", Environment.NewLine);
                }
                else 
                {
                    titleMsg = string.Format("A Win!");
                    bodyMsg = string.Format("The winner is {0}!{1}Would you like to play another round?", m_GameManager.BenchedPlayer.PlayerName, Environment.NewLine);
                    m_GameManager.AddScoresToPlayer();
                    updateScoresLabels();
                }

                showEndGameMsg(bodyMsg, titleMsg);
                m_GameManager.OnGameEnd();
            }
        }

        private void showEndGameMsg(string i_BodyMsg, string i_TitleMsg)
        {
            DialogResult dialogResult = MessageBox.Show(i_BodyMsg, i_TitleMsg, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void m_GameManager_TurnEnd(object sender, EventArgs e)
        {
            m_GameManager.ChangePlayer();
            updateCurrentPlayerLabel();
            if (isAITurnNow())
            {
                playAsAI();
            }
        }

        private void m_GameManager_GameEnd(object sender, EventArgs e)
        {
            restartGame();
            m_GameManager_TurnEnd(sender, e);
        }

        private void updateCurrentPlayerLabel()
        {
            if (m_GameManager.CurrentPlayer == m_Players[0])
            {
                labelPlayer1State.Font = new Font(labelPlayer1State.Font, FontStyle.Bold);
                labelPlayer2State.Font = new Font(labelPlayer1State.Font, FontStyle.Regular);
            }
            else
            {
                labelPlayer2State.Font = new Font(labelPlayer1State.Font, FontStyle.Bold);
                labelPlayer1State.Font = new Font(labelPlayer1State.Font, FontStyle.Regular);
            }
        }

        private bool isAITurnNow()
        {
            return m_GameManager.CurrentPlayer.IsAI;
        }

        private void playAsAI()
        {
            foreach (Button button in m_GameButtons)
            {
                button.Enabled = false;
            }

            m_Timer.Enabled = true;
        }

        private void M_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            m_Timer.Enabled = false;
            System.Threading.Thread.Sleep(800);
            pressButtonAsAi();
            foreach (Button button in m_GameButtons)
            {
                if (button.BackgroundImage == null)
                {
                    button.Enabled = true;
                }
            }
        }

        private void pressButtonAsAi()
        {
            List<Button> avilableButtons = new List<Button>();
            foreach (Button button in m_GameButtons)
            {
                if (button.BackgroundImage == null)
                {
                    avilableButtons.Add(button);
                }
            }

            Random selection = new Random();
            int index = selection.Next(0, avilableButtons.Count - 1);
            playRound(avilableButtons[index]);
        }

        private void restartGame()
        {
            foreach (Button button in m_GameButtons)
            {
                button.BackgroundImage = null;
                button.Enabled = true;
            }

            m_GameManager.RestartGame();
        }

        private void updateScoresLabels()
        {
            labelPlayer1State.Text = string.Format("{0}: {1}", m_Players[0].PlayerName, m_Players[0].PlayerScore);
            labelPlayer2State.Text = string.Format("{0}: {1}", m_Players[1].PlayerName, m_Players[1].PlayerScore);
        }

        private void panelGameButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
