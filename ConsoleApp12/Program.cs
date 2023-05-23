using System;
using System.IO;

class FileCopyApp
{
    static void Main()
    {
        Console.WriteLine("Введіть цифру відповідно до завдання 1-6");
        int ch = int.Parse(Console.ReadLine());
        switch (ch)
        {
            case 1:
                

                Console.Write("Введіть шлях до оригінального файлу: ");
                string sourceFilePath = Console.ReadLine();

                Console.Write("Введіть шлях до папки, куди потрібно перемістити файл: ");
                string destinationFilePath = Console.ReadLine();

                bool success = CopyFile(sourceFilePath, destinationFilePath);

                if (success)
                {
                    Console.WriteLine("Файл переміщено успішно!");
                }
                else
                {
                    Console.WriteLine("Оригінальний файл не знайдено!");
                }
                break;

                case 2:
                Console.WriteLine("Введіть шлях до оригінального файлу:");
                string sourcePath = Console.ReadLine();

                Console.WriteLine("Введіть шлях до папки, куди потрібно перемістити файл:");
                string destinationPath = Console.ReadLine();

                  
                    if (File.Exists(sourcePath))
                    {
                        // Переміщення файлу
                        File.Move(sourcePath, destinationPath,true);
                        Console.WriteLine("Файл переміщено успішно.");
                    }
                    else
                    {
                        Console.WriteLine("Оригінальний файл не знайдено.");
                    }                               
                break;
                case 3:
                Console.WriteLine("Введіть шлях до початкової папки:");
                string sourceDirectory = Console.ReadLine();

                Console.WriteLine("Введіть шлях до папки, куди потрібно скопіювати папку:");
                string destinationDirectory = Console.ReadLine();

                try
                {
                    
                    if (Directory.Exists(sourceDirectory))
                    {
                        // Копіювання папки та її вмісту
                        CopyDirectory2(sourceDirectory, destinationDirectory);
                        Console.WriteLine("Папка скопійована успішно.");
                    }
                    else
                    {
                        Console.WriteLine("Початкова папка не знайдена.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Виникла помилка при копіюванні папки: " + ex.Message);
                }
                break;
                case 4:

                Console.WriteLine("Введіть шлях до початкової папки:");
                string sourceDirectory2 = Console.ReadLine();

                Console.WriteLine("Введіть шлях до папки, куди потрібно скопіювати папку:");
                string destinationDirectory2 = Console.ReadLine();

               
                    // Перевірка, чи існує початкова папка
                    if (Directory.Exists(sourceDirectory2))
                    {
                        // Копіювання папки з підпапками
                        CopyDirectory2(sourceDirectory2, destinationDirectory2);
                        Console.WriteLine("Папка скопійована успішно.");
                    }
                    else
                    {
                        Console.WriteLine("Початкова папка не знайдена.");
                    }
                
              
                break;
                case 5:
                Console.WriteLine("Введіть шлях до початкової папки:");
                string sourceDirectory5 = Console.ReadLine();

                Console.WriteLine("Введіть шлях до папки, куди потрібно перемістити папку:");
                string destinationDirectory5 = Console.ReadLine();

               
                    // Перевірка, чи існує оригінальна папка
                    if (Directory.Exists(sourceDirectory5))
                    {
                        // Переміщення папки
                        Directory.Move(sourceDirectory5, destinationDirectory5);
                        Console.WriteLine("Папку переміщено успішно.");
                    }
                    else
                    {
                        Console.WriteLine("Початкова папка не знайдена.");
                    }               
                break;
                case 6:
                Console.WriteLine("Введіть шлях до Початкової папки:");
                string sourceDirectory6 = Console.ReadLine();

                Console.WriteLine("Введіть шлях до папки, куди потрібно перемістити папку:");
                string destinationDirectory6 = Console.ReadLine();

               
                    // Перевірка, чи існує оригінальна папка
                    if (Directory.Exists(sourceDirectory6))
                    {
                        // Переміщення папки з підпапками
                        MoveDirectory(sourceDirectory6, destinationDirectory6);
                        Console.WriteLine("Папку переміщено успішно.");
                    }
                    else
                    {
                        Console.WriteLine("Початкова папка не знайдена.");
                    }
          
        break; 
        }
   
    
        Console.ReadKey();
    }

    static void MoveDirectory(string sourceDirectory, string destinationDirectory)
    {
       
        Directory.CreateDirectory(destinationDirectory);

       
        string[] directories = Directory.GetDirectories(sourceDirectory);

       
        string[] files = Directory.GetFiles(sourceDirectory);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destinationFilePath = Path.Combine(destinationDirectory, fileName);
            File.Move(file, destinationFilePath,true);
        }

        // Рекурсивне переміщення підпапок
        foreach (string directory in directories)
        {
            string directoryName = Path.GetFileName(directory);
            string destinationSubDirectoryPath = Path.Combine(destinationDirectory, directoryName);
            MoveDirectory(directory, destinationSubDirectoryPath);
        }

        // видалення початково папки
        Directory.Delete(sourceDirectory);
    }
    static void CopyDirectory2(string sourceDirectory, string destinationDirectory)
    {
        
        Directory.CreateDirectory(destinationDirectory);
       
        string[] directories = Directory.GetDirectories(sourceDirectory);
        string[] files = Directory.GetFiles(sourceDirectory);

        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destinationFilePath = Path.Combine(destinationDirectory, fileName);
            File.Copy(file, destinationFilePath, true);
        }

        // Рекурсивне копіювання підпапок
        foreach (string directory in directories)
        {
            string directoryName = Path.GetFileName(directory);
            string destinationSubDirectoryPath = Path.Combine(destinationDirectory, directoryName);
            CopyDirectory2(directory, destinationSubDirectoryPath);
        }
    }   
    static bool CopyFile(string sourceFilePath, string destinationFilePath)
    {
        
            File.Copy(sourceFilePath, destinationFilePath, true);
            return true;
       
    }
}