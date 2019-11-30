using NUnit.Framework;

using Mw.StringUtilities;
using static Mw.StringUtilities.StringExtensions;

namespace DocumentationExamples
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void Left()
        {
            string result = "one,two,three".Left( 3 );
            Assert.AreEqual( "one", result );
        }

        [Test]
        public void Right(  )
        {
            string result = "one,two,three".Right( 3 );
            Assert.AreEqual( "ree", result );
        }

        [Test]
        public void LeftOfFirst(  )
        {
            string result = "one,two,three".LeftOfFirst( "," );
            Assert.AreEqual( "one", result );
        }

        [Test]
        public void LeftOfLast( )
        {
            string result = "one,two,three".LeftOfLast( "," );
            Assert.AreEqual( "one,two", result );
        }

        [Test]
        public void RightOfFirst(  )
        {
            string result = "one,two,three".RightOfFirst( "," );
            Assert.AreEqual( "two,three", result );
        }

        [Test]
        public void RightOfLast(  )
        {
            string result = "one,two,three".RightOfLast( "," );
            Assert.AreEqual( "three", result );
        }


        [Test]
        public void Reverse()
        {
            string result = "one".Reverse();
            Assert.AreEqual( "eno", result );
        }

        [Test]
        public void IsNaturalNumber()
        {
            bool result = "123456789012345678901234567890".IsNaturalNumber();
            Assert.AreEqual( true, result );
        }


        
    }
}