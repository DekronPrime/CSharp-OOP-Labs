using System;
using System.Reflection.Metadata;

namespace OOPLab4
{
    public struct Angle
    {
        public int Degrees { get; private set; }
        public int Minutes { get; private set; }

        public Angle()
        {
            Degrees = 0;
            Minutes = 0;
        }

        public Angle(int degrees)
        {
            Degrees = degrees;
            Minutes = 0;
            FitRange();
        }

        public Angle(int degrees, int minutes)
        {
            try 
            {
                if (degrees < 0 || minutes < 0) { 
                    throw new ArgumentException("Градуси та мінути повинні бути позитивними");
                }
                Degrees = degrees;
                Minutes = minutes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            finally 
            { 
                FitRange();
            }
        }

        private void FitRange()
        {
            Degrees += Minutes / 60;
            Minutes %= 60;
            if (Degrees < 0) {
                Degrees = (Degrees % 360) + 360;
            }
            else if (Degrees >= 360) {
                Degrees %= 360;
            }
        }
        public double ToRadians()
        {
            return (Degrees + Minutes / 60.0) * Math.PI / 180.0;
        }

        public void Add(Angle angle)
        {
            Degrees += angle.Degrees;
            Minutes += angle.Minutes;
            FitRange();
        }

        public void Add(int degrees, int minutes = 0) {
            Degrees += degrees;
            Minutes += minutes;
            FitRange();
        }

        public void Subtract(Angle angle)
        {
            Degrees -= angle.Degrees;
            if (Minutes <= 0)
            {
                Minutes = 60 - angle.Minutes;
                Degrees--;
            }
            else if (Minutes < angle.Minutes)
            {
                Minutes = (60 + Minutes) - angle.Minutes;
                Degrees--;
            }
            else
            {
                Minutes -= angle.Minutes;
            }
            FitRange();
        }

        public void Subtract(int degrees, int minutes = 0)
        {
            Degrees -= degrees;
            if (Minutes <= 0)
            {
                Minutes = 60 - minutes;
                Degrees--;
            }
            else if (Minutes < minutes)
            {
                Minutes = (60 + Minutes) - minutes;
                Degrees--;
            }
            else
            {
                Minutes -= minutes;
            }
            FitRange();
        }

        public double Sin()
        {
            try
            {
                return Math.Sin(ToRadians());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при обчислінні Sin: {ex.Message}");
                return 0;
            }
        }

        public int CompareTo(Angle otherAngle) 
        { 
            return ToRadians().CompareTo(otherAngle.ToRadians());
        }

        public override string ToString() {
            return $"{Degrees}° {Minutes}'";
        }
    }
}
