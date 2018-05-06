using System;
using NUnit.Framework;


namespace Bowling.Score.Specs.Infrastructure
{
	public abstract class concerns
	{
		private Exception ContextSetupException;

		[SetUp]
		public virtual void main_setup()
		{
			try
			{
				context();
			}
			catch (Exception ex)
			{
				ContextSetupException = ex;
			}
		}

		public void context_failure_check()
		{
			if (ContextSetupException != null)
				throw new ContextException(ContextSetupException);
		}

		protected virtual void context()
		{
		}

		[TearDown]
		public virtual void main_teardown()
		{
			decontext();
		}

		protected virtual void decontext()
		{
		}

	

		public class ContextException : Exception
		{
			public ContextException(Exception innerException)
				: base("Test failed in Context", innerException)
			{
			}
		}
	}

	
}