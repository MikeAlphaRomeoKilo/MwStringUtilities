using NUnit.Framework;

using Mw.StringUtilities;
using static Mw.StringUtilities.StringExtensions;

namespace UnitTests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [TestCase( "one,two", 3, "one" )] 
        [TestCase( "one,two", 0, "" )]                 // min
        [TestCase( "one,two", 7, "one,two" )]           // max
        [TestCase( "one,two", -1, null )]               // negative
        [TestCase( "one,two", 9, null )]                // too many
        public void Left( string source, int count, string expected )
        {
            string result = source.Left( count );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "one,two", 3, "two" )]
        [TestCase( "one,two", 0, "" )]                 // min
        [TestCase( "one,two", 7, "one,two" )]           // max
        [TestCase( "one,two", -1, null )]               // negative
        [TestCase( "one,two", 9, null )]                // too many
        public void Right( string source, int count, string expected )
        {
            string result = source.Right( count );
            Assert.AreEqual( expected, result );
        }


        [TestCase( "one,two,two,three", ",", "one" )]                   // single character match string
        [TestCase( "one,two,two,three", "two", "one," )]                // multi character match string
        [TestCase( "one,two,two,three", "abc", null )]                  // no match
        [TestCase( "one,two,two,three", "TWO", null )]                  // no match - default is case sensitive
        [TestCase( "one,two,two,three", "one,two,two,three", "" )]      // match is whole string
        [TestCase( "one,two,two,three", "one", "" )]                    // match at beginning
        [TestCase( "one,two,two,three", "three", "one,two,two," )]      // match at end
        public void LeftOfFirst( string source, string match, string expected )
        {
            string result = source.LeftOfFirst( match );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "00A11", "A", NotFoundAction.returnAll, System.StringComparison.InvariantCultureIgnoreCase, "00" )]
        [TestCase( "00A11", "a", NotFoundAction.returnAll, System.StringComparison.InvariantCultureIgnoreCase, "00" )]
        [TestCase( "00A11", "A", NotFoundAction.returnAll, System.StringComparison.InvariantCulture, "00" )]          
        [TestCase( "00A11", "a", NotFoundAction.returnAll, System.StringComparison.InvariantCulture, "00A11" )]
        [TestCase( "00A11", "a", NotFoundAction.returnEmpty, System.StringComparison.InvariantCulture, "" )]
        [TestCase( "00A11", "a", NotFoundAction.returnNull, System.StringComparison.InvariantCulture, null )]
        public void LeftOfFirst( string source, string match, NotFoundAction notFound, System.StringComparison stringComparison,  string expected )
        {
            string result = source.LeftOfFirst( match, notFound, stringComparison );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "one,two,two,three", ',', "one" )]                   // general case
        [TestCase( "one,two,two,three", 'x', null )]                    // no match
        [TestCase( "one,two,two,three", 'T', null )]                    // no match - default is case sensitive
        [TestCase( "xne,two,two,three", 'x', "" )]                      // match at beginning
        [TestCase( "one,two,two,threx", 'x', "one,two,two,thre" )]      // match at end
        public void LeftOfFirst( string source, char match, string expected )
        {
            string result = source.LeftOfFirst( match );
            Assert.AreEqual( expected, result );
        }

        [Test]
        public void LeftOfFirst_NotFoundActionThrowException_Throws()
        {
            Assert.Throws<System.ArgumentException>( () => "1111111".LeftOfFirst( "2", NotFoundAction.throwException ) );
        }


        [TestCase( "one,two,two,three", ",", "one,two,two" )]           // single character match string
        [TestCase( "one,two,two,three", "two", "one,two," )]            // multi character match string
        [TestCase( "one,two,two,three", "abc", null )]                  // no match
        [TestCase( "one,two,two,three", "TWO", null )]                  // no match - default is case sensitive
        [TestCase( "one,two,two,three", "one,two,two,three", "" )]      // match is whole string
        [TestCase( "one,two,two,three", "one", "" )]                    // match at beginning
        [TestCase( "one,two,two,three", "three", "one,two,two," )]      // match at end
        public void LeftOfLast( string source, string match, string expected )
        {
            string result = source.LeftOfLast( match );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "00A11", "A", NotFoundAction.returnAll, System.StringComparison.InvariantCultureIgnoreCase, "00" )]
        [TestCase( "00A11", "a", NotFoundAction.returnAll, System.StringComparison.InvariantCultureIgnoreCase, "00" )]
        [TestCase( "00A11", "A", NotFoundAction.returnAll, System.StringComparison.InvariantCulture, "00" )]
        [TestCase( "00A11", "a", NotFoundAction.returnAll, System.StringComparison.InvariantCulture, "00A11" )]
        [TestCase( "00A11", "a", NotFoundAction.returnEmpty, System.StringComparison.InvariantCulture, "" )]
        [TestCase( "00A11", "a", NotFoundAction.returnNull, System.StringComparison.InvariantCulture, null )]
        public void LeftOfLast( string source, string match, NotFoundAction notFound, System.StringComparison stringComparison, string expected )
        {
            string result = source.LeftOfLast( match, notFound, stringComparison );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "one,two,two,three", ',', "one,two,two" )]                   // general case
        [TestCase( "one,two,two,three", 'x', null )]                    // no match
        [TestCase( "one,two,two,three", 'T', null )]                    // no match - default is case sensitive
        [TestCase( "xne,two,two,three", 'x', "" )]                      // match at beginning
        [TestCase( "one,two,two,threx", 'x', "one,two,two,thre" )]      // match at end
        public void LeftOfLast( string source, char match, string expected )
        {
            string result = source.LeftOfLast( match );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "one,two,two,three", ",", "two,two,three" )]         // single character match string
        [TestCase( "one,two,two,three", "two", ",two,three" )]          // multi character match string
        [TestCase( "one,two,two,three", "abc", null )]                  // no match
        [TestCase( "one,two,two,three", "TWO", null )]                  // no match - default is case sensitive
        [TestCase( "one,two,two,three", "one,two,two,three", "" )]      // match is whole string
        [TestCase( "one,two,two,three", "one", ",two,two,three" )]      // match at beginning
        [TestCase( "one,two,two,three", "three", "" )]                  // match at end
        public void RightOfFirst( string source, string match, string expected )
        {
            string result = source.RightOfFirst( match );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "00A11", "A", NotFoundAction.returnAll, System.StringComparison.InvariantCultureIgnoreCase, "11" )]
        [TestCase( "00A11", "a", NotFoundAction.returnAll, System.StringComparison.InvariantCultureIgnoreCase, "11" )]
        [TestCase( "00A11", "A", NotFoundAction.returnAll, System.StringComparison.InvariantCulture, "11" )]
        [TestCase( "00A11", "a", NotFoundAction.returnAll, System.StringComparison.InvariantCulture, "00A11" )]
        [TestCase( "00A11", "a", NotFoundAction.returnEmpty, System.StringComparison.InvariantCulture, "" )]
        [TestCase( "00A11", "a", NotFoundAction.returnNull, System.StringComparison.InvariantCulture, null )]
        public void RightOfFirst( string source, string match, NotFoundAction notFound, System.StringComparison stringComparison, string expected )
        {
            string result = source.RightOfFirst( match, notFound, stringComparison );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "one,two,two,three", ',', "two,two,three" )]          // general case
        [TestCase( "one,two,two,three", 'x', null )]                    // no match
        [TestCase( "one,two,two,three", 'T', null )]                    // no match - default is case sensitive
        [TestCase( "xne,two,two,three", 'x', "ne,two,two,three" )]      // match at beginning
        [TestCase( "one,two,two,threx", 'x', "" )]                      // match at end
        public void RightOfFirst( string source, char match, string expected )
        {
            string result = source.RightOfFirst( match );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "one,two,two,three", ",", "three" )]                 // single character match string
        [TestCase( "one,two,two,three", "two", ",three" )]              // multi character match string
        [TestCase( "one,two,two,three", "abc", null )]                  // no match
        [TestCase( "one,two,two,three", "TWO", null )]                  // no match - default is case sensitive
        [TestCase( "one,two,two,three", "one,two,two,three", "" )]      // match is whole string
        [TestCase( "one,two,two,three", "one", ",two,two,three" )]      // match at beginning
        [TestCase( "one,two,two,three", "three", "" )]                  // match at end
        public void RightOfLast( string source, string match, string expected )
        {
            string result = source.RightOfLast( match );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "00A11", "A", NotFoundAction.returnAll, System.StringComparison.InvariantCultureIgnoreCase, "11" )]
        [TestCase( "00A11", "a", NotFoundAction.returnAll, System.StringComparison.InvariantCultureIgnoreCase, "11" )]
        [TestCase( "00A11", "A", NotFoundAction.returnAll, System.StringComparison.InvariantCulture, "11" )]
        [TestCase( "00A11", "a", NotFoundAction.returnAll, System.StringComparison.InvariantCulture, "00A11" )]
        [TestCase( "00A11", "a", NotFoundAction.returnEmpty, System.StringComparison.InvariantCulture, "" )]
        [TestCase( "00A11", "a", NotFoundAction.returnNull, System.StringComparison.InvariantCulture, null )]
        public void RightOfLast( string source, string match, NotFoundAction notFound, System.StringComparison stringComparison, string expected )
        {
            string result = source.RightOfLast( match, notFound, stringComparison );
            Assert.AreEqual( expected, result );
        }

        [TestCase( "one,two,two,three", ',', "three" )]                 // general case
        [TestCase( "one,two,two,three", 'x', null )]                    // no match
        [TestCase( "one,two,two,three", 'T', null )]                    // no match - default is case sensitive
        [TestCase( "xne,two,two,three", 'x', "ne,two,two,three" )]      // match at beginning
        [TestCase( "one,two,two,threx", 'x', "" )]                      // match at end
        public void RightOfLast( string source, char match, string expected )
        {
            string result = source.RightOfLast( match );
            Assert.AreEqual( expected, result );
        }




        [TestCase( "one,two,three", "eerht,owt,eno" )]
        [TestCase( "o", "o" )]
        [TestCase( "", "" )]
        public void Reverse( string source, string expected )
        {
            string result = source.Reverse();
            Assert.AreEqual( expected, result );
        }

        [TestCase( "123456", true )]
        [TestCase( "0", true )]
        [TestCase( "1234567890123456789012345678901234567890", true )]
        [TestCase( "0.7", false )]
        [TestCase( "-7", false )]
        [TestCase( "0x11", false )]
        [TestCase( "0A", false )]
        [TestCase( "123hello456", false )]
        [TestCase( "hello", false )]
        [TestCase( "h", false )]
        [TestCase( "", false )]
        public void IsNaturalNumber( string source, bool expected )
        {
            bool result = source.IsNaturalNumber();
            Assert.AreEqual( expected, result );
        }       
    }
}