﻿using System.Collections;
using Sanicball.Logic;
using UnityEngine;

namespace Sanicball.UI
{
    public class RaceUI : MonoBehaviour
    {
        [SerializeField]
        private PlayerPortrait portraitPrefab = null;

        [SerializeField]
        private Transform portraitContainer = null;

        [SerializeField]
        private Scoreboard scoreboard;

        public RaceManager TargetManager { get; set; }

        private void Start()
        {
            for (int i = 0; i < TargetManager.PlayerCount; i++)
            {
                var p = Instantiate(portraitPrefab);
                p.transform.SetParent(portraitContainer, false);
                p.TargetPlayer = TargetManager[i];
            }
        }

        public void ShowScoreboard()
        {
            scoreboard.GetComponent<ToggleCanvasGroup>().Show();
            scoreboard.DisplayResults(TargetManager);
        }
    }
}