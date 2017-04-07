using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trash {
	public class CS7 {
		int[] _a = new[] {1};

		
		public string InlineOutVars() {
			if (int.TryParse("123", out var i)) {
				return i.ToString();
			}
			
			return "NAN";
		}
		
		public string Tuples() {
			var tuple1 = (First: "better", Ignored: "stuff");
			(string Second, string Ignored) tuple2 = ("tuples!", "stuff");
			
			(int i1, int i2) = new TypeWithDeconstruct(1, 2);
			
			return $"{tuple1.First} {tuple2.Second}  deconstruction: ({i1}, {i2})";
		}
		
		public string IsWithAssignment() {
			object i = 1;
			
			if (i is int i2) {
				return i2.ToString();
			}
			
			return "oops";
		}
		
		public string SwitchWithPatternMatching() {
			object i = 1;
			
			switch (i) {
				case int i2 when i2 <= 1:
					return "small";
				default:
					return "large";
			}
		}
		
		public string LocalRefs() {
			var start = _a[0];
			ref var i = ref GetOne();
			i = 2;
			return $"{start} is now {_a[0]}";
		}
		
		private ref int GetOne() {
			return ref _a[0];
		}
		
		public string LocalFns() {
			return MyLocalFn();
			
			string MyLocalFn() {
				return "From local function";
			}
		}
		
		public string MoreExpressionBodiedMembers() {
			var blah = new ExpressionBodiedMembers("My label");
			return $"{blah}";
		}
		
		public string ThrowExpressions() {
			try {
				return new ThrowExpression().Thing;
			} catch (Exception ex) {
				return ex.Message;
			}
		}

		public ValueTask<int> ValueTasks() {
			return new ValueTask<int>(Task.FromResult(1));
		}
		
		public string NumericLiteralSyntaxImprovements() {
			return $"{100_000_000 + 0b0001}";
		}
		
		private class TypeWithDeconstruct {
			private int _i1;
			private int _i2;
			
			public TypeWithDeconstruct(int i1, int i2) {
				_i1 = i1;
				_i2 = i2;
			}
			
			public void Deconstruct(out int i1, out int i2) {
				i1 = _i1;
				i2 = _i2;
			}
		}
		
		private class ExpressionBodiedMembers {
			private string label;
			
			public ExpressionBodiedMembers(string label) => this.Label = label;
			~ExpressionBodiedMembers() => Console.Error.WriteLine("\nExpressionBodiedMembers finalized!");

			public string Label
			{
				get => label;
				set => this.label = value ?? "Default label";
			}
		}
		
		private class ThrowExpression {
			string _thing;
			
			public string Thing {
				get => _thing ?? throw new Exception("Don't do that!");
				set => _thing = value;
			}
		}
	}
}
