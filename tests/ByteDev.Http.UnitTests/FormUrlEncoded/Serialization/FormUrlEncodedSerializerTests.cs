using System;
using ByteDev.Http.FormUrlEncoded.Serialization;
using NUnit.Framework;

namespace ByteDev.Http.UnitTests.FormUrlEncoded.Serialization
{
    [TestFixture]
    public class FormUrlEncodedSerializerTests
    {
        [TestFixture]
        public class Serialize
        {
            [Test]
            public void WhenObjectIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => FormUrlEncodedSerializer.Serialize(null));
            }

            [Test]
            public void WhenOptionsIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => FormUrlEncodedSerializer.Serialize(new TestDummyString(), null));
            }

            [Test]
            public void WhenPropertiesAreNull_ThenReturnEmpty()
            {
                var obj = new TestDummyString { String = null, AnotherString = null };
                
                var result = FormUrlEncodedSerializer.Serialize(obj);

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenNonStringNotSet_ThenReturnDefaults()
            {
                var obj = new TestDummyBuiltInValueTypes();
                
                var result = FormUrlEncodedSerializer.Serialize(obj);

                Assert.That(result, Is.EqualTo("Bool=False&Char=%00&Byte=0&Short=0&Int=0&Long=0&SByte=0&UShort=0&UInt=0&ULong=0&Float=0&Double=0&Decimal=0"));
            }

            [Test]
            public void WhenPropertiesAreEmpty_ThenReturnSerializedString()
            {
                var obj = new TestDummyString { String = string.Empty, AnotherString = string.Empty };
                
                var result = FormUrlEncodedSerializer.Serialize(obj);

                Assert.That(result, Is.EqualTo("String=&AnotherString="));
            }

            [Test]
            public void WhenMultiplePropertiesSet_ThenReturnSerializedString()
            {
                var obj = new TestDummyString
                {
                    String = "TestString",
                    AnotherString = "AnotherTestString"
                };

                string expected = $"String={obj.String}&AnotherString=AnotherTestString";

                var result = FormUrlEncodedSerializer.Serialize(obj);

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenValueHasSpaces_ThenEscapeToPlus()
            {
                var obj = new TestDummyString { String = "john smith" };

                var result = FormUrlEncodedSerializer.Serialize(obj);

                Assert.That(result, Is.EqualTo("String=john+smith"));
            }

            // RFC 3986 section 2.2 Reserved Characters (January 2005)
            [TestCase("!", "%21")]
            [TestCase("#", "%23")]
            [TestCase("$", "%24")]
            [TestCase("&", "%26")]
            [TestCase("'", "%27")]
            [TestCase("(", "%28")]
            [TestCase(")", "%29")]
            [TestCase("*", "%2A")]
            [TestCase("+", "%2B")]
            [TestCase(",", "%2C")]
            [TestCase("/", "%2F")]
            [TestCase(":", "%3A")]
            [TestCase(";", "%3B")]
            [TestCase("=", "%3D")]
            [TestCase("?", "%3F")]
            [TestCase("@", "%40")]
            [TestCase("[", "%5B")]
            [TestCase("]", "%5D")]
            public void WhenValueIsReserved_ThenReturnEncodedValue(string value, string expected)
            {
                var obj = new TestDummyString { String = value };

                var result = FormUrlEncodedSerializer.Serialize(obj, new SerializeOptions { EncodeSpaceAsPlus = false });

                Assert.That(result, Is.EqualTo("String=" + expected));
            }

            // RFC 3986 section 2.3 Unreserved Characters (January 2005)
            [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
            [TestCase("abcdefghijklmnopqrstuvwxyz")]
            [TestCase("0123456789")]
            [TestCase("-_.~")]
            public void WhenValueIsUnreserved_ThenReturnValue(string value)
            {
                var obj = new TestDummyString { String = value };

                var result = FormUrlEncodedSerializer.Serialize(obj);

                Assert.That(result, Is.EqualTo("String=" + value));
            }

            [Test]
            public void WhenOptionNotToEncode_ThenReturnString()
            {
                var obj = new TestDummyString { String = "john smith" };

                var result = FormUrlEncodedSerializer.Serialize(obj, new SerializeOptions { Encode = false });

                Assert.That(result, Is.EqualTo("String=john smith"));
            }

            [Test]
            public void WhenClassUsesAttribute_ThenTakeNameFromAttribute()
            {
                var obj = new TestDummyAttributes { Name = "John", Email = "somewhere" };

                var result = FormUrlEncodedSerializer.Serialize(obj);

                Assert.That(result, Is.EqualTo("Name=John&emailAddress=somewhere"));
            }
        }

        [TestFixture]
        public class Deserialize
        {
            [Test]
            public void WhenDataIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => FormUrlEncodedSerializer.Deserialize<TestDummyString>(null));
            }

            [Test]
            public void WhenDataIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => FormUrlEncodedSerializer.Deserialize<TestDummyString>(string.Empty));
            }

            [Test]
            public void WhenOptionsIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => FormUrlEncodedSerializer.Deserialize<TestDummyString>("n=1", null));
            }

            [Test]
            public void WhenValuesNotSet_ThenSetPropertiesToDefault()
            {
                const string data = "String=&AnotherString=";

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyString>(data);

                AssertPropertiesAreDefault(result);
            }

            [Test]
            public void WhenNoValuesPresent_ThenSetPropertiesToDefault()
            {
                const string data = "String&AnotherString";

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyString>(data);

                AssertPropertiesAreDefault(result);
            }

            [Test]
            public void WhenNoNameValuesPresent_ThenSetPropertiesToDefault()
            {
                const string data = "SomeNameNotThere=";

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyString>(data);

                AssertPropertiesAreDefault(result);
            }

            [Test]
            public void WhenNameValuePairsSet_ThenSetPropertyValues()
            {
                const string data = "String=Test+String&AnotherString=123.45";

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyString>(data);

                Assert.That(result.String, Is.EqualTo("Test String"));
                Assert.That(result.AnotherString, Is.EqualTo("123.45"));
            }

            // RFC 3986 section 2.2 Reserved Characters (January 2005)
            [TestCase("%21", "!")]
            [TestCase("%23", "#")]
            [TestCase("%24", "$")]
            [TestCase("%26", "&")]
            [TestCase("%27", "'")]
            [TestCase("%28", "(")]
            [TestCase("%29", ")")]
            [TestCase("%2A", "*")]
            [TestCase("%2B", "+")]
            [TestCase("%2C", ",")]
            [TestCase("%2F", "/")]
            [TestCase("%3A", ":")]
            [TestCase("%3B", ";")]
            [TestCase("%3D", "=")]
            [TestCase("%3F", "?")]
            [TestCase("%40", "@")]
            [TestCase("%5B", "[")]
            [TestCase("%5D", "]")]
            public void WhenValueIsReserved_ThenReturnDecodedValue(string value, string expected)
            {
                string data = "String=" + value;

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyString>(data);

                Assert.That(result.String, Is.EqualTo(expected));
            }

            // RFC 3986 section 2.3 Unreserved Characters (January 2005)
            [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
            [TestCase("abcdefghijklmnopqrstuvwxyz")]
            [TestCase("0123456789")]
            [TestCase("-_.~")]
            public void WhenValueIsUnreserved_ThenReturnValue(string value)
            {
                string data = "String=" + value;

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyString>(data);

                Assert.That(result.String, Is.EqualTo(value));
            }

            [Test]
            public void WhenOptionNotToDencode_ThenReturnString()
            {
                var value = "john%20smith";
                var data = "String=" + value;

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyString>(data, new DeserializeOptions { Decode = false });

                Assert.That(result.String, Is.EqualTo(value));
            }

            [Test]
            public void WhenTypeIsPrimative_ThenDoConvertType()
            {
                const string data = "Bool=true&"+
                                    "Char=A&"+
                                    "Byte=128&"+
                                    "Short=5&"+
                                    "Int=10&"+
                                    "Long=20&"+
                                    "SByte=1&"+
                                    "UShort=21&"+
                                    "UInt=31&"+
                                    "ULong=41&"+
                                    "Float=1.1&"+
                                    "Double=1.2&"+
                                    "Decimal=123.45";

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyBuiltInValueTypes>(data);

                Assert.That(result.Bool, Is.True);
                Assert.That(result.Char, Is.EqualTo('A'));
                
                Assert.That(result.Byte, Is.EqualTo(128));
                Assert.That(result.Short, Is.EqualTo(5));
                Assert.That(result.Int, Is.EqualTo(10));
                Assert.That(result.Long, Is.EqualTo(20));

                Assert.That(result.SByte, Is.EqualTo(1));
                Assert.That(result.UShort, Is.EqualTo(21));
                Assert.That(result.UInt, Is.EqualTo(31));
                Assert.That(result.ULong, Is.EqualTo(41));

                Assert.That(result.Float, Is.EqualTo(1.1f));
                Assert.That(result.Double, Is.EqualTo(1.2d));
                Assert.That(result.Decimal, Is.EqualTo(123.45M));
            }

            [Test]
            public void WhenTypeIsObject_ThenCallToString()
            {
                const string data = "Obj=123";

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyBuiltInRefTypes>(data);

                Assert.That(result.Obj, Is.EqualTo("123"));
            }

            [Test]
            public void WhenClassUsesAttribute_ThenTakeNameFromAttribute()
            {
                const string data = "Name=John&emailAddress=somewhere";

                var result = FormUrlEncodedSerializer.Deserialize<TestDummyAttributes>(data);

                Assert.That(result.Name, Is.EqualTo("John"));
                Assert.That(result.Email, Is.EqualTo("somewhere"));
            }

            private static void AssertPropertiesAreDefault(TestDummyString result)
            {
                Assert.That(result.String, Is.EqualTo(default(string)));
                Assert.That(result.AnotherString, Is.EqualTo(default(string)));
            }
        }
    }}