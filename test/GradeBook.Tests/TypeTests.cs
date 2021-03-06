using System;
using Xunit;


namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;


        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            string result = log("Hello");

            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringBehavesLikeValueTypes()
        {
            string name = "Whitson";
            string upperName = MakeUpperCase(name);
            Assert.Equal("WHITSON", upperName);
            Assert.Equal("Whitson", name);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {

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
        public void CSharpCanPassByRef()
        {
            InMemoryBook book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);
            Assert.NotEqual("Book 1", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book1, string name)
        {
            book1 = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            InMemoryBook book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.NotEqual("New Name", book1.Name);
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book1, string name)
        {
            book1 = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            InMemoryBook book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book1, string name)
        {
            book1.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            InMemoryBook book1 = GetBook("Book 1");
            InMemoryBook book2 = book1;

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
            Assert.Same(book1, book2);
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}