using System;

class RangeOfArray
{
    private int[] data;
    private int lowerBound; // Нижний индекс допустимого диапазона
    private int upperBound; // Верхний индекс допустимого диапазона

    public RangeOfArray(int lowerBound, int upperBound)
    {
        if (upperBound < lowerBound)
        {
            throw new ArgumentException("Верхний индекс должен быть больше или равен нижнему индексу.");
        }

        this.lowerBound = lowerBound;
        this.upperBound = upperBound;
        int size = upperBound - lowerBound + 1;
        data = new int[size];
    }

    public int this[int index]
    {
        get
        {
            if (IsIndexValid(index))
            {
                return data[index - lowerBound];
            }
            throw new IndexOutOfRangeException("Индекс находится вне допустимого диапазона.");
        }
        set
        {
            if (IsIndexValid(index))
            {
                data[index - lowerBound] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс находится вне допустимого диапазона.");
            }
        }
    }

    private bool IsIndexValid(int index)
    {
        return index >= lowerBound && index <= upperBound;
    }
}

class Program
{
    static void Main()
    {
        RangeOfArray array = new RangeOfArray(6, 10);

        // Установка и получение значений в пользовательском диапазоне
        array[6] = 10;
        array[7] = 20;
        array[8] = 30;
        array[9] = 40;
        array[10] = 50;

        for (int i = 6; i <= 10; i++)
        {
            Console.WriteLine($"array[{i}] = {array[i]}");
        }
    }
}
