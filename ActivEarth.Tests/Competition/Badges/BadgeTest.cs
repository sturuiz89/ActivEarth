﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ActivEarth.Objects.Groups;
using ActivEarth.Objects.Profile;
using ActivEarth.Objects.Competition;
using ActivEarth.Objects.Competition.Badges;

namespace ActivEarth.Tests.Competition.Badges
{
    /// <summary>
    /// Test the functionality of the Badge system
    /// </summary>
    [TestClass]
    public class BadgeTest
    {
        private User _user;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new user with fresh (level 0) badges.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _user = new User("Test", "Subject");

            _user.Badges[Statistic.BikeDistance] = 
                new Badge(1, "BikeDistance", _user, Statistic.BikeDistance,
                BadgeConstants.BikeDistance.REQUIREMENTS, BadgeConstants.BikeDistance.REWARDS,
                BadgeConstants.BikeDistance.IMAGES);

            _user.Badges[Statistic.WalkDistance] =
                new Badge(2, "WalkDistance", _user, Statistic.WalkDistance,
                BadgeConstants.WalkDistance.REQUIREMENTS, BadgeConstants.WalkDistance.REWARDS,
                BadgeConstants.WalkDistance.IMAGES);

            _user.Badges[Statistic.RunDistance] =
                new Badge(3, "RunDistance", _user, Statistic.RunDistance,
                BadgeConstants.RunDistance.REQUIREMENTS, BadgeConstants.RunDistance.REWARDS,
                BadgeConstants.RunDistance.IMAGES);

            _user.Badges[Statistic.Steps] =
                new Badge(4, "Steps", _user, Statistic.Steps,
                BadgeConstants.Steps.REQUIREMENTS, BadgeConstants.Steps.REWARDS,
                BadgeConstants.Steps.IMAGES);

            _user.Badges[Statistic.ChallengesCompleted] =
                new Badge(5, "ChallengesCompleted", _user, Statistic.ChallengesCompleted,
                BadgeConstants.Challenges.REQUIREMENTS, BadgeConstants.Challenges.REWARDS,
                BadgeConstants.Challenges.IMAGES);

            _user.SetStatistic(Statistic.BikeDistance, 0);
            _user.SetStatistic(Statistic.WalkDistance, 0);
            _user.SetStatistic(Statistic.RunDistance, 0);
            _user.SetStatistic(Statistic.Steps, 0);
            _user.SetStatistic(Statistic.ChallengesCompleted, 0);
        }

        #region ---------- Test Cases ----------

        /// <summary>
        /// Verifies that upon its creation, a fresh badge reports no earned activity points.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1) Initialize new badge with statistic at 0.
        /// 2) VERIFY: No activity points are reported by Update().
        /// </remarks>
        [TestMethod]
        public void TestBadgeUpdateInitialState()
        {
            Log("Fetching Steps badge");
            Badge badge = _user.Badges[Statistic.Steps];

            Log("Verifying no activity points are reported by the badge");
            Assert.AreEqual(0, badge.Update());
        }


        /// <summary>
        /// Verifies that a badge does not report earned activity points more than once.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1) Initialize new badge with statistic at 0.
        /// 2) Increase statistic such that a new badge level is earned.
        /// 3) VERIFY: Update() reports newly earned activity points on first call.
        /// 4) VERIFY; Update() reports no newly earned activity points on subsequent call.
        /// </remarks>
        [TestMethod]
        public void TestBadgeUpdateNoChange()
        {
            Log("Fetching Steps badge");
            Badge badge = _user.Badges[Statistic.Steps];

            Log("Updating user's step statistic to the bronze badge level");
            _user.SetStatistic(Statistic.Steps, BadgeConstants.Steps.REQUIREMENTS[BadgeLevels.Bronze]);

            Log("Verifying that first update reports bronze badge reward");
            Assert.AreEqual(BadgeConstants.Steps.REWARDS[BadgeLevels.Bronze], badge.Update());

            Log("Verifying that second update reports no new activity points");
            Assert.AreEqual(0, badge.Update());
        }

        /// <summary>
        /// Verifies that activity points are reported correctly when a badge increases by a single level.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1) Initialize new badge with statistic at 0.
        /// 2) Loop through each badge level by increasing the statistics to the required level.
        /// 3) VERIFY: For each level, the correct number of activity points are rewarded.
        /// </remarks>
        [TestMethod]
        public void TestBadgeUpdateUpOneLevel()
        {
            Log("Fetching Steps badge");
            Badge badge = _user.Badges[Statistic.Steps];

            for (int level = BadgeLevels.Bronze; level <= BadgeLevels.Max; level++)
            {
                Log(String.Format("Increasing badge to level {0}", level));
                _user.SetStatistic(Statistic.Steps, BadgeConstants.Steps.REQUIREMENTS[level]);

                Log("Verifying badge reward on update");
                Assert.AreEqual(BadgeConstants.Steps.REWARDS[level], badge.Update());
            }
        }

        /// <summary>
        /// Verifies that activity points are reported correctly when a badge increases by multiple levels.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1) Initialize new badge with statistic at 0.
        /// 2) Loop through each badge level (skipping every other level) by increasing the 
        ///     statistics to the required level.
        /// 3) VERIFY: For each level reached, both the earned level and the skipped level's points are reported.
        /// </remarks>
        [TestMethod]
        public void TestBadgeUpdateUpMultipleLevels()
        {
            Log("Fetching Steps badge");
            Badge badge = _user.Badges[Statistic.Steps];

            for (int level = BadgeLevels.Bronze; level <= BadgeLevels.Max; level+=2)
            {
                Log(String.Format("Increasing badge to level {0}", level));
                _user.SetStatistic(Statistic.Steps, BadgeConstants.Steps.REQUIREMENTS[level]);

                Log("Verifying badge reward on update");
                Assert.AreEqual(BadgeConstants.Steps.REWARDS[level] + BadgeConstants.Steps.REWARDS[level - 1], badge.Update());
            }
        }

        /// <summary>
        /// Verifies that badges linked to different statistics operate independently of one another.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1) Initialize new badges with statistic at 0 for two different statistics.
        /// 2) Increase both relevant statistics to the bronze level.
        /// 3) VERIFY: Both badges report bronze-level activity points on Update.
        /// 4) Increase one of the relevant statistics to the silver level.
        /// 5) VERIFY: The unchanged badge reports no new activity points on Update.
        /// 6) VERIFY: The changed badge reports silver-level activity points on Update.
        /// </remarks>
        [TestMethod]
        public void TestBadgeStatisticIndependence()
        {
            Log("Fetching Steps badge");
            Badge stepBadge = _user.Badges[Statistic.Steps];

            Log("Fetching Walking badge");
            Badge walkBadge = _user.Badges[Statistic.WalkDistance];

            Log("Setting user's initial statistics to bronze levels");
            _user.SetStatistic(Statistic.Steps, BadgeConstants.Steps.REQUIREMENTS[BadgeLevels.Bronze]);
            _user.SetStatistic(Statistic.WalkDistance, BadgeConstants.WalkDistance.REQUIREMENTS[BadgeLevels.Bronze]);

            Log("Verifying step badge reward");
            Assert.AreEqual(BadgeConstants.Steps.REWARDS[BadgeLevels.Bronze], stepBadge.Update());

            Log("Verifying walking badge reward");
            Assert.AreEqual(BadgeConstants.WalkDistance.REWARDS[BadgeLevels.Bronze], walkBadge.Update());

            Log("Increasing step statistic to silver level");
            _user.SetStatistic(Statistic.Steps, BadgeConstants.Steps.REQUIREMENTS[BadgeLevels.Silver]);

            Log("Verifying no new walking badge points awarded");
            Assert.AreEqual(0, walkBadge.Update());

            Log("Verifying silver level step badge points awarded");
            Assert.AreEqual(BadgeConstants.Steps.REWARDS[BadgeLevels.Silver], stepBadge.Update());
        }

        /// <summary>
        /// Verifies that the badge image path changes appropriately as the badge increases in level.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1) Initialize new badge with statistic at 0.
        /// 2) Loop through each badge level by increasing the statistics to the required level.
        /// 3) VERIFY: For each level reached, the correct image path is reported.
        /// </remarks>
        [TestMethod]
        public void TestBadgeGetImagePath()
        {

            Log("Fetching Steps badge");
            Badge badge = _user.Badges[Statistic.Steps];

            for (int level = BadgeLevels.None; level <= BadgeLevels.Max; level++)
            {
                Log(String.Format("Increasing badge to level {0}", level));
                _user.SetStatistic(Statistic.Steps, BadgeConstants.Steps.REQUIREMENTS[level]);

                Log("Updating badge");
                badge.Update();

                Log("Verifying badge image path");
                Assert.AreEqual(BadgeConstants.Steps.IMAGES[level], badge.GetImagePath());
            }
        }

        /// <summary>
        /// Verifies that the requirement for the next level is reported correctly for each 
        /// badge level.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1) Initialize new badge with statistic at 0.
        /// 2) Loop through each badge level by increasing the statistics to the required level.
        /// 3) VERIFY: For each level reached, the correct requirement is reported.
        /// 
        /// NOTE: When the badge level is maximized, the next level requirement should be reported
        ///     as infinity.
        /// </remarks>
        [TestMethod]
        public void TestBadgeGetNextLevelRequirement()
        {
            Log("Fetching Steps badge");
            Badge badge = _user.Badges[Statistic.Steps];

            for (int level = BadgeLevels.None; level <= BadgeLevels.Max; level++)
            {
                Log(String.Format("Increasing badge to level {0}", level));
                _user.SetStatistic(Statistic.Steps, BadgeConstants.Steps.REQUIREMENTS[level]);

                Log("Updating badge");
                badge.Update();

                Log(String.Format("Verifying next level requirement. Expected: {0}", 
                    BadgeConstants.Steps.REQUIREMENTS[level + 1]));

                Assert.AreEqual(BadgeConstants.Steps.REQUIREMENTS[level + 1], badge.GetNextLevelRequirement());
            }
        }

        /// <summary>
        /// Verifies that the activity score reward for the next level is reported correctly 
        /// for each badge level.
        /// </summary>
        /// <remarks>
        /// Steps:
        /// 1) Initialize new badge with statistic at 0.
        /// 2) Loop through each badge level by increasing the statistics to the required level.
        /// 3) VERIFY: For each level reached, the correct reward is reported.
        /// 
        /// NOTE: When the badge level is maximized, the next level requirement should be reported
        ///     as 0.
        /// </remarks>
        [TestMethod]
        public void TestBadgeGetNextLevelPoints()
        {
            Log("Fetching Steps badge");
            Badge badge = _user.Badges[Statistic.Steps];

            for (int level = BadgeLevels.None; level <= BadgeLevels.Max; level++)
            {
                Log(String.Format("Increasing badge to level {0}", level));
                _user.SetStatistic(Statistic.Steps, BadgeConstants.Steps.REQUIREMENTS[level]);

                Log("Updating badge");
                badge.Update();

                Log(String.Format("Verifying next level reward. Expected: {0}",
                    BadgeConstants.Steps.REWARDS[level + 1]));

                Assert.AreEqual(BadgeConstants.Steps.REWARDS[level + 1], badge.GetNextLevelReward());
            }
        }

        #endregion ---------- Test Cases ----------

        #region ---------- Utility Methods ----------

        /// <summary>
        /// Logs a message to the Test Context's output (Test Results file).
        /// </summary>
        /// <param name="message">Message to add to the test log.</param>
        private void Log(string message)
        {
            TestContext.WriteLine(message);
        }

        #endregion ---------- Utility Methods ----------
    }
}
