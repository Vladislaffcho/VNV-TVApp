﻿using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TvForms.Forms;
using TvContext;

namespace TvForms
{
    public partial class CoreForm : Form//, IIdentifyUser
    {
        private int CurrentUserId { get; set; }// = 2; // need delete '2' after test programme and uncommit ShowLoginForm() in CoreForm constructor

        private UcTabsForUser _userWindow;// { get; set; }

        private UcAdminView _adminWindow;// { get; set; }

        public CoreForm()
        {
            ShowLoginForm(); //uncommit after test programme

            InitializeComponent();
            LoadMainControl();
            backWorker.RunWorkerAsync();

            Text += @" - " + new BaseRepository<User>().Get(u => u.Id == CurrentUserId).FirstOrDefault()?.Login;
            
        }

        public sealed override string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }


        private void LoadMainControl()
        {
            if (CurrentUserId != 0)
            {
                var user = new BaseRepository<User>().Get(x => x.Id == CurrentUserId).FirstOrDefault();
                if (user != null)
                {
                    var userType = user.UserType.Id;

                    switch (userType)   
                    {
                        case (int) EUserType.ADMIN: //admin
                            _adminWindow = new UcAdminView(CurrentUserId);
                            panelCore.Controls.Add(_adminWindow);
                            break;
                        case (int) EUserType.CLIENT: //user
                            _userWindow = new UcTabsForUser(CurrentUserId);
                            panelCore.Controls.Add(_userWindow);
                            loadFromXmlToolStripMenuItem.Visible = false;
                            addServiceToolStripMenuItem.Visible = false;
                            removeServicesToolStripMenuItem.Visible = false;
                            break;
                    }
                }
            }
        }

        
        private void ShowLoginForm()
        {
            var lg = new PassForm();
            if (lg.ShowDialog() == DialogResult.OK)
            {
                CurrentUserId = lg.CurrentUserId;
            }
            else
            {
                Environment.Exit(0);
            }
        }


        private void openXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openXmlFile = new OpenFileDialog
            {
                DefaultExt = "*.xml",
                Filter = @"XML Files|*.xml"
            };

            if (openXmlFile.ShowDialog() != DialogResult.OK || openXmlFile.FileName.Length <= 0) return;

            XmlFileHelper.ParseChannel(openXmlFile.FileName);
            XmlFileHelper.ParseProgramm(openXmlFile.FileName);

            var userType = new BaseRepository<User>().Get(u => u.Id == CurrentUserId).FirstOrDefault()?.UserType.Id;
            if (userType == (int)EUserType.CLIENT)
                _userWindow.SetReloadChannelButton(true, Color.Crimson);
        }


        private void openSavedScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openSavedFile = new OpenFileDialog
            {
                DefaultExt = "(*.xml, *.zip)|*.xml;*.zip",
                Filter = @"XML/ZIP Files|*.xml;*.zip"
            };
            if(openSavedFile.ShowDialog() != DialogResult.OK || openSavedFile.FileName.Length <= 0)
                return;

            var xmlFileName = ZipHelper.UnzipArchiveWithFavourite(openSavedFile.FileName);
            XmlFileHelper.ParseFavouriteMedia(xmlFileName, CurrentUserId);

            var userType = new BaseRepository<User>().Get(u => u.Id == CurrentUserId).FirstOrDefault()?.UserType.Id;
            if(userType == (int)EUserType.CLIENT)
                _userWindow.SetReloadChannelButton(true, Color.Crimson);
        }


        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Uncomment when bookmarks will be ready end specify appropriate one!!!!
            var actions = new ActionForm(new UcUserProfile(CurrentUserId))
            {
                Text = @"User profile",
                //copy icons folder to ...//TvForms/bin/Debug/icons - folder for icons
                Icon = new Icon(@"icons\profile.ico")
            };
            
            this.Visible = false;
            actions.ShowDialog();
            this.Visible = true;
        }


        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var actions = new ActionForm(new UсOrdersView(CurrentUserId))
            {
                Text = @"User orders history",
                //copy icons folder to ...//TvForms/bin/Debug/icons - folder for icons
                Icon = new Icon(@"icons\wallet.ico")
            };
            this.Visible = false;
            actions.ShowDialog();
            this.Visible = true;
        }


        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ucPay = new UcPayments(CurrentUserId);
            //ucPay.Dock = DockStyle.Fill;
            var actions = new ActionForm(ucPay)
            {
                Text = @"PAYMENTS",
                //copy icons folder to ...//TvForms/bin/Debug/icons - folder for icons
                Icon = new Icon(@"icons\dollar.ico")
            };
            this.Visible = false;
            actions.ShowDialog();
            this.Visible = true;
        }


        private void xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog()
            {
                DefaultExt = "*.xml",
                Filter = @"XML Files(*.xml)|*.xml|All files(*.*)|*.*"
            };

            if (saveFile.ShowDialog() == DialogResult.Cancel)
                return;

            XmlFileHelper.XmlFavouriteWriter(saveFile.FileName, CurrentUserId);

            MessageBox.Show(@"XML file was saved successfully", @"Save",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void zipToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var saveFile = new SaveFileDialog()
            {
                DefaultExt = "*.zip",
                Filter = @"ZIP Files(*.zip)|*.zip"
            };

            if (saveFile.ShowDialog() == DialogResult.Cancel)
                return;

            XmlFileHelper.XmlFavouriteWriter(saveFile.FileName.Split('.')[0] + ".xml", CurrentUserId);
            ZipHelper.CreateZipFile(saveFile.FileName, saveFile.FileName.Split('.')[0] + ".xml");
            Helper.DeleteFileIfExist(saveFile.FileName.Split('.')[0] + ".xml");

            MessageBox.Show(@"ZIP file was saved successfully", @"Save",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private void CoreForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var ordRepo = new BaseRepository<Order>();
            var schedRepo = new BaseRepository<UserSchedule>(ordRepo.ContextDb);
            var ordChannelRepo = new BaseRepository<OrderChannel>(ordRepo.ContextDb);

            var notPaidOrders = ordRepo.Get(order => order.IsPaid == false).ToList();
            var notPaidChannels = ordChannelRepo.Get(ch => ch.Order.IsPaid == false &&
                ch.Order.User.Id == CurrentUserId || ch.Order == null).ToList();

            //var ordChannels = ordChannelRepo.Get(oCh => oCh.Order.User.Id == CurrentUserId)?.ToList();
            var needCheckForRemoveTvShow = schedRepo.Get(pr => pr.User.Id == CurrentUserId)?
                .Include(sh => sh.TvShow).ToList();
            
            //delete all not paid twShows
            if (needCheckForRemoveTvShow != null && notPaidChannels.Count > 0)
                foreach (var show in needCheckForRemoveTvShow)
                {
                    //if (ordChannels.Find(ch => ch.Channel.Id == show.TvShow.Channel.Id) == null)
                    if (notPaidChannels.Find(ch => ch.Channel?.OriginalId == show.TvShow.CodeOriginalChannel) != null)
                        schedRepo.Remove(show);

                }

            //delete all ordered channels which are not paid
            ordChannelRepo.RemoveRange(notPaidChannels);

            //delete not paid orders
            foreach (var order in notPaidOrders)
                ordRepo.Remove(order);
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new About();
            ab.ShowDialog();
        }

        private void accountRechargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var acc = new BaseRepository<Account>().Get(a => a.User.Id == CurrentUserId).FirstOrDefault();
            if (acc?.IsActiveStatus == false)
            {
                MessageContainer.DisplayError("Account is diactivated!" + Environment.NewLine +
                                               "Please connect to administrator", "Attention!!!");
                return;
            }

            var actions = new AccountChargeForm(CurrentUserId)
            {
                Text = @"Account recharge",
                //copy icons folder to ...//TvForms/bin/Debug/icons - folder for icons
                Icon = new Icon(@"icons\mastercard_1450.ico")
            };
            this.ShowInTaskbar = false;
            actions.ShowDialog();
            this.ShowInTaskbar = true;

            var userType = new BaseRepository<User>().Get(u => u.Id == CurrentUserId).FirstOrDefault()?.UserType.Id;
            if (userType == (int)EUserType.CLIENT)
               _userWindow.SetReloadMoneyButton(true, Color.Crimson);
        }

        private void additionalServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userType = new BaseRepository<User>().Get(u => u.Id == CurrentUserId).FirstOrDefault()?.UserType.Id;
            if (userType == (int) EUserType.CLIENT)
            {
                var additionalServices = new AdditionalServicesForm(CurrentUserId);
                this.ShowInTaskbar = false;
                additionalServices.ShowDialog();
                this.ShowInTaskbar = true;
                _userWindow.SetReloadMoneyButton(true, Color.Crimson);
            }
        }

        // add additional servide to the DB
        private void addServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addCompanyServices = new AddServiceForm();
            this.ShowInTaskbar = false;
            addCompanyServices.ShowDialog();
            this.ShowInTaskbar = true;
        }

        // remove addotional service from the db
        private void removeServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var removeCompanyServices = new DeleteServiceForm();
            this.ShowInTaskbar = false;
            removeCompanyServices.ShowDialog();
            this.ShowInTaskbar = true;
        }

        private void backWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(30000);
                MessageContainer.Remind();
            }
        }

    }
}
