﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    
    partial class UcAllChannels
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcAllChannels));
            this.tabControl_Shows = new System.Windows.Forms.TabControl();
            this.tabShows_Sunday = new System.Windows.Forms.TabPage();
            this.tabShows_Monday = new System.Windows.Forms.TabPage();
            this.tabShows_Tuesday = new System.Windows.Forms.TabPage();
            this.tabShows_Wednesday = new System.Windows.Forms.TabPage();
            this.tabShows_Thursday = new System.Windows.Forms.TabPage();
            this.tabShows_Friday = new System.Windows.Forms.TabPage();
            this.tabShows_Saturday = new System.Windows.Forms.TabPage();
            this.gbAllCh_Description = new System.Windows.Forms.GroupBox();
            this.rtbAllCh_Description = new System.Windows.Forms.RichTextBox();
            this.gbUcAllChannel = new System.Windows.Forms.GroupBox();
            this.btReload = new System.Windows.Forms.Button();
            this.cbCheckAllChannels = new System.Windows.Forms.CheckBox();
            this.cbOnlyChosenChannels = new System.Windows.Forms.CheckBox();
            this.lvChannelsList = new System.Windows.Forms.ListView();
            this.lvChNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvChName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPriceChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvIsAdultChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl_Shows.SuspendLayout();
            this.gbAllCh_Description.SuspendLayout();
            this.gbUcAllChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_Shows
            // 
            this.tabControl_Shows.Controls.Add(this.tabShows_Sunday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Monday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Tuesday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Wednesday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Thursday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Friday);
            this.tabControl_Shows.Controls.Add(this.tabShows_Saturday);
            this.tabControl_Shows.Location = new System.Drawing.Point(350, 16);
            this.tabControl_Shows.Name = "tabControl_Shows";
            this.tabControl_Shows.SelectedIndex = 0;
            this.tabControl_Shows.Size = new System.Drawing.Size(409, 307);
            this.tabControl_Shows.TabIndex = 2;
            this.tabControl_Shows.SelectedIndexChanged += new System.EventHandler(this.tabControl_Shows_SelectedIndexChanged);
            // 
            // tabShows_Sunday
            // 
            this.tabShows_Sunday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Sunday.Name = "tabShows_Sunday";
            this.tabShows_Sunday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Sunday.Size = new System.Drawing.Size(401, 281);
            this.tabShows_Sunday.TabIndex = 8;
            this.tabShows_Sunday.Text = "Sunday";
            this.tabShows_Sunday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Monday
            // 
            this.tabShows_Monday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Monday.Name = "tabShows_Monday";
            this.tabShows_Monday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Monday.Size = new System.Drawing.Size(401, 281);
            this.tabShows_Monday.TabIndex = 1;
            this.tabShows_Monday.Text = "Monday";
            this.tabShows_Monday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Tuesday
            // 
            this.tabShows_Tuesday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Tuesday.Name = "tabShows_Tuesday";
            this.tabShows_Tuesday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Tuesday.Size = new System.Drawing.Size(401, 281);
            this.tabShows_Tuesday.TabIndex = 7;
            this.tabShows_Tuesday.Text = "Tuesday";
            this.tabShows_Tuesday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Wednesday
            // 
            this.tabShows_Wednesday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Wednesday.Name = "tabShows_Wednesday";
            this.tabShows_Wednesday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Wednesday.Size = new System.Drawing.Size(401, 281);
            this.tabShows_Wednesday.TabIndex = 3;
            this.tabShows_Wednesday.Text = "Wednesday";
            this.tabShows_Wednesday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Thursday
            // 
            this.tabShows_Thursday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Thursday.Name = "tabShows_Thursday";
            this.tabShows_Thursday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Thursday.Size = new System.Drawing.Size(401, 281);
            this.tabShows_Thursday.TabIndex = 4;
            this.tabShows_Thursday.Text = "Thursday";
            this.tabShows_Thursday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Friday
            // 
            this.tabShows_Friday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Friday.Name = "tabShows_Friday";
            this.tabShows_Friday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Friday.Size = new System.Drawing.Size(401, 281);
            this.tabShows_Friday.TabIndex = 5;
            this.tabShows_Friday.Text = "Friday";
            this.tabShows_Friday.UseVisualStyleBackColor = true;
            // 
            // tabShows_Saturday
            // 
            this.tabShows_Saturday.Location = new System.Drawing.Point(4, 22);
            this.tabShows_Saturday.Name = "tabShows_Saturday";
            this.tabShows_Saturday.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows_Saturday.Size = new System.Drawing.Size(401, 281);
            this.tabShows_Saturday.TabIndex = 6;
            this.tabShows_Saturday.Text = "Saturday";
            this.tabShows_Saturday.UseVisualStyleBackColor = true;
            // 
            // gbAllCh_Description
            // 
            this.gbAllCh_Description.Controls.Add(this.rtbAllCh_Description);
            this.gbAllCh_Description.Location = new System.Drawing.Point(350, 351);
            this.gbAllCh_Description.Name = "gbAllCh_Description";
            this.gbAllCh_Description.Size = new System.Drawing.Size(409, 46);
            this.gbAllCh_Description.TabIndex = 8;
            this.gbAllCh_Description.TabStop = false;
            this.gbAllCh_Description.Text = "Show description";
            // 
            // rtbAllCh_Description
            // 
            this.rtbAllCh_Description.Enabled = false;
            this.rtbAllCh_Description.Location = new System.Drawing.Point(2, 18);
            this.rtbAllCh_Description.Name = "rtbAllCh_Description";
            this.rtbAllCh_Description.Size = new System.Drawing.Size(403, 22);
            this.rtbAllCh_Description.TabIndex = 0;
            this.rtbAllCh_Description.Text = "";
            // 
            // gbUcAllChannel
            // 
            this.gbUcAllChannel.Controls.Add(this.btReload);
            this.gbUcAllChannel.Controls.Add(this.cbCheckAllChannels);
            this.gbUcAllChannel.Controls.Add(this.cbOnlyChosenChannels);
            this.gbUcAllChannel.Controls.Add(this.lvChannelsList);
            this.gbUcAllChannel.Controls.Add(this.gbAllCh_Description);
            this.gbUcAllChannel.Controls.Add(this.tabControl_Shows);
            this.gbUcAllChannel.Location = new System.Drawing.Point(8, 8);
            this.gbUcAllChannel.Name = "gbUcAllChannel";
            this.gbUcAllChannel.Size = new System.Drawing.Size(765, 400);
            this.gbUcAllChannel.TabIndex = 0;
            this.gbUcAllChannel.TabStop = false;
            this.gbUcAllChannel.Text = "Channel choose";
            // 
            // btReload
            // 
            this.btReload.ForeColor = System.Drawing.Color.Crimson;
            this.btReload.Image = ((System.Drawing.Image)(resources.GetObject("btReload.Image")));
            this.btReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReload.Location = new System.Drawing.Point(256, 364);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(70, 29);
            this.btReload.TabIndex = 11;
            this.btReload.Text = "Reload";
            this.btReload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Visible = false;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // cbCheckAllChannels
            // 
            this.cbCheckAllChannels.AutoSize = true;
            this.cbCheckAllChannels.Location = new System.Drawing.Point(506, 332);
            this.cbCheckAllChannels.Name = "cbCheckAllChannels";
            this.cbCheckAllChannels.Size = new System.Drawing.Size(116, 17);
            this.cbCheckAllChannels.TabIndex = 10;
            this.cbCheckAllChannels.Text = "Check all channels";
            this.cbCheckAllChannels.UseVisualStyleBackColor = true;
            this.cbCheckAllChannels.CheckedChanged += new System.EventHandler(this.cbCheckAllChannels_CheckedChanged);
            // 
            // cbOnlyChosenChannels
            // 
            this.cbOnlyChosenChannels.AutoSize = true;
            this.cbOnlyChosenChannels.Location = new System.Drawing.Point(628, 332);
            this.cbOnlyChosenChannels.Name = "cbOnlyChosenChannels";
            this.cbOnlyChosenChannels.Size = new System.Drawing.Size(131, 17);
            this.cbOnlyChosenChannels.TabIndex = 0;
            this.cbOnlyChosenChannels.Text = "Only chosen channels";
            this.cbOnlyChosenChannels.UseVisualStyleBackColor = true;
            this.cbOnlyChosenChannels.CheckedChanged += new System.EventHandler(this.cbOnlyChosenChannels_CheckedChanged);
            // 
            // lvChannelsList
            // 
            this.lvChannelsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvChannelsList.CheckBoxes = true;
            this.lvChannelsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvChNumber,
            this.lvChName,
            this.lvPriceChannel,
            this.lvIsAdultChannel});
            this.lvChannelsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvChannelsList.FullRowSelect = true;
            this.lvChannelsList.GridLines = true;
            this.lvChannelsList.LabelWrap = false;
            this.lvChannelsList.Location = new System.Drawing.Point(3, 16);
            this.lvChannelsList.Name = "lvChannelsList";
            this.lvChannelsList.ShowItemToolTips = true;
            this.lvChannelsList.Size = new System.Drawing.Size(341, 381);
            this.lvChannelsList.TabIndex = 9;
            this.lvChannelsList.UseCompatibleStateImageBehavior = false;
            this.lvChannelsList.View = System.Windows.Forms.View.Details;
            this.lvChannelsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvChannelsList_ItemCheck);
            // 
            // lvChNumber
            // 
            this.lvChNumber.Text = "№";
            this.lvChNumber.Width = 47;
            // 
            // lvChName
            // 
            this.lvChName.Text = "Channel";
            this.lvChName.Width = 166;
            // 
            // lvPriceChannel
            // 
            this.lvPriceChannel.Text = "Price";
            this.lvPriceChannel.Width = 64;
            // 
            // lvIsAdultChannel
            // 
            this.lvIsAdultChannel.Text = "Adult";
            this.lvIsAdultChannel.Width = 37;
            // 
            // UcAllChannels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.gbUcAllChannel);
            this.Name = "UcAllChannels";
            this.Size = new System.Drawing.Size(776, 411);
            this.tabControl_Shows.ResumeLayout(false);
            this.gbAllCh_Description.ResumeLayout(false);
            this.gbUcAllChannel.ResumeLayout(false);
            this.gbUcAllChannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl_Shows;
        private TabPage tabShows_Monday;
        private TabPage tabShows_Wednesday;
        private TabPage tabShows_Thursday;
        private TabPage tabShows_Friday;
        private TabPage tabShows_Saturday;
        private GroupBox gbAllCh_Description;
        private RichTextBox rtbAllCh_Description;
        private GroupBox gbUcAllChannel;
        private ListView lvChannelsList;
        private ColumnHeader lvChNumber;
        private ColumnHeader lvChName;
        private TabPage tabShows_Tuesday;
        private TabPage tabShows_Sunday;
        private ColumnHeader lvPriceChannel;
        private ColumnHeader lvIsAdultChannel;
        private CheckBox cbOnlyChosenChannels;
        private CheckBox cbCheckAllChannels;
        private Button btReload;
    }
}
