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

    class Line : IActable
    {
        Vector2f borders;
        float position;
        bool enabled = false;
        bool done = false;

        public Line(Vector2f borders, float y)
        {
            this.borders = borders*48;
            position = y*48;
        }

        public void Draw(RenderWindow _window)
        {
            Vertex[] line = { new Vertex(new Vector2f(borders.X, position)), new Vertex(new Vector2f(borders.Y, position)) };
            _window.Draw(line, 0, 2, PrimitiveType.Lines);
        }

        public bool IsExpired()
        {
            return false;
        }

        public float StartTime()
        {
            return 0f;
        }

        public virtual void Update(float _deltaTime)
        {
            if (done) return;
            Vector2f playerPos = Player.getPlayer().getPosition() + new Vector2f(24,24);
            Vector2f next;

            if (playerPos.X >= borders.X && playerPos.X <= borders.Y)
            {
                next = Player.getPlayer().getPosition() + _deltaTime * Player.getPlayer().getVelocity();
                if (next.Y > position - 24) Player.getPlayer().setCurrLine(position-24);
            }

            
            float length = Math.Abs(borders.Y - borders.X);
            if (Player.getPlayer().getOnLine())
            {
                if (!enabled) Program.MoveCameraDown(position - 48, 3, resetLine);
                enabled = true;
                Vector2f plPos = Player.getPlayer().getPosition();
                if (Player.getPlayer().getLeftBorder() < borders.X - 24) Player.getPlayer().setLeftBorder((int) borders.X - 24);
                if (Player.getPlayer().getRightBorder() > borders.Y + 24) Player.getPlayer().setRightBorder((int) borders.Y + 24);
            }

        }

        private void resetLine()
        {
            Player.getPlayer().resetLine();
            done = true;
        }
    }
}
