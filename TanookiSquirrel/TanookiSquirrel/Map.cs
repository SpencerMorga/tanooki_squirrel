﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    public class Map
    {
        Color[,] pixels;

        List<TanookiSprite> sprites;

        //make sure the images are the same size which is 200x200
        Vector2 scale = PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.scale;
        Vector2 imageSize = new Vector2(PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.image.Width, PixelItem.Items[TanookiEnums.PixelTypes.Wall].Sprite.image.Height);


        public Map(Texture2D mapImage)
        {
            sprites = new List<TanookiSprite>();

            Color[] colors = new Color[mapImage.Width * mapImage.Height];
            
            mapImage.GetData(colors);
                        
            pixels = new Color[mapImage.Width, mapImage.Height];

            int counter = 0;

            
            for (int i = 0; i < mapImage.Height; i++)
            {
                for (int j = 0; j < mapImage.Width; j++)
                {
                    pixels[j, i] = colors[counter];

                    Vector2 position = new Vector2(j * (scale.X * imageSize.X), i * (scale.Y * imageSize.Y));

                    if (pixels[j, i] == PixelItem.Items[TanookiEnums.PixelTypes.Wall].PixelColor)
                    {
                        AddSprite(TanookiEnums.PixelTypes.Wall, position);
                    }
                    
                    counter++;
                }
            }
        }

        void AddSprite(TanookiEnums.PixelTypes pixelType, Vector2 position)
        {
            sprites.Add(new TanookiSprite(PixelItem.Items[pixelType].Sprite.image, position, PixelItem.Items[pixelType].Sprite.color));
            sprites[sprites.Count - 1].scale = scale;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (TanookiSprite sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }
    }
}