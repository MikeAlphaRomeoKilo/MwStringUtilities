using System;
using System.Collections.Generic;

namespace Mw.StringUtilities
{
    static public class StringExtensions
    {
        public enum NotFound
        {
            originalString,
            emptyString,
            nullString
        }


        /// <summary>
        /// Returns the part of the string after the first occurrence of the specified character.
        /// If the specified character does not exist, returns an empty string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String RightOfFirst( this String str, Char ch, NotFound nf )
        {
            int index = str.IndexOf( ch );
            if( index == -1 ) { return str.GetNotFoundResult( nf ); }
            string subString = str.Substring( index + 1 );
            return subString;
        }

        /// <summary>
        /// Returns the part of the string after the last occurrence of the specified character.
        /// If the specified character does not exist, returns an empty string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String RightOfLast( this String str, Char ch, NotFound nf )
        {
            int index = str.LastIndexOf( ch );
            if( index == -1 ) { return str.GetNotFoundResult( nf ); }
            string subString = str.Substring( index + 1 );
            return subString;
        }

        /// <summary>
        /// Returns the part of the string before the first occurrence of the specified character.
        /// If the specified character does not exist, returns an empty string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String LeftOfFirst( this String str, Char ch, NotFound nf )
        {
            int index = str.IndexOf( ch );
            if( index == -1 ) { return str.GetNotFoundResult( nf ); }
            string subString = str.Substring( 0, index );
            return subString;
        }

        /// <summary>
        /// Returns the part of the string before the first occurrence of the specified character.
        /// If the specified character does not exist, returns an empty string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public String LeftOfLast( this String str, Char ch, NotFound nf )
        {
            int index = str.LastIndexOf( ch );
            if( index == -1 ) { return str.GetNotFoundResult( nf ); }
            string subString = str.Substring( 0, index );
            return subString;
        }

        static public String RemoveRight( this String str, int removeLength )
        {
            string subString = str.Substring( 0, str.Length - removeLength );
            return subString;
        }

        private static String GetNotFoundResult( this String str, NotFound nf )
        {
            if( nf == NotFound.originalString ) { return str; }
            else if( nf == NotFound.emptyString ) { return String.Empty; }
            else if( nf == NotFound.nullString ) { return null; }
            else throw new NotImplementedException( "Unhandled case in GetNotFoundResult()" );
        }
    }

}
