﻿using System;
using System.Collections.Generic;
using Dalamud.Configuration;
using Dalamud.Plugin;
using MakePlacePlugin.Objects;

namespace MakePlacePlugin
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 0;

        public bool ShowTooltips = true;
        public bool DrawScreen = false;
        public float DrawDistance = 0;
        public List<int> HiddenScreenItemHistory = new List<int>();
        public List<int> GroupingList = new List<int>();
        public bool PlaceAnywhere = false;

        public List<HousingItem> HousingItemList = new List<HousingItem>();
        public List<string> Tags = new List<string>();
        public List<bool> TagsSelectList = new List<bool>();
        public int LocationId = 0;
        public List<HousingItem> UploadItems = new List<HousingItem>();
        public int LoadInterval = 400;


        public bool SyncPos = false;
        public int SelectedItemIndex = -1;
        public float PlaceX = 0;
        public float PlaceY = 0;
        public float PlaceZ = 0;
        public float PlaceRotate = 0;
        public DateTime lastPosPackageTime = DateTime.Now;

        public string SaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).Replace('\\', '/') + "/MakePlace/save.json";

        #region Init and Save

        [NonSerialized] private DalamudPluginInterface _pluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            _pluginInterface = pluginInterface;
        }

        public void Save()
        {
            _pluginInterface.SavePluginConfig(this);
        }

        public void ResetRecord()
        {
            PlaceX = 0;
            PlaceY = 0;
            PlaceZ = 0;
            PlaceRotate = 0;
            SelectedItemIndex = -1;
            HiddenScreenItemHistory.Clear();
            GroupingList.Clear();
            Save();
        }

        #endregion
    }
}