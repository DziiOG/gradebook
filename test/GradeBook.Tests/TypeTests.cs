using System;
using Xunit;


namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringBehavesLikeValueTypes(){
            string name = "Whitson";
            string upperName =   MakeUpperCase(name);
            Assert.Equal("WHITSON", upperName);
            Assert.Equal("Whitson", name);
        }

        private string MakeUpperCase(string parameter)
        {
          return  parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue(){

            int x = GetInt();
            SetInt(out x);
            Assert.Equal(42, x);
        }

        private void SetInt(out int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef(){
            Book book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);
            Assert.NotEqual("Book 1", book1.Name);
        }

        private void GetBookSetName(ref Book book1, string name)
        {
            book1 = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue(){
            Book book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.NotEqual("New Name", book1.Name);
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book1, string name)
        {
            book1 = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference(){
            Book book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book1, string name)
        {
            book1.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects(){
            Book book1 = GetBook("Book 1");
            Book book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject(){
            Book book1 = GetBook("Book 1");
            Book book2 = book1;

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
            Assert.Same(book1, book2);
        }
        Book GetBook(string name){
            return new Book(name);
        }
    }
}