﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TanookiSquirrel
{
    public class TanookiSprite
    {
        public Texture2D image;
        public Vector2 position;
        public Color color;
        public Rectangle hitbox;
        public Vector2 scale;
        public Rectangle? sourceRectangle;

        public TanookiSprite (Texture2D image, Vector2 position, Color color)
        {
            this.image = image;
            this.position = position;
            this.color = color;
            scale = Vector2.One;            
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(image, position, sourceRectangle, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
