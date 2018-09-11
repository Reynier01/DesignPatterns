using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern.Builders
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // Extended to show Recursive Generics
    public class PersonRG : Person
    {
        public class Builder : DerivedClass<Builder>
        {

        }

        public static Builder New => new Builder();
    }

    #region Generates Error
    //public class BaseClass
    //{
    //    protected Person person;
    //    public BaseClass()
    //    {
    //        person = new Person();
    //    }
    //    public BaseClass SetName(string name)
    //    {
    //        person.Name = name;
    //        return this;
    //    }
    //}
    //public class DerivedClass : BaseClass
    //{
    //    public DerivedClass SetAge(int age)
    //    {
    //        person.Age = age;
    //        return this;
    //    }
    //}

    #endregion

    #region Recursive Generics

    public abstract class AbstractBase
    {
        protected Person person = new Person();

        public Person Build() => person;
    }
    public class BaseClass<TSelf> : AbstractBase
        where TSelf : BaseClass<TSelf>
    {

        public TSelf SetName(string name)
        {
            person.Name = name;
            return (TSelf)this;
        }
    }
    public class DerivedClass<TSelf> : BaseClass<DerivedClass<TSelf>> // <- This inheritance line will get longer as the inheritance tree grows
        where TSelf : DerivedClass<TSelf>
    {
        public TSelf SetAge(int age)
        {
            person.Age = age;
            return (TSelf)this;
        }
    }

    #endregion

}
