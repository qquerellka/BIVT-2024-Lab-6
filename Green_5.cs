using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 {
  public class Green_5 {
    public struct Student {
      // Поля
      private string? _name;
      private string? _surname;
      private int[]? _marks;
      private const int _examsCount = 5;

      // Доп Поле
      private int _sumMarks;

      // Свойства
      public string? Name => _name is not null ? _name : null;
      public string? Surname => _surname is not null ? _surname : null;
      public int[]? Marks => _marks;
      public double AvgMark => _marks is not null ? (double)_sumMarks/ _examsCount : 0;

      // Конструктор
      public Student(string name, string surname) {
        this._name = name is not null ? name :  null;
        this._surname = surname is not null ? surname : null;
        this._marks = new int[_examsCount];
        this._sumMarks = 0;
      }

      // Методы
      public void Exam(int mark) {
        if ( mark < 2 || mark > 5) {
          Console.WriteLine("Неверный формат оценки");
          return;
        }
        if (Marks == null) {
          _marks = new int[_examsCount];
        }
        for (int i = 0; i < _examsCount; i++) {
          if (_marks[i] == 0) {
            _marks[i] = mark;
            _sumMarks+=mark;
            return;
          }
        }
      }

      public void Print() { }

    }
    public struct Group {
      // Поля 
      private string? _name;
      private Student[] _students;
      private  int _studentsCount;

      // Доп Поле
      private double _sumAvgMarks;

      // Свойства
      public string? Name => _name is not null ? _name : null;
      public Student[] Students => _students;
      public double AvgMark => _studentsCount > 0 ? _sumAvgMarks / _studentsCount : 0;

      // Конструктор
      public Group(string? name) {
        this._name = name is not null ? name : null;
        this._students = new Student[100];
        this._studentsCount = 0;
        this._sumAvgMarks = 0;
      }

      // Методы
      public void Add(Student student)
      {   if (_students == null) {
        _students = new Student[_studentsCount];
      }
          _students[_studentsCount++] = student;
          _sumAvgMarks += student.AvgMark;
      }
      public void Add(Student[] students)
      {
          foreach (var student in students)
          {
              Add(student);
          }
      }

      public static void SortByAvgMark(Group[] array)
      {
          if (array == null || array.Length == 0)
          {
            return;
          }
          int n = array.Length;
          for (int i = 0; i < n - 1; i++)
          {
              for (int j = 0; j < n - i - 1; j++)
              {
                  // Сравниваем средние баллы групп
                  if (array[j].AvgMark < array[j + 1].AvgMark)
                  {
                      // Меняем местами группы
                      Group temp = array[j];
                      array[j] = array[j + 1];
                      array[j + 1] = temp;
                  }
              }
          }
      }

      public void Print() { }

    }
  }
}