using System;
using System.Linq;

namespace Mw.StringUtilities
{
    static public class StringExtensions
    {
        public enum OutOfRangeAction
        {
            returnEmpty,
            returnNull,
            throwException
        }

        public enum NotFoundAction
        {
            returnAll,
            returnEmpty,
            returnNull,
            throwException
        }

        /// <summary>
        /// Returns a string that consists of the leftmost n characters of the source string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left( this string source, int length, OutOfRangeAction outOfRangeAction = OutOfRangeAction.returnNull )
        {
            if( length > source.Length  ||  length < 0 ) { return source.HandleOutOfRangeAction( outOfRangeAction ); }
            return source.Substring( 0, length );
        }

        /// <summary>
        /// Returns a string that consists of the rightmost n characters of the source string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right( this string source, int length, OutOfRangeAction outOfRangeAction = OutOfRangeAction.returnNull )
        {
            if( length > source.Length || length < 0 ) { return source.HandleOutOfRangeAction( outOfRangeAction ); }
            return source.Substring( source.Length - length );
        }


        /// <summary>
        /// Returns the part of the source string before any occurrence of the specified characters.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="match"></param>
        /// <param name="notFoundAction"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static string LeftOfFirst( this string source,
                                     string match,
                                     NotFoundAction notFoundAction = NotFoundAction.returnNull,
                                     StringComparison stringComparison = StringComparison.CurrentCulture )
        {
            int index = source.IndexOf( match, stringComparison );
            if( index == -1 ) { return source.HandleNotFoundAction( notFoundAction ); }
            return source.Substring( 0, index );
        }

        /// <summary>
        /// Returns the part of the source string before the first occurrence of the specified character.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String LeftOfFirst( this String source, Char ch, NotFoundAction notFoundAction = NotFoundAction.returnNull )
        {
            int index = source.IndexOf( ch );
            if( index == -1 ) { return source.HandleNotFoundAction( notFoundAction ); }
            string subString = source.Substring( 0, index );
            return subString;
        }


        /// <summary>
        /// Returns the part of the source string before the first occurrence of the specified character.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String LeftOfLast( this String source,
                                         string match,
                                         NotFoundAction notFoundAction = NotFoundAction.returnNull,
                                         StringComparison stringComparison = StringComparison.CurrentCulture )
        {
            int index = source.LastIndexOf( match, stringComparison );
            if( index == -1 ) { return source.HandleNotFoundAction( notFoundAction ); }
            string subString = source.Substring( 0, index );
            return subString;
        }


        /// <summary>
        /// Returns the part of the source string before the first occurrence of the specified character.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String LeftOfLast( this String source, Char ch, NotFoundAction notFoundAction = NotFoundAction.returnNull )
        {
            int index = source.LastIndexOf( ch );
            if( index == -1 ) { return source.HandleNotFoundAction( notFoundAction ); }
            string subString = source.Substring( 0, index );
            return subString;
        }

        /// <summary>
        /// Returns the part of the source string after any occurrence of the specified match string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="match"></param>
        /// <param name="notFoundAction"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static string RightOfFirst( this string source,
                                           string match,
                                           NotFoundAction notFoundAction = NotFoundAction.returnNull,
                                           StringComparison stringComparison = StringComparison.CurrentCulture )
        {
            int index = source.IndexOf( match, stringComparison );
            if( index == -1 ) { return source.HandleNotFoundAction( notFoundAction ); }
            return source.Substring( index + match.Length );
        }

        /// <summary>
        /// Returns the part of the source string after the first occurrence of the specified character.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String RightOfFirst( this String source, Char ch, NotFoundAction notFoundAction = NotFoundAction.returnNull )
        {
            int index = source.IndexOf( ch );
            if( index == -1 ) { return source.HandleNotFoundAction( notFoundAction ); }
            string subString = source.Substring( index + 1 );
            return subString;
        }


        /// <summary>
        /// Returns the part of the source string after the last occurrence of the specified match string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String RightOfLast( this String source,
                                          string match,
                                          NotFoundAction notFoundAction = NotFoundAction.returnNull,
                                          StringComparison stringComparison = StringComparison.CurrentCulture )
        {
            int index = source.LastIndexOf( match, stringComparison );
            if( index == -1 ) { return source.HandleNotFoundAction( notFoundAction ); }
            string subString = source.Substring( index + match.Length );
            return subString;
        }

        /// <summary>
        /// Returns the part of the source string after the last occurrence of the specified character.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String RightOfLast( this String source, Char ch, NotFoundAction notFoundAction = NotFoundAction.returnNull )
        {
            int index = source.LastIndexOf( ch );
            if( index == -1 ) { return source.HandleNotFoundAction( notFoundAction ); }
            string subString = source.Substring( index + 1 );
            return subString;
        }


        /// <summary>
        /// Returns a reversed string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static String Reverse( this String source )
        {
            int length = source.Length;
            char[] buffer = new char[length];

            for( int i = 0; i < length; i++ )
            {
                buffer[i] = source[length - 1 - i];
            }

            return new string( buffer );
        }


        /// <summary>
        /// Removes a string consisting of the source string with the n specified characters removed from the left.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="removeLength">the number of characters to remove</param>
        /// <returns></returns>
        static public String RemoveLeft( this String source, int removeLength )
        {
            if( removeLength >= source.Length ) return String.Empty;
            string subString = source.Substring( 0, source.Length - removeLength );
            return subString;
        }


        /// <summary>
        /// Removes a string consisting of the source string with the n specified characters removed from the right.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="removeLength">the number of characters to remove</param>
        /// <returns></returns>
        static public String RemoveRight( this String source, int removeLength )
        {
            if( removeLength >= source.Length ) return String.Empty;
            string subString = source.Substring( 0, source.Length - removeLength );
            return subString;
        }


        /// <summary>
        /// Returns true if the string represents a natural number.
        /// Zero is considered to be a natural number.
        /// This function imposes no limit on the size of the number, which may well be larger than a UInt32 or a UInt64
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNaturalNumber( this string source )
        {
            // must have something
            return source.Any() && source.All( char.IsDigit );
        }


        private static string HandleOutOfRangeAction( this string source, OutOfRangeAction outOfRangeAction )
        {
            switch( outOfRangeAction )
            {
                case OutOfRangeAction.returnNull: return null;
                case OutOfRangeAction.returnEmpty: return String.Empty;
                case OutOfRangeAction.throwException: throw new IndexOutOfRangeException( "index is not in range" );
                default: throw new NotImplementedException( $"{outOfRangeAction} is not handled" );
            }
        }


        private static string HandleNotFoundAction( this string source, NotFoundAction notFoundAction )
        {
            switch( notFoundAction )
            {
                case NotFoundAction.returnNull: return null;
                case NotFoundAction.returnEmpty: return String.Empty;
                case NotFoundAction.returnAll: return source;
                case NotFoundAction.throwException: throw new ArgumentException( "Match string not present in the source string" );
                default: throw new NotImplementedException( $"{notFoundAction} is not handled" );
            }
        }

    }
}
