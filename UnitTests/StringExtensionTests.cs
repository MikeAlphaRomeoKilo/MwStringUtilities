using NUnit.Framework;

using Mw.StringUtilities;

namespace UnitTests
{
    [TestFixture]
    public class StringExtensionTests
    {
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

        [TestCase( "one,two,three", "eerht,owt,eno" )]                  // single character match string
        [TestCase( "o", "o" )]                                          // single character match string
        public void Reverse( string source, string expected )
        {
            string result = source.Reverse();
            Assert.AreEqual( expected, result );
        }
    }
}