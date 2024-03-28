// Підключаємо простір імен для роботи з консоллю
using System;
// Підключаємо простір імен для використання колекцій List<>
using System.Collections.Generic;

// Оголошуємо клас FileSystemItem
public class FileSystemItem
{
    // Властивість Name для зберігання імені елементу файлової системи
    public string Name { get; set; }

    // Конструктор класу, приймає параметр name - ім'я елементу файлової системи
    public FileSystemItem(string name)
    {
        // Ініціалізуємо властивість Name значенням, переданим через параметр конструктора
        Name = name;
    }

    // Віртуальний метод PrintTree, який виводить ім'я елементу файлової системи у консоль
    public virtual void PrintTree(string prefix = "")
    {
        // Виводимо ім'я елементу файлової системи з префіксом у консоль
        Console.WriteLine(prefix + "└── " + Name);
    }
}
// Оголошуємо клас File, який є нащадком класу FileSystemItem
public class File : FileSystemItem
{
    // Конструктор класу, приймає параметр name - ім'я файлу
    public File(string name) : base(name) { }
}
// Оголошуємо клас Folder, який є нащадком класу FileSystemItem
public class Folder : FileSystemItem
{
    // Властивість Items для зберігання списку елементів у папці
    public List<FileSystemItem> Items { get; set; }

    // Конструктор класу, приймає параметр name - ім'я папки
    public Folder(string name) : base(name)
    {
        // Ініціалізуємо властивість Items як новий порожній список
        Items = new List<FileSystemItem>();
    }

    // Метод для додавання елементу у папку
    public void AddItem(FileSystemItem item)
    {
        // Додаємо переданий елемент до списку Items папки
        Items.Add(item);
    }

    // Перевизначений метод PrintTree для виведення дерева файлової системи у консоль
    public override void PrintTree(string prefix = "")
    {
        // Викликаємо базовий метод для виведення імені папки з префіксом
        base.PrintTree(prefix);
        // Додаємо пробіл до префіксу
        prefix += "    ";
        // Проходимося по всіх елементах у папці
        for (int i = 0; i < Items.Count; i++)
        {
            // Якщо елемент останній в списку, то викликаємо його метод PrintTree без префікса з символами "   "
            if (i == Items.Count - 1)
            {
                Items[i].PrintTree(prefix + "    ");
            }
            // В іншому випадку викликаємо метод PrintTree з символами "│   "
            else
            {
                Items[i].PrintTree(prefix + "│   ");
            }
        }
    }
}
// Оголошення головного класу Program
class Program
{
    // Головний метод Main
    static void Main(string[] args)
    {
        // Створюємо кореневу папку
        Folder root = new Folder("Root");
        // Створюємо папки та файли
        Folder folder1 = new Folder("Folder1");
        Folder folder2 = new Folder("Folder2");
        File file1 = new File("File1.txt");
        File file2 = new File("File2.txt");
        File file3 = new File("File3.txt");

        // Додаємо папки та файли у кореневу папку
        root.AddItem(folder1);
        root.AddItem(folder2);
        folder1.AddItem(file1);
        folder1.AddItem(file2);
        folder2.AddItem(file3);

        // Викликаємо метод PrintTree для виведення дерева файлової системи у консоль
        root.PrintTree();
    }
}
