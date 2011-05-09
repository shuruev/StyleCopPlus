using System.Collections.Generic;

namespace StyleCopPlus.Tests
{
	public delegate TOutput Delegate1<
		TInput,
		TOutput>(TInput args)
		where TInput : IEnumerable<int>
		where TOutput : IEnumerable<int>;

	public delegate TOutput Delegate2<
		in TInput,
		out TOutput>(TInput args)
		where TInput : IEnumerable<int>
		where TOutput : IEnumerable<int>;

	public delegate bool Delegate3<in TInput>(TInput args)
		where TInput : IEnumerable<byte>;

	public delegate TOutput Delegate4<out TOutput>(int count)
		where TOutput : IEnumerable<byte>;

	public class Class1<TKeys> where TKeys : IEnumerable<int>
	{
		public TResult Method1<TResult>(int arg) where TResult : new()
		{
			return new TResult();
		}
	}
}
