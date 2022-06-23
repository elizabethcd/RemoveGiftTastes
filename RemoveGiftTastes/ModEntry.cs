using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace RemoveGiftTastes
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        // Properties
        public const string modContentPath = "Mods/vl.rgt/GiftTastesToRemove";

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            // Add asset editor
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after an asset is requested.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo(PathUtilities.NormalizeAssetName("Data/NPCDispositions")))
            {
                Dictionary<string, string> removeDict = Helper.GameContent.Load<Dictionary<string, string>>(ModEntry.modContentPath);
            }
            else if(e.NameWithoutLocale.IsEquivalentTo(ModEntry.modContentPath))
            {
                e.LoadFrom(() => new Dictionary<string, string>(), AssetLoadPriority.Low);
            }
        }
    }
}