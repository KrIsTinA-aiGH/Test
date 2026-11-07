using Xunit;
using Todo.Core;
using System.Linq;

namespace Todo.Core.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void SaveAndLoad_PreservesItems()
        {

            var filePath = "test_todos.json";

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            var originalList = new TodoList();
            originalList.Add("Task 1");
            var item2 = originalList.Add("Task 2");
            item2.MarkDone();


            originalList.Save(filePath);

            var loadedList = new TodoList();
            loadedList.Load(filePath);


            Assert.Equal(originalList.Count, loadedList.Count);
            Assert.Equal(originalList.Items[0].Title, loadedList.Items[0].Title);
            Assert.Equal(originalList.Items[1].Title, loadedList.Items[1].Title);
            Assert.Equal(originalList.Items[1].IsDone, loadedList.Items[1].IsDone);


            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}