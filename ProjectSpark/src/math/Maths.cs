﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwistedLogik.Ultraviolet;

namespace ProjectSpark.math
{
    public struct Angle
    {
        public float Value { get; set; }
        public Angle(float value)
        {
            this.Value = value;
        }
        public static Angle operator +(Angle a, Angle b)
        {
            return new Angle((a.Value + b.Value) % 360);
        }
        public static Angle operator -(Angle a)
        {
            return new Angle(-a.Value);
        }
        public static Angle operator -(Angle a, Angle b)
        {
            return new Angle(((a + -b).Value%360 + 360)%360);
        }

    }

    class Maths
    {
        /// <summary>
        /// Erzeugt verwendbare Koordinaten für den Positionsvektor
        /// </summary>
        /// <param name="spawnPosition">Rotationszentrum</param>
        /// <param name="angle">Winkel</param>
        /// <param name="radius">Radius</param>
        public static Vector2 ToCartesian(Vector2 spawnPosition, double angle, double radius)
        {
            angle = ((angle * Math.PI) / 180);
            var x = Convert.ToSingle(radius * Math.Cos(angle)) + spawnPosition.X;
            var y = Convert.ToSingle(radius * Math.Sin(angle)) + spawnPosition.Y;
            return new Vector2(x, y);
        }

        public static Vector2 ToPolar (Vector2 spawnPosition, Vector2 position)
        {
            var radius = (float) Math.Sqrt(Math.Pow(position.X - spawnPosition.X, 2) + Math.Pow(position.Y - spawnPosition.Y, 2));
            var angle = (float) Math.Acos(position.X - spawnPosition.X / radius);
            if ( position.Y < spawnPosition.Y) { angle = 360 - angle; }    //if the positon is below the spwan, the angle is "spun" around the x axis
            return new Vector2(radius, angle);
        }

        public static float Length (Vector2 vector )
        {
            return (float) Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }
    }
}

