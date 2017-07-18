﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ProjectSpark.util;
using _ProjectSpark.actors;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace _ProjectSpark.actors.blocks
{
    class Spike : Block
    {
        public Spike(int x, int y) : base(x, y)
        {
            texture = new Sprite(Resources.GetTexture("spike.png")) { Position = position };
        }

        public override void Update(float _deltaTime)
        {
            if (Player.getPlayer().hitbox().intersectsWithRectangle(position, 48, 48))
            {
                Player.getPlayer().kill();
            }
        }
    }
}
