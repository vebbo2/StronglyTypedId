using Newtonsoft.Json;
using Xunit;

namespace StronglyTypedId
{
    public class LongIdTests
    {
        [Fact]
        public void SameValuesAreEqual()
        {
            var id = 123;
            var foo1 = new LongId(id);
            var foo2 = new LongId(id);

            Assert.Equal(foo1, foo2);
        }

        [Fact]
        public void EmptyValueIsEmpty()
        {
            Assert.Equal(0, LongId.Empty.Value);
        }


        [Fact]
        public void DifferentValuesAreUnequal()
        {
            var foo1 = new LongId(1);
            var foo2 = new LongId(2);

            Assert.NotEqual(foo1, foo2);
        }

        [Fact]
        public void OverloadsWorkCorrectly()
        {
            var id = 12;
            var same1 = new LongId(id);
            var same2 = new LongId(id);
            var different = new LongId(3);

            Assert.True(same1 == same2);
            Assert.False(same1 == different);
            Assert.False(same1 != same2);
            Assert.True(same1 != different);
        }

        [Fact]
        public void DifferentTypesAreUnequal()
        {
            var bar = GeneratedId2.New();
            var foo = new LongId(23);

            //Assert.NotEqual(bar, foo); // does not compile
            Assert.NotEqual((object)bar, (object)foo);
        }

        [Fact]
        public void CanSerializeToString()
        {
            var value = 123;
            var foo = new LongId(value);

            var serializedFoo = JsonConvert.SerializeObject(foo);
            var serializedString = JsonConvert.SerializeObject(value);

            Assert.Equal(serializedFoo, serializedString);
        }

        [Fact]
        public void CanSerializeFromString()
        {
            var value = 123;
            var foo = new LongId(value);

            var serializedValue = JsonConvert.SerializeObject(value);
            var deserializedFoo = JsonConvert.DeserializeObject<LongId>(serializedValue);

            Assert.Equal(foo, deserializedFoo);
        }


        [Fact]
        public void WhenNoJsonConverter_SerializesWithValueProperty()
        {
            var foo = new NoJsonLongId(123);

            var serialized = JsonConvert.SerializeObject(foo);
            var expected = "{\"Value\":123}";

            Assert.Equal(expected, serialized);
        }

    }
}