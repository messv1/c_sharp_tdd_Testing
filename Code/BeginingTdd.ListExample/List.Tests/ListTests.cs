using List.Production;
using Xunit;
using TestData = System.Collections.Generic.IEnumerable<object[]>;

namespace List.Tests
{
    public class ListTests
    {
        [Theory]
        [MemberData("CountTestDataForAdd")]
        public void CountReflectsTheNumberOfItemsThatWereAddedToTheList(int [] itemsToAdd)
        {
            /* Arrange Phase
             * Set up all objects that you need for the test 
             */
            var testTarget = new List<int>();

            /* Act Phase
             * Perform the action that you actually want to test
             */
            foreach (var item in itemsToAdd)
            {
                testTarget.Add(item);
            }

            /*Assert Phase
             *  Test if the outcome oft the action ist correct
             */
            Assert.Equal(itemsToAdd.Length, testTarget.Count);
        }

        public static readonly TestData CountTestDataForAdd = new[] 
                                                                {
                                                                    new object[] { new int[] { 1, 2 , 3 , 4 } },
                                                                    new object[] { new int[] { 33, 22, 44 } },
                                                                    new object[] { new int[] {15, 100, 179, 63, 62, 12, 88 } }
                                                                };
        
        [Theory]
        [MemberData("IndexTestDataForAdd")]
        public void ItemThatAreAddedMustBeRetrievableViaIndex<T>(T[] itemsToBeAdded, 
                                                                    int index,
                                                                    T expected)
        {
            var testTarget = new List<T>();

            foreach (var item in itemsToBeAdded)
            {
                testTarget.Add(item);    
            }

            Assert.Equal(expected, testTarget[index]);
        }

        public static readonly TestData IndexTestDataForAdd = new[] {
            new object[] { new int[] { 1, 2 ,3 ,4 }, 1, 2 },
            new object[] { new string[] { "Hello", "World" }, 0, "Hello" }
        };


        [Fact]
        public void InternalArrayMustBeResizedAutomaticallyWhenExceedingItsCapacity()
        {
            var testTarget = new List<int>(4);
            Assert.Equal(4, testTarget.Capacity);

            var random = new System.Random();
            for (int i = 0; i < 5; i++)
            {
                testTarget.Add(random.Next());
            }

            Assert.True(testTarget.Capacity > 4);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-42)]
        public void ConstructorMustThrowExceptionWhenInitialCapacityIsLessThenTwo(int initialCapacity)
        {
            Assert.Throws<System.ArgumentException>(() => new List<int>(initialCapacity));
        }
    }
   

}
