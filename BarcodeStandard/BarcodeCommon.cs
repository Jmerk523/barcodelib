using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BarcodeLib
{
    abstract class BarcodeCommon
    {
        protected string Raw_Data = "";
        protected List<string> _Errors = new List<string>();

        public string RawData
        {
            get { return this.Raw_Data; }
        }

        public List<string> Errors
        {
            get { return this._Errors; }
        }

        public void Error(string ErrorMessage)
        {
            this._Errors.Add(ErrorMessage);
            throw new BarcodeException(ErrorMessage);
        }

        public void Error(string errorMessage, Exception ex)
        {
            this._Errors.Add(errorMessage);
            this._Errors.Add(ex.Message);
            throw new BarcodeException(errorMessage, ex);
        }

        internal static bool CheckNumericOnly(string Data)
        {
            return Regex.IsMatch(Data, @"^\d+$", RegexOptions.Compiled);
        }
    }//BarcodeVariables abstract class


    [Serializable]
    public class BarcodeException : Exception
    {
        public BarcodeException() { }
        public BarcodeException(string message) : base(message) { }
        public BarcodeException(string message, Exception inner) : base(message, inner) { }
        protected BarcodeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}//namespace
