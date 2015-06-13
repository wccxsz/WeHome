/*************************************************************************************
   * CLR版本：        4.0.30319.34014
   * 机器名称：       whl
   * 文 件 名：       Check.cs
   * 创建时间：       9/16/2014 9:54:59 AM
   * 作    者：       数据检查类
   * 说    明：       此类用于检查数据是否满足条件
  *************************************************************************************/

using System;

namespace WeHome.Framework.Tools
{
    public static class Check
    {
        public static T NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static T? NotNull<T>(T? value, string parameterName) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(parameterName + " ArgumentIsNullOrWhitespace");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(parameterName + " ArgumentIsNullOrEmpty");
            }

            return value;
        }
    }
}
