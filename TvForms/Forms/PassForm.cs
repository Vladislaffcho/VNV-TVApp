﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace TvForms
{
    public partial class PassForm : Form
    {

        public int CurrentUserId { get; set; }

        public PassForm()
        {
            InitializeComponent();

            //set cursor in login textBox field by default
            this.tbPassForm_Login.Select();
            this.tbPassForm_Login.ScrollToCaret();

            //hide characters in pass field by default
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;

            //this.tbPassForm_Login.Text = "litvak83"; //delete this string when program will be tested
            //this.tbPassForm_Pass.Text = "2222";  //delete this string when program will be tested
            //this.tbPassForm_Login.Text = "root"; //delete this string when program will be tested
            //this.tbPassForm_Pass.Text = "1111";  //delete this string when program will be tested
        }


        private int UserIdDetect()
        {
            //go to database and check user or admin exists
            if (tbPassForm_Pass.Text != string.Empty)
            {
                using (var context = new TvContext.TvDbContext())
                {
                    //get datas from form text fields 
                    var loginEntered = tbPassForm_Login.Text;
                    var passEntered = tbPassForm_Pass.Text;

                    //generate appropriate code from entered pass with md5Hash (soul for password)
                    var pssCoded = passEntered.GetMd5Hash();

                    //get saved pass from DB
                    var savedPass = (from p in context.Users
                                        where p.Login == loginEntered
                                        select p.Password).FirstOrDefault();

                    //compare login and pass from text fields and DB
                    if (loginEntered.Length > 0 && loginEntered != string.Empty
                        && savedPass == pssCoded)
                    {
                        CurrentUserId = (from p in context.Users
                                            where p.Login == loginEntered
                                            select p.Id).FirstOrDefault();
                    }
                    else
                    {
                        //return 0 if current user doesn't exist
                        CurrentUserId = 0;
                    }
                }
            }
            else
            {
                //return 0 if current user doesn't exist
                CurrentUserId = 0;
            }
            return CurrentUserId;
        }

        //hide/show pass during tap
        private void chBPassForm_ShowPass_CheckStateChanged(object sender, EventArgs e)
        {
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;
        }

        //behavior of passForm
        private void PassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var eventSource = (Form)sender;

            if (eventSource.DialogResult != DialogResult.OK)
                return;
            CurrentUserId = UserIdDetect();

            if (CurrentUserId != 0)
                return;
            MessageContainer.DisplayError("Incorrect login or password", "Access denied");
            e.Cancel = true;
        }


        //register new user in App
        private void linkLbPassForm_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var actions = new AddUserDataForm(UserDetailType.User)
            {
                Text = @"Register new user",
                Icon = new Icon(@"icons\evolution-contacts_8297.ico")
            };
            this.Visible = false;
            actions.ShowDialog();
            this.Visible = true;
        }


        //recovery password
        private void linkLbPassForm_FogotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var actions = new AddUserDataForm(UserDetailType.Password);
            actions.Text = @"Recovery password";
            actions.Icon = new Icon(@"icons\password_2806.ico");
            this.Visible = false;
            actions.ShowDialog();
            this.Visible = true;
        }
    }
}
