﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using System.Collections.Generic;

namespace Deus.TestingMayContainOtherPeopleCode.UITest
{
    
    [Autoload(Side = ModSide.Client)] 
    public class TestUiSystem : ModSystem
    {
        private UserInterface exampleCoinUserInterface;
        internal TestUiBar exampleCoinsUI;

        public void ShowMyUI()
        {
            exampleCoinUserInterface?.SetState(exampleCoinsUI);
        }

        public void HideMyUI()
        {
            exampleCoinUserInterface?.SetState(null);
        }

        public override void Load()
        {
            exampleCoinUserInterface = new UserInterface();
            exampleCoinsUI = new TestUiBar();

            exampleCoinsUI.Activate();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            
            if (exampleCoinUserInterface?.CurrentState != null)
                exampleCoinUserInterface?.Update(gameTime);
        }

    
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Coins Per Minute",
                    delegate {
                        if (exampleCoinUserInterface?.CurrentState != null)
                            exampleCoinUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }




}