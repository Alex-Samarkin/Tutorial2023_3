using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Person : IEquatable<Person>
    {
        // 1 свойства с атрибутами
        [Description("Уникальный номер"), DefaultValue(0), DisplayName("Код")]
        public int Id { get; set; } = 0;
        [Description("Имя"),DefaultValue(""),DisplayName("Имя")]
        public string FirstName { get; set; } = "";
        [Description("Фамилия"), DefaultValue(""), DisplayName("Фамилия")]
        public string LastName { get; set; } = "";
        [Description("Отчество"), DefaultValue(""), DisplayName("Отчество")]
        public string MiddleName { get; set; } = "";

        // 2 вычисляемые свойства
        [Description("Полное имя"), DisplayName("Полное имя")]
        public string  FullName => $"{FirstName} {MiddleName} {LastName}";
        [Description("Имя с инициалами"), DisplayName("Имя с инициалами")]
        public string FIO => $"{LastName} {FirstName[0]}.{MiddleName[0]}.";

        [Description("Дата рождения"), DisplayName("Дата рождения")]
        public DateTime BirtDate { get; set; } = DateTime.Now;
        [Description("Возраст"), DisplayName("Взраст")]
        public int Age => DateTime.Now.Year - BirtDate.Year;

        // 3
        public Person()
        {

        }

        public Person(int id, string firstName, string middleName, string lastName, DateTime birtDate)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            BirtDate = birtDate;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person other)
        {
            return !(other is null) &&
                   FullName == other.FullName &&
                   Age == other.Age;
        }

        public static bool operator ==(Person left, Person right)
        {
            return EqualityComparer<Person>.Default.Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return base.ToString()+$"{nameof(Id)}: {Id}, Имя: {FullName}, Возраст: {Age}";
        }
    }
}
