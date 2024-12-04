using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите числа через пробел:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) // Проверяем, пустой ли ввод
            {
                Console.WriteLine("Ввод пустой. Пожалуйста, введите числа.");
                return;
            }

            int[] nums = Array.ConvertAll(input.Split(), str =>  // Преобразуем введенные данные в массив чисел
            {
                if (int.TryParse(str, out int result))
                {
                    return result;
                }
                else
                {
                    throw new FormatException($"Некорректное число: {str}");
                }
            });

            MoveZeroes(nums);

            Console.WriteLine("Результат: " + string.Join(" ", nums));
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void MoveZeroes(int[] nums)
    {
        int nonZeroIndex = 0; // Указатель для размещения ненулевых элементов

        // Перемещаем все ненулевые элементы вперёд
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[nonZeroIndex] = nums[i];
                nonZeroIndex++;
            }
        }

        // Заполняем оставшиеся позиции нулями
        for (int i = nonZeroIndex; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }
}