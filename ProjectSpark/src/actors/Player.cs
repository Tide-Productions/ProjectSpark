﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ProjectSpark.util;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace _ProjectSpark.actors
{
    class Player : IActable
    {
        Vector2f position;
        Sprite texture;
        float speed;
        private bool dead = false;

        Vector2f gravity = new Vector2f(0, 500);
        Vector2f velocity = new Vector2f(0, 500);

        public Player()
        {
            position = new Vector2f(1000, 0);
            speed = 1000f;
            texture = new Sprite(Resources.GetTexture("player.png")) { Position = position };
        }

        public void Draw(RenderWindow _window)
        {
            if (dead) return;
            _window.Draw(texture);
        }

        public bool IsExpired()
        {
            return false;
        }

        public float StartTime()
        {
            return 0f;
        }

        public void Update(float _deltaTime)
        {
            if (dead) return;

            position += _deltaTime * velocity;
            velocity += _deltaTime * gravity;

            var move = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                move.X -= speed * _deltaTime;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                move.X += speed * _deltaTime;

            position += move;
            texture.Position = position;

            //just for test purposes:
            if (position.Y > 1000)
            {
                position.Y = 0;
                velocity = new Vector2f(0, 500);
            }
        }

        public Circle hitbox()
        {
            return new Circle(position + new Vector2f(24, 24), 24);
        }

        public void kill()
        {
            dead = true;
        }
    }
}
