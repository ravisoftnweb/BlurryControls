﻿using System;
using System.Windows;
using System.Windows.Media;

namespace BlurryControls.Helper
{
    /// <summary>
    /// provides functionality relating to types <see cref="Brush"/>, <see cref="SolidColorBrush"/> and <see cref="Color"/>
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// returns the currently selected <see cref="SystemParameters.WindowGlassColor"/> with chosen opacity
        /// </summary>
        /// <param name="strength">opacity weight from 0.0 to 1.0 and is set to 0.75 if no value is provided</param>
        /// <returns>the currently selected <see cref="SystemParameters.WindowGlassColor"/> with chosen opacity</returns>
        public static SolidColorBrush TransparentSystemWindowGlassBrush(double strength = 0.75)
        {
            return ((SolidColorBrush)SystemParameters.WindowGlassBrush).OfStrength(strength);
        }
        /// <summary>
        /// returns a <see cref="SolidColorBrush"/> of the given <see cref="SolidColorBrush"/> with inverted color channels
        /// </summary>
        /// <param name="colorBrush"></param>
        /// <returns>a <see cref="SolidColorBrush"/> with inverted color channels</returns>
        public static SolidColorBrush Invert(this SolidColorBrush colorBrush)
        {
            var color = colorBrush.Color;
            color.R = (byte)(255 - color.R);
            color.G = (byte)(255 - color.G);
            color.B = (byte)(255 - color.B);
            return new SolidColorBrush(color);
        }
        /// <summary>
        /// returns a <see cref="SolidColorBrush"/> of the given <see cref="Brush"/> with inverted color channels
        /// </summary>
        /// <param name="colorBrush"></param>
        /// <returns>a <see cref="SolidColorBrush"/> with inverted color channels</returns>
        public static SolidColorBrush Invert(this Brush colorBrush)
        {
            return ((SolidColorBrush)colorBrush).Invert();
        }

        /// <summary>
        /// returns a <see cref="Color"/> of the given <see cref="Color"/> with inverted color channels
        /// </summary>
        /// <param name="color"></param>
        /// <returns>a <see cref="Color"/> with inverted color channels</returns>
        public static Color Invert(this Color color)
        {
            color.R = (byte)(255 - color.R);
            color.G = (byte)(255 - color.G);
            color.B = (byte)(255 - color.B);
            return color;
        }

        /// <summary>
        /// returns a <see cref="SolidColorBrush"/> of the given <see cref="SolidColorBrush"/> with chosen opacity
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="strength">opacity weight from 0.0 to 1.0 and is set to 0.75 if no value is provided</param>
        /// <returns>a given <see cref="SolidColorBrush"/> with chosen opacity</returns>
        public static SolidColorBrush OfStrength(this SolidColorBrush brush, double strength = 0.75d)
        {
            if (strength < 0d || strength > 1d)
                throw new ArgumentOutOfRangeException(nameof(strength), @"strength must be a value between 0.0 and 1.0");
            return brush.OfStrength((byte)(strength * 255));
        }

        /// <summary>
        /// returns a <see cref="SolidColorBrush"/> of the given <see cref="Brush"/> with chosen opacity
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="strength">opacity weight from 0.0 to 1.0 and is set to 0.75 if no value is provided</param>
        /// <returns>a given <see cref="SolidColorBrush"/> with chosen opacity</returns>
        public static SolidColorBrush OfStrength(this Brush brush, double strength = 0.75d)
        {
            if (strength < 0d || strength > 1d)
                throw new ArgumentOutOfRangeException(nameof(strength), @"strength must be a value between 0.0 and 1.0");
            return ((SolidColorBrush)brush).OfStrength((byte)(strength * 255));
        }

        /// <summary>
        /// returns a <see cref="SolidColorBrush"/> of the given <see cref="SolidColorBrush"/> with chosen opacity
        /// </summary>
        /// <param name="colorBrush"></param>
        /// <param name="strength">opacity weight from 0 to 255 and is set to 191 if no value is provided</param>
        /// <returns>a given <see cref="SolidColorBrush"/> with chosen opacity</returns>
        public static SolidColorBrush OfStrength(this SolidColorBrush colorBrush, byte strength = 191)
        {
            var color = colorBrush.Color;
            color.A = strength;
            return new SolidColorBrush(color);
        }
    }
}