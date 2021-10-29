using System;

namespace Mandelbrot
{
    public struct Complex
    {
        public double real, imaginary;

        public Complex(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        
        public static Complex operator *(Complex left, Complex right)
        {
            double resultReal = (left.real * right.real) - (left.imaginary * right.imaginary);
            double resultImaginary = (left.imaginary * right.real) + (left.real * right.imaginary);
            return new Complex(resultReal, resultImaginary);
        }
        
        public static Complex operator +(Complex left, Complex right)
        {
            return new Complex(left.real + right.real, left.imaginary + right.imaginary);
        }
        
        public static double Abs(Complex value)
        {
            return Hypot(value.real, value.imaginary);
        }

        private static double Hypot(double a, double b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            double small, large;
            if (a < b)
            {
                small = a;
                large = b;
            }
            else
            {
                small = b;
                large = a;
            }

            if (small == 0.0)
            {
                return (large);
            }
            else if (double.IsPositiveInfinity(large) && !double.IsNaN(small))
            {
                return (double.PositiveInfinity);
            }
            else
            {
                double ratio = small / large;
                return (large * Math.Sqrt(1.0 + ratio * ratio));
            }

        }
    }
}