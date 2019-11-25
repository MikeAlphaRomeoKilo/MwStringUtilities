using System;
using System.Linq;

namespace Mw.StringUtilities
{
    static public class StringExtensions
    {
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
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left( this string value, int length )
        {
            return value.Substring( 0, length );
        }

        /// <summary>
        /// Returns a string that consists of the rightmost n characters of the source string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right( this string value, int length )
        {
            return value.Substring( value.Length - length );
        }


        /// <summary>
        /// Returns the part of the source string before any occurrence of the specified characters.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="match"></param>
        /// <param name="notFoundAction"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static string LeftOfFirst( this string str,
                                     string match,
                                     NotFoundAction notFoundAction = NotFoundAction.returnNull,
                                     StringComparison stringComparison = StringComparison.CurrentCulture )
        {
            int index = str.IndexOf( match, stringComparison );
            if( index == -1 ) { return str.HandleNotFoundAction( notFoundAction ); }
            return str.Substring( 0, index );
        }

        /// <summary>
        /// Returns the part of the source string before the first occurrence of the specified character.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String LeftOfFirst( this String str, Char ch, NotFoundAction notFoundAction = NotFoundAction.returnNull )
        {
            int index = str.IndexOf( ch );
            if( index == -1 ) { return str.HandleNotFoundAction( notFoundAction ); }
            string subString = str.Substring( 0, index );
            return subString;
        }


        /// <summary>
        /// Returns the part of the source string before the first occurrence of the specified character.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String LeftOfLast( this String str,
                                         string match,
                                         NotFoundAction notFoundAction = NotFoundAction.returnNull,
                                         StringComparison stringComparison = StringComparison.CurrentCulture )
        {
            int index = str.LastIndexOf( match, stringComparison );
            if( index == -1 ) { return str.HandleNotFoundAction( notFoundAction ); }
            string subString = str.Substring( 0, index );
            return subString;
        }


        /// <summary>
        /// Returns the part of the source string before the first occurrence of the specified character.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String LeftOfLast( this String str, Char ch, NotFoundAction notFoundAction = NotFoundAction.returnNull )
        {
            int index = str.LastIndexOf( ch );
            if( index == -1 ) { return str.HandleNotFoundAction( notFoundAction ); }
            string subString = str.Substring( 0, index );
            return subString;
        }

        /// <summary>
        /// Returns the part of the source string after any occurrence of the specified match string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="match"></param>
        /// <param name="notFoundAction"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static string RightOfFirst( this string str,
                                           string match,
                                           NotFoundAction notFoundAction = NotFoundAction.returnNull,
                                           StringComparison stringComparison = StringComparison.CurrentCulture )
        {
            int index = str.IndexOf( match, stringComparison );
            if( index == -1 ) { return str.HandleNotFoundAction( notFoundAction ); }
            return str.Substring( index + match.Length );
        }

        /// <summary>
        /// Returns the part of the source string after the first occurrence of the specified character.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String RightOfFirst( this String str, Char ch, NotFoundAction notFoundAction = NotFoundAction.returnNull )
        {
            int index = str.IndexOf( ch );
            if( index == -1 ) { return str.HandleNotFoundAction( notFoundAction ); }
            string subString = str.Substring( index + 1 );
            return subString;
        }


        /// <summary>
        /// Returns the part of the source string after the last occurrence of the specified match string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String RightOfLast( this String str,
                                          string match,
                                          NotFoundAction notFoundAction = NotFoundAction.returnNull,
                                          StringComparison stringComparison = StringComparison.CurrentCulture )
        {
            int index = str.LastIndexOf( match, stringComparison );
            if( index == -1 ) { return str.HandleNotFoundAction( notFoundAction ); }
            string subString = str.Substring( index + match.Length );
            return subString;
        }

        /// <summary>
        /// Returns the part of the source string after the last occurrence of the specified character.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String RightOfLast( this String str, Char ch, NotFoundAction notFoundAction = NotFoundAction.returnNull )
        {
            int index = str.LastIndexOf( ch );
            if( index == -1 ) { return str.HandleNotFoundAction( notFoundAction ); }
            string subString = str.Substring( index + 1 );
            return subString;
        }


        /// <summary>
        /// Returns a reversed string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String Reverse( this String str )
        {
            int len = str.Length;
            char[] arr = new char[len];

            for( int i = 0; i < len; i++ )
            {
                arr[i] = str[len - 1 - i];
            }

            return new string( arr );
        }


        /// <summary>
        /// Removes a string consisting of the source string with the n specified characters removed from the right.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="removeLength">the number of characters to remove</param>
        /// <returns></returns>
        static public String RemoveRight( this String str, int removeLength )
        {
            if( removeLength >= str.Length ) return String.Empty;
            string subString = str.Substring( 0, str.Length - removeLength );
            return subString;
        }


        public static bool IsNumeric( this string source )
        {
            // must have something
            return source.Any() && source.All( char.IsDigit );
        }


        private static string HandleNotFoundAction( this string value, NotFoundAction notFoundAction )
        {
            switch( notFoundAction )
            {
                case NotFoundAction.returnNull: return null;
                case NotFoundAction.returnEmpty: return String.Empty;
                case NotFoundAction.returnAll: return value;
                case NotFoundAction.throwException: throw new ArgumentException( "Match string not present in the source string" );
                default: throw new NotImplementedException( $"{notFoundAction} is not handled" );
            }
        }

    }
}
