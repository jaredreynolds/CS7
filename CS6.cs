using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Math;

namespace Trash {
	public class CS6 {
		private string n = null;
		private int i1 = 1;
		private int i2 = 2;
		
		public string ReadonlyAutoProperty { get; }
		public string AutoPropertyInitializer { get; } = "From the autoproperty initializer.";
		public override string ToString() => "From overloaded ToString using expression-bodied function member.";
		public string ExpressionBodiedProperty => "From read-only property using expression-bodied function member.";
		public string UsingStatic => "Using static: " + PI.ToString();
		public string NullConditional => "Null conditional: {" + n?.ToString() + "}";
		public string StringInterpolation => $"String interpolation: {i1 + i2}";
		
		public CS6() {
			ReadonlyAutoProperty = "From the readonly autoproperty.";
		}
		
		public string ExceptionFilter() {
			try {
				throw new Exception("known!");
			} catch (Exception ex) when (ex.Message.Contains("known")) {
				return "It was a known exception.";
			}
		}
		
		public string Nameof() {
			var myvar = "blah!";
			return nameof(myvar);
		}
		
		public async Task<string> AwaitFinally() {
			string rval = null;
			
			try {
				rval = "inside try";
			} finally {
				rval = await Task.FromResult("Finally awaited");
			}
			
			return rval;
		}
		
		public Dictionary<int, string> IndexInitializer() {
			return new Dictionary<int, string> {
				[1] = "One!",
				[2] = "Two!"
			};
		}
	}
}