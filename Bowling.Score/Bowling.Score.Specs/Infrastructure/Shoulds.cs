using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Bowling.Score.Specs.Infrastructure
{
	public static class ShouldExtensionMethods
	{
		public static T and<T>(this T actual)
		{
			return actual;
		}

		public static void should_be_false(this bool condition)
		{
			Assert.IsFalse(condition);
		}

		public static void should_be_true(this bool condition)
		{
			Assert.IsTrue(condition);
		}

		public static void should_be_true(this bool condition, string message)
		{
			Assert.IsTrue(condition, message);
		}

		public static T that_equals<T>(this T actual, T expected)
		{
			return actual.should_equal(expected);
		}

		public static T should_equal<T>(this T actual, T expected)
		{
			Assert.AreEqual(expected, actual);
			return actual;
		}

		public static T should_equal<T>(this T actual, T expected, string message)
		{
			Assert.AreEqual(expected, actual, message);
			return actual;
		}

		public static T should_not_equal<T>(this T actual, T expected)
		{
			Assert.AreNotEqual(expected, actual);
			return actual;
		}

		public static void should_be_null(this object anObject)
		{
			Assert.IsNull(anObject);
		}

		public static void should_be_null(this object anObject, string message)
		{
			Assert.IsNull(anObject, message);
		}

		public static void should_not_be_null(this object anObject)
		{
			Assert.IsNotNull(anObject);
		}

		public static void should_not_be_null(this object anObject, string message)
		{
			Assert.IsNotNull(anObject, message);
		}

		public static object should_be_the_same_as(this object actual, object expected)
		{
			Assert.AreSame(expected, actual);
			return actual;
		}

		public static object should_not_be_the_same_as(this object actual, object expected)
		{
			Assert.AreNotSame(expected, actual);
			return actual;
		}

		public static T should_be_a<T>(this object actual)
		{
			Assert.IsInstanceOf(typeof (T), actual);
			return (T) actual;
		}

	
		public static void should_contain<T>(this IEnumerable<T> actual, Func<T, bool> predicate)
		{
			actual.should_contain(predicate, "Collection did not contain a matching item");
		}

		public static void should_contain<T>(this IEnumerable<T> actual, Func<T, bool> predicate, string message)
		{
			var contained = false;
			foreach (T item in actual)
			{
				if (predicate(item)) contained = true;
			}
			Assert.IsTrue(contained, message);
		}


		

		public static void should_not_contain<T>(this IEnumerable<T> actual, Func<T, bool> predicate)
		{
			actual.should_not_contain(predicate, "Collection did not contain a matching item");
		}

		public static void should_not_contain<T>(this IEnumerable<T> actual, Func<T, bool> predicate, string message)
		{
			var contained = false;
			foreach (T item in actual)
			{
				if (predicate(item)) contained = true;
			}
			Assert.IsFalse(contained, message);
		}

		public static void Should<T>(this IEnumerable<T> list, Func<T, bool> predicate, string message)
		{
			foreach (T item in list)
				if (!predicate(item))
					throw new AssertionException(message);
		}

		public static void should_not<T>(this IEnumerable<T> list, Func<T, bool> predicate, string message)
		{
			foreach (T item in list)
				if (predicate(item))
					throw new AssertionException(message);
		}

		public static IComparable should_be_greater_than(this IComparable arg1, IComparable arg2)
		{
			Assert.Greater(arg1, arg2);
			return arg1;
		}

		public static IComparable should_be_less_than(this IComparable arg1, IComparable arg2)
		{
			Assert.Less(arg1, arg2);
			return arg1;
		}

		public static void should_be_empty(this IEnumerable collection)
		{
			Assert.IsEmpty(collection);
		}

		public static void should_be_empty<T>(this IEnumerable<T> collection)
		{
			Assert.IsEmpty(collection);
		}

		public static void should_be_empty(this string aString)
		{
			Assert.IsEmpty(aString);
		}

		public static void should_not_be_empty(this IEnumerable collection)
		{
			Assert.IsNotEmpty(collection);
		}

		public static void should_not_be_empty<T>(this IEnumerable<T> collection)
		{
			Assert.IsNotEmpty(collection);
		}

		public static void should_not_be_empty(this string aString)
		{
			Assert.IsNotEmpty(aString);
		}

	

		public static void should_not_contain(this string actual, string unexpected)
		{
			Assert.IsFalse(actual.Contains(unexpected), "Did not expect to contain the string {0}\nActual was {1}", unexpected,
			               actual);
		}



	

		public static void ShouldMatch(this string actual, string expectedPattern)
		{
			Assert.IsTrue(actual.matches(expectedPattern));
		}

		public static bool matches(this string actual, string expectedPattern)
		{
			var regex = new Regex(expectedPattern, RegexOptions.Singleline | RegexOptions.ExplicitCapture);
			return regex.IsMatch(actual);
		}

		public static Exception should_be_thrown_by(this Type exceptionType, Action method)
		{
			Exception exception = null;

			try
			{
				method();
			}
			catch (Exception e)
			{
				Assert.AreEqual(exceptionType, e.GetType());
				exception = e;
			}

			if (exception == null)
			{
				Assert.Fail(String.Format("Expected {0} to be thrown.", exceptionType.FullName));
			}

			return exception;
		}

		public static IEnumerable<T> should_equal<T>(this IEnumerable<T> actual, params T[] expected)
		{
			return should_equal(actual, (IEnumerable<T>) expected);
		}

		public static IEnumerable<T> should_equal<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
		{
			Assert.AreEqual(expected, actual);
			return actual;
		}
	}

	
}