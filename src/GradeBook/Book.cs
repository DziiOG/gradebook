using System.Collections.Generic;
using System;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade);

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract Statistics GetStatistics();


    }


}