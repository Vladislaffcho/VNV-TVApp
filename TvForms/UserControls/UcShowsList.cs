﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcShowsList : UserControl
    {

        private int CurrentUserId { get; set; }

        private int DisplayIndexShows { get; } = /*new BaseRepository<TvShow>().Get(s => s.Id > 0).First().Id - */0;



        public UcShowsList(int userId)
        {
            InitializeComponent();
            CurrentUserId = userId;
        }

    
        public void LoadShows(List<TvShow> shows)
        {
            if (shows.Count <= 0)
                return;

            var scheduleShows = new BaseRepository<UserSchedule>().Get(sc => sc.User.Id == CurrentUserId).ToList();
            var schShowsIdList = scheduleShows.Select(show => show.TvShow.Id).ToList();

            lvShowPrograms.Items.Clear();

            ListViewItem[] arrTvShowsItems = ProgrammeToListViewItem(shows).ToArray();

            lvShowPrograms.BeginUpdate();

            ListView.ListViewItemCollection lvic = new ListView.ListViewItemCollection(lvShowPrograms);
            lvic.AddRange(arrTvShowsItems);

            foreach (ListViewItem item in arrTvShowsItems)
                if (schShowsIdList.Any(schedule => schedule == item.SubItems[5].Text.GetInt()))
                    item.Checked = true;

            lvShowPrograms.EndUpdate();
        }

        private List<ListViewItem> ProgrammeToListViewItem(List<TvShow> shows)
        {
            var itemsList = new List<ListViewItem>();
            //var displayIndexShows = 1;
            //-----------------------------------------
            var channelsAll = new BaseRepository<Channel>().GetAll().ToList();
            var scheduleShows = new BaseRepository<UserSchedule>()
                .Get(sc => sc.User.Id == CurrentUserId).ToList();
            //-----------------------------------------

            foreach (var sh in shows)
            {
                var item = new ListViewItem((sh.Id - DisplayIndexShows).ToString());

                item.SubItems.Add($"{sh.Date.Hour:00}:{sh.Date.Minute:00}");
                item.SubItems.Add($"{sh.Date.Day:00}/{sh.Date.Month:00}");
                item.SubItems.Add(sh.Name);

                var channel = channelsAll.Find(ch => ch.OriginalId == sh.CodeOriginalChannel);
                item.SubItems.Add(channel?.Name ?? "o|o");
                item.SubItems.Add(channel?.OriginalId.ToString() ?? "0");

                item.SubItems.Add(sh.Id.ToString());

                itemsList.Add(item);

                if (scheduleShows.Find(s => s.TvShow.Id == sh.Id) != null)
                {
                    item.Checked = true;
                }
            }

            return itemsList;
        }


        public void AddTvShowsToControl(List<TvShow> addShows)
        {
            //-----------------------------------------
            var channelsAll = new BaseRepository<Channel>().GetAll().ToList();

            //do not add shows if this shows are in the list
            foreach (ListViewItem item in lvShowPrograms.Items)
            {
                if (addShows[0].CodeOriginalChannel == item.SubItems[5].Text.GetInt())
                {
                    return;
                }    
            }
            

            //-----------------------------------------
            foreach (var sh in addShows)
            {
                var item = new ListViewItem((sh.Id - DisplayIndexShows).ToString());

                item.SubItems.Add($"{sh.Date.Hour:00}:{sh.Date.Minute:00}");
                item.SubItems.Add($"{sh.Date.Day:00}/{sh.Date.Month:00}");
                item.SubItems.Add(sh.Name);

                var channel = channelsAll.Find(ch => ch.OriginalId == sh.CodeOriginalChannel);
                item.SubItems.Add(channel.Name);
                item.SubItems.Add(channel.OriginalId.ToString());
                item.SubItems.Add(sh.Id.ToString());

                lvShowPrograms.Items.Add(item);
            }

        }

        public void RemoveTvShowsFromControl(int channelOriginalId)
        {
            foreach (ListViewItem item in lvShowPrograms.Items)
                if (item.SubItems[5].Text.GetInt() == channelOriginalId)
                    lvShowPrograms.Items[item.Index].Remove();
        }


        private void lvShowPrograms_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //tv programme id in listview
            var id = lvShowPrograms.Items[e.Index].SubItems[6].Text.GetInt();
            var userRepo = new BaseRepository<User>();
            var scheduleRepo = new BaseRepository<UserSchedule>(userRepo.ContextDb);
            var user = userRepo.Get(u => u.Id == CurrentUserId).FirstOrDefault();

            switch (e.NewValue)
            {
                case CheckState.Checked:
                    if (scheduleRepo.GetAll().ToList().Find(s => s.TvShow.Id == id 
                        && s.User.Id == CurrentUserId) == null)
                    {
                        var schedule = new UserSchedule
                        {
                            DueDate = DateTime.Now.AddDays(7),
                            User = user,
                            TvShow = new BaseRepository<TvShow>(userRepo.ContextDb)
                                .Get(s => s.Id == id).FirstOrDefault()
                        };
                        scheduleRepo.Insert(schedule);
                    }
                    break;

                case CheckState.Unchecked:
                    var removeSh = scheduleRepo.Get(x => x.TvShow.Id == id).FirstOrDefault();
                    if (removeSh != null)
                    {
                        scheduleRepo.Remove(removeSh);
                    }
                    break;

                case CheckState.Indeterminate:
                    MessageContainer.DisplayError("Something went wrong in checking/unchecking tvShows (case CheckState.Indeterminate:)", "Error");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }
    
    }
}
