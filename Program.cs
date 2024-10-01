using System.ComponentModel.Design;

int[] numbers = new int[5];
int count = 0; //счетчик кол-ва чисел в массиве
int warn = 0; //счетчик кол-ва ошибок пользователя
Console.WriteLine("Введите число:");
for (int i = 0; i <= numbers.Length; i++)
{
    //Если массив переполнен,
    if (numbers.Length >= i)
    {
        //то расширяем его
        Array.Resize(ref numbers, numbers.Length * 2);
    }
    
    string? input = Console.ReadLine();
    //запишем число в массив
    if (int.TryParse(input, out int number))
    {
        numbers[i] = number;
        count++;
    }

    else if (input == "Q" || input == "q")        
    {
        i--;
        Console.WriteLine($"МЕНЮ:\nОчистить - 1 \nПродолжить - 2\nВыйти - 3");
        //действия меню
        void Clear()
        {
            i--;
            Array.Clear(numbers, 0, numbers.Length);
            count = 0;
            i = 0;
        }
        void Continues()
        {
            i--;
            Console.WriteLine("Продолжите ввод");
        }
        void Quit()
        {
            i--;
            Console.WriteLine($"Итоговые данные:");
            for (int j = 0; j <= count - 1; j++)
            {                
                Console.WriteLine($"{numbers[j]} ");
            }
            Console.WriteLine($"Количество ошибок: {warn}");
            Console.WriteLine();
            
        }
        string input1 = Console.ReadLine();
        int Menus = int.Parse(input1);

        switch (Menus)
        {
            case 1:
                Clear();
                break;
            case 2:
                Continues();
                break;
            case 3:
                Quit();
                break;
        }
    }
    else
    {
        i--;
        Console.WriteLine("Ошибка! Введены некорректные данные");
        warn++;
    }
}
    