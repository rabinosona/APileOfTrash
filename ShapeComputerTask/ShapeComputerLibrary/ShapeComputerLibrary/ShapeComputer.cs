using System;

/*
 * Напишите тесты на код (и сам код), который вычисляет
 * площадь прямоугольного треугольника по трем сторонам
 * площадь круга по его радиусу
 * 
 * Код будет поставляться внешним клиентам в составе библиотеки. Предусмотрите возможность добавления в эту библиотеку кода вычисления площади и других фигур. 
 * Также нужна возможно вычислять площадь фигуры без знания о том, с какой именно фигурой работает пользователь библиотеки.
 * 
 * Пожалуйста, не пишите код внутри форм ответов, разместите ссылки (код должен открываться в браузере, без архивов). GitHub будет идеальным. 
 * 
 */

namespace ShapeComputer
{
    public interface IShapeComputer
    {
        double Square { get; }

    }

    public class RightTriangle : IShapeComputer
    {
        private double[] sides;

        public RightTriangle(params double [] sides)
        {
            if (sides.Length == 3)
            {
                this.sides = sides.Clone() as double[];
                Array.Sort(this.sides);
            }
            else throw new Exception("You should pass 3 sides to the method as you do work with triangle.");
        }

        public double Square
        {
            get
            {
                return (sides[0] * sides[1]) / 2;
            }
        }

    }

    public class Circle : IShapeComputer
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius; // √√√
        }

        public double Square
        {
            get { return Math.PI * Math.Pow(radius, 2); }
        }
    }
}
