using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using PostSharp.Extensibility;
using PostSharp.Aspects;

namespace SignalR.Demo.Aspects
{
	[Serializable]
	#region Multicasting
	[MulticastAttributeUsage(MulticastTargets.Method)]
	#endregion
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Event)]
	public class LogExecutionAttribute : PostSharp.Aspects.OnMethodBoundaryAspect
	{
		public sealed override void OnEntry(MethodExecutionArgs args)
		{
			Debug.WriteLine(
				string.Format("ENTER {0}.{1}",
							  args.Method.DeclaringType.Name,
							  args.Method.Name));

			base.OnEntry(args);
		}

		public sealed override void OnSuccess(MethodExecutionArgs args)
		{
			Debug.WriteLine(
				   string.Format("COMPLETE {0}.{1}",
								 args.Method.DeclaringType.Name,
								 args.Method.Name));

			base.OnSuccess(args);
		}
	}
}